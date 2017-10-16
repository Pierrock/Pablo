//  1.4.4.0     31/07/2017  WINDOWS 10 LATTEPANDA English : coordonnées GPS en englais
//  1.4.5.0     19/08/2017  carte 4 relais remplace dio48


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

using System.IO;

namespace PABLO
{

    public partial class frm_main : Form
    {
        
        bool MODE_DEBUG = false;     //  mise au point de l'application, sans capteur
        bool GMAP_TRACKING = true;      //  plus de rapidité = moins d'affichage
         


        double mapLatidude;
        double mapLongitude;
 
        //  Télécommande via smartphone en bluetooth
        Cls_Bluetooth BTRemote = new Cls_Bluetooth();
        Timer BTRemoteTimer = new Timer();

        //  Compas
        Cls_Compas Compas = new Cls_Compas();

        //  Odometre
        cls_Odometre Odometre = new cls_Odometre();

        //  GPS
        cls_GPS GPS = new cls_GPS();
        //cls_GPSandroid GPS = new cls_GPSandroid();

        bool gps_FirstPosition = true;

        //  DXF
        cls_DXF DXF = new cls_DXF();

        //  sabertooth
        cls_Sabertooth Driver = new cls_Sabertooth();
        Timer sabertoothTimer = new Timer();
        int sabertoothcounter = 0;      //  on intéroge les valeurs les unes après les autres

        // carte relais 
        cls_Relais relais = new cls_Relais();

        //  Timer de supervision
        Timer supervisorTimer = new Timer();

        //  Timer Navigateur
        Timer navigateurTimer = new Timer();

        //  Timer Rotate
        Timer rotateTimer = new Timer();

        //  ouverture des ports en séquence, une seule fois
        Timer OpenPortsTimer = new Timer();

        cls_navigateur Navigateur = new cls_navigateur();

        Color couleur_erreur = Color.Red;
        Color couleur_back = SystemColors.ControlDark; // Color.Black;
        Color couleur_try = Color.Yellow;

        StreamWriter stream_log = new StreamWriter("log.txt");    //  création du fichier.txt

        public frm_main()
        {
            InitializeComponent();

            //  sabertooth : evenement
            sabertoothTimer.Enabled = false;    //  Thrue par sabertooth_open()
            sabertoothTimer.Interval = 5000;
            sabertoothTimer.Tick += new EventHandler(sabertooth_Tick);

            //  le navigateur
            navigateurTimer.Enabled = false;
            navigateurTimer.Interval = 250;
            navigateurTimer.Tick += new EventHandler(navigateur_Timer);

            //  la rotation
            rotateTimer.Enabled = false;
            rotateTimer.Interval = 250;
            rotateTimer.Tick += new EventHandler(rotate_Timer);

            //  la supervision, hors navigation
            supervisorTimer.Enabled = false;
            supervisorTimer.Interval = 200;
            supervisorTimer.Tick += new EventHandler(supervisorTimer_Timer);
            //supervisorTimer.Enabled = true;

            //  Remote    : timer         
            BTRemoteTimer.Enabled = false;
            BTRemoteTimer.Interval = 200;
            BTRemoteTimer.Tick += new EventHandler(EvenementBTRemote);
            BTRemoteTimer.Enabled = true;

            //  ouverture des ports un par un, une seule fois
            OpenPortsTimer.Enabled = false;
            OpenPortsTimer.Interval = 1000;
            OpenPortsTimer.Tick += new EventHandler(OpenPorts_Timer);

        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName;
            this.Text += " V" + Application.ProductVersion.ToString();
 
            if (MODE_DEBUG)
            {
                this.Text += " MODE DEBUG";
            }

            LogToFile(this.Text);


            //  Télécommande par smartphone via Bluetooth
            BTRemote.DisplayWindow = lbl_Remote;
            BTRemote.PortName = PABLO.Properties.Settings.Default.com_bluetooth;
            BTRemote.OpenPort();

            //  sabertooth
            Driver.LabelMessage = lbl_Sabertooth;
            Driver.LabelDrive = lbl_motors;
            Driver.PortName = PABLO.Properties.Settings.Default.com_sabertooth;
            sabertooth_lbl_port.Text = Driver.PortName.ToString();

            //  GPS             
            GPS.LabelDisplay = lbl_GPS;
            GPS.DisplayGmap = gmap;
            GPS.PortName = PABLO.Properties.Settings.Default.com_gps;
            gps_lbl_port.Text = GPS.PortName.ToString();
            GPS.Gmap_Tracking = GMAP_TRACKING;
 
            //  Odometre
            Odometre.DisplayWindow = lbl_Odometre;
            Odometre.PortName = PABLO.Properties.Settings.Default.com_odometre;
            odo_lbl_port.Text = Odometre.PortName.ToString();
            Odometre.Reset();

            //  Compas
            Compas.LabelDisplay = lbl_Compas;
            Compas.PortName = PABLO.Properties.Settings.Default.com_compas;
            compas_lbl_port.Text = Compas.PortName.ToString();

            // Dio48
            //Dio48.DisplayWindow = lbl_Dio48;
            //Dio48.PortName = PABLO.Properties.Settings.Default.com_dio;
            //Dio_lbl_port.Text = Dio48.PortName;

            // carte 4 relais
            relais.DisplayWindow = lbl_Dio48;
            

            //  navigateur
            Navigateur.set_run_speed = PABLO.Properties.Settings.Default.run_speed;
            Navigateur.set_plot_speed = PABLO.Properties.Settings.Default.plot_speed;
            lbl_Plot_Speed.Text = Navigateur.set_plot_speed.ToString();
            lbl_Run_Speed.Text = Navigateur.set_run_speed.ToString();

            Driver.set_direction = 0;

            // Initialize map:




            GMap.NET.MapProviders.GMapProvider.UserAgent = "PABLO"; // utile ???

            gmap.MapProvider = GMap.NET.MapProviders.BingSatelliteMapProvider.Instance;
            //  gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            //  gmap.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
            //  gmap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;

            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            
            gmap.MaxZoom = 24;
            gmap.Zoom = 19;
            gmap.DragButton = MouseButtons.Left;


            gmap.Position = new GMap.NET.PointLatLng(48.4419847890688, -2.07414954900742);

            // map events
            gmap.OnPositionChanged += new PositionChanged(MainMap_OnCurrentPositionChanged);

            if (!MODE_DEBUG)
            {
                // inutile d'ouvrir les ports en mode DEBUG
                OpenPortsTimer.Enabled = true;
            }

            

            supervisorTimer.Enabled = true;

        }

        private void OpenPorts_Timer(object sender, EventArgs e)
        {
            //  ouverture des ports de communication

            OpenPortsTimer.Enabled = false; //  1 seule fois par l'ouverture de la fenêtre

            //return;

            System.Threading.Thread.Sleep(500);
            Application.DoEvents();

            odo_open();

            System.Threading.Thread.Sleep(500);
            Application.DoEvents();

            odo_reset();
            odo_start();

            compas_open();

            System.Threading.Thread.Sleep(500);
            Application.DoEvents();

            sabertooth_open();

            System.Threading.Thread.Sleep(500);
            Application.DoEvents();

            gps_open();

            System.Threading.Thread.Sleep(500);
            Application.DoEvents();

            relais_init();

        }

