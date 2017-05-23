namespace WarShipController
{
    partial class CameraControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraControl));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGocQuayDoc = new System.Windows.Forms.Label();
            this.lblGocQuayNgang = new System.Windows.Forms.Label();
            this.UpDown = new System.Windows.Forms.TrackBar();
            this.LeftRight = new System.Windows.Forms.TrackBar();
            this.btnMui1 = new System.Windows.Forms.Button();
            this.btnDuoi1 = new System.Windows.Forms.Button();
            this.btnMui2 = new System.Windows.Forms.Button();
            this.btnPhai3 = new System.Windows.Forms.Button();
            this.btnTrai3 = new System.Windows.Forms.Button();
            this.btnPhai2 = new System.Windows.Forms.Button();
            this.btnTrai2 = new System.Windows.Forms.Button();
            this.btnPhai1 = new System.Windows.Forms.Button();
            this.btnTrai1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.timerSendCamCtrl = new System.Windows.Forms.Timer(this.components);
            this.Zoom = new System.Windows.Forms.TrackBar();
            this.timerSendCamZoom = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zoom)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Zoom);
            this.groupBox1.Controls.Add(this.lblGocQuayDoc);
            this.groupBox1.Controls.Add(this.lblGocQuayNgang);
            this.groupBox1.Controls.Add(this.UpDown);
            this.groupBox1.Controls.Add(this.LeftRight);
            this.groupBox1.Controls.Add(this.btnMui1);
            this.groupBox1.Controls.Add(this.btnDuoi1);
            this.groupBox1.Controls.Add(this.btnMui2);
            this.groupBox1.Controls.Add(this.btnPhai3);
            this.groupBox1.Controls.Add(this.btnTrai3);
            this.groupBox1.Controls.Add(this.btnPhai2);
            this.groupBox1.Controls.Add(this.btnTrai2);
            this.groupBox1.Controls.Add(this.btnPhai1);
            this.groupBox1.Controls.Add(this.btnTrai1);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 410);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn Camera";
            // 
            // lblGocQuayDoc
            // 
            this.lblGocQuayDoc.AutoSize = true;
            this.lblGocQuayDoc.Location = new System.Drawing.Point(57, 289);
            this.lblGocQuayDoc.Name = "lblGocQuayDoc";
            this.lblGocQuayDoc.Size = new System.Drawing.Size(20, 13);
            this.lblGocQuayDoc.TabIndex = 25;
            this.lblGocQuayDoc.Text = "độ";
            // 
            // lblGocQuayNgang
            // 
            this.lblGocQuayNgang.AutoSize = true;
            this.lblGocQuayNgang.Location = new System.Drawing.Point(57, 69);
            this.lblGocQuayNgang.Name = "lblGocQuayNgang";
            this.lblGocQuayNgang.Size = new System.Drawing.Size(20, 13);
            this.lblGocQuayNgang.TabIndex = 25;
            this.lblGocQuayNgang.Text = "độ";
            // 
            // UpDown
            // 
            this.UpDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UpDown.LargeChange = 1;
            this.UpDown.Location = new System.Drawing.Point(6, 72);
            this.UpDown.Maximum = 900;
            this.UpDown.Name = "UpDown";
            this.UpDown.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.UpDown.Size = new System.Drawing.Size(45, 245);
            this.UpDown.TabIndex = 13;
            this.UpDown.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.UpDown.Scroll += new System.EventHandler(this.UpDown_Scroll);
            this.UpDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scroll_MouseDown);
            this.UpDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Scroll_MouseUp);
            // 
            // LeftRight
            // 
            this.LeftRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeftRight.LargeChange = 1;
            this.LeftRight.Location = new System.Drawing.Point(6, 21);
            this.LeftRight.Maximum = 3600;
            this.LeftRight.Name = "LeftRight";
            this.LeftRight.Size = new System.Drawing.Size(259, 45);
            this.LeftRight.TabIndex = 12;
            this.LeftRight.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.LeftRight.Scroll += new System.EventHandler(this.LeftRight_Scroll);
            this.LeftRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scroll_MouseDown);
            this.LeftRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Scroll_MouseUp);
            // 
            // btnMui1
            // 
            this.btnMui1.BackColor = System.Drawing.Color.Red;
            this.btnMui1.ForeColor = System.Drawing.Color.Blue;
            this.btnMui1.Location = new System.Drawing.Point(141, 73);
            this.btnMui1.Name = "btnMui1";
            this.btnMui1.Size = new System.Drawing.Size(55, 36);
            this.btnMui1.TabIndex = 11;
            this.btnMui1.UseVisualStyleBackColor = false;
            this.btnMui1.Click += new System.EventHandler(this.btnSelectCam_Click);
            // 
            // btnDuoi1
            // 
            this.btnDuoi1.BackColor = System.Drawing.Color.Red;
            this.btnDuoi1.ForeColor = System.Drawing.Color.Blue;
            this.btnDuoi1.Location = new System.Drawing.Point(139, 157);
            this.btnDuoi1.Name = "btnDuoi1";
            this.btnDuoi1.Size = new System.Drawing.Size(55, 36);
            this.btnDuoi1.TabIndex = 10;
            this.btnDuoi1.UseVisualStyleBackColor = false;
            this.btnDuoi1.Click += new System.EventHandler(this.btnSelectCam_Click);
            // 
            // btnMui2
            // 
            this.btnMui2.BackColor = System.Drawing.Color.Red;
            this.btnMui2.ForeColor = System.Drawing.Color.Blue;
            this.btnMui2.Location = new System.Drawing.Point(139, 115);
            this.btnMui2.Name = "btnMui2";
            this.btnMui2.Size = new System.Drawing.Size(55, 36);
            this.btnMui2.TabIndex = 10;
            this.btnMui2.UseVisualStyleBackColor = false;
            this.btnMui2.Click += new System.EventHandler(this.btnSelectCam_Click);
            // 
            // btnPhai3
            // 
            this.btnPhai3.BackColor = System.Drawing.Color.Red;
            this.btnPhai3.ForeColor = System.Drawing.Color.Blue;
            this.btnPhai3.Location = new System.Drawing.Point(202, 157);
            this.btnPhai3.Name = "btnPhai3";
            this.btnPhai3.Size = new System.Drawing.Size(55, 36);
            this.btnPhai3.TabIndex = 10;
            this.btnPhai3.UseVisualStyleBackColor = false;
            this.btnPhai3.Click += new System.EventHandler(this.btnSelectCam_Click);
            // 
            // btnTrai3
            // 
            this.btnTrai3.BackColor = System.Drawing.Color.Red;
            this.btnTrai3.ForeColor = System.Drawing.Color.Blue;
            this.btnTrai3.Location = new System.Drawing.Point(78, 157);
            this.btnTrai3.Name = "btnTrai3";
            this.btnTrai3.Size = new System.Drawing.Size(55, 36);
            this.btnTrai3.TabIndex = 10;
            this.btnTrai3.UseVisualStyleBackColor = false;
            this.btnTrai3.Click += new System.EventHandler(this.btnSelectCam_Click);
            // 
            // btnPhai2
            // 
            this.btnPhai2.BackColor = System.Drawing.Color.Red;
            this.btnPhai2.ForeColor = System.Drawing.Color.Blue;
            this.btnPhai2.Location = new System.Drawing.Point(200, 115);
            this.btnPhai2.Name = "btnPhai2";
            this.btnPhai2.Size = new System.Drawing.Size(55, 36);
            this.btnPhai2.TabIndex = 10;
            this.btnPhai2.UseVisualStyleBackColor = false;
            this.btnPhai2.Click += new System.EventHandler(this.btnSelectCam_Click);
            // 
            // btnTrai2
            // 
            this.btnTrai2.BackColor = System.Drawing.Color.Red;
            this.btnTrai2.ForeColor = System.Drawing.Color.Blue;
            this.btnTrai2.Location = new System.Drawing.Point(78, 115);
            this.btnTrai2.Name = "btnTrai2";
            this.btnTrai2.Size = new System.Drawing.Size(55, 36);
            this.btnTrai2.TabIndex = 10;
            this.btnTrai2.UseVisualStyleBackColor = false;
            this.btnTrai2.Click += new System.EventHandler(this.btnSelectCam_Click);
            // 
            // btnPhai1
            // 
            this.btnPhai1.BackColor = System.Drawing.Color.Red;
            this.btnPhai1.ForeColor = System.Drawing.Color.Blue;
            this.btnPhai1.Location = new System.Drawing.Point(202, 72);
            this.btnPhai1.Name = "btnPhai1";
            this.btnPhai1.Size = new System.Drawing.Size(55, 36);
            this.btnPhai1.TabIndex = 10;
            this.btnPhai1.UseVisualStyleBackColor = false;
            this.btnPhai1.Click += new System.EventHandler(this.btnSelectCam_Click);
            // 
            // btnTrai1
            // 
            this.btnTrai1.BackColor = System.Drawing.Color.Red;
            this.btnTrai1.ForeColor = System.Drawing.Color.Blue;
            this.btnTrai1.Location = new System.Drawing.Point(78, 73);
            this.btnTrai1.Name = "btnTrai1";
            this.btnTrai1.Size = new System.Drawing.Size(55, 36);
            this.btnTrai1.TabIndex = 10;
            this.btnTrai1.UseVisualStyleBackColor = false;
            this.btnTrai1.Click += new System.EventHandler(this.btnSelectCam_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(-341, -234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 190);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn Camera";
            // 
            // btnHide
            // 
            this.btnHide.ForeColor = System.Drawing.Color.Blue;
            this.btnHide.Location = new System.Drawing.Point(85, 428);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(121, 36);
            this.btnHide.TabIndex = 10;
            this.btnHide.Text = "Thoát";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // timerSendCamCtrl
            // 
            this.timerSendCamCtrl.Tick += new System.EventHandler(this.timerSendCamCtrl_Tick);
            // 
            // Zoom
            // 
            this.Zoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Zoom.LargeChange = 1;
            this.Zoom.Location = new System.Drawing.Point(14, 341);
            this.Zoom.Maximum = 700;
            this.Zoom.Minimum = 50;
            this.Zoom.Name = "Zoom";
            this.Zoom.Size = new System.Drawing.Size(259, 45);
            this.Zoom.TabIndex = 26;
            this.Zoom.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Zoom.Value = 50;
            this.Zoom.Scroll += new System.EventHandler(this.Zoom_Scroll);
            this.Zoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scroll_MouseDown);
            this.Zoom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Scroll_MouseUp);
            // 
            // timerSendCamZoom
            // 
            this.timerSendCamZoom.Tick += new System.EventHandler(this.timerSendCamZoom_Tick);
            // 
            // CameraControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 476);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CameraControl";
            this.ShowInTaskbar = false;
            this.Text = "Điều khiển Camera";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CameraControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMui1;
        private System.Windows.Forms.Button btnDuoi1;
        private System.Windows.Forms.Button btnMui2;
        private System.Windows.Forms.Button btnPhai3;
        private System.Windows.Forms.Button btnTrai3;
        private System.Windows.Forms.Button btnPhai2;
        private System.Windows.Forms.Button btnTrai2;
        private System.Windows.Forms.Button btnPhai1;
        private System.Windows.Forms.Button btnTrai1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.TrackBar UpDown;
        private System.Windows.Forms.TrackBar LeftRight;
        private System.Windows.Forms.Timer timerSendCamCtrl;
        private System.Windows.Forms.Label lblGocQuayDoc;
        private System.Windows.Forms.Label lblGocQuayNgang;
        private System.Windows.Forms.TrackBar Zoom;
        private System.Windows.Forms.Timer timerSendCamZoom;
    }
}