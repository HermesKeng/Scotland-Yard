using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Game_Client2._0
{
    public partial class Form1 : Form
    {
        private int player_ID;
        private int player_Sum=3;
        private Client client = new Client();
        private Thread data_listener;
        private delegate void callUI(String msg, Control unit);
        private delegate void Disable(Control unit,bool is_Open);
        private delegate void Visable(Control unit,bool is_Open);
        private void DisableUI(Control unit, bool is_Open)
        {
            if (this.InvokeRequired)
            {
                Disable cb = new Disable(DisableUI);
                this.Invoke(cb,unit,is_Open);
            }
            else
            {
                unit.Enabled = is_Open;
            }
        }
        private void VisableUI(Control unit,bool is_Open)
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
        private void UpdateUI(string value, Control unit)
        {
            if (this.InvokeRequired)
            {
                callUI cb = new callUI(UpdateUI);
                this.Invoke(cb, value, unit);
            }
            else
            {
                unit.Text += value;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            string IP_num;
            IP_num = textBox1.Text;
            client.Set_IP(IP_num);
            client.connect(this);
            textBox1.Visible = false;
            start_btn.Visible = false;
            player.Visible = true;
            data_listener = new Thread(listen);
            data_listener.Name = "data_listener";
            data_listener.Start();
            while (!data_listener.IsAlive) { }
        }
       
        private void listen()
        {
            string msg;
            msg = client.Read_Data();
            player_ID = Int32.Parse(msg[0].ToString());
            if (player_ID == 1)
            {
                UpdateUI("玩家" + player_ID + ": MR.X", player);
            }
            else
            {
                UpdateUI("玩家" + player_ID + ": Police", player);
            }
            msg = client.Read_Data();//所有玩家已經加入遊戲
            UpdateUI(msg, infobox);
            String[] decode_Msg=new String[2];
            while (true)
            {
                /*遊戲內容-Coding*/
                
                msg = client.Read_Data();
                int positon = 0, start = 0,index=0;
                do
                {
                    positon = msg.IndexOf(' ', start);
                    if (positon >= 0)
                    {
                        decode_Msg[index] = msg.Substring(start, positon - start + 1).Trim();
                        start = positon + 1;
                        index++;
                    }
                } while (positon > 0);
                /*檢驗是否遊戲結束*/
                if (Int32.Parse(decode_Msg[0]) == 1001)
                {
                    UpdateUI(decode_Msg[1]+"\n", infobox);
                    break;
                }
                else
                {
                    /*宣布回合開始*/
                    /*Each round what we should do*/
                    UpdateUI(decode_Msg[1], infobox);
                    /*第 i 號 要聽i-1次*/
                    for (int i = player_ID - 1; i > 0; i--)
                    {
                        msg = client.Read_Data();
                        UpdateUI(msg, infobox);
                    }
                    VisableUI(move, true);
                    msg = client.Read_Data();
                    if (Int32.Parse(msg[0].ToString()) != player_ID)
                    {
                        UpdateUI(msg, infobox);
                    }
                    VisableUI(move, false);
                    /*第 i 號 傳送後要聽player_Sum-i次*/
                    for (int i = player_Sum - player_ID; i > 0; i--)
                    {
                        msg = client.Read_Data();
                        UpdateUI(msg, infobox);
                    }
                    
                }
                /*遊戲內容-Coding*/
            }
        }
        private int round=1;
        private void move_Click(object sender, EventArgs e)
        {
            client.Send_Data(player_ID+" "+round+"\n");
            round++;
        }
    }
}