        /// <summary>
        /// Timer de supervision
        /// </summary>
        private void supervisorTimer_Timer(object sender, EventArgs e)
        {
            supervisorTimer.Enabled = false;

            // Odométrie

            double moyenne = Odometre.compteur_M;
 
            //  10 tours = 1316 counts
            //   1 tour  = 131.6 counts
            //  diamètre de roue = 12,5" = 31,75 cm
            //  circonférence = 31,75 * PI
            double distance = moyenne * ((31.75 * Math.PI) / 131.6);

            Navigateur.get_distance = distance / 100;  //  cm => m

            lbl_DistanceCm.Text = Navigateur.get_distance.ToString("0000.00");


            //  Compas
            Navigateur.set_cap = Compas.degres;
            lbl_Compas_X.Text = Navigateur.set_cap.ToString() + "°";
            if (Navigateur.set_cap != Navigateur.get_cap)
            {
                gmap.Refresh();
                Navigateur.get_cap = Navigateur.set_cap;
            }


            //cls_AttitudeIndicator1.SetAttitudeIndicatorParameters(-Compas.tangage, -Compas.roulis);

            supervisorTimer.Enabled = true;
        }

        #region gmap

        private void gmap_Paint(object sender, PaintEventArgs e)
        {
            //  draw Pablo au dessus de la carte

            SHAPE myshape = new SHAPE();
            myshape.PenColor = Color.Blue;
            myshape.PenWidth = 1;
            myshape.Centre = new Point(gmap.Width / 2, gmap.Height / 2);
            myshape.drawshape(e, Compas.degres);

        }

        #endregion

        #region remote bluetooth

        //  Evènement de la télécommande smartphone via bluetooth
        private void EvenementBTRemote(object sender, EventArgs e)
        {

            if (!BTRemote.Lost)
            { img_Remote_Lost.Image = PABLO.Properties.Resources.gray_rounded_led_4_th; }
            else
            {
                //  Stop !
                //  arrête le timer navigateurTimer
                //  lance le timer supervisorTimer

                Stop_Navigateur();
                img_Remote_Lost.Image = PABLO.Properties.Resources.red_rounded_led_4_th;
            }


            if (BTRemote.Connected)
            { img_Remote_Connected.Image = PABLO.Properties.Resources.cyan_rounded_led_4_th; }
            else
            {
                img_Remote_Connected.Image = PABLO.Properties.Resources.gray_rounded_led_4_th;
                return;
            }


            BTRemoteTimer.Enabled = false;


            Cls_Bluetooth.RemoteToucheType myTouche = BTRemote.Touche;
            

            switch (myTouche)
            {
                case Cls_Bluetooth.RemoteToucheType.FORWARD:
                    //  en avant
                    Driver.set_vitesse = Driver.set_vitesse + Driver.step;
                    Driver.CommandDifferentialDrive();
                    break;

                case Cls_Bluetooth.RemoteToucheType.LEFT:
                    //  à gauche
                    Driver.set_direction = Driver.set_direction - Driver.step;
                    Driver.CommandDifferentialDrive();
                    break;

                case Cls_Bluetooth.RemoteToucheType.RIGHT:
                    //  à droite
                    Driver.set_direction = Driver.set_direction + Driver.step;
                    Driver.CommandDifferentialDrive();
                    break;

                case Cls_Bluetooth.RemoteToucheType.REAR:
                    //  en arrière
                    Driver.set_vitesse = Driver.set_vitesse - Driver.step;
                    Driver.CommandDifferentialDrive();
                    break;

                case Cls_Bluetooth.RemoteToucheType.STOP:
                    //   Stop !
                    //  arrête le timer navigateurTimer
                    //  lance le timer supervisorTimer
                    Stop_Navigateur();
                    break;

                case Cls_Bluetooth.RemoteToucheType.MIDDLE:
                    //  pour aller tout droit 
                    Driver.set_direction = 0;
                    Driver.CommandDifferentialDrive();
                    break;

                case Cls_Bluetooth.RemoteToucheType.TURNL:
                    break;

                case Cls_Bluetooth.RemoteToucheType.TURNR:
                    break;

                case Cls_Bluetooth.RemoteToucheType.BACKL:
                    break;

                case Cls_Bluetooth.RemoteToucheType.LOOPR:
                    break;

                case Cls_Bluetooth.RemoteToucheType.PATHPLAY:
                    //  Lance le navigateur
                    Run_Navigateur();
                    break;

                case Cls_Bluetooth.RemoteToucheType.PATHPAUSE:
                    break;

                case Cls_Bluetooth.RemoteToucheType.PENUP:
                    //  flip/flop outil en haut
                    Tool_UP();
                    break;

                case Cls_Bluetooth.RemoteToucheType.PENDOWN:
                    //  flip/flop outil en bas
                    Tool_DOWN();
                    break;

                case Cls_Bluetooth.RemoteToucheType.PENON:
                    //  flip/flop outil en rotation
                    break;

                case Cls_Bluetooth.RemoteToucheType.PENOFF:
                    //  flip/flop outil ARRET
                    break;

                case Cls_Bluetooth.RemoteToucheType.TRACK01:
                    Load_Track(1);
                    break;

                case Cls_Bluetooth.RemoteToucheType.TRACK02:
                    Load_Track(2);
                    break;

                case Cls_Bluetooth.RemoteToucheType.TRACK03:
                    Load_Track(3);
                    break;

                case Cls_Bluetooth.RemoteToucheType.TRACK04:
                    Load_Track(4);
                    break;

            }
            //  l'info est traitée, purge la touche
            BTRemote.Touche = Cls_Bluetooth.RemoteToucheType.VIDE;

            BTRemoteTimer.Enabled = true;
        }

        #endregion

        #region relais

        void relais_init()
        {
            if (!relais.connected())
            {
                Dio_group.BackColor = couleur_erreur;
            }
            else
            {
                Dio_group.BackColor = couleur_back;
                relais.relaisUP = false;
                relais.relaisDOWN = false;
                relais.relais03 = false;
                relais.relais04 = false;
                relais.write_status();
            }
        }
 
        private void Tool_UP()
        {
            if (!MODE_DEBUG)
            {
                pict_Tool_DOWN.Visible = false;
                relais.Tool_UP();
                pict_Tool_UP.Visible = true;
                Application.DoEvents();
            }
            else
            {
                pict_Tool_DOWN.Visible = false;
                Wait(1000);
                pict_Tool_UP.Visible = true;
                Application.DoEvents();
            }
        }

        private void Tool_DOWN()
        {
            if (!MODE_DEBUG)
            {
                pict_Tool_UP.Visible = false;
                relais.Tool_DOWN();
                pict_Tool_DOWN.Visible = true;
                Application.DoEvents();
            }
            else
            {
                pict_Tool_UP.Visible = false;
                Wait(1000);
                pict_Tool_DOWN.Visible = true;
                Application.DoEvents();
            }
        }

        public void Wait(int TimeOut)
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

        private void btn_UP_Click(object sender, EventArgs e)
        {
            Tool_UP();
        }

        private void btn_DOWN_Click(object sender, EventArgs e)
        {
            Tool_DOWN();
        }

        #endregion

        #region odometre

        private void odo_lbl_port_Click(object sender, EventArgs e)
        {
            if (!Odometre.IsOpen)
            {
                odo_open();
            }
            else
            {
                odo_close();
            }
            
            
        }

        void odo_open()
        {
            odo_group.BackColor = couleur_try;
            Application.DoEvents();

            System.Threading.Thread.Sleep(100);

            if (!Odometre.OpenPort())
            {
                odo_group.BackColor = couleur_erreur;
            }
            else
            {
                odo_group.BackColor = couleur_back;
            }
        }

