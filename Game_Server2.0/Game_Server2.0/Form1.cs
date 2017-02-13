using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace Game_Server2._0
{
    public partial class Form1 : Form
    {
        
        private TcpListener myTcpListener;
        private List<TcpClient> Client_List = new List<TcpClient>();
        private List<NetworkStream> ns_List = new List<NetworkStream>();
        private Byte[] myByte;
        private delegate void callbUI(String message, Control ctl);
        private void UpdateUI(string value, Control ctl)
        {
            if (this.InvokeRequired)
            {
                callbUI cb = new callbUI(UpdateUI);
                this.Invoke(cb, value, ctl);
            }
            else
            {
                ctl.Text += value;
            }
        }
        private int Player=3,counter=0;
        private void Set_Connect(){
            int Port = 1101;
            System.Net.IPAddress myIpAddress;
            myIpAddress = System.Net.IPAddress.IPv6Any;
            myTcpListener = new TcpListener(myIpAddress, Port);
            myTcpListener.Server.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);
            myTcpListener.Start();
        }
        private void Send_Data(int i,string msg)
        {
            myByte = Encoding.Unicode.GetBytes(msg);
            ns_List[i].Write(myByte, 0, myByte.Length);
        }
        private String Read_Data(int i)
        {
            string msg = null;
            int datalength = myTcpListener.Server.ReceiveBufferSize;
            myByte = new Byte[datalength];
            ns_List[i].Read(myByte, 0, myByte.Length);
            msg = System.Text.Encoding.Unicode.GetString(myByte);
            return msg;
        }
        public Form1()
        {
            InitializeComponent();
            
        }
        private void listen()
        {
            TcpClient client;
            NetworkStream ns;
            String msg=null;
        
            while (true)
            {
                if (counter <Player)
                {
                    client = default(TcpClient);
                    client = myTcpListener.AcceptTcpClient();
                    ns = client.GetStream();
                    ns_List.Add(ns);
                    Client_List.Add(client);
                    Send_Data(counter, + (counter + 1) + "號玩家歡迎加入，請等待其他玩家\n");
                    counter++;
                    msg=counter +"位玩家已加入，尚有"+(Player-counter)+"位\n";
                    UpdateUI(msg, infobox);
                    Thread.Sleep(100);
                }
                else
                {
                    for (int i = 0; i < Player; i++)
                    {
                        Send_Data(i, "所有玩家已經加入，遊戲開始\n");
                    }
                    break;
                }
            }

            int turn = 1;
            while(true){
                /*遊戲內容-Coding*/
                if (turn<=1)
                {
                    msg = "1000 ------第" + turn + "回合開始-------\n ";
                    for (int i = 0; i < Player; i++)
                    {
                        Send_Data(i, msg);
                        Thread.Sleep(100);
                    }
                    for (int i = 0; i < Player; i++)
                    {
                        msg = Read_Data(i);
                        for (int j = 0; j < Player; j++)
                        {
                            Send_Data(j, msg);
                            Thread.Sleep(100);
                        }
                        UpdateUI(msg, infobox);
                    }
                    turn++;
                }
                else {
                    msg = "1001 遊戲結束\n ";
                    for (int i = 0; i < Player; i++)
                    {
                        Send_Data(i, msg);
                        Thread.Sleep(100);
                    }
                }
                /*遊戲內容-Coding*/
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            Set_Connect();
            infobox.Text += "Server 已啟動\n";
            Thread listener = new Thread(listen);
            listener.IsBackground = true;
            listener.Start();
            while (!listener.IsAlive) { }
        }
        
    }
}
