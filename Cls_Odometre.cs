using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace PABLO
{
    class cls_Odometre
    {
        #region Variables

        private string _portName = string.Empty;

        private int _compteur_G;
        private int _compteur_D;
        private int _compteur_M;    // la moyenne

        private Label _displayWindow;
        private SerialPort comPort = new SerialPort();

        #endregion

        #region Propriétés

        public bool IsOpen
        {
            get { return comPort.IsOpen; }
        }


        /// <summary>
        /// Compteur Gauche
        /// </summary>
        public int compteur_G
        {
            get { return _compteur_G; }
            set { _compteur_G = value; }
        }

        /// <summary>
        /// Compteur Droite
        /// </summary>
        public int compteur_D
        {
            get { return _compteur_D; }
            set { _compteur_D = value; }
        }

        /// <summary>
        /// Moyenne des 2 compteurs Droite et Gauche
        /// </summary>
        public int compteur_M
        {
            get { return _compteur_M; }
            set { _compteur_M = value; }
        }

        /// <summary>
        /// Proprieté PortName de la classe ("COM1", "COM2", "COM3" ect...)
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        ///  Proprieté DisplayWindow de la classe : un objet RichTextBox
        /// </summary>
        public Label DisplayWindow
        {
            get { return _displayWindow; }
            set { _displayWindow = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Comstructor pour fixer les propriétes à vide lorsqu'on ne passe aucun paramètre
        /// </summary>
        public cls_Odometre()
        {
            _portName = string.Empty; ;
            _displayWindow = null;
            //add event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }
        
        #endregion

        #region Affichage des données

        /// <summary>
        /// Affichage des trames reçues sur l'IHM
        /// </summary>
        /// <param name="type">ce type permet de varier la couleur d'affichage</param>
        /// <param name="msg">Message à afficher</param>
        [STAThread]
        private void AfficheDatas( string msg)
        {
            _displayWindow.Invoke(new EventHandler(delegate
        {
            //msg = DateTime.Now.ToString("HH:mm:ss ") + msg;
            _displayWindow.Text = msg;
        }));
        }

        #endregion

        #region Open / close Port

        public void Reset()
        {
            _compteur_D = 0;
            _compteur_G = 0;
            _compteur_M = 0;
        }

        public bool OpenPort()
        {
            try
            {

                AfficheDatas(comPort.PortName + " ...");
                Application.DoEvents();

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

             // Affiche le message d'ouverture
                AfficheDatas( comPort.PortName + " ouvert");
                
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
            AfficheDatas( comPort.PortName + " fermé");
        }

        #endregion

        #region Emission des données

        public bool WriteData(string msg)
        {
            //  S'assurer que le port est ouvert. S'il est fermé on l'ouvre
            //if (!(comPort.IsOpen == true)) OpenPort();

            try
            {
                //  Envoi du message
                //comPort.WriteLine(msg);
                comPort.Write(msg);
                comPort.Write("\r");

                //  Affichage du message
                AfficheDatas(msg); //+ "\n");

                return true;
            }
            catch (Exception ex)
            {
                AfficheDatas(ex.Message);
                return false;
            }

        }
        
        #endregion

        #region Réception des données

        /// <summary>
        /// cette méthode est appelée à chaque réception de caractère
        /// </summary>

        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
              
        //  lecture des datas 
            string msg = comPort.ReadLine();

            //  "2727 2764\r"
            AfficheDatas( msg );
            try
            {
                string[] lineArr = msg.Split(' ');

                _compteur_D = Convert.ToInt32(lineArr[0]);
                _compteur_G = Convert.ToInt32(lineArr[1]);
                _compteur_M = (_compteur_D + _compteur_G) / 2;

            }
            catch
            { }

        }
        
        #endregion

    }
}
