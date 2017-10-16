using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
//using System.Threading;
using System.Timers;


namespace PABLO
{
     public class Cls_Bluetooth
    {
        #region Variables

        private string  _portName = string.Empty;
        private SerialPort comPort = new SerialPort();
        private Label _displayWindow;

        static System.Timers.Timer watchdog; // From System.Timers

        private RemoteToucheType _touche;


        private bool _connected;
        private bool _lost;

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

        public Label DisplayWindow
        {
            get { return _displayWindow; }
            set { _displayWindow = value; }
        }

        public RemoteToucheType Touche
        {
            get { return _touche; }
            set { _touche = value; }
        }

        public bool Connected
        {
            get { return _connected; }
        }

        public bool Lost
        {
            get { return _lost; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Comstructor pour fixer les propriétes à vide lorsqu'on ne passe aucun paramètre
        /// </summary>
        public Cls_Bluetooth()
        {
            watchdog = new System.Timers.Timer(10000); // Set up the timer for 10 seconds
            watchdog.Elapsed  += new ElapsedEventHandler(EventWatchdog);
            watchdog.Enabled = false;
            
            _portName = string.Empty; ;
            //add event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);

            // connecté ?
            _connected = false;
            // signal perdu
            _lost = false;

        }

        #endregion

        private void EventWatchdog(object sender, ElapsedEventArgs e)
        {
            // cet évènement indique qu'on n'a pas reçu le mot "CLOCK" depuis xx secondes
            watchdog.Enabled = false; //    inutile de répéter
            _connected = false;
            _lost = true;
        }

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

                //  Ouverture du port de communication
                comPort.Open();

                return true;
            }
            catch (Exception)
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
        /// <param name="type">ce type permet de varier la couleur d'affichage</param>
        /// <param name="msg">Message à afficher</param>
        [STAThread]
        private void AfficheDatas(string msg)
        {
            try
            {
                _displayWindow.Invoke(new EventHandler(delegate
                {
                    _displayWindow.Text = msg;
                }));
            }
            catch
            { }
        }

        #endregion

        #region Réception des données

        /// <summary>
        /// cette méthode est appelée à chaque réception de caractère
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //FORWARD
            //LEFT
            //RIGHT
            //REAR\n
            //STOP\n
            //MIDDLE\n
            //TURNL\n
            //TURNR\n
            //BACKL\n
            //LOOPR\n
            //PATHPLAY\n
            //PATHSTOP\n
            //PATHPAUSE\n
            //PENUP\n
            //PENDOWN\n
            //PENON\n
            //PENOFF\n
            //
            //CLOCK\n
            //LAT=xxxxx;LON=yyyyy\n

            string msg = comPort.ReadLine();
            AfficheDatas(msg);

            _connected = true;
            _lost = false;

            int firstCharacter = msg.IndexOf("CLOCK");
            if (firstCharacter != -1)
            {
                // signal CLOCK ok, on relance le timer pour un tour
                watchdog.Enabled = false;   //  disable
                watchdog.Enabled = true;    //  enable
                return;
            }

            firstCharacter = msg.IndexOf("STOP");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.STOP;
                return;
            }

            firstCharacter = msg.IndexOf("FORWARD");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.FORWARD;
                return;
            }

            firstCharacter = msg.IndexOf("LEFT");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.LEFT;
                return;
            }

            firstCharacter = msg.IndexOf("RIGHT");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.RIGHT;
                return;
            }

            firstCharacter = msg.IndexOf("REAR");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.REAR;
                return;
            }

            firstCharacter = msg.IndexOf("MIDDLE");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.MIDDLE;
                return;
            }

            firstCharacter = msg.IndexOf("TURNL");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.TURNL;
                return;
            }

            firstCharacter = msg.IndexOf("TURNR");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.TURNR;
                return;
            }

            firstCharacter = msg.IndexOf("BACKL");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.BACKL;
                return;
            }

            firstCharacter = msg.IndexOf("LOOPR");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.LOOPR;
                return;
            }

            firstCharacter = msg.IndexOf("PATHPLAY");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.PATHPLAY;
                return;
            }

            firstCharacter = msg.IndexOf("PATHSTOP");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.PATHSTOP;
                return;
            }

            firstCharacter = msg.IndexOf("PATHPAUSE");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.PATHPAUSE;
                return;
            }

            firstCharacter = msg.IndexOf("PENUP");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.PENUP;
                return;
            }

            firstCharacter = msg.IndexOf("PENDOWN");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.PENDOWN;
                return;
            }


            firstCharacter = msg.IndexOf("PENON");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.PENON;
                return;
            }

            firstCharacter = msg.IndexOf("PENOFF");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.PENOFF;
                return;
            }












            firstCharacter = msg.IndexOf("TRACK01");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.TRACK01;
                return;
            }

            firstCharacter = msg.IndexOf("TRACK02");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.TRACK02;
                return;
            }

            firstCharacter = msg.IndexOf("TRACK03");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.TRACK03;
                return;
            }

            firstCharacter = msg.IndexOf("TRACK04");
            if (firstCharacter != -1)
            {
                _touche = RemoteToucheType.TRACK04;
                return;
            }
        }




        #endregion

        //     Remote Touche type
        public enum RemoteToucheType
        {
            //FORWARD
            //LEFT
            //RIGHT
            //REAR\n
            //STOP\n
            //MIDDLE\n
            //TURNL\n
            //TURNR\n
            //BACKL\n
            //LOOPR\n
            //PATHPLAY\n
            //PATHSTOP\n
            //PATHPAUSE\n
            //PENUP\n
            //PENDOWN\n
            //PENON\n
            //PENOFF\n
            //
            //CLOCK\n
            //LAT=xxxxx;LON=yyyyy\n
 
            VIDE = -1,
            FORWARD = 0,
            LEFT = 1,
            RIGHT = 2,
            REAR = 3,
            STOP = 4,
            MIDDLE = 5,
            TURNL = 6,
            TURNR = 7,
            BACKL = 8,
            BACKR = 9,
            LOOPL = 10,
            LOOPR = 11,
            PATHPLAY = 12,
            PATHSTOP = 13,
            PATHPAUSE = 14,
            PENUP = 15,
            PENDOWN = 16,
            TRACK01 = 17,
            TRACK02 = 18,
            TRACK03 = 19,
            TRACK04 = 20,

            PENON = 21,
            PENOFF = 22

        }

    }
    
}