        void odo_close()
        {
            Odometre.ClosePort();
            odo_group.BackColor = SystemColors.ControlDarkDark; //couleur_back;
        }

        private void odo_btn_start_Click(object sender, EventArgs e)
        {
            //  ODO_start
            odo_start();
        }

        void odo_start()
        {
            if (!Odometre.WriteData("ODO_start"))
            {
                odo_group.BackColor = couleur_erreur;
            }
            else
            {
                odo_group.BackColor = couleur_back;
            }
        }

        private void odo_btn_reset_Click(object sender, EventArgs e)
        {
            odo_reset();
        }

        void odo_reset()
        {
            if (!Odometre.WriteData("ODO_reset"))
            {
                odo_group.BackColor = couleur_erreur;
            }
            else
            {
                odo_group.BackColor = couleur_back;
            }

            Odometre.Reset();
            lbl_DistanceCm.Text = " - ";
            txt_Move_distance_delta.Text = "000.0";
        }

        private void odo_btn_stop_Click(object sender, EventArgs e)
        {
            //  ODO_stop
            odo_stop();
        }

        void odo_stop()
        {
            if (!Odometre.WriteData("ODO_stop"))
            {
                odo_group.BackColor = couleur_erreur;
            }
            else
            {
                odo_group.BackColor = couleur_back;
            }
        }

        #endregion

        #region sabertooth

        private void sabertooth_btn_open_Click(object sender, EventArgs e)
        {
            sabertooth_open();
        }

        void sabertooth_open()
        {
            if (!Driver.OpenPort())
            {
                sabertooth_group.BackColor = couleur_erreur;
            }
            else
            {
                //  le timer interroge le contrôleur pour connaître l'état de la batterie et la température
                sabertoothTimer.Enabled = true;
                sabertooth_group.BackColor = couleur_back;
            }

        }

        private void sabertooth_btn_close_Click(object sender, EventArgs e)
        {
             sabertooth_close();
        }

        void sabertooth_close()
        {
            sabertoothTimer.Enabled = false;
            Driver.ClosePort();

            lbl_M1_voltage.Text = "--.-V";
            lbl_M1_temperature.Text = "--°";
 
            sabertooth_group.BackColor = SystemColors.ControlDarkDark;

        }

        private void sabertooth_Tick(object sender, EventArgs e)
        {
            sabertoothTimer.Enabled = false;
            try
            {
                //  on interroge les valeurs du contrôleur Driver l'une après l'autre
                switch (sabertoothcounter)
                {
                    case 0:
                        //  l'état de la batterie
                        Driver.WriteData("M1:getb");
                        break;
                    case 1:
                        // la température
                        Driver.WriteData("M1:gett");
                        break;
                }

                sabertoothcounter++;
                if (sabertoothcounter >= 2) sabertoothcounter = 0;

                //  tension batterie 1
                float fVoltage = Driver.BatterieDroite;
                lbl_M1_voltage.Text = fVoltage.ToString("00.0V");

                //  température 1
                lbl_M1_temperature.Text = Driver.TemperatureDroite.ToString("00°");
 
            }
            catch
            {
            }
            sabertoothTimer.Enabled = true;
        }

        #endregion

        #region gps et calculs

        private void gps_btn_close_Click(object sender, EventArgs e)
        {
            gps_close();
        }

        void gps_close()
        {
            GPS.ClosePort();
            gps_group.BackColor = SystemColors.ControlDarkDark; //couleur_back;
        }

        private void gps_btn_open_Click(object sender, EventArgs e)
        {
            gps_open();
        }

        void gps_open()
        {
            if (!GPS.OpenPort())
            {
                gps_group.BackColor = couleur_erreur;
            }
            else
            {
                gps_group.BackColor = couleur_back;
            }
        }

        private void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            textBox1.Text = point.ToString();

            mapLatidude = point.Lat;
            mapLongitude = point.Lng;

            if (MODE_DEBUG)
            {   // utile pour mise au point
                GPS.Latitude = mapLatidude;
                GPS.Longitude = mapLongitude;
            }

            lbl_Latitude.Text = GPS.Latitude.ToString("00.00000000");
            lbl_Longitude.Text = GPS.Longitude.ToString("00.00000000");

            if (GPS.Degres_valide)
            {
                lbl_Degres.Text = GPS.Degres.ToString();
            }
            else
            {
                lbl_Degres.Text = "...";
            }

            switch (GPS.ModeIndicator)
            {
                case gpsModeType.Autonomous: lbl_Mode.Text = "Autonomous"; break;
                case gpsModeType.DeadReckoning: lbl_Mode.Text = "Dead Reckoning"; break;
                case gpsModeType.Differential: lbl_Mode.Text = "Differential"; break;
                case gpsModeType.FixedRTK: lbl_Mode.Text = "Fixed RTK"; break;
                case gpsModeType.FloatRTK: lbl_Mode.Text = "Float RTK"; break;
                case gpsModeType.None: lbl_Mode.Text = "None"; break;
                default: lbl_Mode.Text = "None"; break;
            }
        }

        private void GPS_AfficheCoordonnees()
        {
            lbl_Latitude.Text = GPS.Latitude.ToString();
            lbl_Longitude.Text = GPS.Longitude.ToString();

            if (GPS.Degres_valide)
            {
                lbl_Degres.Text = GPS.Degres.ToString();
            }
            else
            {
                lbl_Degres.Text = "...";
            }

            switch (GPS.ModeIndicator)
            {
                case gpsModeType.Autonomous: lbl_Mode.Text = "Autonomous"; break;
                case gpsModeType.DeadReckoning: lbl_Mode.Text = "Dead Reckoning"; break;
                case gpsModeType.Differential: lbl_Mode.Text = "Differential"; break;
                case gpsModeType.FixedRTK: lbl_Mode.Text = "Fixed RTK"; break;
                case gpsModeType.FloatRTK: lbl_Mode.Text = "Float RTK"; break;
                case gpsModeType.None: lbl_Mode.Text = "None"; break;
                default: lbl_Mode.Text = "None"; break;
            }

            //list.Add(new PointLatLng(GPS.Latitude, GPS.Longitude));

            //GMapRoute r2 = new GMapRoute(list, "pablo"); // object for routing
            //r2.Stroke.Width = 2;
            //r2.Stroke.Color = Color.White ; //  .Blue;
            //routes.Routes.Add(r2);

            if (gps_FirstPosition) gmap.Position = new GMap.NET.PointLatLng(GPS.Latitude, GPS.Longitude);
            gps_FirstPosition = false;

            gmap.Position = new GMap.NET.PointLatLng(GPS.Latitude, GPS.Longitude);

        }

        /// <summary>
        /// Calcul de la distance entre deux points sur la terre
        /// </summary>
        /// <param name="Lat1">point1 - latitude</param>
        /// <param name="Long1">point 1 - longitude</param>
        /// <param name="Lat2">point 2 _ latitude</param>
        /// <param name="Long2">point 2 - longitude</param>
        /// <returns>distance en m&#232;tres</returns>
        public double EarthDistanceCalc(double Long1, double Lat1, double Long2, double Lat2)
        {
            /*
            The Haversine formula according to Dr. Math.
 
            dlon = lon2 - lon1
            dlat = lat2 - lat1
            a = (sin(dlat/2))^2 + cos(lat1) * cos(lat2) * (sin(dlon/2))^2
            c = 2 * atan2(sqrt(a), sqrt(1-a))
            d = R * c

            Where
            * dlon is the change in longitude
            * dlat is the change in latitude
            * c is the great circle distance in Radians.
            * R is the radius of a spherical Earth.
            * The locations of the two points in
            spherical coordinates (longitude and
            latitude) are lon1,lat1 and lon2, lat2.
            */
            double dDistance = Double.MinValue;
            double dLat1InRad = Lat1 * (Math.PI / 180.0);
            double dLong1InRad = Long1 * (Math.PI / 180.0);
            double dLat2InRad = Lat2 * (Math.PI / 180.0);
            double dLong2InRad = Long2 * (Math.PI / 180.0);

            double dLongitude = dLong2InRad - dLong1InRad;
            double dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
            Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) *
            Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            // Distance.
            // const Double kEarthRadiusMiles = 3956.0;
            const Double kEarthRadiusKms = 6376.5;
            dDistance = kEarthRadiusKms * c;

