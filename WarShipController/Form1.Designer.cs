namespace WarShipController
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxComSetting = new System.Windows.Forms.GroupBox();
            this.txtMinValue = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblGocQuay = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMaxValue = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbRate = new System.Windows.Forms.ComboBox();
            this.btNgat = new System.Windows.Forms.Button();
            this.btKetNoi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtkq = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBit = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbBits = new System.Windows.Forms.ComboBox();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbShipId = new System.Windows.Forms.ComboBox();
            this.btnFire = new System.Windows.Forms.Button();
            this.btnCamCtrl = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbTraiphai = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tbTienlui = new System.Windows.Forms.TrackBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.comStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.controllerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.startStopStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerSendCommand = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.groupBoxComSetting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTraiphai)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTienlui)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxComSetting
            // 
            this.groupBoxComSetting.Controls.Add(this.txtMinValue);
            this.groupBoxComSetting.Controls.Add(this.label17);
            this.groupBoxComSetting.Controls.Add(this.lblGocQuay);
            this.groupBoxComSetting.Controls.Add(this.label15);
            this.groupBoxComSetting.Controls.Add(this.txtMaxValue);
            this.groupBoxComSetting.Controls.Add(this.label13);
            this.groupBoxComSetting.Controls.Add(this.cbRate);
            this.groupBoxComSetting.Controls.Add(this.btNgat);
            this.groupBoxComSetting.Controls.Add(this.btKetNoi);
            this.groupBoxComSetting.Controls.Add(this.label6);
            this.groupBoxComSetting.Controls.Add(this.txtkq);
            this.groupBoxComSetting.Controls.Add(this.label5);
            this.groupBoxComSetting.Controls.Add(this.label4);
            this.groupBoxComSetting.Controls.Add(this.label3);
            this.groupBoxComSetting.Controls.Add(this.label2);
            this.groupBoxComSetting.Controls.Add(this.label1);
            this.groupBoxComSetting.Controls.Add(this.cbBit);
            this.groupBoxComSetting.Controls.Add(this.cbParity);
            this.groupBoxComSetting.Controls.Add(this.cbBits);
            this.groupBoxComSetting.Controls.Add(this.cbCom);
            this.groupBoxComSetting.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxComSetting.Location = new System.Drawing.Point(8, 10);
            this.groupBoxComSetting.Name = "groupBoxComSetting";
            this.groupBoxComSetting.Size = new System.Drawing.Size(321, 210);
            this.groupBoxComSetting.TabIndex = 0;
            this.groupBoxComSetting.TabStop = false;
            this.groupBoxComSetting.Text = "Thiết lập cổng COM";
            // 
            // txtMinValue
            // 
            this.txtMinValue.ForeColor = System.Drawing.Color.Red;
            this.txtMinValue.Location = new System.Drawing.Point(65, 156);
            this.txtMinValue.Name = "txtMinValue";
            this.txtMinValue.Size = new System.Drawing.Size(60, 20);
            this.txtMinValue.TabIndex = 26;
            this.txtMinValue.TextChanged += new System.EventHandler(this.txtMinValue_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 160);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Min Value";
            // 
            // lblGocQuay
            // 
            this.lblGocQuay.AutoSize = true;
            this.lblGocQuay.Location = new System.Drawing.Point(223, 189);
            this.lblGocQuay.Name = "lblGocQuay";
            this.lblGocQuay.Size = new System.Drawing.Size(20, 13);
            this.lblGocQuay.TabIndex = 24;
            this.lblGocQuay.Text = "độ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(128, 189);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Góc quay vô lăng: ";
            // 
            // txtMaxValue
            // 
            this.txtMaxValue.ForeColor = System.Drawing.Color.Red;
            this.txtMaxValue.Location = new System.Drawing.Point(65, 181);
            this.txtMaxValue.Name = "txtMaxValue";
            this.txtMaxValue.Size = new System.Drawing.Size(60, 20);
            this.txtMaxValue.TabIndex = 22;
            this.txtMaxValue.TextChanged += new System.EventHandler(this.txtMaxValue_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 185);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Max Value";
            // 
            // cbRate
            // 
            this.cbRate.ForeColor = System.Drawing.Color.Red;
            this.cbRate.FormattingEnabled = true;
            this.cbRate.Location = new System.Drawing.Point(65, 49);
            this.cbRate.Name = "cbRate";
            this.cbRate.Size = new System.Drawing.Size(60, 21);
            this.cbRate.TabIndex = 20;
            this.cbRate.SelectedIndexChanged += new System.EventHandler(this.cbRate_SelectedIndexChanged);
            // 
            // btNgat
            // 
            this.btNgat.ForeColor = System.Drawing.Color.Blue;
            this.btNgat.Location = new System.Drawing.Point(230, 149);
            this.btNgat.Name = "btNgat";
            this.btNgat.Size = new System.Drawing.Size(80, 27);
            this.btNgat.TabIndex = 19;
            this.btNgat.Text = "Ngắt";
            this.btNgat.UseVisualStyleBackColor = true;
            this.btNgat.Click += new System.EventHandler(this.btNgat_Click);
            // 
            // btKetNoi
            // 
            this.btKetNoi.ForeColor = System.Drawing.Color.Blue;
            this.btKetNoi.Location = new System.Drawing.Point(131, 149);
            this.btKetNoi.Name = "btKetNoi";
            this.btKetNoi.Size = new System.Drawing.Size(80, 27);
            this.btKetNoi.TabIndex = 18;
            this.btKetNoi.Text = "Kết Nối";
            this.btKetNoi.UseVisualStyleBackColor = true;
            this.btKetNoi.Click += new System.EventHandler(this.btKetNoi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Nhận dữ liệu:";
            // 
            // txtkq
            // 
            this.txtkq.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkq.Location = new System.Drawing.Point(131, 49);
            this.txtkq.Multiline = true;
            this.txtkq.Name = "txtkq";
            this.txtkq.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtkq.Size = new System.Drawing.Size(179, 90);
            this.txtkq.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(6, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Stop Bit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(6, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Parity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Data Bits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Baud Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "COM";
            // 
            // cbBit
            // 
            this.cbBit.ForeColor = System.Drawing.Color.Red;
            this.cbBit.FormattingEnabled = true;
            this.cbBit.Location = new System.Drawing.Point(65, 130);
            this.cbBit.Name = "cbBit";
            this.cbBit.Size = new System.Drawing.Size(60, 21);
            this.cbBit.TabIndex = 14;
            this.cbBit.SelectedIndexChanged += new System.EventHandler(this.cbBit_SelectedIndexChanged);
            // 
            // cbParity
            // 
            this.cbParity.ForeColor = System.Drawing.Color.Red;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(65, 103);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(60, 21);
            this.cbParity.TabIndex = 12;
            this.cbParity.SelectedIndexChanged += new System.EventHandler(this.cbParity_SelectedIndexChanged);
            // 
            // cbBits
            // 
            this.cbBits.ForeColor = System.Drawing.Color.Red;
            this.cbBits.FormattingEnabled = true;
            this.cbBits.Location = new System.Drawing.Point(65, 76);
            this.cbBits.Name = "cbBits";
            this.cbBits.Size = new System.Drawing.Size(60, 21);
            this.cbBits.TabIndex = 10;
            this.cbBits.SelectedIndexChanged += new System.EventHandler(this.cbBits_SelectedIndexChanged);
            // 
            // cbCom
            // 
            this.cbCom.ForeColor = System.Drawing.Color.Red;
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(65, 22);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(60, 21);
            this.cbCom.TabIndex = 6;
            this.cbCom.SelectedIndexChanged += new System.EventHandler(this.cbCom_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtIpAddress);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(8, 226);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thiết lập kết nối mạng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(62, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Địa chỉ máy 3D";
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.ForeColor = System.Drawing.Color.Red;
            this.txtIpAddress.Location = new System.Drawing.Point(153, 19);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(157, 20);
            this.txtIpAddress.TabIndex = 0;
            this.txtIpAddress.TextChanged += new System.EventHandler(this.txtIpAddress_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.cbShipId);
            this.groupBox3.Controls.Add(this.btnFire);
            this.groupBox3.Controls.Add(this.btnCamCtrl);
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(335, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 262);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bảng điều khiển";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(120, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Số hiệu tàu:";
            // 
            // cbShipId
            // 
            this.cbShipId.ForeColor = System.Drawing.Color.Red;
            this.cbShipId.FormattingEnabled = true;
            this.cbShipId.Location = new System.Drawing.Point(202, 122);
            this.cbShipId.Name = "cbShipId";
            this.cbShipId.Size = new System.Drawing.Size(114, 21);
            this.cbShipId.TabIndex = 11;
            this.cbShipId.SelectedIndexChanged += new System.EventHandler(this.cbShipId_SelectedIndexChanged);
            // 
            // btnFire
            // 
            this.btnFire.Location = new System.Drawing.Point(226, 159);
            this.btnFire.Name = "btnFire";
            this.btnFire.Size = new System.Drawing.Size(93, 43);
            this.btnFire.TabIndex = 9;
            this.btnFire.Text = "ĐK Hỏa lực";
            this.btnFire.UseVisualStyleBackColor = true;
            this.btnFire.Click += new System.EventHandler(this.btnFire_Click);
            // 
            // btnCamCtrl
            // 
            this.btnCamCtrl.Location = new System.Drawing.Point(123, 159);
            this.btnCamCtrl.Name = "btnCamCtrl";
            this.btnCamCtrl.Size = new System.Drawing.Size(93, 43);
            this.btnCamCtrl.TabIndex = 9;
            this.btnCamCtrl.Text = "ĐK Camera";
            this.btnCamCtrl.UseVisualStyleBackColor = true;
            this.btnCamCtrl.Click += new System.EventHandler(this.btnCamCtrl_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(226, 208);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(93, 43);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(123, 208);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 43);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.tbTraiphai);
            this.groupBox4.Location = new System.Drawing.Point(123, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(196, 77);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(164, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(10, 12);
            this.label21.TabIndex = 12;
            this.label21.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 60);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(93, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 12);
            this.label16.TabIndex = 7;
            this.label16.Text = "0";
            // 
            // tbTraiphai
            // 
            this.tbTraiphai.BackColor = System.Drawing.Color.White;
            this.tbTraiphai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbTraiphai.Enabled = false;
            this.tbTraiphai.LargeChange = 1;
            this.tbTraiphai.Location = new System.Drawing.Point(12, 18);
            this.tbTraiphai.Maximum = 50;
            this.tbTraiphai.Minimum = -50;
            this.tbTraiphai.Name = "tbTraiphai";
            this.tbTraiphai.Size = new System.Drawing.Size(171, 45);
            this.tbTraiphai.TabIndex = 0;
            this.tbTraiphai.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbTraiphai.Scroll += new System.EventHandler(this.MoveShipScrollLeftRight);
            this.tbTraiphai.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbScroll_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.tbTienlui);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(103, 232);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(65, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(67, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(67, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(67, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 17);
            this.label10.TabIndex = 30;
            this.label10.Text = "5";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(65, 179);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(26, 17);
            this.label34.TabIndex = 30;
            this.label34.Text = "10";
            // 
            // tbTienlui
            // 
            this.tbTienlui.BackColor = System.Drawing.Color.White;
            this.tbTienlui.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbTienlui.Enabled = false;
            this.tbTienlui.LargeChange = 1;
            this.tbTienlui.Location = new System.Drawing.Point(21, 31);
            this.tbTienlui.Maximum = 100;
            this.tbTienlui.Minimum = -100;
            this.tbTienlui.Name = "tbTienlui";
            this.tbTienlui.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbTienlui.Size = new System.Drawing.Size(45, 172);
            this.tbTienlui.TabIndex = 0;
            this.tbTienlui.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbTienlui.Scroll += new System.EventHandler(this.MoveShipScrollUpDown);
            this.tbTienlui.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbScroll_MouseDown);
            this.tbTienlui.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbScroll_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comStatus,
            this.controllerStatus,
            this.startStopStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 281);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(666, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // comStatus
            // 
            this.comStatus.ForeColor = System.Drawing.Color.Red;
            this.comStatus.Name = "comStatus";
            this.comStatus.Size = new System.Drawing.Size(68, 17);
            this.comStatus.Text = "Com Status";
            // 
            // controllerStatus
            // 
            this.controllerStatus.ForeColor = System.Drawing.Color.Red;
            this.controllerStatus.Name = "controllerStatus";
            this.controllerStatus.Size = new System.Drawing.Size(95, 17);
            this.controllerStatus.Text = "Controller Status";
            // 
            // startStopStatus
            // 
            this.startStopStatus.ForeColor = System.Drawing.Color.Red;
            this.startStopStatus.Name = "startStopStatus";
            this.startStopStatus.Size = new System.Drawing.Size(19, 17);
            this.startStopStatus.Text = "....";
            // 
            // timerSendCommand
            // 
            this.timerSendCommand.Tick += new System.EventHandler(this.timerSendCommand_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Ship Controller";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 1000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 303);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxComSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Phần mềm điều khiển tàu - ISI Ship Controller";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBoxComSetting.ResumeLayout(false);
            this.groupBoxComSetting.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTraiphai)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTienlui)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxComSetting;
        private System.Windows.Forms.Button btNgat;
        private System.Windows.Forms.Button btKetNoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtkq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBit;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbBits;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar tbTraiphai;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TrackBar tbTienlui;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel comStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbShipId;
        private System.Windows.Forms.ComboBox cbRate;
        private System.Windows.Forms.TextBox txtMaxValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblGocQuay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMinValue;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Timer timerSendCommand;
        private System.Windows.Forms.Button btnFire;
        private System.Windows.Forms.Button btnCamCtrl;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripStatusLabel controllerStatus;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.ToolStripStatusLabel startStopStatus;
    }
}

