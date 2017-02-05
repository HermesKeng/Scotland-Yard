using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
namespace Game_Client
{
    
    class Client
    {
        private TcpClient myTcpClient;
        private NetworkStream myNetworkStream;
        private int Port = 1101;
        private string IP;
        private Byte[] myByte;

        public void connect(Form1 mainpage){


            myTcpClient = new TcpClient();
            try
            {
                myTcpClient.Connect(IP, Port);
                mainpage.label1.Text = "connecting server...";
                myNetworkStream = myTcpClient.GetStream();
            }
            catch
            {
                MessageBox.Show("Connecting fail");
                Environment.Exit(0);
            }
        }
        public void Set_Ip(string ip_string)
        {
            IP = ip_string;
        }
    }
}
