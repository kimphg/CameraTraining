using System;
using System.Collections;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

namespace CameraTraining
{
    public partial class Form1 : Form
    {
        bool bt1 = false, bt2 = false, bt3 = false,
             bt4 = false, bt5 = false, bt6 = false,
             bt7 = false, bt8 = false, bt9 = false,
            bt10 = false, bt11 = false, bt12 = false;
        internal Form1 _MainFrm;
        bool dataChanged = false;
        double camPan = 0, camTilt = 0, camZoom = 10;
        double camVpan = 0, camVtilt = 0;
        double joystick_sensitive = 0;
        UsbHidDevice Device;

        public Form1()
        {
            InitializeComponent();
            Device = new UsbHidDevice(0x046D, 0xC215);
            Device.OnConnected += DeviceOnConnected;
            Device.OnDisConnected += DeviceOnDisConnected;
            Device.DataReceived += DeviceDataReceived;
            bool isConnect = Device.Connect();
            
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
                    if (camZoom < 60) camZoom += 5;
                    dataChanged = true;

                }

            }
            if (bt5 != newbt5)
            {
                bt5 = newbt5;

                if (bt5)
                {
                    if (camZoom > 5) camZoom -= 5;
                    dataChanged = true;
                }

            }
        }

        private void DeviceOnDisConnected()
        {
            //MessageBox.Show("Joystick disconnected");
        }

        private void DeviceOnConnected()
        {
            //MessageBox.Show("Joystick connected");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            
        }
        //bool sending = false;
        void sendUDPControl(double pan, double tilt, double zoom)
        {
            
            string str = pan.ToString() + ";" + tilt.ToString() + ";" + zoom.ToString()+";";
            byte[] data = Encoding.ASCII.GetBytes(str);
            var client = new UdpClient();
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(textBox1.Text), 8888); // endpoint where server is listening (testing localy)
            client.Connect(ep); 

            // send data
            client.Send(data,data.Length);

        }
        private void SendControlCam(double pan, double tilt, double zoom)
        {
            Hashtable hashtable = new Hashtable();
            hashtable["Control"] = "Enable";
            //hashtable["Index"] = strIndex;
            hashtable["LeftRight"] = "20";//pan.ToString();
            hashtable["UpDown"] = "None";//tilt.ToString();
            hashtable["Zoom"] = "None";//zoom.ToString();

            SendData(hashtable, 8888,textBox1.Text);
        }
        public static void SendData(Hashtable data, int port, string ipaddress)
        {
            var client = new TcpClient();
            //sending = true;
            try
            {
                //IPEndPoint clientep = new IPEndPoint(IPAddress.Parse(ipaddress), 11000); // endpoint where server is listening (testing localy)
                //client.Connect(clientep); 
                var result = client.BeginConnect(ipaddress, port, null, null);
                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(0.02));
                

                //TcpClient client = new TcpClient(ipaddress, port); // have my connection established with a Tcp Server 
                //if (!client.Connected) return;
                IFormatter formatter = new BinaryFormatter(); // the formatter that will serialize my object on my stream 
                NetworkStream strm = client.GetStream(); // the stream 
                formatter.Serialize(strm, data); // the serialization process 
                strm.Close();
                client.Close();
                //sending = false;
            }
            catch (Exception) {
                return;

            }
        }
        double curCamZoom = 120;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //SendControlCam(_strCam, _strIndex, _strLeftRight, _strUpDown, _strZoom);

            
            if (Math.Abs(camVpan) > 10 || Math.Abs(camVtilt) > 10) dataChanged = true;
            if (dataChanged)
            {
                curCamZoom += (camZoom - curCamZoom) / 3.0;
                camPan += camVpan * joystick_sensitive / 100.0 * curCamZoom;
                if (camPan >= 360.0) camPan -= 360.0;
                if (camPan < 0.0) camPan += 360.0;
                camTilt += camVtilt * joystick_sensitive / 100.0 * curCamZoom;
                if (camTilt >= 90) camTilt = 90.0;
                if (camTilt < -90) camTilt =-90.0;
                sendUDPControl(camPan, camTilt, camZoom);
            }
            dataChanged = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataChanged = true;
        }
    }
}
