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
// added by Phuong
using UsbHid;
using UsbHid.USB.Classes.Messaging;
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
    public partial class CameraControl : Form
    {
        bool bt1 = false, bt2 = false, bt3 = false,
              bt4 = false, bt5 = false, bt6 = false,
              bt7 = false, bt8 = false, bt9 = false,
             bt10 = false, bt11 = false, bt12 = false;
        internal Form1 _MainFrm;
        double camPan = 0, camTilt=0, camZoom=0;
        double camVpan = 0, camVtilt = 0;
        double joystick_sensitive = 0;
        UsbHidDevice Device;
        public CameraControl(Form1 MainFrm)
        {
            InitializeComponent();
            _MainFrm = MainFrm;
            Device = new UsbHidDevice(0x046D, 0xC215);
            Device.OnConnected += DeviceOnConnected;
            Device.OnDisConnected += DeviceOnDisConnected;
            Device.DataReceived += DeviceDataReceived;
            bool isConnect = Device.Connect();
            isConnect = isConnect;
        }

        private void DeviceDataReceived(byte[] data)
        {
            int newjy = (data[2] >> 2) | ((data[3] & 0x0f) << 6);
            camVtilt = (newjy - 512) / 8;// giá trị từ -64 đến 64
            int newjx = (data[1] | ((data[2] & 0x03) << 8));
            camVpan = (newjx - 512) / 8;// giá trị từ -64 đến 64
            joystick_sensitive = (255.0 - Convert.ToDouble(data[6])) / 255.0;// giá trị từ 0 đến 255
            int new_mArrow = data[3] >> 4;
            int buttons = (data[5] | (data[7]) << 8);
            bool newbt1 = ((buttons & 0x01) > 0);
            bool newbt2 = ((buttons & 0x02) > 0);
            bool newbt3 = ((buttons & 0x04) > 0);
            bool newbt4 = ((buttons & 0x08) > 0);
            bool newbt5 = ((buttons & 0x10) > 0);
            bool newbt6 = ((buttons & 0x20) > 0);
            bool newbt7 = ((buttons & 0x40) > 0);
            bool newbt8 = ((buttons & 0x80) > 0);
            bool newbt9 = ((buttons & 0x0100) > 0);
            bool newbt10 = ((buttons & 0x0200) > 0);
            bool newbt11 = ((buttons & 0x0400) > 0);
            bool newbt12 = ((buttons & 0x0800) > 0);
            if (bt3 != newbt3)
            {
                bt3 = newbt3;

                if (bt3)
                {
                    camZoom--;

                }



            }
            if (bt5 != newbt5)
            {
                bt5 = newbt5;

                if (bt5)
                {
                    camZoom++;

                }

            }
        }

        private void DeviceOnDisConnected()
        {
            //throw new NotImplementedException();
        }

        private void DeviceOnConnected()
        {
            //throw new NotImplementedException();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
            _MainFrm.Show();
        }

        private void CameraControl_Load(object sender, EventArgs e)
        {
            timerSendCamCtrl.Interval = 200;
            timerSendCamCtrl.Enabled = false;
            timerSendCamZoom.Interval = 200;
            timerSendCamZoom.Enabled = false;
        }


        string _strCam, _strIndex, _strLeftRight, _strUpDown, _strZoom;
        Button _curBtn = null;

        private void btnSelectCam_Click(object sender, EventArgs e)
        {
            if (_curBtn != null)
                _curBtn.BackColor = Color.Red;

            _curBtn = sender as Button;
            _curBtn.BackColor = Color.Green;
            string strBtnName = _curBtn.Name;

            if (strBtnName.Length == 8)
            {
                _strCam = strBtnName.Substring(3, 4);
                _strIndex = strBtnName.Substring(7, 1);
            }
            else if (strBtnName.Length == 7)
            {
                _strCam = strBtnName.Substring(3, 3);
                _strIndex = strBtnName.Substring(6, 1);
            }

            _strLeftRight = (LeftRight.Value / 10).ToString();
            _strUpDown = (UpDown.Value / 10).ToString();

            SendSelectCam(_strCam, _strIndex, _strLeftRight, _strUpDown);            
        }

        private void SendSelectCam(string strCam, string strIndex, string strLeftRight, string strUpDown)
        {
            Hashtable hashtable = new Hashtable();            
            hashtable["ObjectId"] =  _MainFrm.strShipId;
            hashtable["Cam"] = strCam;
            hashtable["Index"] = strIndex;
            hashtable["LeftRight"] = strLeftRight;
            hashtable["UpDown"] = strUpDown;

            SendData(hashtable, _MainFrm.PortRotateCamKhoang, _MainFrm.strIpAddr3D);
        }

        private void SendControlCam(string strCam, string strIndex, string strLeftRight, string strUpDown, string strZoom)
        {
            Hashtable hashtable = new Hashtable();            
            hashtable["Control"] = "Enable";
            //hashtable["Index"] = strIndex;
            hashtable["LeftRight"] = strLeftRight;
            hashtable["UpDown"] = strUpDown;
            hashtable["Zoom"] = strZoom;

            SendData(hashtable, 8888, _MainFrm.strIpAddr3D);
        }
        private void SendControlCam(double pan,double tilt,double zoom)
        {
            Hashtable hashtable = new Hashtable();
            hashtable["Control"] = "Enable";
            //hashtable["Index"] = strIndex;
            hashtable["LeftRight"] = pan.ToString();
            hashtable["UpDown"] = tilt.ToString();
            hashtable["Zoom"] = zoom.ToString();

            SendData(hashtable, 8888, _MainFrm.strIpAddr3D);
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
            catch (Exception) { }
        }

        private void LeftRight_Scroll(object sender, EventArgs e)
        {
            _strLeftRight = ((float)LeftRight.Value / 10).ToString();
            _strUpDown = "None";
            _strZoom = "None";
            lblGocQuayNgang.Text = _strLeftRight + " độ";
        }

        private void UpDown_Scroll(object sender, EventArgs e)
        {
            _strLeftRight = "None";
            _strZoom = "None";
            _strUpDown = ((float)UpDown.Value / 10).ToString();
            lblGocQuayDoc.Text = _strUpDown + " độ";
        }

        private void Zoom_Scroll(object sender, EventArgs e)
        {
            _strUpDown = "None";
            _strLeftRight = "None";
            _strZoom = ((float)Zoom.Value / 10).ToString();
        }
        
        private void timerSendCamCtrl_Tick(object sender, EventArgs e)
        {
            //SendControlCam(_strCam, _strIndex, _strLeftRight, _strUpDown, _strZoom);
            camPan += camVpan * joystick_sensitive / 255.0;
            camTilt += camVtilt * joystick_sensitive / 255.0;
            SendControlCam(camPan,camTilt,camZoom);
        }

        private void Scroll_MouseDown(object sender, MouseEventArgs e)
        {
            timerSendCamCtrl.Enabled = true;
        }

        private void Scroll_MouseUp(object sender, MouseEventArgs e)
        {
            timerSendCamCtrl.Enabled = false;
        }

        

        private void timerSendCamZoom_Tick(object sender, EventArgs e)
        {

        }

        
    }
}
