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
        private delegate void Visable(Control unit, bool is_Open);
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
        private void VisableUI(Control unit, bool is_Open)
        {
            if (this.InvokeRequired)
            {
                Visable cb = new Visable(VisableUI);
                this.Invoke(cb, unit, is_Open);
            }
            else
            {
                unit.Visible = is_Open;
            }
        }
        private int Player=5,counter=0;
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
        private void Broadcast_Data(string msg)
        {
            myByte = Encoding.Unicode.GetBytes(msg);
            for (int i = 0; i < Player; i++)
            {
                ns_List[i].Write(myByte, 0, myByte.Length);
                Thread.Sleep(100);
            }
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
        private void Game_Manager()
        {
            int[] initial_Point = { 13,16,26,29,34,50,
                                    53,94,103,112,117,132,
                                    138,141,155,174,197,198 };
            List<int> start_Point = new List<int>();
            String msg = null;
            int count = 0,turn=1;
            while (count < Player)
            {
                Random ranNum = new Random();
                int temp = ranNum.Next(18);
                Thread.Sleep(100);
                if (!start_Point.Contains(initial_Point[temp]))
                {
                    start_Point.Add(initial_Point[temp]);
                    count++;
                }
            }
            for (int j = 0; j < start_Point.Count; j++)
            {
                msg = msg + start_Point[j] + " ";
            }
            Broadcast_Data(msg);
            
            //執行回合，輪流移動
            while (true)
            {
                if (turn >= 24)
                {
                    //結束遊戲
                    msg = "0";
                    Broadcast_Data(msg);
                    Thread.Sleep(100);
                    Disconnect();
                    VisableUI(restart,true);
                    break;
                }
                else
                {
                    //繼續移動
                    msg = "1";
                    Broadcast_Data(msg);
                    //依序聆聽每位玩家移動--傳送表格 Player Transportation Postition
                    for (int i = 0; i < Player; i++)
                    {
                        msg = Read_Data(i);
                        Broadcast_Data(msg);
                        UpdateUI(msg, infobox);
                        if (msg[2] == '4')
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                msg = Read_Data(i);
                                Broadcast_Data(msg);
                                UpdateUI(msg, infobox);
                            }
                        }
                        else if (msg == "0000")
                        {
                            Disconnect();
                            VisableUI(start, true);
                            return;
                        }
                        
                    }
                    turn++;
                }
                
            }
            //結束遊戲時聆聽所有人按重新開始
        }
        private void listen()
        {
            TcpClient client;
            NetworkStream ns;
            String msg=null;
            counter = 0;
            msg = "等待玩家加入\n";
            UpdateUI(msg, infobox);
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
                    Broadcast_Data("所有玩家已經加入，遊戲開始\n");
                    break;
                }
            }
            //-----遊戲開始-----//
            Game_Manager();
        }
        private void Disconnect()
        {
            for (int i = 0; i < ns_List.Count; i++)
            {
                ns_List[i].Close();
            }
                ns_List.Clear();
                UpdateUI("結束連線", infobox);
        }
        private void start_Click(object sender, EventArgs e)
        {
            Set_Connect();
            infobox.Text += "Server 已啟動\n";
            Thread listener = new Thread(listen);
            listener.IsBackground = true;
            listener.Start();
            while (!listener.IsAlive) { }
            start.Visible = false;
        }

        private void restart_Click(object sender, EventArgs e)
        {
            Thread listener = new Thread(listen);
            listener.IsBackground = true;
            listener.Start();
            while (!listener.IsAlive) { }
            restart.Visible = false;
        }
        
    }
}
