﻿using System;
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
        int turn = 1;
        private Client client = new Client();
        private Thread data_listener;
        private Map map ;
        private String[] transportation = {"計程車","公車","地下鐵","萬用卡","兩步券"};
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
        private void AppendUI(string value, Control unit)
        {
            if (this.InvokeRequired)
            {
                callUI cb = new callUI(AppendUI);
                this.Invoke(cb, value, unit);
            }
            else
            {
                unit.Text += value;
            }
        }
        private void EditUI(string value, Control unit)
        {
            if (this.InvokeRequired)
            {
                callUI cb = new callUI(EditUI);
                this.Invoke(cb, value, unit);
            }
            else
            {
                unit.Text = value;
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
        //更新車票剩餘數量
        private void Renew_Ticket()
        {
            String msg;
            int Taxi_Ticket, Bus_Ticket, Double_Ticket, Train_Ticket, All_Ticket;
            Taxi_Ticket = map.GetTicket(player_ID, 0);
            Bus_Ticket = map.GetTicket(player_ID, 1);
            Train_Ticket = map.GetTicket(player_ID, 2);
            All_Ticket = map.GetTicket(player_ID, 3);
            Double_Ticket = map.GetTicket(player_ID, 4);
            msg = "目前還有：\n 計乘車票 " + Taxi_Ticket + " 張\n 公車票 " + Bus_Ticket + " 張\n 地鐵票 " + Train_Ticket + " 張\n";
            if (Double_Ticket != 0 && All_Ticket != 0||player_ID==1)
            {
                msg = msg + " 萬用票 " + All_Ticket + " 張\n 兩步券 " + Double_Ticket + " 張\n";
            }
            EditUI(msg, ticket);
            return ;
        }
        private void Game()
        {
            
            turn = 1;
            String msg;
            String[] moveData;
            map = new Map();
            //遊戲開始
            //遊戲配置-隨機分配開始位置
            msg = client.Read_Data();
            int positon = 0,start = 0,index=1;
            do
            {
                positon = msg.IndexOf(' ', start);
                if (positon >= 0)
                {
                    String temp;
                    temp = msg.Substring(start, positon - start + 1).Trim().ToString();
                    int pos = Int32.Parse(temp);
                    map.SetPos(index, pos, 0);
                    start = positon + 1;
                    index++;
                }
            } while (positon > 0);
            AppendUI("你的初始位置 " + map.GetPos(player_ID,0) + "\n", infobox);
            //設立車票數
            if (player_ID == 1)
            {
                Transport.Items.Add("萬用");
                Transport.Items.Add("兩步");
            }
            Renew_Ticket();
            //執行回合，輪流移動
            while (true)
            {
                msg = client.Read_Data();
                if (Int32.Parse(msg)==0)
                {
                    AppendUI("遊戲結束\n", infobox);
                    VisableUI(restart, true);
                    //所有Button消失並產生Button重新開始遊戲(未完成)
                    break;
                }
                else
                {
                    moveData = new String[3];
                    AppendUI("------第 " + turn + " 回合------\n", infobox);
                    
                    //等待Player_ID-1次的玩家移動
                    for (int i = player_ID - 1; i > 0; i--)
                    {
                        msg = client.Read_Data();
                       // AppendUI(msg, infobox);
                        moveData = Decoding(msg);
                        map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[2]),turn);//設定遊戲記錄表位置
                        map.DeductTicket(Int32.Parse(moveData[0]), Int32.Parse(moveData[1]));//使用車票須扣除
                        if(Int32.Parse(moveData[0]) == 1)
                        if ((turn == 3 || turn == 8 || turn == 13 || turn == 18))
                        {
                            AppendUI("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "移動至" + moveData[2] + "\n", infobox);
                        }
                        else
                        {
                            AppendUI("MR.X使用" + transportation[Int32.Parse(moveData[1])] +"\n", infobox);
                        }
                        //移動後判斷是否在同一個位置
                        if (is_SamePos(map.GetPos(1, turn), Int32.Parse(moveData[2])) && Int32.Parse(moveData[0])!=1)
                        {
                            MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                            //GameOver
                        }
                    }
                    
                    VisableUI(Transport, true);
                    VisableUI(textBox2, true);
                    VisableUI(move, true);
                    //顯示移動時產生的元件
                    msg = client.Read_Data();
                    moveData = Decoding(msg);
                    //判定是否抓到MR.X
                    if (is_SamePos(map.GetPos(1, turn), Int32.Parse(moveData[2])) && Int32.Parse(moveData[0]) != 1)
                    {
                        MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                        //GameOver
                    }
                    VisableUI(textBox2, false);
                    VisableUI(move, false);
                    VisableUI(Transport, false);
                    //關閉移動時產生的元件
                    //等待自己以後玩家移動
                    for (int i = player_Sum - player_ID; i > 0; i--)
                    {
                        msg = client.Read_Data();
                       // AppendUI(msg, infobox);
                        moveData = Decoding(msg);
                        map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[2]), turn);
                        map.DeductTicket(Int32.Parse(moveData[0]), Int32.Parse(moveData[1]));
                        if (player_ID == 1)
                        {
                            map.AddTicket(Int32.Parse(moveData[1]));//MR.X向其他玩家收取車票當其他人移動時
                            Renew_Ticket();
                        }
                        //移動後判斷是否在同一個位置
                        if (is_SamePos(map.GetPos(1, turn), Int32.Parse(moveData[2])) && Int32.Parse(moveData[0]) != 1)
                        {
                            MessageBox.Show("於 "+moveData[2]+" 找到MR.X，警察獲勝!");
                            //GameOver
                        }
                    }
                    //ShowInfo();
                    turn++;
                    if (turn == 24)
                    {
                        MessageBox.Show("MR.X獲勝，請現身!\n");
                    }
                }
            }
        }
        //遊戲按下START 後等待其他玩家入場
        private void listen()
        {
            string msg;
            msg = client.Read_Data();
            player_ID = Int32.Parse(msg[0].ToString());
            if (player_ID == 1)
            {
                AppendUI("玩家" + player_ID + ": MR.X", player);
            }
            else
            {
                AppendUI("玩家" + player_ID + ": Police", player);
            }
            msg = client.Read_Data();//所有玩家已經加入遊戲
            AppendUI(msg, infobox);
            Game();
        }
        //移動時點下"MOVE"所觸發的事件
        //流程：檢查Textbox中是否輸入非數字->檢查是否選擇交通方式和車票足夠->檢查是否相連->檢查是否在相同位置->移動
        //                                  
        private void move_Click(object sender, EventArgs e)
        {
            bool is_Number=true;
            int vertex;
            try
            {
                vertex = Int32.Parse(textBox2.Text.ToString());
            }
            catch
            {
                is_Number = false;
            }
            if (Transport.Text != "" && is_Number && map.CheckTicket(player_ID, Transport.SelectedIndex))
            {
                
                vertex=Int32.Parse(textBox2.Text.ToString());//欲前往位置
                int pos=map.GetPos(player_ID,turn-1);//現在位置

                if (map.is_ConnectingVertex(pos, vertex, Transport.SelectedIndex) )
                {
                    bool is_same = false;
                    for (int i = 2; i <= player_Sum; i++)
                    {
                        if (i < player_ID)
                        {
                            if (is_SamePos(map.GetPos(i, turn), vertex))
                            {
                                is_same = true;
                                MessageBox.Show("兩個角色不得在同一點\n");
                                break;
                            }
                            //比自己早動
                        }
                        else
                        {
                            if (is_SamePos(map.GetPos(i, turn-1), vertex))
                            {
                                is_same = true;
                                if (i == player_ID)
                                {
                                    MessageBox.Show("不得原地踏步\n");
                                }
                                else
                                {
                                    MessageBox.Show("兩個角色不得在同一點\n");
                                }
                                break;
                            }
                            //比自己晚動
                        }
                    }
                    if (!is_same)
                    {
                        DialogResult myResult = MessageBox.Show(player_ID + "請確認是否前往" + textBox2.Text + "\n", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (myResult == DialogResult.OK)
                        {
                            //更改現在位置並傳送資料給Server
                            map.SetPos(player_ID, vertex, turn);
                            String Msg = player_ID.ToString() + " " + Transport.SelectedIndex + " " + textBox2.Text + " \n";//Player Transportation position
                            map.DeductTicket(player_ID, Transport.SelectedIndex);
                            infobox.Text = infobox.Text + "你已移動到" + textBox2.Text + "\n";
                            Renew_Ticket();
                            client.Send_Data(Msg);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("請檢查是否相連或使用正確的交通方式\n");
                }
            }
            else
            {
                MessageBox.Show("請檢查是否發生下列錯誤：\n(1) 未輸入位置\n(2) 未選擇交通工具\n(3) 未輸入字元\n");
            }
            Transport.SelectedIndex = -1;
            textBox2.Text = "";
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //在遊戲過程中解析傳來的封包
        //------------------------------
        //| 玩家  | 交通方式 | 移動位置 |
        //------------------------------
        private String[] Decoding(String msg)
        {
            int positon = 0, start = 0, index = 0;
            String[] Data=new String[3];
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
        private void ShowInfo()
        {
            String msg = "";
            for (int i = 1; i <= player_Sum; i++)
            {
                msg = msg + "第" + i + "玩家在 " + map.GetPos(i,turn) + "\n";
            }
            //Debug 用
            MessageBox.Show(msg, "第" + turn + "回合結果");
        }
        //使用時機：
        //1.每一步動完後需要檢查是否和其他警察在同一地點
        //2.每次警察動完判定是否結束遊戲
        private bool is_SamePos(int A, int B)
        {
            if (A == B)
            {
                return true;
            }
            return false;
        }
        private void restart_Click(object sender, EventArgs e)
        {
            Game();
            restart.Visible = false;
        }

    }
}
