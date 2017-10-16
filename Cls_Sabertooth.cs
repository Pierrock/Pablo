using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace PABLO
{
    class cls_Sabertooth
    {
        #region Variables

        private string _portName = string.Empty;
        private string _trace = string.Empty;

        private Label _lblMessage;
        private Label _labelDrive;
        private SerialPort comPort = new SerialPort();

        private int _motor1;
        private int _motor2;

        private int _temperature1;
        private int _temperature2;

        private float _batterie1;
        private float _batterie2;

        private int _consigneMax = 1800;
        private int _consigneMin = -1800;

        private int _set_direction = 0;
        private int _set_vitesse = 0;

        private int _step = 100;

        #endregion

        #region Propriétés

        public int set_vitesse
        {
            get { return _set_vitesse; }
            set {
                if (value >= consigneMax) value = consigneMax;
                if (value <= consigneMin) value = consigneMin;
                _set_vitesse = value;
                }
        }

        public int set_direction
        {
            get { return _set_direction; }
            set {
                if (value >= consigneMax) value = consigneMax;
                if (value <= consigneMin) value = consigneMin;
                _set_direction = value; }
                }

        public int consigneMax
        {
            get { return _consigneMax; }
            set { _consigneMax = value; }
        }

        public int consigneMin
        {
            get { return _consigneMin; }
            set { _consigneMin = value; }
        }

        public int step
        {
            get { return _step; }
            set { _step = value; }
        }


        /// <summary>
        /// Returns the duty cycle of the M1 output, from -2047 for full reverse to 2047 for full forward.
        /// </summary>
        public int MoteurDroite
        {
            get { return _motor1; }
        }

        /// <summary>
        /// Returns the duty cycle of the M2 output, from -2047 for full reverse to 2047 for full forward.
        /// </summary>
        public int MoteurGauche
        {
            get { return _motor2; }
        }

        public int TemperatureDroite
        {
            get { return _temperature1; }
        }

        public int TemperatureGauche
        {
            get { return _temperature2; }
        }

        public float BatterieDroite
        {
            get { return _batterie1; }
        }

        public float BatterieGauche
        {
            get { return _batterie2; }
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
        public Label LabelMessage
        {
            get { return _lblMessage; }
            set { _lblMessage = value; }
        }

        public Label LabelDrive
        {
            get { return _labelDrive; }
            set { _labelDrive = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Comstructor pour fixer les propriétes à vide lorsqu'on ne passe aucun paramètre
        /// </summary>
        public cls_Sabertooth()
        {
            _portName = string.Empty; ;
            _lblMessage = null;
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
            _lblMessage.Invoke(new EventHandler(delegate
        {
            // recherche fin de ligne
            int secondCharacter = msg.IndexOf("\r", 0);
            if (secondCharacter > -1)
            {
                //  une réponse complète
                msg = msg.Substring(0, secondCharacter);
            }
            _lblMessage.Text = msg;
        }));
        }

        /// <summary>
        /// Affichage des trames reçues sur l'IHM
        /// </summary>
        [STAThread]
        private void AfficheDrive(string msg)
        {
            _labelDrive.Invoke(new EventHandler(delegate
            {
                // recherche fin de ligne
                int secondCharacter = msg.IndexOf("\r", 0);
                if (secondCharacter > -1)
                {
                    //  une réponse complète
                    msg = msg.Substring(0, secondCharacter);
                }
                _labelDrive.Text = msg;
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
                //AfficheDatas(ex.Message);
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

        public void CommandDifferentialDrive()
        {
            int intXpos = _set_direction;
            int intYpos = _set_vitesse;

            // Calculate Throttled Steering Motor values
            double dblSteer = intXpos / _consigneMax;

            // Turn with throttle
            double dblTsMotorA = intYpos * (1 + dblSteer);
            Limit(ref dblTsMotorA, _consigneMin, _consigneMax);   // Govern Axis to Minimum and Maximum range
            double dblTsMotorB = intYpos * (1 - dblSteer);
            Limit(ref dblTsMotorB, _consigneMin, _consigneMax);   // Govern Axis to Minimum and Maximum range

            // Calculate No Throttle Steering Motors values (Turn with little to no throttle)
            double dblThrot = 1 - Math.Abs(intYpos / _consigneMax);  // Throttle inverse magnitude
                                                                               // (1 = min, 0 = max)
            double dblNtsMotorA = -intXpos * dblThrot;
            double dblNtsMotorB = intXpos * dblThrot;

            // Calculate final motor output values
            double dblMotorA = dblTsMotorA + dblNtsMotorA;
            Limit(ref dblMotorA, _consigneMin, _consigneMax);
            double dblMotorB = dblTsMotorB + dblNtsMotorB;
            Limit(ref dblMotorB, _consigneMin, _consigneMax);

            // Now do something with dblMotorA and dblMotorB

            try
            {
                WriteData("M2:" + dblMotorA.ToString());
                WriteData("M1:" + dblMotorB.ToString());

                AfficheDrive(dblMotorB.ToString("0000 ") + dblMotorA.ToString("0000"));

            }
            catch { }
        }

        private void Limit(ref double Value, double Minimum, double Maximum)
        {
            if (Value > Maximum)
                Value = Maximum;
            if (Value < Minimum)
                Value = Minimum;
        }

        #region Emission des données

        public void WriteData(string msg)
        {
            if (!(comPort.IsOpen == true)) return;

            //  Envoi du message
            comPort.Write(msg);
            comPort.Write("\r\n");
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

            AfficheDatas( msg );

            int firstCharacter = msg.IndexOf("M");
            if (firstCharacter != -1)
            {
                msg = msg.Remove(0, firstCharacter);   //  remove tout ce qui est reçu avant

             // recherche fin de ligne
                int secondCharacter = msg.IndexOf("\r", 0);
                if (secondCharacter == -1)
                    {
                    return;
                    }
                if (secondCharacter <5 )
                {
                    return;
                }


                //  une réponse complète
                string _reponse = msg.Substring(0, secondCharacter);
                //  012345678
                //  M1: 0
                //  M1: 1000
                //  M1:B127
                //  M1:T23

                int separator = _reponse.IndexOf(":");

                if (separator != 2)
                {
                    return;
                }

                //  moteur 1 ou 2
                string smotor = _reponse.Substring(1, 1);
                int motor = Convert.ToInt32(smotor);    //  1 ou 2

                //  
                string command = _reponse.Substring(separator+1, 1);

                if (command=="T")
                {
                    string svalue = _reponse.Substring(separator + 2);
                    int value = Convert.ToInt32(svalue);

                    switch (motor)
                    {
                        case 1: _temperature1 = value;
                            break;
                        case 2: _temperature2 = value;
                            break;
                    }

                }
                else if (command == "B")
                {
                    string svalue = _reponse.Substring(separator + 2);
                    int value = Convert.ToInt32(svalue);

                    switch (motor)
                    {
                        case 1: _batterie1 = (float)value / 10;
                            break;
                        case 2: _batterie2 = (float)value / 10;
                            break;
                    }
                }
                else if (command == " ")
                {
                    string svalue = _reponse.Substring(separator + 2);
                    int value = Convert.ToInt32(svalue);

                    switch (motor)
                    {
                        case 1: _motor1  = value;
                            break;
                        case 2: _motor2 = value;
                            break;
                    }
                }
            }
        }

        #endregion

    }
}
