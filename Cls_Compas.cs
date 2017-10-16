using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Ports;

namespace PABLO
{
    class Cls_Compas
    {
        #region Variables

        private string  _portName = string.Empty;
        private SerialPort comPort = new SerialPort();
        private Label _labelDisplay;

        private int _degres;
        private int _roulis;
        private int _tangage;

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

        public Label LabelDisplay
        {
            get { return _labelDisplay; }
            set { _labelDisplay = value; }
        }

        public int degres
        {
            get { return _degres; }
            set { _degres = value; }    //  pour mise au point
        }

        public int roulis
        {
            get { return _roulis; }
        }

        public int tangage
        {
            get { return _tangage; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Comstructor
        /// </summary>
        public Cls_Compas()
        {
            _portName = string.Empty; ;

            //add event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
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
                comPort.BaudRate = 9600;
                comPort.DataBits = 8;
                comPort.StopBits = System.IO.Ports.StopBits.One;
                comPort.Handshake = System.IO.Ports.Handshake.None;
                comPort.Encoding = System.Text.Encoding.Default;

                comPort.RtsEnable = true;

                //  Ouverture du port de communication
                comPort.Open();

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
        }

        #endregion

        #region Affichage des données

        /// <summary>
        /// Affichage des trames reçues sur l'IHM
        /// </summary>
        [STAThread]
        private void AfficheDatas(string msg)
        {
            try
            {
                _labelDisplay.Invoke(new EventHandler(delegate
                {
                    _labelDisplay.Text = msg;
                }));
            }
            catch
            { }
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
            //AfficheDatas("-->" + msg + "\n");
        }
        #endregion

        #region Réception des données

        /// <summary>
        /// cette méthode est appelée à chaque réception de caractère
        /// </summary>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string msg = comPort.ReadLine();

            //*360;-1;-1;1;#

            if (msg.Length <= 10)
            { return; }

            int StartCharacter = msg.IndexOf("*");
            if (StartCharacter < 0)
            {
                return;
            }

            int StopCharacter = msg.IndexOf("#");
            if (StopCharacter < 0)
            {
                return;
            }
            try
            {
                string[] lineArr = msg.Split(';','*','#');

                string sValue = lineArr[1];             //  "180"
                 _degres = Convert.ToInt16 (sValue);    //  180

                sValue = lineArr[2];                    //  "-14"
                _roulis = Convert.ToInt16(sValue);      //  -14   

                sValue = lineArr[3];                    //  "16"
                _tangage = Convert.ToInt16(sValue);     //  16
            }

            catch (Exception)
            {
                //Can't Read compas values
                AfficheDatas(msg);
            }
        }

        #endregion

    }
}