            // resultat en m&#232;tres
            return dDistance * 1000;
        }

        protected double DegreeBearing(double lat1, double lon1, double lat2, double lon2)
        {
            var dLon = ToRad(lon2 - lon1);
            var dPhi = Math.Log(Math.Tan(ToRad(lat2) / 2 + Math.PI / 4) / Math.Tan(ToRad(lat1) / 2 + Math.PI / 4));
            if (Math.Abs(dLon) > Math.PI)
                dLon = dLon > 0 ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);

            double bearing = ToBearing(Math.Atan2(dLon, dPhi));

            bearing = bearing - 180;
            while (bearing < 0)
            {
                bearing += 360;
            }
            return bearing;
        }

        public static double ToRad(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public static double ToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        public static double ToBearing(double radians)
        {
            // convert radians to degrees (as bearing: 0...360)
            return (ToDegrees(radians) + 360) % 360;
        }

        private int DifferenceEntreAngles(int firstAngle, int secondAngle)
        {
            int difference = secondAngle - firstAngle;
            while (difference < -180) difference += 360;
            while (difference > 180) difference -= 360;
            return difference;
        }

        #endregion

        #region compas

        private void compas_btn_open_Click(object sender, EventArgs e)
        {
            compas_open();
        }

        void compas_open()
        {
            if (!Compas.OpenPort())
            {
                compas_group.BackColor = couleur_erreur;
            }
            else
            {
                compas_group.BackColor = couleur_back;
            }
        }

        private void compas_btn_close_Click(object sender, EventArgs e)
        {
            compas_close();
        }

        void compas_close()
        {
            Compas.ClosePort();
            compas_group.BackColor = SystemColors.ControlDarkDark; //couleur_back;
        }

        #endregion

        #region navigateur

        private void navigateur_Timer(object sender, EventArgs e)
        {
            int angle_delta;
            bool tourne_a_droite = false;
            bool tourne_a_gauche = false;

            double dnewdistance;
            double dnewcap;

            // arrêt de ce Timer
            navigateurTimer.Enabled = false;

            string myString = string.Empty;


            //    état initial : Navigateur.nrSegment = 0;

            myString = Navigateur.nrSegment.ToString("000") + "\t";
            myString += Navigateur.nbrSegmentTotal.ToString("000") + "\t";     //  log en fichier pour mise au point
            myString += Navigateur.newsegment.ToString() + "\t";
            myString += Navigateur.Mode.ToString() + "\t";


            if (Navigateur.nrSegment >= Navigateur.nbrSegmentTotal)
            {
                //  ------------------------
                //  STOP !
                //  ------------------------

                Driver.set_vitesse = 0;
                Driver.CommandDifferentialDrive();

                //  les icones = invisibles
                pict_droite.Visible = false;
                pict_gauche.Visible = false;
                pict_haut.Visible = false;
                pict_navigateur.Visible = false;

                // Tool UP
                Tool_UP();  //  il y a une temporisation 
                Navigateur.tool_down = false;
                Navigateur.tool_trace = false;

                //  lance une autre activité 
                supervisorTimer.Enabled = true;
                 
                LogToFile(myString);

                return; 
            }

            

            //  état initial : Mode = GNSS

            if (Navigateur.Mode == cls_navigateur.NavigationMode.ODOMETRIE)
            {
                //  ------------------------
                //  navigation par Odométrie
                //  ------------------------

                // Odométrie : distance parcourue

                double moyenne = Odometre.compteur_M;


                //  on déduit la distance parcourue :
                //  10 tours = 1316 counts
                //   1 tour  = 131.6 counts
                //  diamètre de roue = 12,5" = 31,75 cm
                //  circonférence = 31,75 * PI
                double distance = moyenne * ((31.75 * Math.PI) / 131.6);
                Navigateur.get_distance = distance / 100;  //  cm => m

                lbl_DistanceCm.Text = Navigateur.get_distance.ToString("0000.00");

                // distance qui reste à parcourir
                double distance_delta = Navigateur.set_distance - Navigateur.get_distance;
                txt_Move_distance_delta.Text = distance_delta.ToString("0.00");


                if (distance_delta <= 0.3)
                {
                    //   la distance est atteinte
                    Navigateur.nrSegment++;
                    Navigateur.newsegment = true;
                    Navigateur.Mode = cls_navigateur.NavigationMode.GNSS;
                    lbl_ModeNAV.Text = "GNSS";


                    Grid.Rows[Navigateur.nrSegment].Selected = true;
                    try
                    {
                        Grid.FirstDisplayedScrollingRowIndex = Navigateur.nrSegment - 3;
                    }
                    catch
                    { }

                    //  odométrie : on repart à zéro (utile ? )
                    //Odometre.WriteData("ODO_reset");
                    //Odometre.Reset();
                    odo_reset();

                    LogToFile(myString);

                    navigateurTimer.Enabled = true;  //  relance ce timer pour le prochain segment
                    return;
                }

            }
            else
            {
                //  ------------------  
                //  navigation par GNSS
                //  -------------------

                //  Où est-on ?

 
                //  état initial : Navigateur.newsegment = true;
                if (Navigateur.newsegment)
                {
                    //  Où va-t-on ?

                    //  la nouvelle coordonnée à ateindre
                    Navigateur.dMoveToLatitude = Convert.ToDouble(Grid.Rows[Navigateur.nrSegment].Cells[1].Value);
                    Navigateur.dMoveToLongitude = Convert.ToDouble(Grid.Rows[Navigateur.nrSegment].Cells[2].Value);

                    odo_reset();

                }

                myString += GPS.Latitude.ToString() + "\t";
                myString += GPS.Longitude.ToString() + "\t";

                myString += Navigateur.dMoveToLatitude.ToString() + "\t";
                myString += Navigateur.dMoveToLongitude.ToString() + "\t";

                //  calcul de la distance à parcourir depuis la position actuelle du GPS
                dnewdistance = EarthDistanceCalc(GPS.Longitude, GPS.Latitude, Navigateur.dMoveToLongitude, Navigateur.dMoveToLatitude);
                Navigateur.set_distance = dnewdistance;
                txt_Move_distance.Text = Navigateur.set_distance.ToString("0.00");

                myString += Navigateur.set_distance.ToString() + "\t";

                //  calcul du cap depuis la position actuelle du GPS
                dnewcap = DegreeBearing(Navigateur.dMoveToLatitude, Navigateur.dMoveToLongitude, GPS.Latitude, GPS.Longitude);

                Navigateur.set_cap = Convert.ToInt16(dnewcap);                             //  le cap à suivre ( 0 à 360° )
                txt_Move_angle.Text = Navigateur.set_cap.ToString();

                myString += Navigateur.set_cap.ToString() + "\t";

                //  faut-il tracer ce nouveau segment ?
                Navigateur.tool_trace = Convert.ToBoolean(Grid.Rows[Navigateur.nrSegment].Cells[4].Value);

                myString += Navigateur.tool_trace.ToString() + "\t";

                if (Navigateur.newsegment)
                {
                    Grid.Rows[Navigateur.nrSegment].Cells[5].Value = dnewdistance.ToString("##0.00");
                    Grid.Rows[Navigateur.nrSegment].Cells[6].Value = dnewcap.ToString("##0°");

                    if (Navigateur.tool_trace)
                    {
                        Navigateur.set_speed = Navigateur.set_plot_speed;
                    }
                    else
                    {
                        Navigateur.set_speed = Navigateur.set_run_speed;
                    }

                    Grid.Rows[Navigateur.nrSegment].Cells[3].Value = Navigateur.set_speed.ToString("###0");

                    GMapOverlay MapOverlay = new GMapOverlay("MyMapOverlay");       // Constructing object for Overlay

                    // marqueur : la coordonnée suivante
                    GMarkerGoogle mymarker1 = new GMarkerGoogle(new PointLatLng(Navigateur.dMoveToLatitude, Navigateur.dMoveToLongitude), GMarkerGoogleType.blue_small);
                    mymarker1.ToolTipText = Grid.Rows[Navigateur.nrSegment].Cells[0].Value.ToString();   // "Next point";
                    MapOverlay.Markers.Add(mymarker1);

                    gmap.Overlays.Add(MapOverlay);

                    gmap.Zoom--;
                    gmap.Refresh();
                    Application.DoEvents();
                    gmap.Zoom++;

                    gmap.Refresh();
                    Application.DoEvents();
                }

                myString += Navigateur.set_speed.ToString() + "\t";


                if (Navigateur.newsegment)
                {
                    //  faut-il tracer ce nouveau segment ?
                    if (Navigateur.tool_trace)
                    {
                        //  il faut tracer

                        //  état initial : Navigateur.tool_down = false ( tool en haut )
                        if (!Navigateur.tool_down)
                        {
                            //  l'outil est en haut
                            
                            //  STOP + rotation, une seule fois
                            if ( !Navigateur.rotation_termine )
                            {
                                //  on n'a pas encore fait la rotation 

                                //  STOP !
                                Driver.set_vitesse = 0;
                                Driver.CommandDifferentialDrive();

                                LogToFile(myString);

                                //  maintenant on s'oriente, lance l'activité rotation
                                rotateTimer.Enabled = true;

                                return;
                            }

                            Navigateur.rotation_termine = false;

                            // puis abaisse l'outil
                            Tool_DOWN();
                            Navigateur.tool_down = true;
                            //  l'outil est en bas
 
                        }
                    }
                    else
                    {
                        //  il ne faut pas tracer

                        if (Navigateur.tool_down)
                        {
                            //  l'outil est en bas

                            //  STOP !
                            Driver.set_vitesse = 0;
                            Driver.CommandDifferentialDrive();

                            // d'abord on lève l'outil
                            Tool_UP();
                            Navigateur.tool_down = false;

                        }
                    }

                }


                if (Navigateur.newsegment)
                {
                    Navigateur.newsegment = false;
                }


                if (Navigateur.set_distance <= 1.0) //  1.0
                {
                    // les derniers mètres se font par l'odométrie, pas par le GPS
                    Navigateur.Mode = cls_navigateur.NavigationMode.ODOMETRIE;

                    lbl_ModeNAV.Text = "ODO";
                    //Application.DoEvents();

                    //  odométrie : on repart à zéro pour mesurer la fin du segment
                    //Odometre.WriteData("ODO_reset");                    //  ODO_reset
                    //Odometre.Reset();
                    odo_reset();

                    Navigateur.get_distance = 0;
                }

            }


            //  ----------------------------------------------------------------------------------------------
            //  Quelle que soit la méthode de calcul de la distance ( GNS ou Odométrie ) on doit suivre le cap
            //  ----------------------------------------------------------------------------------------------

            Navigateur.get_cap = Compas.degres;     //  lecture du cap actuel

            myString += Navigateur.get_cap.ToString() + "\t";

            //  Le Compas, simple affichage
            lbl_Compas_X.Text = Navigateur.get_cap.ToString() + "°";

            // tourne à droite ou à gauche ?

            angle_delta = DifferenceEntreAngles(Navigateur.get_cap, Navigateur.set_cap);

            myString += angle_delta.ToString("0000") + "\t";

            tourne_a_droite = false;
            tourne_a_gauche = false;

            if (angle_delta < 0) tourne_a_gauche = true;
            if (angle_delta > 0) tourne_a_droite = true;

            pict_gauche.Visible = tourne_a_gauche;                                  //  juste une indiquation à l'écran
            pict_droite.Visible = tourne_a_droite;                                  //  idem
            pict_haut.Visible = !(tourne_a_droite || tourne_a_gauche);              //  idem
 
            txt_Angle_delta.Text = angle_delta.ToString();                          //  idem






            //// old Méthode

            ////  Navigateur.set_vitesse = de -2000 à +2000
            //int indice_Vitesse = Math.Abs(Navigateur.set_speed);   //  de 0 à +2000
            //indice_Vitesse = indice_Vitesse / 100;                //  de 0 à 20
            //if (indice_Vitesse > 20) indice_Vitesse = 20;         //  pour être sûr de ne pas dépasser l'indice du tableau Tnavigateur [.., XX] 
            //if (indice_Vitesse < 0) indice_Vitesse = 0;           //  pour être sûr ...

            ////  tourne à droite : ++
            ////  tourne à gauche : --

            ////  angle_delta = - 180 à +180
            //int indice_Angle = Math.Abs(angle_delta);             //  de 0 à 180

            ////  correction d'angle de 10° à 180°
            //indice_Angle = indice_Angle / 10;                     //  de 0 à 18
            //if (indice_Angle > 18) indice_Angle = 18;             //  pour être sûr de ne pas dépasser l'indice du tableau Tnavigateur [XX, ..] 
            //if (indice_Angle < 0) indice_Angle = 0;               //  pour être sûr ...

            //// correction en fonction de la vitesse (de 0 à 20) et du cap (0 à 18)
            //int correction = 0;
            //correction = Tnavigateur[indice_Angle, indice_Vitesse];


            // new méthode
            int correctionMAX = Navigateur.set_speed;
            int angleMAX = 90;
            int correction = 0;
            int AngleAbs = Math.Abs(angle_delta);             //  de 0 à 180
            // de 0 = 800 pour 0 à 180

            if (AngleAbs!=0)
            { 
                correction = (correctionMAX / angleMAX) * AngleAbs;
                correction += 50;
                if ( correction > (correctionMAX ) )
                {
                    correction = correctionMAX ;
                }
            }



            myString += correction.ToString("0000") + "\t";

            txt_Angle_correction.Text = correction.ToString();

            int sov_Direction = Driver.set_direction;

            if (tourne_a_droite) { Driver.set_direction = sov_Direction + correction; }
            if (tourne_a_gauche) { Driver.set_direction = sov_Direction - correction; }
            if (!(tourne_a_droite || tourne_a_gauche)) { Driver.set_direction = 0; }

            myString += Driver.set_direction.ToString("0000") + "\t";

            Driver.set_vitesse = Navigateur.set_speed;

            Driver.CommandDifferentialDrive();

            Driver.set_direction = sov_Direction;

            LogToFile(myString);

            navigateurTimer.Enabled = true;  //  relance ce timer

        }

        private void rotate_Timer(object sender, EventArgs e)
        {
            rotateTimer.Enabled = false;

            //string myString = string.Empty;

            // le cap à suivre ( 0 à 360° ) = Navigateur.set_cap
            //LogToFile("RotateToCap(" + Navigateur.set_cap.ToString() + ")");

            int FromCap;
            int ToCap;
            int angle_delta;
            bool tourne_a_droite = false;
            bool tourne_a_gauche = false;

            int consigne_max = 700;         //  pour éviter de tourner trop vite
            int consigne_min = 300;         //  pour éviter de rester à trop faible vitesse

            //  lecture du cap actuel
            FromCap = Compas.degres;        
            lbl_Compas_X.Text = Compas.degres.ToString() + "°";


            //  le cap à atteindre
            ToCap = Navigateur.set_cap;     

            // l'écart entre le cap actuel et le cap à atteindre
            angle_delta = DifferenceEntreAngles(FromCap, ToCap);

            //myString = "\t FromCap = " + FromCap.ToString() + "\t angle_delta = " + angle_delta.ToString();     //  log en fichier pour mise au point

            //  sortie si l'angle est (presque) atteint
            if (Math.Abs(angle_delta) <= 10)
            {
                //  la rotation est terminée
                Navigateur.rotation_termine = true;

                Driver.set_vitesse = 0;
                Driver.set_direction = 0;
                Driver.CommandDifferentialDrive();

                pict_gauche.Visible = false;
                pict_droite.Visible = false;
                pict_haut.Visible = false;

                //LogToFile("RotateToCap(" + ToCap.ToString() + ") terminé");
                //LogToFile(myString);

                //  ici, on doit avoir terminé la rotation, à l'arrêt


                //  lorsque la rotation est terminée, on rebascule dans l'activité de navigation
                navigateurTimer.Enabled = true;  //  relance le timer de navigation

                return;

            }

            // tourne à droite ou à gauche ?
            tourne_a_droite = false;
            tourne_a_gauche = false;

            if (angle_delta < 0) tourne_a_gauche = true;
            if (angle_delta > 0) tourne_a_droite = true;

            pict_gauche.Visible = tourne_a_gauche;                                  //  juste une indiquation à l'écran
            pict_droite.Visible = tourne_a_droite;                                  //  idem
            pict_haut.Visible = !(tourne_a_droite || tourne_a_gauche);              //  idem

            txt_Angle_delta.Text = angle_delta.ToString();                          //  idem

            //  la set_direction en fonction du delta de l'angle
            int consigne = consigne_max / (180 / Math.Abs(angle_delta));

            //  pour éviter de rester planté là dans le sable à trop faible vitesse
            consigne = consigne + consigne_min; 
            if (consigne > consigne_max) { consigne = consigne_max; }

            if (tourne_a_droite) { Driver.set_direction = consigne; }
            if (tourne_a_gauche) { Driver.set_direction = -consigne; }
            if (!(tourne_a_droite || tourne_a_gauche)) { Driver.set_direction = 0; }

            //myString += "\t " + set_direction.ToString();
            //LogToFile(myString);

            Driver.CommandDifferentialDrive();

            //  on continue sur cette activité
            rotateTimer.Enabled = true;

        }

        private void AfficheDistances()
        {
            //  calcul de la première distance et d'un nouveau cap à partir de la position actuelle ( simulée sur la carte )
            //  mapLatidude;    //  simulée sur la carte
            //  mapLongitude;   //  simulée sur la carte

            double dMoveToLatitude = Convert.ToDouble(Grid.Rows[0].Cells[1].Value);        //  la première latitude
            double dMoveToLongitude = Convert.ToDouble(Grid.Rows[0].Cells[2].Value);       //  la première longitude

            double firstdistance = EarthDistanceCalc(mapLongitude, mapLatidude, dMoveToLongitude, dMoveToLatitude);
            Grid.Rows[0].Cells[5].Value = firstdistance.ToString("##0.00");

            double firstcap = DegreeBearing(dMoveToLatitude, dMoveToLongitude, mapLatidude, mapLongitude);
            Grid.Rows[0].Cells[6].Value = firstcap.ToString("##0°");

            for (int I = 1; I < Grid.RowCount - 1; I++)
            {
                double dMoveFromLatitude1;
                double dMoveFromLongitude1;
                double dMoveToLatitude2;
                double dMoveToLongitude2;
                double dnewdistance;
                double dnewcap;

                //  calcul des distances et caps suivants

                dMoveFromLatitude1 = Convert.ToDouble(Grid.Rows[I - 1].Cells[1].Value);      //  la précédante latitude
                dMoveFromLongitude1 = Convert.ToDouble(Grid.Rows[I - 1].Cells[2].Value);     //  la prochaine longitude

                dMoveToLatitude2 = Convert.ToDouble(Grid.Rows[I].Cells[1].Value);        //  la nouvelle latitude
                dMoveToLongitude2 = Convert.ToDouble(Grid.Rows[I].Cells[2].Value);       //  la nouvelle longitude

                dnewdistance = EarthDistanceCalc(dMoveFromLongitude1, dMoveFromLatitude1, dMoveToLongitude2, dMoveToLatitude2);
                Grid.Rows[I].Cells[5].Value = dnewdistance.ToString("##0.00");

                if (dnewdistance < 1)
                {
                    Grid.Rows[I].DefaultCellStyle.BackColor = Color.Yellow;
                }

                dnewcap = DegreeBearing(dMoveToLatitude2, dMoveToLongitude2, dMoveFromLatitude1, dMoveFromLongitude1);
                Grid.Rows[I].Cells[6].Value = dnewcap.ToString("##0°");
            }
        }

        private void AfficheTrack()
        {
            double longitude;
            double latitude;
            bool outil;

            GMapOverlay MapOverlay = new GMapOverlay("MyMapOverlay");       // Constructing object for Overlay
            List<PointLatLng> chemin = new List<PointLatLng>();             // The list of Coordinates to be plotted

            gmap.Overlays.Clear();
            Application.DoEvents();

            // marqueur : la coordonnée de départ
            GMarkerGoogle mymarker1 = new GMarkerGoogle(new PointLatLng(GPS.Latitude, GPS.Longitude), GMarkerGoogleType.black_small);
            mymarker1.ToolTipText = "Center point";
            MapOverlay.Markers.Add(mymarker1);

            gmap.Overlays.Add(MapOverlay);
            gmap.Refresh();
            Application.DoEvents();

            chemin.Clear();

            //  on peut montrer le premier déplmacement
            latitude = mapLatidude;
            longitude = mapLongitude;
            chemin.Add(new PointLatLng(latitude, longitude));


            latitude = Convert.ToDouble(Grid.Rows[0].Cells[1].Value);
            longitude = Convert.ToDouble(Grid.Rows[0].Cells[2].Value);
            outil = Convert.ToBoolean(Grid.Rows[0].Cells[4].Value);

            chemin.Add(new PointLatLng(latitude, longitude));

            for (int I = 1; I < Grid.RowCount - 1; I++)
            {

                latitude = Convert.ToDouble(Grid.Rows[I].Cells[1].Value);
                longitude = Convert.ToDouble(Grid.Rows[I].Cells[2].Value);
                outil = Convert.ToBoolean(Grid.Rows[I].Cells[4].Value);

                if (outil)
                {
                    chemin.Add(new PointLatLng(latitude, longitude));

                }
                else
                {
                    GMapRoute MapRoute = new GMapRoute(chemin, "MyRoute"); // object for routing
                    MapRoute.Stroke.Width = 1;
                    MapRoute.Stroke.Color = Color.Blue;
                    MapOverlay.Routes.Add(MapRoute);
                    gmap.Overlays.Add(MapOverlay);
                    gmap.Refresh();

                    chemin.Clear();
                    chemin.Add(new PointLatLng(latitude, longitude));

                }

            }

            GMapRoute MapRouteFin = new GMapRoute(chemin, "MyRoute"); // object for routing
            MapRouteFin.Stroke.Width = 1;
            MapRouteFin.Stroke.Color = Color.Blue;
            MapOverlay.Routes.Add(MapRouteFin);
            gmap.Overlays.Add(MapOverlay);
            gmap.Refresh();
            chemin.Clear();

        }

        private void btn_STOP_Click(object sender, EventArgs e)
        {
            Stop_Navigateur();
        }

        private void Stop_Navigateur()
        {
            //  arrêt de l'activité navigation
            navigateurTimer.Enabled = false;
            //  arrêt de l'activité rotation
            rotateTimer.Enabled = false;

            Driver.set_vitesse = 0;
            Navigateur.newsegment = true;  //  pour calculer la nouvelle distance et cap

            //  arrêt des moteurs
            Driver.set_direction = 0;
            Driver.CommandDifferentialDrive();

            pict_navigateur.Visible = false;
            pict_gauche.Visible = false;                      //  juste une indiquation à l'écran
            pict_droite.Visible = false;                      //  idem
            pict_haut.Visible = false;

            txt_Move_distance_delta.Text = "000.0";
            txt_Move_distance.Text = "000.0";
            lbl_ModeNAV.Text = "----";
            txt_Angle_correction.Text = "000";
            txt_Angle_delta.Text = "000";
            txt_Move_angle.Text = "000";

            //sld_ConsigneVitesse.Value = Driver.set_vitesse;

            odo_reset();

            supervisorTimer.Enabled = true;
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            Run_Navigateur();
        }

        /// <summary>
        /// Navigation
        /// </summary>
        private void Run_Navigateur()
        {
            supervisorTimer.Enabled = false;

            //  relève l'outil
            Tool_UP();
            Navigateur.tool_down = false;   //  tool en haut

            //  purge toutes les valeurs cap et distance
            //  (calculés à la volée)
            for (int I = 0; I < Grid.RowCount - 1; I++)
            {
                Grid.Rows[I].Cells[3].Value = string.Empty; //  vitesse
                Grid.Rows[I].Cells[5].Value = string.Empty;
                Grid.Rows[I].Cells[6].Value = string.Empty;
                Application.DoEvents();
            }

            Odometre.WriteData("ODO_start");
            Application.DoEvents();

            odo_reset();
            //Odometre.WriteData("ODO_reset");

            Application.DoEvents();

            // prépare le premier step
            
            Navigateur.tool_trace = false;  //  !tool 
            Navigateur.nrSegment = 0;
            Grid.Rows[Navigateur.nrSegment].Selected = true;
            Navigateur.nbrSegmentTotal = Grid.RowCount - 1;
            Navigateur.newsegment = true;   //  forcement, nouveau segment
            Navigateur.newtrack = true;     //  forcement, nouvelle track
            Navigateur.Mode = cls_navigateur.NavigationMode.GNSS;
            //Navigateur.set_vitesse = sld_ConsigneVitesse.Value;
            lbl_ModeNAV.Text = "GNSS";

            AfficheTrack();

            pict_navigateur.Visible = true;
            navigateurTimer.Enabled = true;
            Application.DoEvents();

        }
 
        private void btn_TRACK03_Click(object sender, EventArgs e)
        {
            Load_Track(3);
        }

        private void btn_TRACK02_Click(object sender, EventArgs e)
        {
            Load_Track(2);
        }

        private void btn_TRACK01_Click(object sender, EventArgs e)
        {
            Load_Track(1);
        }

        private void btn_TRACK04_Click(object sender, EventArgs e)
        {
            Load_Track(4);

        }

        private void Load_Track(int track)
        {
            Grid.Rows.Clear();
            string fichier;

            switch (track)
            {
                case 1:
                    fichier = "h.txt";  //  "Tracks1grille.txt";
                    break;
                case 2:
                    fichier = "Tracks2croix.txt";   //"Tracks2.txt";
                    break;
                case 3:
                    fichier = "Tracks3.txt";
                    break;
                case 4:
                    fichier = "Tracks4.txt";
                    break;
                default:
                    fichier = "Tracks1.txt";
                    break;
            }


            try
            {
                using (StreamReader reader = new StreamReader(fichier))
                {
                    string line;
                    double longitude = 0;
                    double latitude = 0;
                    bool outil = false ;

                    int i = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] lineArr = line.Split(';');

                        if (lineArr[0].Contains("."))
                        {
                            lineArr[0] = lineArr[0].Replace('.', ',');        //  0000,0000
                        }
                        try
                        {  longitude = Convert.ToDouble(lineArr[0]); }
                        catch {}

                        if (lineArr[1].Contains("."))
                        {
                            lineArr[1] = lineArr[1].Replace('.', ',');        //  0000,0000
                        }

                        try
                        { latitude = Convert.ToDouble(lineArr[1]); }
                        catch { }

                        string vitesse;

                        switch (lineArr[2])
                        {
                            case "0":
                                outil = false;
                                //vitesse = PABLO.Properties.Settings.Default.run_speed.ToString();
                                vitesse = Navigateur.set_run_speed.ToString();
                                break;
                            case "1":
                                outil = true;
                                //vitesse = PABLO.Properties.Settings.Default.plot_speed.ToString();
                                vitesse = Navigateur.set_plot_speed.ToString();
                                break;
                            default:
                                outil = false;
                                vitesse = Navigateur.set_run_speed.ToString();
                                break;

                        }



                        //Grid.Rows.Add(i.ToString() , mapLatidude + latitude, mapLongitude +  longitude, "1000", outil);

                        //  on se base sur la position acuelle pour centre le dessin
                        Grid.Rows.Add(i.ToString(), (mapLatidude + latitude).ToString("00.00000000"), (mapLongitude + longitude).ToString("00.00000000"), vitesse, outil);

                        i++;
                    }
                }

                Application.DoEvents();
                AfficheDistances();
                AfficheTrack();
            }
            catch
            {
            }
        }

        #endregion

        #region myutils

        private void LogToFile(string infos)
        {
            stream_log.AutoFlush = true;

            stream_log.Write(DateTime.Now.TimeOfDay);
            stream_log.Write("\t");

            stream_log.WriteLine(infos);

            //stream_log.Close();
        }


        #endregion


        private void btn_SPEEDPLUS_Click(object sender, EventArgs e)
        {
            Navigateur.set_plot_speed += 100;
            Navigateur.set_run_speed += 100;
            lbl_Plot_Speed.Text = Navigateur.set_plot_speed.ToString();
            lbl_Run_Speed.Text = Navigateur.set_run_speed.ToString();
        }

        private void btn_SPEEDMOINS_Click(object sender, EventArgs e)
        {
            Navigateur.set_plot_speed -= 100;
            Navigateur.set_run_speed -= 100;
            lbl_Plot_Speed.Text = Navigateur.set_plot_speed.ToString();
            lbl_Run_Speed.Text = Navigateur.set_run_speed.ToString();
        }

        private void btn_FORWARD_Click(object sender, EventArgs e)
        {
            Driver.set_vitesse = Driver.set_vitesse + Driver.step;
            Driver.CommandDifferentialDrive();
        }

        private void btn_LEFT_Click(object sender, EventArgs e)
        {
            Driver.set_direction = Driver.set_direction - Driver.step;
            Driver.CommandDifferentialDrive();
        }

        private void btn_RIGHT_Click(object sender, EventArgs e)
        {
            Driver.set_direction = Driver.set_direction + Driver.step;
            Driver.CommandDifferentialDrive();
        }

        private void btn_REAR_Click(object sender, EventArgs e)
        {
            Driver.set_vitesse = Driver.set_vitesse - Driver.step;
            Driver.CommandDifferentialDrive();
        }

        private void btn_MIDDLE_Click(object sender, EventArgs e)
        {
            //  pour aller tout droit 
            Driver.set_direction = 0;
            Driver.CommandDifferentialDrive();
        }

        private void btn_TURNL_Click(object sender, EventArgs e)
        {

        }

        private void btn_TURNR_Click(object sender, EventArgs e)
        {

        }

        private void btn_BACKL_Click(object sender, EventArgs e)
        {

        }

        private void btn_BACKR_Click(object sender, EventArgs e)
        {

        }

        private void btn_SPEEDP_Click(object sender, EventArgs e)
        {

        }

        private void btn_SPEEDM_Click(object sender, EventArgs e)
        {

        }

        private void btn_ZOOMIN_Click(object sender, EventArgs e)
        {
            gmap.Zoom++;
        }

        private void btn_ZOOMOUT_Click(object sender, EventArgs e)
        {
            gmap.Zoom--;
        }


        // avec/sans mise à jour de la carte par l'évènement du GPS
        private void btn_GMAP_Mode_Click(object sender, EventArgs e)
        {
            GMAP_TRACKING = !GMAP_TRACKING;
            GPS.Gmap_Tracking = GMAP_TRACKING;

            switch (GMAP_TRACKING)
            {
                case true:
                    btn_GMAP_Mode.Text = "tracking\nON";
                    break;

                case false:
                    btn_GMAP_Mode.Text = "tracking\nOFF";
                    break;
            }
        }

        private void lbl_Compas_X_TextChanged(object sender, EventArgs e)
        {
            gmap.Refresh();
        }
    }


    internal class SHAPE
    {
        #region variables internes
        //  centre
        Point _centre = new Point(0, 0);

        //  couleur du trait
        Color _penColor = Color.Black;

        //  épaisseur du trait
        int _penWidth = 2;

        //  body
        Point[] body =
                     {
                 new Point(-25, -30),
                 new Point(+25, -30),
                 new Point(+25, +30),
                 new Point(-25, +30),
                 new Point(-25, -30)
             };

        Point[] wheelL =
                     {
                 new Point(-30, 0),
                 new Point(-40, 0),
                 new Point(-40, +30),
                 new Point(-30, +30),
                 new Point(-30, 0)
             };

        Point[] wheelR =
                        {
                 new Point(+30, 0),
                 new Point(+40, 0),
                 new Point(+40, +30),
                 new Point(+30, +30),
                 new Point(+30, 0)
             };

        Point[] wheelA =
                        {
                 new Point( -5, -35),
                 new Point( +5, -35),
                 new Point( +5, -50),
                 new Point( -5, -50),
                 new Point( -5, -35)
             };

        //  body
        Point[] cap =
                     {
                 new Point(  0,   0),
                 new Point(  0, -300)
             };


        #endregion

        #region propriétés

        public Point Centre
        {
            set { _centre = value; }
        }

        public int PenWidth
        {
            set { _penWidth = value; }
        }

        public Color PenColor
        {
            set { _penColor = value; }
        }

        #endregion

        #region fonctions

        private Point rotate(Point myPoint, int angle)
        {
            int newX1 = 0;
            int newY1 = 0;

            try
            {
                double angleRadian = Math.PI * angle / 180;

                newX1 = (int)(myPoint.X * Math.Cos(angleRadian) - myPoint.Y * Math.Sin(angleRadian));       //  rotation
                newY1 = (int)(myPoint.X * Math.Sin(angleRadian) + myPoint.Y * Math.Cos(angleRadian));
            }
            catch
            {

            }

            return new Point(newX1, newY1);
        }

        public void drawshape(PaintEventArgs e, int angle)
        {
            try
            {
                //  rotate body
                for (int x = 0; x < body.Length; x++)
                {
                    body[x] = rotate(body[x], angle);
                    body[x].Offset(_centre);
                }

                //  rotate
                for (int x = 0; x < wheelL.Length; x++)
                {
                    wheelL[x] = rotate(wheelL[x], angle);
                    wheelL[x].Offset(_centre);
                }

                //  rotate
                for (int x = 0; x < wheelR.Length; x++)
                {
                    wheelR[x] = rotate(wheelR[x], angle);
                    wheelR[x].Offset(_centre);
                }

                //  rotate
                for (int x = 0; x < wheelA.Length; x++)
                {
                    wheelA[x] = rotate(wheelA[x], angle);
                    wheelA[x].Offset(_centre);
                }

                //  rotate cap
                for (int x = 0; x < cap.Length; x++)
                {
                    cap[x] = rotate(cap[x], angle);
                    cap[x].Offset(_centre);
                }


                Pen myPen = new Pen(_penColor, _penWidth);

                //Draw lines to screen.
                e.Graphics.DrawLines(myPen, body);
                e.Graphics.DrawLines(myPen, wheelL);
                e.Graphics.DrawLines(myPen, wheelR);
                e.Graphics.DrawLines(myPen, wheelA);

                Pen myPen2 = new Pen(Color.Red, _penWidth);
                e.Graphics.DrawLines(myPen2, cap);
            }
            catch
            {
            }

        }

        #endregion

    }


    internal class cls_navigateur
    {
        private int _vitesseMax = 1600;
        private int _vitesseMin = 0;
        private int _set_run_speed = 0;
        private int _set_plot_speed = 0;
        private int _set_speed = 0;

        public enum NavigationMode
        {
            GNSS = 0,
            ODOMETRIE = 1
        }


        public double dMoveToLatitude;
        public double dMoveToLongitude;

        public int set_speed
        {
            get { return _set_speed; }
            set
            {
                if (value >= _vitesseMax) value = _vitesseMax;
                if (value <= _vitesseMin) value = _vitesseMin;
                _set_speed = value;
            }
        }

        public int set_plot_speed
        {
            get { return _set_plot_speed; }
            set
            {
                if (value >= _vitesseMax) value = _vitesseMax;
                if (value <= _vitesseMin) value = _vitesseMin;
                _set_plot_speed = value;
            }
        }

        public int set_run_speed
        {
            get { return _set_run_speed; }
            set
            {
                if (value >= _vitesseMax) value = _vitesseMax;
                if (value <= _vitesseMin) value = _vitesseMin;
                _set_run_speed = value;
            }
        }

        public double set_distance { get; set; }
        public double get_distance { get; set; }
        public int set_cap { get; set; }
        public int get_cap { get; set; }

        public bool running { get; set; }
        public bool rotation_termine { get; set; }

        public int nrSegment { get; set; }
        public int nbrSegmentTotal { get; set; }

        public bool tool_trace { get; set; }

        public bool tool_down { get; set; }

        public bool newsegment { get; set; }
        public bool newtrack { get; set; }

        public NavigationMode Mode { get; set; }

    }


}
