using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;

using GMap.NET.WindowsForms;

namespace PABLO
{
    class cls_GPS
    {
  
        #region Variables

        private string _portName = string.Empty;

        private Label _labelDisplay;
        private SerialPort comPort = new SerialPort();

        private GMap.NET.WindowsForms.GMapControl _gmap;

        private Double _Latitude;
        private Double _Longitude;
        private Double _Degrees;
        private bool   _DegresValide;
        private gpsModeType  _ModeIndicator;

        private string tString = string.Empty;

        private bool _gmap_tracking = false;      //  plus de rapidité = moins d'affichage


        #endregion

        #region Propriétés

        /// <summary>
        /// Proprieté PortName de la classe ("COM1", "COM2", "COM3" ect...)
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        ///  Proprieté DisplayWindow de la classe : un objet Label
        /// </summary>
        public Label LabelDisplay
        {
            get { return _labelDisplay; }
            set { _labelDisplay = value; }
        }

        public GMap.NET.WindowsForms.GMapControl DisplayGmap
        {
            get { return _gmap; }
            set { _gmap = value; }
        }

        public double Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        public double Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        public double Degres
        {
            get { return _Degrees; }
            set { _Degrees = value; }
        }

        public bool Degres_valide
        {
            get { return _DegresValide; }
        }

        public gpsModeType ModeIndicator
        {
            get { return _ModeIndicator; }
        }

