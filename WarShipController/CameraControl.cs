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
        internal Form1 _MainFrm;

        public CameraControl(Form1 MainFrm)
        {
            InitializeComponent();
            _MainFrm = MainFrm;
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
            SendControlCam(_strCam, _strIndex, _strLeftRight, _strUpDown, _strZoom);
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
