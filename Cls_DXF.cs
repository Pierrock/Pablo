using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;                //  pour FileInfo
using System.Windows.Forms;     //  pour MessageBox

namespace PABLO
{
    class cls_DXF
    {
        private FileInfo theSourceFile;
        private double XMax, XMin;
        private double YMax, YMin;
        private double xOld = -1;
        private double yOld = -1;

        private ListBox _myListbox;




        public ListBox ListeDatas
        {
            get { return _myListbox; }
            set { _myListbox = value; }
        }



        [STAThread]
        private void AfficheDatas(string msg)
        {
            _myListbox.Invoke(new EventHandler(delegate
            {
                _myListbox.Items.Add(msg);
                
            }));
        }



        #region Lecture de fichier

        public void ReadFromFile(string textFile)			//Reads a text file (in fact a DXF file) for importing an Autocad drawing.
        //In the DXF File structure, data is stored in two-line groupings ( or bi-line, coupling line ...whatever you call it)
        //in this grouping the first line defines the data, the second line contains the data value.
        //..as a result there is always even number of lines in the DXF file..
        {
            string line1, line2;							//these line1 and line2 is used for getting the a/m data groups...

            line1 = "0";									//line1 and line2 are are initialized here...
            line2 = "0";

            //long position = 0;

            theSourceFile = new FileInfo(textFile);		    //  the sourceFile is set.

            StreamReader reader = null;						//  a reader is prepared...

            try
            {
                reader = theSourceFile.OpenText();			//the reader is set ...
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.FileName.ToString() + " cannot be found");
            }
            catch
            {
                MessageBox.Show("An error occured while opening the DXF file");
                return;
            }

            do
            {

            //  This part interpretes the drawing objects found in the DXF file...
                if (line1 == "0" && line2 == "LINE") LineModule(reader);

                GetLineCouple(reader, out line1, out line2);		//the related method is called for iterating through the text file and assigning values to line1 and line2...

            }
            while (line2 != "EOF");

            reader.DiscardBufferedData();							//reader is cleared...
            theSourceFile = null;

            reader.Close();											//...and closed.
        }

        private void GetLineCouple(StreamReader theReader, out string line1, out string line2)		//this method is used to iterate through the text file and assign values to line1 and line2
        {
            System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            string decimalSeparator = ci.NumberFormat.CurrencyDecimalSeparator;

            line1 = line2 = "";

            if (theReader == null)
                return;

            line1 = theReader.ReadLine();
            if (line1 != null)
            {
                line1 = line1.Trim();
                line1 = line1.Replace('.', decimalSeparator[0]);

            }
            line2 = theReader.ReadLine();
            if (line2 != null)
            {
                line2 = line2.Trim();
                line2 = line2.Replace('.', decimalSeparator[0]);
            }

        }


        private void LineModule(StreamReader reader)		//Interpretes line objects in the DXF file
        {
            string line1, line2;
            line1 = "0";
            line2 = "0";

            double x1 = 0;
            double y1 = 0;
            double x2 = 0;
            double y2 = 0;


            //  0
            //  LINE
            //  8
            //  Layer 1
            //  10
            //  216.416526
            //  20
            //  184.773900
            //  11
            //  214.282220
            //  21
            //  184.632789

            do
            {
                GetLineCouple(reader, out line1, out line2);

                if (line1 == "10")                      //  Start point X
                {
                    x1 = Convert.ToDouble(line2);
                    if (x1 > XMax)  XMax = x1;
                    if (x1 < XMin)  XMin = x1;
                }

                if (line1 == "20")                      //  Start point Y
                {
                    y1 = Convert.ToDouble(line2);
                    if (y1 > YMax)  YMax = y1;
                    if (y1 < YMin)  YMin = y1;
                }

                if (line1 == "11")                      //  End point X
                {
                    x2 = Convert.ToDouble(line2);
                    if (x2 > XMax)  XMax = x2;
                    if (x2 < XMin)  XMin = x2;
                }

                if (line1 == "21")                      //  End point Y
                {
                    y2 = Convert.ToDouble(line2);
                    if (y2 > YMax)  YMax = y2;
                    if (y2 < YMin)  YMin = y2;
                }
            }
            while (line1 != "21");

            if ( (x1 != xOld) || (y1 != yOld) )

            {
                AfficheDatas(x1.ToString() + " " + y1.ToString() + " " + x2.ToString() + " " + y2.ToString() + " ");
            }
            else
            {
                AfficheDatas( "to " + x2.ToString() + " " + y2.ToString() + " ");
            }
            
            xOld = x2;
            yOld = y2;



        //  This Part is related with the drawing editor...the data taken from the dxf file is interpreted hereinafter

            //if ((Math.Abs(XMax) - Math.Abs(XMin)) > _myPictureBox.Size.Width)
            //{
            //    scaleX = (double)(_myPictureBox.Size.Width) / (double)(Math.Abs(XMax) - Math.Abs(XMin));
            //}
            //else
            //    scaleX = 1;


            //if ((Math.Abs(YMax) - Math.Abs(YMin)) > _myPictureBox.Size.Height)
            //{
            //    scaleY = (double)(_myPictureBox.Size.Height) / (double)(Math.Abs(YMax) - Math.Abs(YMin));
            //}
            //else
            //    scaleY = 1;

            //mainScale = Math.Min(scaleX, scaleY);

            //int ix = drawingList.Add(new Line(new Point((int)x1, (int)-y1), new Point((int)x2, (int)-y2), Color.White, 1));
            //objectIdentifier.Add(new DrawingObject(2, ix));

            //AfficheInfo("    " + x1.ToString() + " " + y1.ToString() + " " + x2.ToString() + " " + y2.ToString() + " ");
        }

        #endregion

    }
}
