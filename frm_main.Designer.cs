namespace PABLO
{
    partial class frm_main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gps_group = new System.Windows.Forms.GroupBox();
            this.lbl_Mode = new System.Windows.Forms.Label();
            this.gps_lbl_port = new System.Windows.Forms.Label();
            this.lbl_Degres = new System.Windows.Forms.Label();
            this.lbl_Latitude = new System.Windows.Forms.Label();
            this.lbl_Longitude = new System.Windows.Forms.Label();
            this.lbl_GPS = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_STOP = new System.Windows.Forms.Button();
            this.odo_group = new System.Windows.Forms.GroupBox();
            this.odo_btn_stop = new System.Windows.Forms.Button();
            this.odo_btn_start = new System.Windows.Forms.Button();
            this.odo_btn_reset = new System.Windows.Forms.Button();
            this.lbl_Odometre = new System.Windows.Forms.Label();
            this.odo_lbl_port = new System.Windows.Forms.Label();
            this.lbl_DistanceCm = new System.Windows.Forms.Label();
            this.sabertooth_group = new System.Windows.Forms.GroupBox();
            this.lbl_motors = new System.Windows.Forms.Label();
            this.lbl_M1_voltage = new System.Windows.Forms.Label();
            this.lbl_M1_temperature = new System.Windows.Forms.Label();
            this.lbl_Sabertooth = new System.Windows.Forms.Label();
            this.sabertooth_lbl_port = new System.Windows.Forms.Label();
            this.compas_group = new System.Windows.Forms.GroupBox();
            this.lbl_Compas_X = new System.Windows.Forms.Label();
            this.compas_lbl_port = new System.Windows.Forms.Label();
            this.lbl_Compas = new System.Windows.Forms.Label();
            this.pict_gauche = new System.Windows.Forms.PictureBox();
            this.pict_haut = new System.Windows.Forms.PictureBox();
            this.pict_droite = new System.Windows.Forms.PictureBox();
            this.btn_Move = new System.Windows.Forms.Button();
            this.txt_Move_distance = new System.Windows.Forms.TextBox();
            this.txt_Move_angle = new System.Windows.Forms.TextBox();
            this.txt_Angle_delta = new System.Windows.Forms.TextBox();
            this.txt_Angle_correction = new System.Windows.Forms.TextBox();
            this.txt_Move_distance_delta = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.step = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vitesse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nav_group = new System.Windows.Forms.GroupBox();
            this.lbl_ModeNAV = new System.Windows.Forms.Label();
            this.pict_navigateur = new System.Windows.Forms.PictureBox();
            this.btn_TRACK01 = new System.Windows.Forms.Button();
            this.btn_TRACK02 = new System.Windows.Forms.Button();
            this.btn_TRACK03 = new System.Windows.Forms.Button();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.lbl_Remote = new System.Windows.Forms.Label();
            this.lbl_Dio48 = new System.Windows.Forms.Label();
            this.Dio_group = new System.Windows.Forms.GroupBox();
            this.pict_Tool_UP = new System.Windows.Forms.PictureBox();
            this.pict_Tool_DOWN = new System.Windows.Forms.PictureBox();
            this.btn_PENDOWN = new System.Windows.Forms.Button();
            this.btn_PENUP = new System.Windows.Forms.Button();
            this.btn_BACKL = new System.Windows.Forms.Button();
            this.btn_TURNR = new System.Windows.Forms.Button();
            this.btn_TURNL = new System.Windows.Forms.Button();
            this.btn_LEFT = new System.Windows.Forms.Button();
            this.btn_RIGHT = new System.Windows.Forms.Button();
            this.btn_REAR = new System.Windows.Forms.Button();
            this.btn_MIDDLE = new System.Windows.Forms.Button();
            this.btn_FORWARD = new System.Windows.Forms.Button();
            this.img_Remote_Lost = new System.Windows.Forms.PictureBox();
            this.img_Remote_Connected = new System.Windows.Forms.PictureBox();
            this.btn_BACKR = new System.Windows.Forms.Button();
            this.btn_TRACK04 = new System.Windows.Forms.Button();
            this.btn_ZOOMIN = new System.Windows.Forms.Button();
            this.btn_ZOOMOUT = new System.Windows.Forms.Button();
            this.btn_SPEEDPLUS = new System.Windows.Forms.Button();
            this.btn_SPEEDMOINS = new System.Windows.Forms.Button();
            this.lbl_Plot_Speed = new System.Windows.Forms.Label();
            this.btn_GMAP_Mode = new System.Windows.Forms.Button();
            this.lbl_Run_Speed = new System.Windows.Forms.Label();
            this.gps_group.SuspendLayout();
            this.odo_group.SuspendLayout();
            this.sabertooth_group.SuspendLayout();
            this.compas_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pict_gauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_haut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_droite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.nav_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pict_navigateur)).BeginInit();
            this.Dio_group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Tool_UP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Tool_DOWN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_Remote_Lost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_Remote_Connected)).BeginInit();
            this.SuspendLayout();
            // 
            // gps_group
            // 
            this.gps_group.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gps_group.Controls.Add(this.lbl_Mode);
            this.gps_group.Controls.Add(this.gps_lbl_port);
            this.gps_group.Controls.Add(this.lbl_Degres);
            this.gps_group.Controls.Add(this.lbl_Latitude);
            this.gps_group.Controls.Add(this.lbl_Longitude);
            this.gps_group.ForeColor = System.Drawing.Color.Black;
            this.gps_group.Location = new System.Drawing.Point(1, 395);
            this.gps_group.Name = "gps_group";
            this.gps_group.Size = new System.Drawing.Size(140, 130);
            this.gps_group.TabIndex = 0;
            this.gps_group.TabStop = false;
            this.gps_group.Text = "GPS";
            // 
            // lbl_Mode
            // 
            this.lbl_Mode.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Mode.ForeColor = System.Drawing.Color.Black;
            this.lbl_Mode.Location = new System.Drawing.Point(6, 68);
            this.lbl_Mode.Name = "lbl_Mode";
            this.lbl_Mode.Size = new System.Drawing.Size(130, 23);
            this.lbl_Mode.TabIndex = 98;
            this.lbl_Mode.Text = "--";
            this.lbl_Mode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gps_lbl_port
            // 
            this.gps_lbl_port.BackColor = System.Drawing.Color.White;
            this.gps_lbl_port.ForeColor = System.Drawing.Color.Black;
            this.gps_lbl_port.Location = new System.Drawing.Point(86, 2);
            this.gps_lbl_port.Name = "gps_lbl_port";
            this.gps_lbl_port.Size = new System.Drawing.Size(50, 18);
            this.gps_lbl_port.TabIndex = 1;
            this.gps_lbl_port.Text = "COM99";
            this.gps_lbl_port.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Degres
            // 
            this.lbl_Degres.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Degres.ForeColor = System.Drawing.Color.Black;
            this.lbl_Degres.Location = new System.Drawing.Point(6, 91);
            this.lbl_Degres.Name = "lbl_Degres";
            this.lbl_Degres.Size = new System.Drawing.Size(130, 18);
            this.lbl_Degres.TabIndex = 50;
            this.lbl_Degres.Text = "--";
            this.lbl_Degres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Latitude
            // 
            this.lbl_Latitude.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Latitude.ForeColor = System.Drawing.Color.Black;
            this.lbl_Latitude.Location = new System.Drawing.Point(6, 18);
            this.lbl_Latitude.Name = "lbl_Latitude";
            this.lbl_Latitude.Size = new System.Drawing.Size(128, 27);
            this.lbl_Latitude.TabIndex = 46;
            this.lbl_Latitude.Text = "00.0000000";
            this.lbl_Latitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Longitude
            // 
            this.lbl_Longitude.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Longitude.ForeColor = System.Drawing.Color.Black;
            this.lbl_Longitude.Location = new System.Drawing.Point(7, 45);
            this.lbl_Longitude.Name = "lbl_Longitude";
            this.lbl_Longitude.Size = new System.Drawing.Size(129, 23);
            this.lbl_Longitude.TabIndex = 47;
            this.lbl_Longitude.Text = "00.0000000";
            this.lbl_Longitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_GPS
            // 
            this.lbl_GPS.BackColor = System.Drawing.Color.Transparent;
            this.lbl_GPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_GPS.ForeColor = System.Drawing.Color.Black;
            this.lbl_GPS.Location = new System.Drawing.Point(143, 497);
            this.lbl_GPS.Name = "lbl_GPS";
            this.lbl_GPS.Size = new System.Drawing.Size(501, 28);
            this.lbl_GPS.TabIndex = 54;
            this.lbl_GPS.Text = "lbl_GPS";
            this.lbl_GPS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(248, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 20);
            this.textBox1.TabIndex = 49;
            // 
            // btn_STOP
            // 
            this.btn_STOP.BackColor = System.Drawing.Color.Red;
            this.btn_STOP.ForeColor = System.Drawing.Color.White;
            this.btn_STOP.Location = new System.Drawing.Point(829, 277);
            this.btn_STOP.Name = "btn_STOP";
            this.btn_STOP.Size = new System.Drawing.Size(176, 50);
            this.btn_STOP.TabIndex = 74;
            this.btn_STOP.Text = "STOP";
            this.btn_STOP.UseVisualStyleBackColor = false;
            this.btn_STOP.Click += new System.EventHandler(this.btn_STOP_Click);
            // 
            // odo_group
            // 
            this.odo_group.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.odo_group.Controls.Add(this.odo_btn_stop);
            this.odo_group.Controls.Add(this.odo_btn_start);
            this.odo_group.Controls.Add(this.odo_btn_reset);
            this.odo_group.Controls.Add(this.lbl_Odometre);
            this.odo_group.Controls.Add(this.odo_lbl_port);
            this.odo_group.Controls.Add(this.lbl_DistanceCm);
            this.odo_group.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.odo_group.ForeColor = System.Drawing.Color.Black;
            this.odo_group.Location = new System.Drawing.Point(0, 0);
            this.odo_group.Name = "odo_group";
            this.odo_group.Size = new System.Drawing.Size(140, 92);
            this.odo_group.TabIndex = 84;
            this.odo_group.TabStop = false;
            this.odo_group.Text = "Odometre";
            // 
            // odo_btn_stop
            // 
            this.odo_btn_stop.Location = new System.Drawing.Point(59, 46);
            this.odo_btn_stop.Name = "odo_btn_stop";
            this.odo_btn_stop.Size = new System.Drawing.Size(40, 23);
            this.odo_btn_stop.TabIndex = 144;
            this.odo_btn_stop.Text = "stop";
            this.odo_btn_stop.UseVisualStyleBackColor = true;
            this.odo_btn_stop.Click += new System.EventHandler(this.odo_btn_stop_Click);
            // 
            // odo_btn_start
            // 
            this.odo_btn_start.Location = new System.Drawing.Point(13, 46);
            this.odo_btn_start.Name = "odo_btn_start";
            this.odo_btn_start.Size = new System.Drawing.Size(40, 23);
            this.odo_btn_start.TabIndex = 143;
            this.odo_btn_start.Text = "start";
            this.odo_btn_start.UseVisualStyleBackColor = true;
            this.odo_btn_start.Click += new System.EventHandler(this.odo_btn_start_Click);
            // 
            // odo_btn_reset
            // 
            this.odo_btn_reset.Location = new System.Drawing.Point(103, 46);
            this.odo_btn_reset.Name = "odo_btn_reset";
            this.odo_btn_reset.Size = new System.Drawing.Size(30, 23);
            this.odo_btn_reset.TabIndex = 142;
            this.odo_btn_reset.Text = "raz";
            this.odo_btn_reset.UseVisualStyleBackColor = true;
            this.odo_btn_reset.Click += new System.EventHandler(this.odo_btn_reset_Click);
            // 
            // lbl_Odometre
            // 
            this.lbl_Odometre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Odometre.Location = new System.Drawing.Point(6, 67);
            this.lbl_Odometre.Name = "lbl_Odometre";
            this.lbl_Odometre.Size = new System.Drawing.Size(129, 17);
            this.lbl_Odometre.TabIndex = 141;
            this.lbl_Odometre.Text = "lbl_Odometre";
            this.lbl_Odometre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // odo_lbl_port
            // 
            this.odo_lbl_port.BackColor = System.Drawing.Color.White;
            this.odo_lbl_port.ForeColor = System.Drawing.Color.Black;
            this.odo_lbl_port.Location = new System.Drawing.Point(83, 1);
            this.odo_lbl_port.Name = "odo_lbl_port";
            this.odo_lbl_port.Size = new System.Drawing.Size(50, 18);
            this.odo_lbl_port.TabIndex = 1;
            this.odo_lbl_port.Text = "COM99";
            this.odo_lbl_port.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.odo_lbl_port.Click += new System.EventHandler(this.odo_lbl_port_Click);
            // 
            // lbl_DistanceCm
            // 
            this.lbl_DistanceCm.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DistanceCm.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DistanceCm.ForeColor = System.Drawing.Color.Black;
            this.lbl_DistanceCm.Location = new System.Drawing.Point(6, 17);
            this.lbl_DistanceCm.Name = "lbl_DistanceCm";
            this.lbl_DistanceCm.Size = new System.Drawing.Size(127, 31);
            this.lbl_DistanceCm.TabIndex = 89;
            this.lbl_DistanceCm.Text = "0000.00";
            this.lbl_DistanceCm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sabertooth_group
            // 
            this.sabertooth_group.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sabertooth_group.Controls.Add(this.lbl_motors);
            this.sabertooth_group.Controls.Add(this.lbl_M1_voltage);
            this.sabertooth_group.Controls.Add(this.lbl_M1_temperature);
            this.sabertooth_group.Controls.Add(this.lbl_Sabertooth);
            this.sabertooth_group.Controls.Add(this.sabertooth_lbl_port);
            this.sabertooth_group.ForeColor = System.Drawing.Color.Black;
            this.sabertooth_group.Location = new System.Drawing.Point(1, 155);
            this.sabertooth_group.Name = "sabertooth_group";
            this.sabertooth_group.Size = new System.Drawing.Size(140, 119);
            this.sabertooth_group.TabIndex = 85;
            this.sabertooth_group.TabStop = false;
            this.sabertooth_group.Text = "Driver";
            // 
            // lbl_motors
            // 
            this.lbl_motors.BackColor = System.Drawing.Color.Transparent;
            this.lbl_motors.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_motors.ForeColor = System.Drawing.Color.Black;
            this.lbl_motors.Location = new System.Drawing.Point(6, 73);
            this.lbl_motors.Name = "lbl_motors";
            this.lbl_motors.Size = new System.Drawing.Size(127, 26);
            this.lbl_motors.TabIndex = 115;
            this.lbl_motors.Text = "0000 - 0000";
            this.lbl_motors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_M1_voltage
            // 
            this.lbl_M1_voltage.BackColor = System.Drawing.Color.Transparent;
            this.lbl_M1_voltage.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_M1_voltage.ForeColor = System.Drawing.Color.Black;
            this.lbl_M1_voltage.Location = new System.Drawing.Point(5, 19);
            this.lbl_M1_voltage.Name = "lbl_M1_voltage";
            this.lbl_M1_voltage.Size = new System.Drawing.Size(128, 27);
            this.lbl_M1_voltage.TabIndex = 114;
            this.lbl_M1_voltage.Text = "0.0 V";
            this.lbl_M1_voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_M1_temperature
            // 
            this.lbl_M1_temperature.BackColor = System.Drawing.Color.Transparent;
            this.lbl_M1_temperature.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_M1_temperature.ForeColor = System.Drawing.Color.Black;
            this.lbl_M1_temperature.Location = new System.Drawing.Point(6, 47);
            this.lbl_M1_temperature.Name = "lbl_M1_temperature";
            this.lbl_M1_temperature.Size = new System.Drawing.Size(127, 26);
            this.lbl_M1_temperature.TabIndex = 112;
            this.lbl_M1_temperature.Text = "00 °";
            this.lbl_M1_temperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Sabertooth
            // 
            this.lbl_Sabertooth.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Sabertooth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sabertooth.ForeColor = System.Drawing.Color.Black;
            this.lbl_Sabertooth.Location = new System.Drawing.Point(3, 94);
            this.lbl_Sabertooth.Name = "lbl_Sabertooth";
            this.lbl_Sabertooth.Size = new System.Drawing.Size(131, 18);
            this.lbl_Sabertooth.TabIndex = 54;
            this.lbl_Sabertooth.Text = "lbl_Sabertooth";
            this.lbl_Sabertooth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sabertooth_lbl_port
            // 
            this.sabertooth_lbl_port.BackColor = System.Drawing.Color.White;
            this.sabertooth_lbl_port.Location = new System.Drawing.Point(83, 3);
            this.sabertooth_lbl_port.Name = "sabertooth_lbl_port";
            this.sabertooth_lbl_port.Size = new System.Drawing.Size(50, 18);
            this.sabertooth_lbl_port.TabIndex = 1;
            this.sabertooth_lbl_port.Text = "COM99";
            this.sabertooth_lbl_port.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // compas_group
            // 
            this.compas_group.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.compas_group.Controls.Add(this.lbl_Compas_X);
            this.compas_group.Controls.Add(this.compas_lbl_port);
            this.compas_group.Controls.Add(this.lbl_Compas);
            this.compas_group.ForeColor = System.Drawing.Color.Black;
            this.compas_group.Location = new System.Drawing.Point(0, 90);
            this.compas_group.Name = "compas_group";
            this.compas_group.Size = new System.Drawing.Size(140, 67);
            this.compas_group.TabIndex = 96;
            this.compas_group.TabStop = false;
            this.compas_group.Text = "Compas";
            // 
            // lbl_Compas_X
            // 
            this.lbl_Compas_X.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Compas_X.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Compas_X.ForeColor = System.Drawing.Color.Black;
            this.lbl_Compas_X.Location = new System.Drawing.Point(6, 20);
            this.lbl_Compas_X.Name = "lbl_Compas_X";
            this.lbl_Compas_X.Size = new System.Drawing.Size(129, 28);
            this.lbl_Compas_X.TabIndex = 100;
            this.lbl_Compas_X.Text = "000";
            this.lbl_Compas_X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Compas_X.TextChanged += new System.EventHandler(this.lbl_Compas_X_TextChanged);
            // 
            // compas_lbl_port
            // 
            this.compas_lbl_port.BackColor = System.Drawing.Color.White;
            this.compas_lbl_port.ForeColor = System.Drawing.Color.Black;
            this.compas_lbl_port.Location = new System.Drawing.Point(83, 3);
            this.compas_lbl_port.Name = "compas_lbl_port";
            this.compas_lbl_port.Size = new System.Drawing.Size(50, 18);
            this.compas_lbl_port.TabIndex = 1;
            this.compas_lbl_port.Text = "COM99";
            this.compas_lbl_port.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Compas
            // 
            this.lbl_Compas.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Compas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Compas.ForeColor = System.Drawing.Color.Black;
            this.lbl_Compas.Location = new System.Drawing.Point(4, 48);
            this.lbl_Compas.Name = "lbl_Compas";
            this.lbl_Compas.Size = new System.Drawing.Size(132, 14);
            this.lbl_Compas.TabIndex = 54;
            this.lbl_Compas.Text = "lbl_Compas";
            this.lbl_Compas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pict_gauche
            // 
            this.pict_gauche.Image = global::PABLO.Properties.Resources.fleche_gauche;
            this.pict_gauche.Location = new System.Drawing.Point(203, 42);
            this.pict_gauche.Name = "pict_gauche";
            this.pict_gauche.Size = new System.Drawing.Size(30, 30);
            this.pict_gauche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pict_gauche.TabIndex = 104;
            this.pict_gauche.TabStop = false;
            this.pict_gauche.Visible = false;
            // 
            // pict_haut
            // 
            this.pict_haut.BackColor = System.Drawing.Color.Transparent;
            this.pict_haut.Image = global::PABLO.Properties.Resources.fleche_haut;
            this.pict_haut.Location = new System.Drawing.Point(235, 42);
            this.pict_haut.Name = "pict_haut";
            this.pict_haut.Size = new System.Drawing.Size(30, 30);
            this.pict_haut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pict_haut.TabIndex = 105;
            this.pict_haut.TabStop = false;
            this.pict_haut.Visible = false;
            // 
            // pict_droite
            // 
            this.pict_droite.Image = global::PABLO.Properties.Resources.fleche_droite;
            this.pict_droite.Location = new System.Drawing.Point(264, 42);
            this.pict_droite.Name = "pict_droite";
            this.pict_droite.Size = new System.Drawing.Size(30, 30);
            this.pict_droite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pict_droite.TabIndex = 103;
            this.pict_droite.TabStop = false;
            this.pict_droite.Visible = false;
            // 
            // btn_Move
            // 
            this.btn_Move.Location = new System.Drawing.Point(648, 279);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(175, 48);
            this.btn_Move.TabIndex = 98;
            this.btn_Move.Text = "Move";
            this.btn_Move.UseVisualStyleBackColor = true;
            this.btn_Move.Click += new System.EventHandler(this.btn_Move_Click);
            // 
            // txt_Move_distance
            // 
            this.txt_Move_distance.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Move_distance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Move_distance.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Move_distance.Location = new System.Drawing.Point(73, 14);
            this.txt_Move_distance.Name = "txt_Move_distance";
            this.txt_Move_distance.Size = new System.Drawing.Size(76, 24);
            this.txt_Move_distance.TabIndex = 99;
            this.txt_Move_distance.Text = "000.0";
            this.txt_Move_distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Move_angle
            // 
            this.txt_Move_angle.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Move_angle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Move_angle.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Move_angle.Location = new System.Drawing.Point(73, 46);
            this.txt_Move_angle.Name = "txt_Move_angle";
            this.txt_Move_angle.Size = new System.Drawing.Size(54, 24);
            this.txt_Move_angle.TabIndex = 100;
            this.txt_Move_angle.Text = "000";
            this.txt_Move_angle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Angle_delta
            // 
            this.txt_Angle_delta.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Angle_delta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Angle_delta.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Angle_delta.Location = new System.Drawing.Point(153, 45);
            this.txt_Angle_delta.Name = "txt_Angle_delta";
            this.txt_Angle_delta.Size = new System.Drawing.Size(57, 24);
            this.txt_Angle_delta.TabIndex = 101;
            this.txt_Angle_delta.Text = "000";
            this.txt_Angle_delta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Angle_correction
            // 
            this.txt_Angle_correction.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Angle_correction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Angle_correction.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Angle_correction.Location = new System.Drawing.Point(299, 46);
            this.txt_Angle_correction.Name = "txt_Angle_correction";
            this.txt_Angle_correction.Size = new System.Drawing.Size(54, 24);
            this.txt_Angle_correction.TabIndex = 108;
            this.txt_Angle_correction.Text = "000";
            this.txt_Angle_correction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_Move_distance_delta
            // 
            this.txt_Move_distance_delta.BackColor = System.Drawing.SystemColors.ControlDark;
            this.txt_Move_distance_delta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Move_distance_delta.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Move_distance_delta.Location = new System.Drawing.Point(185, 14);
            this.txt_Move_distance_delta.Name = "txt_Move_distance_delta";
            this.txt_Move_distance_delta.Size = new System.Drawing.Size(73, 24);
            this.txt_Move_distance_delta.TabIndex = 109;
            this.txt_Move_distance_delta.Text = "000.0";
            this.txt_Move_distance_delta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(5, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 125;
            this.label9.Text = "distance";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(148, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 17);
            this.label10.TabIndex = 126;
            this.label10.Text = "r";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(37, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 16);
            this.label11.TabIndex = 127;
            this.label11.Text = "cap";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(128, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 17);
            this.label12.TabIndex = 128;
            this.label12.Text = "r";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.step,
            this.latitude,
            this.longitude,
            this.vitesse,
            this.trace,
            this.distance,
            this.cap});
            this.Grid.Location = new System.Drawing.Point(6, 76);
            this.Grid.MultiSelect = false;
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowHeadersWidth = 10;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Grid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid.Size = new System.Drawing.Size(347, 128);
            this.Grid.TabIndex = 131;
            // 
            // step
            // 
            this.step.FillWeight = 150F;
            this.step.HeaderText = "step";
            this.step.MaxInputLength = 6;
            this.step.MinimumWidth = 20;
            this.step.Name = "step";
            this.step.ReadOnly = true;
            this.step.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.step.ToolTipText = "Numéro du segment dans le tracé";
            this.step.Width = 30;
            // 
            // latitude
            // 
            this.latitude.FillWeight = 500F;
            this.latitude.HeaderText = "latitud";
            this.latitude.MaxInputLength = 100;
            this.latitude.MinimumWidth = 60;
            this.latitude.Name = "latitude";
            this.latitude.ReadOnly = true;
            this.latitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.latitude.Width = 74;
            // 
            // longitude
            // 
            this.longitude.HeaderText = "longitud";
            this.longitude.MaxInputLength = 6;
            this.longitude.MinimumWidth = 60;
            this.longitude.Name = "longitude";
            this.longitude.ReadOnly = true;
            this.longitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.longitude.Width = 74;
            // 
            // vitesse
            // 
            this.vitesse.HeaderText = "speed";
            this.vitesse.MaxInputLength = 100;
            this.vitesse.MinimumWidth = 30;
            this.vitesse.Name = "vitesse";
            this.vitesse.ReadOnly = true;
            this.vitesse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.vitesse.ToolTipText = "De min=0 à max=2048";
            this.vitesse.Width = 38;
            // 
            // trace
            // 
            this.trace.HeaderText = "O";
            this.trace.MaxInputLength = 100;
            this.trace.MinimumWidth = 20;
            this.trace.Name = "trace";
            this.trace.ReadOnly = true;
            this.trace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.trace.Width = 20;
            // 
            // distance
            // 
            this.distance.HeaderText = "dist";
            this.distance.MinimumWidth = 30;
            this.distance.Name = "distance";
            this.distance.ReadOnly = true;
            this.distance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.distance.Width = 40;
            // 
            // cap
            // 
            this.cap.HeaderText = "cap";
            this.cap.MinimumWidth = 30;
            this.cap.Name = "cap";
            this.cap.ReadOnly = true;
            this.cap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cap.Width = 40;
            // 
            // nav_group
            // 
            this.nav_group.Controls.Add(this.lbl_ModeNAV);
            this.nav_group.Controls.Add(this.Grid);
            this.nav_group.Controls.Add(this.pict_gauche);
            this.nav_group.Controls.Add(this.pict_navigateur);
            this.nav_group.Controls.Add(this.label12);
            this.nav_group.Controls.Add(this.pict_droite);
            this.nav_group.Controls.Add(this.txt_Angle_correction);
            this.nav_group.Controls.Add(this.label11);
            this.nav_group.Controls.Add(this.txt_Move_distance);
            this.nav_group.Controls.Add(this.label10);
            this.nav_group.Controls.Add(this.txt_Move_angle);
            this.nav_group.Controls.Add(this.label9);
            this.nav_group.Controls.Add(this.txt_Angle_delta);
            this.nav_group.Controls.Add(this.txt_Move_distance_delta);
            this.nav_group.Controls.Add(this.pict_haut);
            this.nav_group.ForeColor = System.Drawing.Color.Black;
            this.nav_group.Location = new System.Drawing.Point(645, -3);
            this.nav_group.Name = "nav_group";
            this.nav_group.Size = new System.Drawing.Size(360, 210);
            this.nav_group.TabIndex = 132;
            this.nav_group.TabStop = false;
            this.nav_group.Text = "Navigateur";
            // 
            // lbl_ModeNAV
            // 
            this.lbl_ModeNAV.Enabled = false;
            this.lbl_ModeNAV.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ModeNAV.ForeColor = System.Drawing.Color.Black;
            this.lbl_ModeNAV.Location = new System.Drawing.Point(291, 16);
            this.lbl_ModeNAV.Name = "lbl_ModeNAV";
            this.lbl_ModeNAV.Size = new System.Drawing.Size(58, 23);
            this.lbl_ModeNAV.TabIndex = 136;
            this.lbl_ModeNAV.Text = "----";
            this.lbl_ModeNAV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pict_navigateur
            // 
            this.pict_navigateur.Image = global::PABLO.Properties.Resources.Compass_256;
            this.pict_navigateur.Location = new System.Drawing.Point(3, 43);
            this.pict_navigateur.Name = "pict_navigateur";
            this.pict_navigateur.Size = new System.Drawing.Size(30, 30);
            this.pict_navigateur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pict_navigateur.TabIndex = 107;
            this.pict_navigateur.TabStop = false;
            this.pict_navigateur.Visible = false;
            // 
            // btn_TRACK01
            // 
            this.btn_TRACK01.Location = new System.Drawing.Point(647, 223);
            this.btn_TRACK01.Name = "btn_TRACK01";
            this.btn_TRACK01.Size = new System.Drawing.Size(85, 50);
            this.btn_TRACK01.TabIndex = 133;
            this.btn_TRACK01.Text = "Parcours 1";
            this.btn_TRACK01.UseVisualStyleBackColor = true;
            this.btn_TRACK01.Click += new System.EventHandler(this.btn_TRACK01_Click);
            // 
            // btn_TRACK02
            // 
            this.btn_TRACK02.Location = new System.Drawing.Point(738, 223);
            this.btn_TRACK02.Name = "btn_TRACK02";
            this.btn_TRACK02.Size = new System.Drawing.Size(85, 50);
            this.btn_TRACK02.TabIndex = 134;
            this.btn_TRACK02.Text = "Parcours 2";
            this.btn_TRACK02.UseVisualStyleBackColor = true;
            this.btn_TRACK02.Click += new System.EventHandler(this.btn_TRACK02_Click);
            // 
            // btn_TRACK03
            // 
            this.btn_TRACK03.Location = new System.Drawing.Point(829, 223);
            this.btn_TRACK03.Name = "btn_TRACK03";
            this.btn_TRACK03.Size = new System.Drawing.Size(85, 50);
            this.btn_TRACK03.TabIndex = 135;
            this.btn_TRACK03.Text = "Parcours 3";
            this.btn_TRACK03.UseVisualStyleBackColor = true;
            this.btn_TRACK03.Click += new System.EventHandler(this.btn_TRACK03_Click);
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(141, 0);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(503, 494);
            this.gmap.TabIndex = 48;
            this.gmap.Zoom = 5D;
            this.gmap.Paint += new System.Windows.Forms.PaintEventHandler(this.gmap_Paint);
            // 
            // lbl_Remote
            // 
            this.lbl_Remote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Remote.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Remote.Location = new System.Drawing.Point(803, 695);
            this.lbl_Remote.Name = "lbl_Remote";
            this.lbl_Remote.Size = new System.Drawing.Size(130, 26);
            this.lbl_Remote.TabIndex = 137;
            this.lbl_Remote.Text = "000";
            this.lbl_Remote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Dio48
            // 
            this.lbl_Dio48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Dio48.Location = new System.Drawing.Point(9, 105);
            this.lbl_Dio48.Name = "lbl_Dio48";
            this.lbl_Dio48.Size = new System.Drawing.Size(125, 18);
            this.lbl_Dio48.TabIndex = 140;
            this.lbl_Dio48.Text = "lbl_Dio48";
            this.lbl_Dio48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dio_group
            // 
            this.Dio_group.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Dio_group.Controls.Add(this.pict_Tool_UP);
            this.Dio_group.Controls.Add(this.pict_Tool_DOWN);
            this.Dio_group.Controls.Add(this.btn_PENDOWN);
            this.Dio_group.Controls.Add(this.btn_PENUP);
            this.Dio_group.Controls.Add(this.lbl_Dio48);
            this.Dio_group.ForeColor = System.Drawing.Color.Black;
            this.Dio_group.Location = new System.Drawing.Point(1, 270);
            this.Dio_group.Name = "Dio_group";
            this.Dio_group.Size = new System.Drawing.Size(140, 127);
            this.Dio_group.TabIndex = 141;
            this.Dio_group.TabStop = false;
            this.Dio_group.Text = "Digital IO";
            // 
            // pict_Tool_UP
            // 
            this.pict_Tool_UP.Image = global::PABLO.Properties.Resources.arrow_green_up;
            this.pict_Tool_UP.Location = new System.Drawing.Point(24, 24);
            this.pict_Tool_UP.Name = "pict_Tool_UP";
            this.pict_Tool_UP.Size = new System.Drawing.Size(28, 27);
            this.pict_Tool_UP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pict_Tool_UP.TabIndex = 142;
            this.pict_Tool_UP.TabStop = false;
            this.pict_Tool_UP.Visible = false;
            // 
            // pict_Tool_DOWN
            // 
            this.pict_Tool_DOWN.Image = global::PABLO.Properties.Resources.arrow_green_down;
            this.pict_Tool_DOWN.Location = new System.Drawing.Point(89, 24);
            this.pict_Tool_DOWN.Name = "pict_Tool_DOWN";
            this.pict_Tool_DOWN.Size = new System.Drawing.Size(27, 27);
            this.pict_Tool_DOWN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pict_Tool_DOWN.TabIndex = 143;
            this.pict_Tool_DOWN.TabStop = false;
            this.pict_Tool_DOWN.Visible = false;
            // 
            // btn_PENDOWN
            // 
            this.btn_PENDOWN.BackColor = System.Drawing.Color.Transparent;
            this.btn_PENDOWN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_PENDOWN.Location = new System.Drawing.Point(74, 55);
            this.btn_PENDOWN.Name = "btn_PENDOWN";
            this.btn_PENDOWN.Size = new System.Drawing.Size(60, 50);
            this.btn_PENDOWN.TabIndex = 188;
            this.btn_PENDOWN.Text = "DOWN";
            this.btn_PENDOWN.UseVisualStyleBackColor = false;
            this.btn_PENDOWN.Click += new System.EventHandler(this.btn_DOWN_Click);
            // 
            // btn_PENUP
            // 
            this.btn_PENUP.BackColor = System.Drawing.Color.Transparent;
            this.btn_PENUP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_PENUP.Location = new System.Drawing.Point(6, 55);
            this.btn_PENUP.Name = "btn_PENUP";
            this.btn_PENUP.Size = new System.Drawing.Size(62, 50);
            this.btn_PENUP.TabIndex = 187;
            this.btn_PENUP.Text = "UP";
            this.btn_PENUP.UseVisualStyleBackColor = false;
            this.btn_PENUP.Click += new System.EventHandler(this.btn_UP_Click);
            // 
            // btn_BACKL
            // 
            this.btn_BACKL.BackgroundImage = global::PABLO.Properties.Resources.arrow_back_gauche;
            this.btn_BACKL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_BACKL.Location = new System.Drawing.Point(743, 465);
            this.btn_BACKL.Name = "btn_BACKL";
            this.btn_BACKL.Size = new System.Drawing.Size(80, 60);
            this.btn_BACKL.TabIndex = 153;
            this.btn_BACKL.UseVisualStyleBackColor = true;
            this.btn_BACKL.Click += new System.EventHandler(this.btn_BACKL_Click);
            // 
            // btn_TURNR
            // 
            this.btn_TURNR.BackgroundImage = global::PABLO.Properties.Resources.arrow0_turnright;
            this.btn_TURNR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_TURNR.Location = new System.Drawing.Point(921, 333);
            this.btn_TURNR.Name = "btn_TURNR";
            this.btn_TURNR.Size = new System.Drawing.Size(80, 60);
            this.btn_TURNR.TabIndex = 152;
            this.btn_TURNR.UseVisualStyleBackColor = true;
            this.btn_TURNR.Click += new System.EventHandler(this.btn_TURNR_Click);
            // 
            // btn_TURNL
            // 
            this.btn_TURNL.BackgroundImage = global::PABLO.Properties.Resources.arrow0_turnleft;
            this.btn_TURNL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_TURNL.Location = new System.Drawing.Point(743, 333);
            this.btn_TURNL.Name = "btn_TURNL";
            this.btn_TURNL.Size = new System.Drawing.Size(80, 60);
            this.btn_TURNL.TabIndex = 151;
            this.btn_TURNL.UseVisualStyleBackColor = true;
            this.btn_TURNL.Click += new System.EventHandler(this.btn_TURNL_Click);
            // 
            // btn_LEFT
            // 
            this.btn_LEFT.BackgroundImage = global::PABLO.Properties.Resources.arrow0_left;
            this.btn_LEFT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_LEFT.Location = new System.Drawing.Point(743, 399);
            this.btn_LEFT.Name = "btn_LEFT";
            this.btn_LEFT.Size = new System.Drawing.Size(80, 60);
            this.btn_LEFT.TabIndex = 148;
            this.btn_LEFT.UseVisualStyleBackColor = true;
            this.btn_LEFT.Click += new System.EventHandler(this.btn_LEFT_Click);
            // 
            // btn_RIGHT
            // 
            this.btn_RIGHT.BackgroundImage = global::PABLO.Properties.Resources.arrow0_right;
            this.btn_RIGHT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RIGHT.Location = new System.Drawing.Point(921, 399);
            this.btn_RIGHT.Name = "btn_RIGHT";
            this.btn_RIGHT.Size = new System.Drawing.Size(80, 60);
            this.btn_RIGHT.TabIndex = 147;
            this.btn_RIGHT.UseVisualStyleBackColor = true;
            this.btn_RIGHT.Click += new System.EventHandler(this.btn_RIGHT_Click);
            // 
            // btn_REAR
            // 
            this.btn_REAR.BackgroundImage = global::PABLO.Properties.Resources.arrow0_reverse;
            this.btn_REAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_REAR.Location = new System.Drawing.Point(830, 465);
            this.btn_REAR.Name = "btn_REAR";
            this.btn_REAR.Size = new System.Drawing.Size(80, 60);
            this.btn_REAR.TabIndex = 146;
            this.btn_REAR.UseVisualStyleBackColor = true;
            this.btn_REAR.Click += new System.EventHandler(this.btn_REAR_Click);
            // 
            // btn_MIDDLE
            // 
            this.btn_MIDDLE.BackgroundImage = global::PABLO.Properties.Resources.arrow0_forward;
            this.btn_MIDDLE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_MIDDLE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MIDDLE.ForeColor = System.Drawing.Color.White;
            this.btn_MIDDLE.Location = new System.Drawing.Point(830, 399);
            this.btn_MIDDLE.Name = "btn_MIDDLE";
            this.btn_MIDDLE.Size = new System.Drawing.Size(80, 60);
            this.btn_MIDDLE.TabIndex = 145;
            this.btn_MIDDLE.Text = "CAP";
            this.btn_MIDDLE.UseVisualStyleBackColor = true;
            this.btn_MIDDLE.Click += new System.EventHandler(this.btn_MIDDLE_Click);
            // 
            // btn_FORWARD
            // 
            this.btn_FORWARD.BackgroundImage = global::PABLO.Properties.Resources.arrow0_forward;
            this.btn_FORWARD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_FORWARD.Location = new System.Drawing.Point(830, 333);
            this.btn_FORWARD.Name = "btn_FORWARD";
            this.btn_FORWARD.Size = new System.Drawing.Size(80, 60);
            this.btn_FORWARD.TabIndex = 144;
            this.btn_FORWARD.UseVisualStyleBackColor = true;
            this.btn_FORWARD.Click += new System.EventHandler(this.btn_FORWARD_Click);
            // 
            // img_Remote_Lost
            // 
            this.img_Remote_Lost.Image = global::PABLO.Properties.Resources.gray_rounded_led_4_th;
            this.img_Remote_Lost.Location = new System.Drawing.Point(737, 695);
            this.img_Remote_Lost.Name = "img_Remote_Lost";
            this.img_Remote_Lost.Size = new System.Drawing.Size(62, 33);
            this.img_Remote_Lost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_Remote_Lost.TabIndex = 139;
            this.img_Remote_Lost.TabStop = false;
            // 
            // img_Remote_Connected
            // 
            this.img_Remote_Connected.Image = global::PABLO.Properties.Resources.gray_rounded_led_4_th;
            this.img_Remote_Connected.Location = new System.Drawing.Point(669, 695);
            this.img_Remote_Connected.Name = "img_Remote_Connected";
            this.img_Remote_Connected.Size = new System.Drawing.Size(62, 32);
            this.img_Remote_Connected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img_Remote_Connected.TabIndex = 138;
            this.img_Remote_Connected.TabStop = false;
            // 
            // btn_BACKR
            // 
            this.btn_BACKR.BackgroundImage = global::PABLO.Properties.Resources.arrow_back_droite;
            this.btn_BACKR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_BACKR.Location = new System.Drawing.Point(921, 465);
            this.btn_BACKR.Name = "btn_BACKR";
            this.btn_BACKR.Size = new System.Drawing.Size(80, 60);
            this.btn_BACKR.TabIndex = 154;
            this.btn_BACKR.UseVisualStyleBackColor = true;
            this.btn_BACKR.Click += new System.EventHandler(this.btn_BACKR_Click);
            // 
            // btn_TRACK04
            // 
            this.btn_TRACK04.Location = new System.Drawing.Point(920, 223);
            this.btn_TRACK04.Name = "btn_TRACK04";
            this.btn_TRACK04.Size = new System.Drawing.Size(85, 50);
            this.btn_TRACK04.TabIndex = 155;
            this.btn_TRACK04.Text = "Parcours 4";
            this.btn_TRACK04.UseVisualStyleBackColor = true;
            this.btn_TRACK04.Click += new System.EventHandler(this.btn_TRACK04_Click);
            // 
            // btn_ZOOMIN
            // 
            this.btn_ZOOMIN.Location = new System.Drawing.Point(143, 444);
            this.btn_ZOOMIN.Name = "btn_ZOOMIN";
            this.btn_ZOOMIN.Size = new System.Drawing.Size(75, 50);
            this.btn_ZOOMIN.TabIndex = 156;
            this.btn_ZOOMIN.Text = "Zoom IN";
            this.btn_ZOOMIN.UseVisualStyleBackColor = true;
            this.btn_ZOOMIN.Click += new System.EventHandler(this.btn_ZOOMIN_Click);
            // 
            // btn_ZOOMOUT
            // 
            this.btn_ZOOMOUT.Location = new System.Drawing.Point(569, 444);
            this.btn_ZOOMOUT.Name = "btn_ZOOMOUT";
            this.btn_ZOOMOUT.Size = new System.Drawing.Size(75, 50);
            this.btn_ZOOMOUT.TabIndex = 157;
            this.btn_ZOOMOUT.Text = "Zoom OUT";
            this.btn_ZOOMOUT.UseVisualStyleBackColor = true;
            this.btn_ZOOMOUT.Click += new System.EventHandler(this.btn_ZOOMOUT_Click);
            // 
            // btn_SPEEDPLUS
            // 
            this.btn_SPEEDPLUS.BackgroundImage = global::PABLO.Properties.Resources.arrow0_forward;
            this.btn_SPEEDPLUS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SPEEDPLUS.Location = new System.Drawing.Point(650, 333);
            this.btn_SPEEDPLUS.Name = "btn_SPEEDPLUS";
            this.btn_SPEEDPLUS.Size = new System.Drawing.Size(80, 60);
            this.btn_SPEEDPLUS.TabIndex = 158;
            this.btn_SPEEDPLUS.UseVisualStyleBackColor = true;
            this.btn_SPEEDPLUS.Click += new System.EventHandler(this.btn_SPEEDPLUS_Click);
            // 
            // btn_SPEEDMOINS
            // 
            this.btn_SPEEDMOINS.BackgroundImage = global::PABLO.Properties.Resources.arrow0_reverse;
            this.btn_SPEEDMOINS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SPEEDMOINS.Location = new System.Drawing.Point(650, 465);
            this.btn_SPEEDMOINS.Name = "btn_SPEEDMOINS";
            this.btn_SPEEDMOINS.Size = new System.Drawing.Size(80, 60);
            this.btn_SPEEDMOINS.TabIndex = 159;
            this.btn_SPEEDMOINS.UseVisualStyleBackColor = true;
            this.btn_SPEEDMOINS.Click += new System.EventHandler(this.btn_SPEEDMOINS_Click);
            // 
            // lbl_Plot_Speed
            // 
            this.lbl_Plot_Speed.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Plot_Speed.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Plot_Speed.ForeColor = System.Drawing.Color.Black;
            this.lbl_Plot_Speed.Location = new System.Drawing.Point(650, 431);
            this.lbl_Plot_Speed.Name = "lbl_Plot_Speed";
            this.lbl_Plot_Speed.Size = new System.Drawing.Size(80, 28);
            this.lbl_Plot_Speed.TabIndex = 160;
            this.lbl_Plot_Speed.Text = "0000";
            this.lbl_Plot_Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_GMAP_Mode
            // 
            this.btn_GMAP_Mode.Location = new System.Drawing.Point(341, 444);
            this.btn_GMAP_Mode.Name = "btn_GMAP_Mode";
            this.btn_GMAP_Mode.Size = new System.Drawing.Size(75, 50);
            this.btn_GMAP_Mode.TabIndex = 161;
            this.btn_GMAP_Mode.Text = "Mode";
            this.btn_GMAP_Mode.UseVisualStyleBackColor = true;
            this.btn_GMAP_Mode.Click += new System.EventHandler(this.btn_GMAP_Mode_Click);
            // 
            // lbl_Run_Speed
            // 
            this.lbl_Run_Speed.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Run_Speed.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Run_Speed.ForeColor = System.Drawing.Color.Black;
            this.lbl_Run_Speed.Location = new System.Drawing.Point(650, 403);
            this.lbl_Run_Speed.Name = "lbl_Run_Speed";
            this.lbl_Run_Speed.Size = new System.Drawing.Size(80, 28);
            this.lbl_Run_Speed.TabIndex = 162;
            this.lbl_Run_Speed.Text = "0000";
            this.lbl_Run_Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1008, 529);
            this.Controls.Add(this.lbl_Run_Speed);
            this.Controls.Add(this.btn_GMAP_Mode);
            this.Controls.Add(this.gps_group);
            this.Controls.Add(this.lbl_Plot_Speed);
            this.Controls.Add(this.btn_SPEEDMOINS);
            this.Controls.Add(this.btn_SPEEDPLUS);
            this.Controls.Add(this.btn_ZOOMOUT);
            this.Controls.Add(this.btn_ZOOMIN);
            this.Controls.Add(this.btn_TRACK04);
            this.Controls.Add(this.btn_BACKR);
            this.Controls.Add(this.btn_BACKL);
            this.Controls.Add(this.btn_TURNR);
            this.Controls.Add(this.btn_TURNL);
            this.Controls.Add(this.btn_LEFT);
            this.Controls.Add(this.btn_RIGHT);
            this.Controls.Add(this.btn_REAR);
            this.Controls.Add(this.btn_MIDDLE);
            this.Controls.Add(this.btn_FORWARD);
            this.Controls.Add(this.nav_group);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Dio_group);
            this.Controls.Add(this.img_Remote_Lost);
            this.Controls.Add(this.img_Remote_Connected);
            this.Controls.Add(this.lbl_Remote);
            this.Controls.Add(this.btn_TRACK03);
            this.Controls.Add(this.lbl_GPS);
            this.Controls.Add(this.btn_TRACK02);
            this.Controls.Add(this.btn_TRACK01);
            this.Controls.Add(this.sabertooth_group);
            this.Controls.Add(this.btn_Move);
            this.Controls.Add(this.compas_group);
            this.Controls.Add(this.odo_group);
            this.Controls.Add(this.btn_STOP);
            this.Controls.Add(this.gmap);
            this.Name = "frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PABLO";
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.gps_group.ResumeLayout(false);
            this.odo_group.ResumeLayout(false);
            this.sabertooth_group.ResumeLayout(false);
            this.compas_group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pict_gauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_haut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_droite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.nav_group.ResumeLayout(false);
            this.nav_group.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pict_navigateur)).EndInit();
            this.Dio_group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pict_Tool_UP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pict_Tool_DOWN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_Remote_Lost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_Remote_Connected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gps_group;
        private System.Windows.Forms.Label gps_lbl_port;
        private System.Windows.Forms.Label lbl_Longitude;
        private System.Windows.Forms.Label lbl_Latitude;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_Degres;
        private System.Windows.Forms.Label lbl_GPS;
        private System.Windows.Forms.Button btn_STOP;
        private System.Windows.Forms.GroupBox odo_group;
        private System.Windows.Forms.Label odo_lbl_port;
        private System.Windows.Forms.GroupBox sabertooth_group;
        private System.Windows.Forms.Label lbl_Sabertooth;
        private System.Windows.Forms.Label sabertooth_lbl_port;
        private System.Windows.Forms.Label lbl_DistanceCm;
        private System.Windows.Forms.GroupBox compas_group;
        private System.Windows.Forms.Label lbl_Compas;
        private System.Windows.Forms.Label compas_lbl_port;
        private System.Windows.Forms.Button btn_Move;
        private System.Windows.Forms.TextBox txt_Move_distance;
        private System.Windows.Forms.TextBox txt_Move_angle;
        private System.Windows.Forms.TextBox txt_Angle_delta;
        private System.Windows.Forms.PictureBox pict_droite;
        private System.Windows.Forms.PictureBox pict_gauche;
        private System.Windows.Forms.PictureBox pict_haut;
        private System.Windows.Forms.PictureBox pict_navigateur;
        private System.Windows.Forms.TextBox txt_Angle_correction;
        private System.Windows.Forms.Label lbl_M1_voltage;
        private System.Windows.Forms.Label lbl_M1_temperature;
        private System.Windows.Forms.Label lbl_Compas_X;
        private System.Windows.Forms.TextBox txt_Move_distance_delta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.GroupBox nav_group;
        private System.Windows.Forms.Button btn_TRACK01;
        private System.Windows.Forms.Button btn_TRACK02;
        private System.Windows.Forms.Button btn_TRACK03;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.Label lbl_Remote;
        private System.Windows.Forms.PictureBox img_Remote_Connected;
        private System.Windows.Forms.PictureBox img_Remote_Lost;
        private System.Windows.Forms.Label lbl_Dio48;
        private System.Windows.Forms.GroupBox Dio_group;
        private System.Windows.Forms.Button btn_PENUP;
        private System.Windows.Forms.Button btn_PENDOWN;
        private System.Windows.Forms.PictureBox pict_Tool_UP;
        private System.Windows.Forms.PictureBox pict_Tool_DOWN;
        private System.Windows.Forms.Label lbl_ModeNAV;
        private System.Windows.Forms.Label lbl_Mode;
        private System.Windows.Forms.Label lbl_Odometre;
        private System.Windows.Forms.DataGridViewTextBoxColumn step;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn vitesse;
        private System.Windows.Forms.DataGridViewTextBoxColumn trace;
        private System.Windows.Forms.DataGridViewTextBoxColumn distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn cap;
        private System.Windows.Forms.Button btn_FORWARD;
        private System.Windows.Forms.Button btn_MIDDLE;
        private System.Windows.Forms.Button btn_REAR;
        private System.Windows.Forms.Button btn_RIGHT;
        private System.Windows.Forms.Button btn_LEFT;
        private System.Windows.Forms.Button btn_TURNL;
        private System.Windows.Forms.Button btn_TURNR;
        private System.Windows.Forms.Button btn_BACKL;
        private System.Windows.Forms.Button btn_BACKR;
        private System.Windows.Forms.Button btn_TRACK04;
        private System.Windows.Forms.Button btn_ZOOMIN;
        private System.Windows.Forms.Button btn_ZOOMOUT;
        private System.Windows.Forms.Button btn_SPEEDPLUS;
        private System.Windows.Forms.Button btn_SPEEDMOINS;
        private System.Windows.Forms.Label lbl_Plot_Speed;
        private System.Windows.Forms.Label lbl_motors;
        private System.Windows.Forms.Button odo_btn_reset;
        private System.Windows.Forms.Button odo_btn_start;
        private System.Windows.Forms.Button odo_btn_stop;
        private System.Windows.Forms.Button btn_GMAP_Mode;
        private System.Windows.Forms.Label lbl_Run_Speed;
    }
}

