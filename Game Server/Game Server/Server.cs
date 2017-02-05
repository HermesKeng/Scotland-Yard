using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace Game_Server
{
    class Server
    {
        private static int Port=1101;
        private TcpListener myTcpListener;
        private NetworkStream myNetworkStream;
        private Byte[] myByte;
        private void Set_Connect()
        {
            System.Net.IPAddress MyIPaddress;
            MyIPaddress = System.Net.IPAddress.IPv6Any;
            myTcpListener = new TcpListener(MyIPaddress, Port);
            myTcpListener.Server.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            myTcpListener.Start();
        }
        public void Start(Form1 main)
        {
            String str = "等待Client連線\n";
            Set_Connect();
            main.infobox.Text += str;  
        }
        public TcpClient Wait_Client(Form1 main,TcpClient client)
        {
            client = default(TcpClient);
            client = myTcpListener.AcceptTcpClient();
           // main.infobox.Text += "Accept connection from client\n";
            myNetworkStream = client.GetStream();
            return client;
        }
    }
}
