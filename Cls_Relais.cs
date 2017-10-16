using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;

using System.Runtime.InteropServices;   //  pour DllImport



namespace PABLO
{
    class cls_Relais
    {

        // constants needed for "CreateFile" 
        private const uint GENERIC_ALL = 0x10000000;    // & H10000000
        private const uint GENERIC_READ = 0x80000000;     //  &H80000000 
        private const uint GENERIC_WRITE = 0x40000000;    //  &H40000000
        private const uint GENERIC_EXECUTE = 0x20000000;   //  &H20000000
        private const uint OPEN_EXISTING = 0x3;
        //public const FILE_SHARE_READ = &H1
        //public const FILE_SHARE_WRITE = &H2
        private const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        private const uint FILE_FLAG_OVERLAPPED = 0x40000000;


        #region Variables
        private string _port;
        private bool _connected;
        private bool _relaisUP;
        private bool _relaisDOWN;
        private bool _relais03;
        private bool _relais04;

        private bool _tool_HI = false;
        private bool _tool_LO = false;

        private Label _displayWindow;
  
        #endregion

        #region Propriétés

        /// <summary>
        /// Etat du relais nr 1
        /// </summary>
        public bool relaisUP
        {
            get { return _relaisUP; }
            set { _relaisUP = value; }
        }

        /// <summary>
        /// Etat du relais nr 2
        /// </summary>
        public bool relaisDOWN
        {
            get { return _relaisDOWN; }
            set { _relaisDOWN = value; }
        }

        /// <summary>
        /// Etat du relais nr 3
        /// </summary>
        public bool relais03
        {
            get { return _relais03; }
            set { _relais03 = value; }
        }

        /// <summary>
        /// Etat du relais nr 4
        /// </summary>
        public bool relais04
        {
            get { return _relais04; }
            set { _relais04 = value; }
        }

        /// <summary>
        ///  Proprieté DisplayWindow de la classe : un Label
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
        public cls_Relais()
        {
            _displayWindow = null;
            //connected();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hHandle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr SecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32.dll")]
        static extern FileType GetFileType(IntPtr hFile);

        enum FileType : uint
        {
            UNKNOWN = 0x0000,
            DISK = 0x0001,
            CHAR = 0x0002,
            PIPE = 0x0003,
            REMOTE = 0x8000,
        }

        public bool connected()
        {
            string oneport;
            byte device_type = 0;

            _connected = false;

            try
            {
                // Get a list of serial port names.
                string[] ports = SerialPort.GetPortNames();

                foreach (string port in ports)
                {
                    // oneport = "\\\\.\\" + port;
                    oneport = @"\\.\" + port;
                    IntPtr myHandle = CreateFile(oneport, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL | FILE_FLAG_OVERLAPPED, IntPtr.Zero);
                    if (myHandle.ToInt32() != -1)
                    {
                        int myresult = Cls_CP210X.CP210xRT_GetPartNumber(myHandle, ref device_type);
                        if (Cls_CP210X.CP210x_SUCCESS == myresult)
                        {
                            if (device_type == Cls_CP210X.CP210x_CP2104_VERSION)
                            {
                                _port = oneport;
                                _connected = true;
                            }
                        }
                    }
                    
                    CloseHandle(myHandle);
                }

            }
            catch (Exception)
            {
                //
            }

            return _connected;
        }

        #endregion

        #region pilotage des relais

        public void read_status()
        {
            byte latch_state_recieved = 0;
            int relais_states;

            _relaisUP = false;
            _relaisDOWN = false;
            _relais03 = false;
            _relais04 = false;

            if (!_connected)       { return; }
            if (_port.Length < 1)  { return; }

            try
            {
                IntPtr myHandle = CreateFile(_port, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL | FILE_FLAG_OVERLAPPED, IntPtr.Zero);
                if (myHandle.ToInt32() != -1)
                {
                    int myresult = Cls_CP210X.CP210xRT_ReadLatch(myHandle, ref latch_state_recieved);
                }
                CloseHandle(myHandle);

            }
            catch (Exception)
            {
                //
            }

            //au repos latch_state_recieved = 15  = 0000 1111
            relais_states = ~latch_state_recieved;  //  inversion bes bits
            relais_states = relais_states & 0x0f;   //  masque 0000 1111

            _relaisUP = (relais_states & Cls_CP210X.CP210x_GPIO_0) == Cls_CP210X.CP210x_GPIO_0;
            _relaisDOWN = (relais_states & Cls_CP210X.CP210x_GPIO_1) == Cls_CP210X.CP210x_GPIO_1;
            _relais03 = (relais_states & Cls_CP210X.CP210x_GPIO_2) == Cls_CP210X.CP210x_GPIO_2;
            _relais04 = (relais_states & Cls_CP210X.CP210x_GPIO_3) == Cls_CP210X.CP210x_GPIO_3;
        }

        public void write_status()
        {
            int i = 0;

            if (!_connected) { return; }
            if (_port.Length < 1) { return; }

            //  Calculate new  CP2104 output latch value according choosen relays
            if (_relaisUP) i = (i | Cls_CP210X.CP210x_GPIO_0) ;
            if (_relaisDOWN) i = (i | Cls_CP210X.CP210x_GPIO_1);
            if (_relais03) i = (i | Cls_CP210X.CP210x_GPIO_2);
            if (_relais04) i = (i | Cls_CP210X.CP210x_GPIO_3);
            i = i ^ 0xFF;

            try
            {
                IntPtr myHandle = CreateFile(_port, GENERIC_READ | GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL | FILE_FLAG_OVERLAPPED, IntPtr.Zero);
                if (myHandle.ToInt32() != -1)
                {
                    // Write new GPIO setting to switch the relays. 0F(hex) => all GPIOs will be addressed
                    int myresult = Cls_CP210X.CP210xRT_WriteLatch(myHandle, 0xFF, (byte)i);
                }
                CloseHandle(myHandle);

            }
            catch (Exception)
            {
                //
            }
        }


        /// <summary>
        /// Relève l'outil de traçé
        /// </summary>
        public void Tool_UP()
        {
            _tool_LO = false;

            //  moteur UP on
            relaisUP = true;
            write_status();

            Wait(1500);

            //  l'alimentation du moteur est coupée par le capteur de fin de course

            //  moteur UP off
            relaisUP = false;
            write_status();

            _tool_HI = true;
        }

        /// <summary>
        /// Abaisse l'outil de traçé
        /// </summary>
        public void Tool_DOWN()
        {
            _tool_HI = false;

            //  moteur DOWN on
            relaisDOWN = true;
            write_status();

            Wait(1000);

            //  moteur DOWN off
            relaisDOWN = false;
            write_status();

            _tool_LO = true;

        }


        private void Wait(int TimeOut)
        {
            DateTime _timeStart;            //  util pour calculer le temps passé : start
            TimeSpan _timeElapsed;          //  util pour calculer le temps passé : le temps écoulé
            int total = 0;

            _timeStart = DateTime.Now;                  //  le comptage commence maintenant
            do
            {
                Application.DoEvents();
                _timeElapsed = DateTime.Now - _timeStart;
                total = (int)_timeElapsed.TotalMilliseconds;  //  le temps écoulé depuis le start du timer
            } while (total < TimeOut);
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

    }
}
