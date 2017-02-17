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
        private Map map ;
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
        void myButton_Click(Object sender, System.EventArgs e)
        {
            MessageBox.Show("Click");
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
            map = new Map();
            msg = client.Read_Data();//所有玩家已經加入遊戲
            UpdateUI(msg, infobox);
            String[] decode_Msg = new String[2];
            String[] moveData = new String[2];
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
                        decode_Msg[index]=msg.Substring(start, positon - start + 1).Trim();
                        start = positon + 1;
                        index++;
                    }
                } while (positon > 0);
                
                /*檢驗是否遊戲結束*/
                if (Int32.Parse(decode_Msg[0]) == 1001)
                {
                    UpdateUI("遊戲結束\n", infobox);
                    break;
                }
                else
                {
                    /*宣布回合開始*/
                    /*Each round what we should do*/
                    UpdateUI("-------"+decode_Msg[1] + " 回合開始-------\n", infobox);
                    
                    if (Int32.Parse(decode_Msg[1]) == 1)
                    {
                        msg = client.Read_Data();
                        positon = 0;
                        start = 0; 
                        do
                        {
                            positon = msg.IndexOf(' ', start);
                            if (positon >= 0)
                            {
                                String temp;
                                temp=msg.Substring(start, positon - start + 1).Trim().ToString();
                                int pos = Int32.Parse(temp);
                                map.CreatePos(pos);
                                start = positon + 1;
                            }
                        } while (positon > 0);
                        UpdateUI("你的初始位置 " + map.get_position(player_ID)+"\n", infobox);
                        client.Send_Data("");
                    }
                    /*第 i 號 要聽i-1次*/
                    for (int i = player_ID - 1; i > 0; i--)
                    {
                        msg = client.Read_Data();
                        UpdateUI(msg, infobox);
                        moveData = Decoding(msg);
                        map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[1]));
                        //每次移動判斷是否在同一個位置--未完成

                    }
                    VisableUI(textBox2, true);
                    VisableUI(move, true);
                    //顯示移動時產生的元件
                    msg = client.Read_Data();
                    if (Int32.Parse(msg[0].ToString()) != player_ID)
                    {
                        UpdateUI(msg, infobox);
                    }
                    VisableUI(textBox2, false);
                    VisableUI(move, false);
                    //關閉移動時產生的元件
                    /*第 i 號 傳送後要聽player_Sum-i次*/
                    for (int i = player_Sum - player_ID; i > 0; i--)
                    {
                        msg = client.Read_Data();
                        UpdateUI(msg, infobox);
                        moveData = Decoding(msg);
                        map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[1]));
                        //每次移動判斷是否在同一個位置--未完成
                    }
                    
                }
                ShowInfo(decode_Msg[1]);
                /*遊戲內容-Coding*/
            }
        }
        private void move_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null)
            {
                int vertex=Int32.Parse(textBox2.Text.ToString());//欲前往位置
                int pos=map.get_position(player_ID);//現在位置
                if(map.is_ConnectingVertex(pos,vertex)){
                    DialogResult myResult=MessageBox.Show(player_ID + "請確認是否前往" + textBox2.Text + "\n"," ", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                    if (myResult == DialogResult.OK)
                    {
                        //更改現在位置並傳送資料給Server
                        map.SetPos(player_ID, vertex);
                        String Msg = player_ID.ToString() + " " + textBox2.Text + "\n ";
                        client.Send_Data(Msg);
                        
                    }
                }
                else
                {
                    MessageBox.Show("請檢查是否相連 !\n");
                }
            }
            else
            {
                MessageBox.Show("請輸入位置 !\n");
            }
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private String[] Decoding(String msg)
        {
            int positon = 0, start = 0, index = 0;
            String[] Data=new String[2];
            do
            {
                positon = msg.IndexOf(' ', start);
                if (positon >= 0)
                {
                    Data[index] = msg.Substring(start, positon - start + 1).Trim();
                    start = positon + 1;
                    index++;
                }
            } while (positon > 0);
            return Data;
        }
        private void ShowInfo(String round)
        {
            String msg = "";
            for (int i = 1; i <= player_Sum; i++)
            {
                msg = msg + "第" + i + "玩家在 " + map.get_position(i) + "\n";
            }
            //Debug 用
            MessageBox.Show(msg, "第" + round+ "回合結果");
        }
    }
}