        public bool Gmap_Tracking
        {
            set { _gmap_tracking = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Comstructor pour fixer les propriétes à vide lorsqu'on ne passe aucun paramètre
        /// </summary>
        public cls_GPS()
        {
            _portName = string.Empty; ;
            _labelDisplay = null;
            _gmap = null;

            //add event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }
        
        #endregion

        #region Affichage des données

        /// <summary>
        /// Affichage des trames reçues sur l'IHM
        /// </summary>
        [STAThread]
        private void AfficheDatas( string msg)
        {
            _labelDisplay.Invoke(new EventHandler(delegate
        {
             _labelDisplay.Text = msg;
        }));
        }

        /// <summary>
        /// Affichage la position sur la carte
        /// </summary>
        [STAThread]
        private void AfficheGmap()
        {
            _gmap.Invoke(new EventHandler(delegate
            {
                _gmap.Position = new GMap.NET.PointLatLng(_Latitude, _Longitude);
            }));
        }

        #endregion

        #region Open / close Port

        public bool OpenPort()
        {
            try
            {
             // S'assurer que le port est fermé. S'il est ouvert on le ferme
                if (comPort.IsOpen == true) comPort.Close();

                // Fixe les propriétés du protocole: vitesse, nombre de bits, parité ...
                comPort.PortName = _portName;
                comPort.Parity = System.IO.Ports.Parity.None;
                comPort.BaudRate = 57600; 
                comPort.DataBits = 8;
                comPort.StopBits = System.IO.Ports.StopBits.One;
                comPort.Handshake = System.IO.Ports.Handshake.None;

                comPort.Encoding = System.Text.Encoding.Default;
                comPort.RtsEnable = true;
                comPort.DtrEnable = true;
 
            //  Ouverture du port de communication
                comPort.Open();                                                 

             // Affiche le message d'ouverture
                AfficheDatas("Port " + comPort.PortName + " (" + comPort.BaudRate + "," + comPort.Parity + "," + comPort.DataBits + "," + comPort.StopBits + ") ouvert. \n");
                
                return true;
            }
            catch (Exception ex)
            {
                // ha.. problème.
                AfficheDatas(comPort.PortName + " ERREUR");
                return false;
            }
        }

        public void ClosePort()
        {
            comPort.Close();
            // Affiche le message de fermeture
            //AfficheDatas("Port " + comPort.PortName + " fermé. \n");
        }

        #endregion

        #region Emission des données
        public void WriteData(string msg)
        {
            //  S'assurer que le port est ouvert. S'il est fermé on l'ouvre
            if (!(comPort.IsOpen == true)) OpenPort();

            //  Envoi du message
            comPort.Write(msg);

            //  Affichage du message
            AfficheDatas("-->" + msg + "\n");
        }
        #endregion

        #region Réception des données

        /// <summary>
        /// cette méthode est appelée à chaque réception de caractère
        /// </summary>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //  lecture des datas 
            //14:09:52  $GNRMC,14xxxx.00,A,48xx.xxxx,N,002yy.yyyyy,W,0.058,,230417,,,D*79
            //14:09:54  $GNRMC,14xxxx.00,A,48xx.xxxxx,N,002yy.yyyyy,W,0.268,291.79,230417,,,D*64
            //14:10:19  $GNRMC,14xxxx.00,A,48xx.xxxxx,N,002yy.yyyyy,W,1.172,97.23,230417,,,D*5F

            string tramesNMEA = string.Empty;   // comPort.ReadLine();

            try
            {
                while (comPort.BytesToRead > 1)
                {
                    tramesNMEA = tramesNMEA + comPort.ReadLine();
                 }
            }
            catch (Exception)
            {
                //Can't Read GPS values
                AfficheDatas("Exception");
                tramesNMEA = string.Empty;
                return;
            }

            string[] tramesArr = tramesNMEA.Split('\r');

            int nbrTrames = tramesArr.Length;

            string _trace = string.Empty;

            for (int iTrame = 0; iTrame < nbrTrames; iTrame++)
            {
                _trace = tramesArr[iTrame];

                int firstCharacter = _trace.IndexOf("$GNRMC");   // 
                if (firstCharacter != -1)
                {
                     AfficheDatas(_trace);

                         string[] lineArr = _trace.Split(',','*');

                        //lineArr	{string[13]}	string[]
                        //[0]	"$GNRMC"	string
                        //[1]	"143152.00"	string
                        //[2]	"A"	string
                        //[3]	"48xx.xxxxx"	string
                        //[4]	"N"	string
                        //[5]	"002yy.yyyyy"	string
                        //[6]	"W"	string
                        //[7]	"0.011"	string
                        //[8]	""	string
                        //[9]	"230417"	string
                        //[10]	""	string
                        //[11]	""	string
                        //[12]	"D"	string
                        //[13]	"75" string

                        try
                        {
                            //  Latitude
                            string myLat = lineArr[3];              //  "48xx.xxxxx"
                            if (myLat.Contains("."))
                            {
                                //myLat = myLat.Replace('.', ',');    //  "48xx,xxxxx"
                            }
                            Double dLat = Convert.ToDouble(myLat);  //  48xx.xxx
                            dLat = dLat / 100;                      //  48.xxxxxxxxxxxxxxx

                            int degrees = (int)dLat;                //  48
                            Double minutesseconds = ((dLat - degrees) * 100) / 60.0;    //  0.xxxxxxxxxx
                            _Latitude = degrees + minutesseconds;   //  48.xxxxxxxxxxxxxx

                            string signe = string.Empty;
                            switch (lineArr[4])
                            {
                                case "N":   signe = "+";
                                            break;
                                case "S":   signe = "-";
                                            _Latitude = -_Latitude;
                                            break;
                                default:    signe = "-";
                                            break;
                            }

                            //Longitude
                            string myLon = lineArr[5];                          //  "002yy.yyyyy"
                            if (myLon.Contains("."))
                            {
                                //myLon = myLon.Replace('.', ',');                //  "002yy,yyyyy"
                            }
                            //
                            Double dLon = Convert.ToDouble(myLon);              //  2yy.yyyyy
                            dLon = dLon / 100;                                  //  2.yyyyyyyyyyyy
                            degrees = (int)dLon;                                //  2              
                            minutesseconds = ((dLon - degrees) * 100) / 60.0;   //  0.yyyyyyyyyyyy
                            _Longitude = degrees + minutesseconds;              //  2.yyyyyyyyyyy

                            switch (lineArr[6])
                            {
                                case "E":   signe = "+";
                                            break;
                                case "W":   signe = "-";
                                            _Longitude = -_Longitude;
                                            break;
                                default:    signe = "-";
                                            break;
                            }

                            //degrees
                            try
                            {
                                string myDegrees = lineArr[8];                  //  "238.94"
                                if (myDegrees.Contains("."))
                                {
                                    //myDegrees = myDegrees.Replace('.', ',');    //  "238,94"
                                }
                                _Degrees = Convert.ToDouble(myDegrees);         //  238.94
                                _DegresValide = true;
                            }
                            catch
                            {
                                _Degrees = 0;
                                _DegresValide = false;
                            }

                            //  Mode
                            //  A=Autonomous, D=Differential, R=Fixed RTK, F=Float RTK, E=Dead Reckoning, N=None
                            try
                            {
                                switch (lineArr[12])
                                {
                                    case "A": _ModeIndicator = gpsModeType.Autonomous;   break;
                                    case "D": _ModeIndicator = gpsModeType.Differential; break;
                                    case "R": _ModeIndicator = gpsModeType.FixedRTK; break;
                                    case "F": _ModeIndicator = gpsModeType.FloatRTK; break;
                                    case "E": _ModeIndicator = gpsModeType.DeadReckoning; break;
                                    case "N": _ModeIndicator = gpsModeType.None; break;
                                    default: _ModeIndicator = gpsModeType.None; break;
                                }
                            }
                            catch
                            {
                                _ModeIndicator = gpsModeType.None; break;
                            }

                        if (_gmap_tracking)
                        {
                            //  moins de rapidité = plus d'affichage
                            AfficheGmap();
                        }

                        }
                        catch (Exception )
                        {
                            // une erreur lors de la lecture des valeurs
                            AfficheDatas("Exception $GNRMC");
                        }
                }
            }
        } 

        #endregion
    }


    public enum gpsModeType
    {
        //Parameter	Value	Unit	Description
        //Mode Indicator	A		A=Autonomous, D=Differential, R=Fixed RTK, F=Float RTK, E=Dead Reckoning, N=None
        Autonomous = 0,
        Differential = 1,
        FixedRTK = 2,
        FloatRTK = 3,
        DeadReckoning = 4,
        None = 5
    }


}
