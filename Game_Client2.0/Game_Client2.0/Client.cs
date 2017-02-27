using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;
namespace Game_Client2._0
{
    class Client
    {
        private TcpClient myTcpClient;
        private NetworkStream myNetworkStream;
        private int Port=1101;
        private String IP;
        private Byte[] myByte;
        public void Set_IP(string ip_string)
        {
            IP = ip_string;
        }
        public void connect(Form1 mainpage)
        {
            myTcpClient = new TcpClient();
            try
            {
                myTcpClient.Connect(IP, Port);
                mainpage.infobox.Text = "成功連線\n";
                myNetworkStream = myTcpClient.GetStream();
            }
            catch
            {
                MessageBox.Show("連線失敗");
                Environment.Exit(0);
            }
        }
        public string Read_Data()
        {
            string rcv_msg = null;
            int datalength = myTcpClient.ReceiveBufferSize;
            try
            {
                myByte = new Byte[datalength];
                myNetworkStream.Read(myByte, 0, myByte.Length);
                myNetworkStream.Flush();
                rcv_msg = System.Text.Encoding.Unicode.GetString(myByte);
            }
            catch
            {
                Environment.Exit(0);
            }
            return rcv_msg;
        }
        public void Send_Data(string msg)
        {
            myByte = Encoding.Unicode.GetBytes(msg);
            myNetworkStream.Write(myByte, 0, myByte.Length);
            myNetworkStream.Flush();
            
        }
        public void DisConnect()
        {
            myNetworkStream.Close();
            myTcpClient.Close();
        }
    }
}
