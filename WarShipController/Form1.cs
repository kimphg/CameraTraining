using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

// Added by Thinq
using System.IO;
using System.IO.Ports;
using System.Xml;

using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WarShipController
{
    public partial class Form1 : Form
    {
        SerialPort P = new SerialPort(); // Khai báo 1 Object SerialPort mới.
        SerialPort P1 = new SerialPort(); // Khai báo 1 Object SerialPort mới.
        string InputData = String.Empty; // Khai báo string buff dùng cho hiển thị dữ liệu sau này.
        string InputStr = String.Empty; // Khai báo string buff dùng cho hiển thị dữ liệu sau này.
        delegate void SetTextCallback(string text); // Khai bao delegate SetTextCallBack voi tham so string 
        public Boolean thoat = true;
        string str = String.Empty;
        public int PortControlWarShip1 = 1111;  // HQ375
        public int PortControlWarShip2 = 1112;  // HQ376
        public int PortControlWarShip3 = 1113;  // HQ377
        public int PortControlTable = 1110;
        public string strIpAddr3D;
        public string strIpAddrControlTable;
        public string strShipId;
        public string strMinValue;
        public string strMaxValue;        
        public string strIsRemote;
        public string strComSel;
        public int PotentiometerValue = 0;      // Giá trị của chiết áp truyền về qua cổng COM
        public float _speedRotate = 0f;
        public float _sendSpeedRotate = 0f;

        public int maxValue;
        public int minValue;
        public int intervalValue;

        private static TcpListener m_tcpListener = null; // Phiên TCP lắng nghe cho lệnh điều khiển tàu
        private static Hashtable m_hashtable = null;
        internal Thread         m_threadStartListen;
        private bool isComOn = false;

        internal CameraControl m_CamController = null;
        // CamKhoang
        public int PortRotateCamKhoang = 30000;

        private bool lockSteeringWheel = false;

        public Form1()
        {
            InitializeComponent();           
            
            //Id Tàu
            string[] ShipId = { "HQ375", "HQ376", "HQ377" };
            cbShipId.Items.AddRange(ShipId);


            LoadInfor();
            // Cài đặt các thông số cho COM
            // Mảng string port để chứa tất cả các cổng COM đang có trên máy tính
            string[] ports = SerialPort.GetPortNames();

            if (ports.Length == 0)
            {
                return;
            }
            // Thêm toàn bộ các COM đã tìm được vào combox cbCom
            cbCom.Items.AddRange(ports); // Sử dụng AddRange thay vì dùng foreach            
            P.ReadTimeout = 1000;
            // Khai báo hàm delegate bằng phương thức DataReceived của Object SerialPort;
            // Cái này khi có sự kiện nhận dữ liệu sẽ nhảy đến phương thức DataReceive
            // Nếu ko hiểu đoạn này bạn có thể tìm hiểu về Delegate, còn ko cứ COPY . Ko cần quan tâm
            P.DataReceived += new SerialDataReceivedEventHandler(DataReceive);

            // Cài đặt cho BaudRate
            string[] BaudRate = {"9600", "14400", "19200", "38400", "57600", "115200", "128000"};
            //string[] BaudRate = { "115200"};
            cbRate.Items.AddRange(BaudRate);           
            

            // Cài đặt cho DataBits
            string[] Databits = { "5", "6", "7", "8" };
            //string[] Databits = { "8" };
            cbBits.Items.AddRange(Databits);            

            //Cho Parity
            string[] Parity = { "Even", "Odd", "None", "Mark", "Space" };
            //string[] Parity = { "None"};
            cbParity.Items.AddRange(Parity);            

            //Cho Stop bit
            string[] stopbit = { "1", "1.5", "2"};
            //string[] stopbit = { "1" };
            cbBit.Items.AddRange(stopbit);

            
            this.Show();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ClassStyle |= 0x200;
                return parms;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            
            timerSendCommand.Interval = 400;
            timerSendCommand.Enabled = true;

            timerStatus.Interval = 1000;
            timerStatus.Enabled = true;

            btNgat.Enabled = false;

            if (strShipId == "HQ375")
                cbShipId.SelectedIndex = 0;
            else if (strShipId == "HQ376")
                cbShipId.SelectedIndex = 1;
            else if (strShipId == "HQ377")
                cbShipId.SelectedIndex = 2;
            else
                cbShipId.SelectedIndex = 0;          

            

            //IP của máy 3D
            //strIpAddr = "192.168.1.80";
            txtIpAddress.Text = strIpAddr3D;
                        
            txtMaxValue.Text = strMaxValue;
            txtMinValue.Text = strMinValue;
            //Hiện thị Status cho Pro tí
            comStatus.Text = "Hãy chọn 1 cổng COM để kết nối.";

            CreateListener();
            btnStart.Enabled = true;

            //if (strIsRemote == "True")
            //{
            //    txtIpAddress.Enabled = false;
            //    btnStart.Enabled = false;
            //    CreateListener();
            //}                
            //else
            //    btnStart.Enabled = true;

            if (cbCom.Items.Count == 0)
            {
                //chkBoxControl.Checked = false;
                //chkBoxControl.Enabled = false;
                //tbTraiphai.Enabled = false;
                return;
            }
            int intComSel = int.Parse(strComSel);

            if (intComSel >= cbCom.Items.Count)
                cbCom.SelectedIndex = 0;
            else
                cbCom.SelectedIndex = intComSel;           
            cbRate.SelectedIndex = 5; // 115200
            cbBits.SelectedIndex = 3; // 8
            cbParity.SelectedIndex = 2; // None
            cbBit.SelectedIndex = 0; // None
        }



        long str2hex2(string buf)// BUF LA NGUYEN CHUOI NHAN DUOC
        {
            long k;
            char ch;
            buf = buf.ToUpper();
            ch = (buf[0]);
            if (ch > '9') k = ch - 'A' + 10; else k = ch - 0x30;
            ch = (buf[1]);
            if (ch > '9') k = 16 * k + ch - 'A' + 10; else k = 16 * k + ch - 0x30;
            ch = (buf[2]);
            if (ch > '9') k = 16 * k + ch - 'A' + 10; else k = 16 * k + ch - 0x30;
            ch = (buf[3]);
            if (ch > '9') k = 16 * k + ch - 'A' + 10; else k = 16 * k + ch - 0x30;
            return (k);
        }

        private bool _activeGetCommandData = true;
        private void GetCommandData()
        {
            //bool bAcceptd = true;
            while (_activeGetCommandData)
            {
                _activeGetCommandData = false;

                //if (!bAcceptd)
                //    continue;

                if (!m_tcpListener.Pending())
                {
                    _activeGetCommandData = true;
                    continue;
                }

                TcpClient tcpClient = m_tcpListener.AcceptTcpClient();
                if (!tcpClient.Connected)
                {
                    _activeGetCommandData = true;
                    continue;
                }

                //bAcceptd = false;

                object data = null;

                try
                {
                    NetworkStream strm = tcpClient.GetStream();
                    IFormatter formatter = new BinaryFormatter();
                    data = formatter.Deserialize(strm);
                    strm.Close();
                    tcpClient.Close();
                    
                }
                catch (Exception ex)
                {
                    _activeGetCommandData = true;
                    continue;
                }                

                m_hashtable = (Hashtable)data;

                if (data == null)
                {
                    _activeGetCommandData = true;
                    continue;
                }                     

                if (m_hashtable.Count == 2) // Mở/tắt máy
                {
                    if (!m_hashtable.ContainsKey("ObjectId"))
                    {
                        _activeGetCommandData = true;
                        continue;
                    }
                    if (m_hashtable["ObjectId"].ToString() != strShipId)
                    {
                        _activeGetCommandData = true;
                        continue;
                    }
                    if (!m_hashtable.ContainsKey("IsStart"))
                    {
                        _activeGetCommandData = true;
                        continue;
                    }

                    if (m_hashtable["IsStart"].ToString() == "Start")
                    {
                        if (!isComOn)
                            ConnectToCOM();
                        _isStart = true;                        

                    }

                    else if (m_hashtable["IsStart"].ToString() == "Stop")
                    {
                        _isStart = false;                        
                    }                        
                    
                    SendControlCommand(m_hashtable["IsStart"].ToString());
                }
                else if (m_hashtable.ContainsKey("Speed")) // Thay đổi tốc độ
                {                    
                    if (!m_hashtable.ContainsKey("ObjectId"))
                    {
                        _activeGetCommandData = true;
                        continue;
                    }
                    if (!m_hashtable.ContainsKey("UpDown"))
                    {
                        _activeGetCommandData = true;
                        continue;
                    }

                    tam = Int16.Parse(m_hashtable["Speed"].ToString());
                    
                    updown = m_hashtable["UpDown"].ToString();

                    if ((SetSteeringValue() == true) && (_isStart))
                    {
                        SetValueAndSendTo3D(tam * 0.514f, updown, leftright, speedRotate);
                    } 
                }

                else if (m_hashtable.ContainsKey("speedRotate")) // Thay đổi hướng
                {                    
                    if (!lockSteeringWheel)
                    {
                        _activeGetCommandData = true;
                        continue;
                    }
                    if (!m_hashtable.ContainsKey("ObjectId"))
                    {
                        _activeGetCommandData = true;
                        continue;
                    }
                    if (!m_hashtable.ContainsKey("leftright"))
                    {
                        _activeGetCommandData = true;
                        continue;
                    }

                    float tmpFloat = float.Parse(m_hashtable["speedRotate"].ToString());
                    tmpFloat = (float)Math.Round(tmpFloat, 1);
                    if (m_hashtable["leftright"].ToString() == "left")
                        _speedRotate = -tmpFloat;
                    else if (m_hashtable["leftright"].ToString() == "right")
                        _speedRotate = tmpFloat;
                    else
                        _speedRotate = 0;

                    tmpFloat = (tmpFloat * 7f);
                    SendSteeringValue(tmpFloat.ToString("####0.00"));
                }

                else if (m_hashtable.ContainsKey("Lock"))
                {
                    lockSteeringWheel = bool.Parse(m_hashtable["Lock"].ToString());                    
                }

                //bAcceptd = true;
                _activeGetCommandData = true;
                
            }
        }

        private void CreateListener()
        {
            // Create an instance of the TcpListener class.            
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                return;

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress localIP = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            
            try
            {                
                m_tcpListener = new TcpListener(localIP, 1980);
                m_tcpListener.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            m_threadStartListen = new Thread(new ThreadStart(GetCommandData));
            m_threadStartListen.Start();
        }

        private void DataReceive(object obj, SerialDataReceivedEventArgs e)
        {
            int ix;
            long adc1, adc2;
            try
            {
                InputData = P.ReadExisting();
                if (InputData != String.Empty)
                {
                    str = str + InputData;
                    if (str.Length >= 30)
                    {
                        ix = str.LastIndexOf("\r\n");
                        if (ix >= 29)
                        {
                            string s1 = str.Substring(ix - 30, 28);// 29 vi tri lay du lieu, do dai 31
                            adc1 = str2hex2(s1.Substring(0, 4));
                            adc1 = adc1 / 8;
                            adc2 = str2hex2(s1.Substring(4, 4));
                            adc2 = adc2 / 8;
                            str = str.Substring(ix + 2);
                            s1 = s1.Substring(8);
                            string s2 = Convert.ToString(adc2);
                            while (s2.Length < 4) s2 = "0" + s2;
                            s1 = s2 + s1;
                            s2 = Convert.ToString(adc1);
                            while (s2.Length < 4) s2 = "0" + s2;
                            s1 = s2 + s1;
                            SetText(s1);// s1 chứa khung dữ liệu đọc về.
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi nhận dữ liệu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void SetText(string text)
        {
            if (this.txtkq.InvokeRequired)
            {
                try
                {
                    SetTextCallback d = new SetTextCallback(SetText); // khởi tạo 1 delegate mới gọi đến SetText
                    this.Invoke(d, new object[] { text });
                }
                catch
                {

                }
            }
            else
            {
                this.txtkq.Text = text;
                ProcessString(text);
            }

        }

        private void ProcessString(string str)
        {
            //if (lockSteeringWheel)
            //    return;
            var strStrim = str;                
            var strCheckLeft = strStrim.Substring(8, 1);
            var strCheckRight = strStrim.Substring(13, 1);

            int OldPV = PotentiometerValue;
            
            if (strCheckLeft != "@")
                return;
            if (strCheckRight != ",")
                return;

            string strValue = strStrim.Substring(9, 4);

            try
            {
                PotentiometerValue = Int32.Parse(strValue);
            }
            catch (FormatException e)
            {
                PotentiometerValue = intervalValue/2;
            }

            PotentiometerValue = (int)(OldPV * 0.5f + PotentiometerValue * 0.5f);

            // Xu ly du lieu tu cong com
            if (PotentiometerValue > maxValue)
                PotentiometerValue = maxValue;
            if (PotentiometerValue < minValue)
                PotentiometerValue = minValue;
            //if ((PotentiometerValue <= (maxValue / 2 + 25)) && (PotentiometerValue >= (maxValue / 2 - 25)))
            //    PotentiometerValue = maxValue / 2;

            float floatRotate = ((float)(PotentiometerValue - minValue) / (intervalValue / 100)) - 50;
            float rounded = (float)(Math.Round((double)floatRotate, 0));
            rounded = rounded / 10;

            if (rounded > 5)
                rounded = 5;
            if (rounded < -5)
                rounded = -5;

            gocQuay = (rounded * 7);
            lblGocQuay.Text = gocQuay.ToString("####0.00") + " độ";
            if (!lockSteeringWheel)
            {
                _speedRotate = rounded;
                SendSteeringValue(gocQuay.ToString("####0.00"));
            }
                

            //if (Math.Abs(rounded - _speedRotate) > 0.1)
            //{                
            //    gocQuay = (rounded * 7);
            //    lblGocQuay.Text = gocQuay.ToString("####0.00") + " độ"; 
            //    SendSteeringValue(gocQuay.ToString("####0.00"));
            //    if (!lockSteeringWheel)
            //        _speedRotate = rounded;
            //}


            //if (PotentiometerValue > maxValue)
            //    PotentiometerValue = maxValue;
            //if ((PotentiometerValue <= (maxValue / 2 + 25)) && (PotentiometerValue >= (maxValue / 2 - 25)))
            //    PotentiometerValue = maxValue / 2;
            
            //float floatRotate = ((float)PotentiometerValue / (maxValue/10)) - 5;
            //float rounded = (float)(Math.Round((double)floatRotate, 2));            
            //if (Math.Abs(rounded - _speedRotate) >= 0.05)
            //{
            //    _speedRotate = rounded;
            //    if (SetSteeringValue() == true)
            //        SetValueAndSendTo3D(tam * 0.514, updown, leftright, speedRotate);
            //}
                
        }

        private bool SetSteeringValue()
        {
            if (_sendSpeedRotate == 0)
            {
                leftright = "";
                speedRotate = _sendSpeedRotate.ToString();
            }
            else if (_sendSpeedRotate > 0)
            {
                leftright = "right";
                speedRotate = _sendSpeedRotate.ToString();
            }
            else if (_sendSpeedRotate < 0)
            {
                leftright = "left";
                speedRotate = (-_sendSpeedRotate).ToString();
            }
            return true;
        }

        private void btNgat_Click(object sender, EventArgs e)
        {
            DisconnectFromCOM();
        }

        private void ConnectToCOM()
        {
            try
            {
                P.Open();
                //timer1.Enabled = true;
                btNgat.Enabled = true;
                btKetNoi.Enabled = false;

                cbCom.Enabled = false;
                cbRate.Enabled = false;
                cbBits.Enabled = false;
                cbParity.Enabled = false;
                cbBit.Enabled = false;
                txtMaxValue.Enabled = false;
                txtMinValue.Enabled = false;
                //timer1.Enabled = true;

                // Hiện thị Status
                comStatus.Text = "Đang kết nối với cổng " + cbCom.SelectedItem.ToString();
                comStatus.ForeColor = System.Drawing.Color.Green;
                intervalValue = (maxValue - minValue);
                isComOn = true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Không kết nối được! Xem lại thiết lập cổng COM.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DisconnectFromCOM()
        {
            P.Close();
            btKetNoi.Enabled = true;
            btNgat.Enabled = false;

            cbCom.Enabled = true;
            cbRate.Enabled = true;
            cbBits.Enabled = true;
            cbParity.Enabled = true;
            cbBit.Enabled = true;
            txtMaxValue.Enabled = true;
            txtMinValue.Enabled = true;
            // Hiện thị Status
            comStatus.Text = "Đã ngắt kết nối!";
            comStatus.ForeColor = System.Drawing.Color.Red;
            isComOn = false;
        }

        private void btKetNoi_Click(object sender, EventArgs e)
        {
            ConnectToCOM();
        }

        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close(); // Nếu đang mở Port thì phải đóng lại
            }
            P.PortName = cbCom.SelectedItem.ToString(); // Gán PortName bằng COM đã chọn 
        }

        private void cbRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.BaudRate = Convert.ToInt32(cbRate.Text);
        }

        private void cbBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            P.DataBits = Convert.ToInt32(cbBits.Text);
        }

        private void cbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            
            switch (cbParity.SelectedItem.ToString())
            {
                case "None":
                    P.Parity = Parity.None;
                    break;
                case "Even":
                    P.Parity = Parity.Even;
                    break;
                case "Mark":
                    P.Parity = Parity.Mark;
                    break;
                case "Odd":
                    P.Parity = Parity.Odd;
                    break;
                case "Space":
                    P.Parity = Parity.Space;
                    break;
            }
        }

        private void cbBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (P.IsOpen)
            {
                P.Close();
            }
            switch (cbBit.SelectedItem.ToString())
            {
                case "1":
                    P.StopBits = StopBits.One;
                    break;
                case "1.5":
                    P.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    P.StopBits = StopBits.Two;
                    break;
            }
        }

        private void txtIpAddress_TextChanged(object sender, EventArgs e)
        {
            strIpAddr3D = txtIpAddress.Text;
        }

        private void cbShipId_SelectedIndexChanged(object sender, EventArgs e)
        {
            strShipId = cbShipId.Text;
        }

        public static void SendData(Hashtable data, int port, string ipaddress)
        {
            var client = new TcpClient();

            try
            {
                var result = client.BeginConnect(ipaddress, port, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(0.1));
                if (!success)
                    return;

                //TcpClient client = new TcpClient(ipaddress, port); // have my connection established with a Tcp Server 
                //if (!client.Connected) return;
                IFormatter formatter = new BinaryFormatter(); // the formatter that will serialize my object on my stream 
                NetworkStream strm = client.GetStream(); // the stream 
                formatter.Serialize(strm, data); // the serialization process 
                strm.Close();
                client.Close();
            }
            catch (Exception) {
            }
        }

        private void SendControlCommand(string isStart)
        {
            Hashtable hashtable = new Hashtable();
            hashtable["ObjectController"] = "Manual";
            hashtable["X"] = "0";
            hashtable["Y"] = "0";
            hashtable["Z"] = "14.5";
            hashtable["Speed"] = "0";
            hashtable["IsRotate"] = false;
            hashtable["Action"] = "Stand";
            hashtable["IsStart"] = isStart;
            hashtable["ObjectId"] = strShipId; // added by Thinq - Thiết lập giá trị Object Id tạm thời để gửi sang 3D

            SendData(hashtable, PortControlWarShip1, strIpAddr3D);

            //if (strShipId == "HQ375")
            //    SendData(hashtable, PortControlWarShip1, strIpAddr3D);
            //else if (strShipId == "HQ376")
            //    SendData(hashtable, PortControlWarShip2, strIpAddr3D);
            //else if (strShipId == "HQ377")
            //    SendData(hashtable, PortControlWarShip3, strIpAddr3D);
        }

        private void SetValueAndSendTo3D(double speed, string statusUpDown, string statusLeftRight, string speedRotate)
        {
            Hashtable hashtable = new Hashtable();
            hashtable["UpDown"] = statusUpDown;
            hashtable["LeftRight"] = statusLeftRight;
            hashtable["SpeedRotate"] = speedRotate;
            hashtable["Speed"] = (speed / 10).ToString();
            hashtable["Action"] = "Move";
            hashtable["ObjectController"] = "Manual";
            hashtable["IsStart"] = "Start";
            hashtable["ObjectId"] = strShipId;

            SendData(hashtable, PortControlWarShip1, strIpAddr3D);

            //if (strShipId == "HQ375")
            //    SendData(hashtable, PortControlWarShip1, strIpAddr3D);
            //else if (strShipId == "HQ376")
            //    SendData(hashtable, PortControlWarShip2, strIpAddr3D);
            //else if (strShipId == "HQ377")
            //    SendData(hashtable, PortControlWarShip3, strIpAddr3D);
        }

        private bool _isStart = false;

       // private float _Angle = 270f;

        private void SendHashTableTest()
        {
            Hashtable hashtable = new Hashtable();
            hashtable["Cam"] = "Mui";
            hashtable["LeftRight"] = "180";
            hashtable["UpDown"] = "50";
            SendData(hashtable, 30000, "192.168.1.80");
        }
        private void btnStart_Click(object sender, EventArgs e)
        {            
            //SendHashTableTest();
            ////_Angle += 0.5f;
            //return;

            if (_isStart)
            {
                _isStart = false;
                btnStart.Text = "Start";
                tbTienlui.Enabled = false;
                tbTraiphai.Enabled = false;
                txtIpAddress.Enabled = true;
                cbShipId.Enabled = true;
                tbTienlui.Value = 0;
                tbTraiphai.Value = 0;                              
                SendControlCommand("Stop");

                // Đưa tất cả giá trị về 0 khi dừng tàu
                tam = 0;
                updown = "";
                leftright = "";
                speedRotate = "0";
                _speedRotate = 0f;
            }
            else
            {
                if (!isComOn)
                    ConnectToCOM();
                _isStart = true;
                btnStart.Text = "Stop";
                tbTienlui.Enabled = true;                
                tbTraiphai.Enabled = true;
                txtIpAddress.Enabled = false;
                cbShipId.Enabled = false;
                SendControlCommand("Start");
            }
        }

        internal int tam = 0;
        internal string updown = "";
        internal string leftright = "";
        internal string speedRotate = "0";
        internal float gocQuay = 0f;        
        

        

        private void txtMaxValue_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                int txtBoxNum = Int32.Parse(txtMaxValue.Text);
                if ((txtBoxNum < 1500) || (txtBoxNum > 4100))
                {
                    MessageBox.Show("Giá trị không hợp lệ! \n (1500 - 4100)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaxValue.Text = maxValue.ToString();
                    return;
                }
            }
            catch (Exception) 
            {
                txtMaxValue.Text = maxValue.ToString();
                return;
            }            

            maxValue = Int32.Parse(txtMaxValue.Text);
        }

        private void txtMinValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int txtBoxNum = Int32.Parse(txtMinValue.Text);
                if ((txtBoxNum < 0) || (txtBoxNum > 1000))
                {
                    MessageBox.Show("Giá trị không hợp lệ! \n (0 - 1000)", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMinValue.Text = minValue.ToString();
                    return;
                }
            }
            catch (Exception)
            {
                txtMinValue.Text = minValue.ToString();
                return;
            }

            minValue = Int32.Parse(txtMinValue.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var res = MessageBox.Show(this, "Bạn thực sự muốn thoát chương trình?", "ISI Ship Controller", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //if (res != DialogResult.Yes)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //try
            //{
            //    Environment.Exit(Environment.ExitCode);
            //    Application.ExitThread();
            //    Application.Exit();
            //}
            //catch (Exception ex)
            //{

            //}
        }


        private void LoadInfor()
        {
            string path = "Config.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode _config = doc.DocumentElement.GetElementsByTagName("Config")[0];
            if (_config != null)
            {
                strShipId = _config["ShipId"].InnerText;
                strIpAddr3D = _config["IpAddr3D"].InnerText;
                strMinValue = _config["MinValue"].InnerText;
                strMaxValue = _config["MaxValue"].InnerText;                
                strIsRemote = _config["IsRemote"].InnerText;
                strIpAddrControlTable = _config["IpCtrl"].InnerText;
                strComSel = _config["ComSel"].InnerText;
            }
        }

        private void SendSteeringValue(string strValue)
        {
            Hashtable hashtable = new Hashtable();
            hashtable["Steering"] = "Wheel";
            hashtable["Angle"] = strValue;
            SendData(hashtable, PortControlTable, strIpAddrControlTable);
        }

        private void MoveShipScrollUpDown(object sender, EventArgs e)
        {
            //Tien lui
            if (tbTienlui.Value > 0)
            {
                tam = (tbTienlui.Value / 10) * 5;
                updown = "up";
            }
            else if (tbTienlui.Value < 0)
            {
                tam = -(tbTienlui.Value / 10) * 5;
                updown = "down";
            }
            else if (tbTienlui.Value == 0)
            {
                tam = (tbTienlui.Value / 10) * 5;
                updown = "";
            }

            _speedRotate = tbTraiphai.Value / 10f;
            //Math.Round(_speedRotate, 1);

            // For testing:
            float _Goc = (tbTraiphai.Value / 10f) * 7f;
            //SendSteeringValue(_Goc.ToString("####0.00"));
            lblGocQuay.Text = _Goc.ToString("####0.00") + " độ";

        }

        private void MoveShipScrollLeftRight(object sender, EventArgs e)
        {
//             if (isComOn)
//                 return;

            //Trai phai
            //if (tbTraiphai.Value > 0)
            //{
            //    leftright = "right";
            //    speedRotate = (tbTraiphai.Value / 10).ToString();
            //}
            //else if (tbTraiphai.Value < 0)
            //{
            //    leftright = "left";
            //    speedRotate = (-tbTraiphai.Value / 10).ToString();
            //}
            //else if (tbTraiphai.Value == 0)
            //{
            //    leftright = "";
            //    speedRotate = tbTraiphai.Value.ToString();
            //}

            _speedRotate = tbTraiphai.Value / 10f;
            //Math.Round(_speedRotate, 1);

            // For testing:
            float _Goc = (tbTraiphai.Value / 10f) * 7f;
            //SendSteeringValue(_Goc.ToString("####0.00"));
            lblGocQuay.Text = _Goc.ToString("####0.00") + " độ";
        }

        private void timerSendCommand_Tick(object sender, EventArgs e)
        {
            if (_sendSpeedRotate == _speedRotate)
                return;

            _sendSpeedRotate = _speedRotate;
            //else if (_sendSpeedRotate < _speedRotate)
            //     _sendSpeedRotate += 0.1f;
            //else if (_sendSpeedRotate > _speedRotate)
            //    _sendSpeedRotate -= 0.1f;

            _sendSpeedRotate = (float)Math.Round(_sendSpeedRotate, 1);

            if ((SetSteeringValue() == true) && (_isStart))
            {
                SetValueAndSendTo3D(tam * 0.514f, updown, leftright, speedRotate);
                //float gocMuiTau = (_sendSpeedRotate * 7f);
                //lblMuiTau.Text = gocMuiTau.ToString("####0.00") + " độ";
            } 
            //SetValueAndSendTo3D(tam * 0.514, updown, leftright, speedRotate);            
        }

        private void tbScroll_MouseDown(object sender, MouseEventArgs e)
        {           
            //timerSendCommand.Enabled = true;
        }

        private void tbScroll_MouseUp(object sender, MouseEventArgs e)
        {
            if ((SetSteeringValue() == true) && (_isStart))
            {
                SetValueAndSendTo3D(tam * 0.514f, updown, leftright, speedRotate);
            } 
        }

        private void btnCamCtrl_Click(object sender, EventArgs e)
        {
            if (m_CamController == null)
            {
                m_CamController = new CameraControl(this);
                m_CamController.StartPosition = FormStartPosition.CenterParent;                
            }
            m_CamController.Show();
            this.Hide();
        }

        private void btnFire_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //var res = MessageBox.Show(this, "Bạn thực sự muốn thoát chương trình?", "ISI Ship Controller", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //if (res != DialogResult.Yes)
            //{
            //  //  e.Cancel = true;
            //    return;
            //}

            try
            {
                Environment.Exit(Environment.ExitCode);
                Application.ExitThread();
                Application.Exit();
            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Minimize to Tray App";
            //notifyIcon1.BalloonTipText = "You have successfully minimized your form.";

            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            if (lockSteeringWheel)
            {
                controllerStatus.Text = "Điền khiển bằng Vô lăng đã bị khóa!";
                controllerStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                controllerStatus.Text = "Điều khiển bằng Vô lăng đã được mở!";
                controllerStatus.ForeColor = System.Drawing.Color.Green;
            }

            if (_isStart)
            {
                startStopStatus.Text = "Máy đã được mở";
                startStopStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                startStopStatus.Text = "Máy chưa được mở";
                startStopStatus.ForeColor = System.Drawing.Color.Red;
            }
                
        }

    }
}
