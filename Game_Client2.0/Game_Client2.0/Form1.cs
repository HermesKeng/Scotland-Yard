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
        private PictureBox[] figure=new PictureBox[5];
        private int player_Sum=3;
        private bool isTwoStep = false;
        int turn = 0;
        private Client client = new Client();
        private Thread data_listener;
        private Map map ;
        private String[] transportation = {"計程車","公車","地下鐵","萬用卡","兩步券"};
        //Thread控制UI用
        private delegate void callUI(String msg, Control unit);
        private delegate void Disable(Control unit,bool is_Open);
        private delegate void Visable(Control unit,bool is_Open);
        private delegate void setPos(Point new_pos, Control unit);
        private delegate void setFig(Control unit);
        private delegate void setRichTextBox(String msg, RichTextBox rtb);
        private void SetInfoBox(String value, RichTextBox rtb)
        {
            if (this.InvokeRequired)
            {
                setRichTextBox cb = new setRichTextBox(SetInfoBox);
                this.Invoke(cb, value,rtb);
            }
            else
            {
                rtb.Text += value;
                try
                {
                    rtb.SelectionStart = rtb.Text.Length;
                }
                catch
                {

                }
                rtb.ScrollToCaret();
            }
        }
        private void MoveUI(Control unit)
        {
            if (this.InvokeRequired)
            {
                setFig cb = new setFig(MoveUI);
                this.Invoke(cb, unit);
            }
            else
            {
                unit.SendToBack();
            }
        }
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
        private void moveFig(Point new_pos, Control unit)
        {
            if (this.InvokeRequired)
            {
                setPos cb = new setPos(moveFig);
                this.Invoke(cb,  new_pos,unit);
            }
            else
            {
                unit.Location = new_pos;
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
            ini_Figure(); 
        }
        private void start_btn_Click(object sender, EventArgs e)
        {
            string IP_num;
            IP_num = textBox1.Text;//Get IP position
            client.Set_IP(IP_num);
            client.connect(this);
            Login.Visible = false;
            Player_Text.Visible = true;
            game_panel.Visible = true;
            Move_Panel.Visible = true;
            data_listener = new Thread(listen);
            data_listener.Name = "data_listener";
            data_listener.Start();
            while (!data_listener.IsAlive) { }
        }
        private void Ini_SetUp()
        {
            String msg;
            turn =22;
            map = new Map();
            //遊戲開始
            //遊戲配置-隨機分配開始位置
            msg = client.Read_Data();
            int positon = 0, start = 0, index = 1;
            do
            {
                positon = msg.IndexOf(' ', start);
                if (positon >= 0)
                {
                    String temp;
                    temp = msg.Substring(start, positon - start + 1).Trim().ToString();
                    int pos = Int32.Parse(temp);
                    map.SetPos(index, pos, turn - 1);
                    start = positon + 1;
                    index++;
                }
            } while (positon > 0);

            for (int i = 1; i <= player_Sum; i++) {
                if (i == player_ID)
                {
                    SetInfoBox("你的初始位置 " + map.GetPos(player_ID, turn - 1) + "\n", infobox);
                }
                else
                {
                    if (i != 1)
                    {
                        SetInfoBox("玩家 "+i +"的初始位置 "+ map.GetPos(i, turn - 1) + "\n", infobox);
                    }
                }
            }
            MessageBox.Show("你的初始位置 " + map.GetPos(player_ID, turn - 1) + "\n");
            //設立棋子位置
            int point = map.GetPos(player_ID, turn - 1);
            if (player_ID == 1)
            {
                VisableUI(figure[player_ID - 1], true);
                SetFigure(point, player_ID);
            }
            for (int i = 2; i <= player_Sum; i++)
            {
                point = map.GetPos(i, turn - 1);
                VisableUI(figure[i - 1], true);
                SetFigure(point, i);
            }
            //設立車票數
            if (player_ID == 1)
            {
                Transport.Items.Add("萬用");
                Transport.Items.Add("兩步");
            }
            Renew_Ticket();
        }
        private bool is_ShowPos()
        {
            if (turn == 3 || turn == 8 || turn == 13 || turn == 18)
            {
                if (player_ID == 1)
                {
                    MessageBox.Show("本回合你的位置將被公佈\n");
                }
                else
                {
                    MessageBox.Show("本回合MR.X的位置將被公佈");
                }
                return true;
            }
            return false;
        }
        
        private void Game()
        {
            Ini_SetUp();
            String msg;
            String[] moveData;
            bool is_GameOver = false;
            bool is_Special = false;
            //執行回合，輪流移動
            while (true)
            {
                msg = client.Read_Data();
                is_Special = is_ShowPos();
                if (Int32.Parse(msg) == 0)//24回合
                {
                    client.DisConnect();
                    MessageBox.Show("MR.X獲勝，請現身!\n");
                    SetInfoBox("遊戲結束\n", infobox);
                    GameOver();
                    VisableUI(ResultPic_Theft, true);
                    VisableUI(Close, true);
                    return;
                }
                else//非24回合
                {
                    moveData = new String[3];
                    SetInfoBox("------第 " + turn + " 回合------\n", infobox);
                   
                    //等別人動
                    for (int i = player_ID - 1; i > 0; i--)
                    {
                        moveData = Decoding();
                        if (Int32.Parse(moveData[0]) == 1&&moveData!=null)
                        {
                            //Mr.X進行移動的設定
                            if (Int32.Parse(moveData[1]) == 4)//使用兩步券
                            {
                                SetInfoBox("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "\n", infobox);
                                map.DeductTicket(Int32.Parse(moveData[0]), Int32.Parse(moveData[1]));
                                //連續動兩回合
                                for (int j = 0; j < 2; j++)
                                {
                                    
                                    moveData = Decoding();
                                    map.DeductTicket(Int32.Parse(moveData[0]), Int32.Parse(moveData[1]));
                                    if (is_Special)
                                    {
                                        is_Special = false;
                                        SetInfoBox("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "移動至" + moveData[2] + "\n", infobox);
                                        map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[2]), turn);
                                        SetFigure(Int32.Parse(moveData[2]), Int32.Parse(moveData[0]));
                                        VisableUI(figure[0], true);
                                    }
                                    else
                                    {
                                        SetInfoBox("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "\n", infobox);
                                        map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[2]), turn);
                                        VisableUI(figure[0], false);
                                    }
                                    if (j == 0)
                                    {
                                        for (int l = 2; l <= player_Sum; l++)
                                        {
                                            map.SetPos(l, map.GetPos(l, turn - 1), turn);//設定遊戲記錄表位置
                                        }
                                        turn++;
                                        SetInfoBox("------第 " + turn + " 回合------\n", infobox);
                                        is_Special = is_ShowPos();
                                        
                                    }
                                    msg = client.Read_Data();
                                    if (Int32.Parse(msg) == 1000)
                                    {
                                        MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                                        VisableUI(ResultPic_Police, true);
                                        VisableUI(Close, true);
                                        GameOver();
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                //非使用兩步券
                                if (is_Special)
                                {
                                    is_Special = false;
                                    SetInfoBox("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "移動至" + moveData[2] + "\n", infobox);
                                    SetFigure(Int32.Parse(moveData[2]), Int32.Parse(moveData[0]));
                                    VisableUI(figure[0], true);
                                }
                                else
                                {
                                    SetInfoBox("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "\n", infobox);     
                                    VisableUI(figure[0], false);
                                }
                                map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[2]), turn);
                                //判定是否相同地方

                                msg = client.Read_Data();
                                if (Int32.Parse(msg) == 1000)
                                {
                                    MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                                    VisableUI(ResultPic_Police, true);
                                    VisableUI(Close, true);
                                    GameOver();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            //其餘角色進行移動
                            map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[2]), turn);
                            map.DeductTicket(Int32.Parse(moveData[0]), Int32.Parse(moveData[1]));
                            map.AddTicket(Int32.Parse(moveData[1]));
                            SetFigure(Int32.Parse(moveData[2]), Int32.Parse(moveData[0]));
                            SetInfoBox("玩家 " + Int32.Parse(moveData[0]) + "移動到 " + Int32.Parse(moveData[2]) + "\n", infobox);
                            //判定是否相同地方

                            msg = client.Read_Data();
                            if (Int32.Parse(msg) == 1000)
                            {
                                MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                                VisableUI(ResultPic_Police, true);
                                VisableUI(Close, true);
                                GameOver();
                                return;
                            }
                        }
                    }

                    //自己動
                    VisableUI(Input_Panel, true);
                    moveData = Decoding();
                    if (Int32.Parse(moveData[0]) == 1)
                    {
                        if (moveData[1] == "4")
                        {
                            isTwoStep = true;
                            EditUI("請輸入第一步\n", Input_TextBox);
                            VisableUI(Input_Panel, true);
                            moveData = Decoding();
                            for (int l = 2; l <= player_Sum; l++)
                            {
                                map.SetPos(l, map.GetPos(l, turn - 1), turn);//設定遊戲記錄表位置
                            }
                            for (int i = 2; i <= player_Sum; i++)
                            {
                                if (is_SamePos(map.GetPos(i, turn - 1), Int32.Parse(moveData[2])))
                                {

                                    is_GameOver = true;
                                }
                            }
                            if (is_GameOver)
                            {
                                MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                                client.Send_Data("1000");
                                client.Read_Data();
                                VisableUI(ResultPic_Police, true);
                                VisableUI(Close, true);
                                GameOver();
                                return;
                            }
                            else
                            {
                                client.Send_Data("11");
                                client.Read_Data();
                            }
                            turn++;
                            SetInfoBox("------第 " + turn + " 回合------\n", infobox);
                            EditUI("請輸入第二步\n", Input_TextBox);
                            VisableUI(Input_Panel, true);
                            moveData = Decoding();
                            for (int i = 2; i <= player_Sum; i++)
                            {
                                if (is_SamePos(map.GetPos(i, turn - 1), Int32.Parse(moveData[2])))
                                {

                                    is_GameOver = true;
                                }
                            }
                            if (is_GameOver)
                            {
                                MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                                client.Send_Data("1000");
                                client.Read_Data();
                                VisableUI(ResultPic_Police, true);
                                VisableUI(Close, true);
                                GameOver();
                                return;
                            }
                            else
                            {
                                client.Send_Data("11");
                                client.Read_Data();
                            }
                            isTwoStep = false;

                        }
                        else
                        {
                            
                            for (int i = 2; i <= player_Sum; i++)
                            {
                                if (is_SamePos(map.GetPos(i, turn-1), Int32.Parse(moveData[2])))
                                {

                                    is_GameOver=true;
                                }
                            }
                            if(is_GameOver){
                                    MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                                    client.Send_Data("1000");
                                    client.Read_Data();
                                    VisableUI(ResultPic_Police, true);
                                    VisableUI(Close, true);
                                    GameOver();
                                    return;
                            }
                            else
                            {
                                client.Send_Data("11");
                                client.Read_Data();
                            }
                        }
                    }
                    else
                    {
                        
                        if (is_SamePos(map.GetPos(1, turn), Int32.Parse(moveData[2])) && Int32.Parse(moveData[0]) != 1)
                        {       //判定是否抓到MR.X

                            MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                            client.Send_Data("1000");
                            client.Read_Data();
                            VisableUI(ResultPic_Police, true);
                            VisableUI(Close, true);
                            GameOver();

                            return;
                            //GameOver

                        }
                        else
                        {
                            client.Send_Data("11");
                            client.Read_Data();
                        }
                    }
                   
                    
                    
                   
                    //等別人動
                    for (int i = player_Sum-player_ID; i > 0; i--)
                    {
                        moveData = Decoding();
                        if (moveData != null)
                        {
                            map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[2]), turn);
                            map.DeductTicket(Int32.Parse(moveData[0]), Int32.Parse(moveData[1]));
                            map.AddTicket(Int32.Parse(moveData[1]));
                            SetFigure(Int32.Parse(moveData[2]), Int32.Parse(moveData[0]));
                            SetInfoBox("玩家 " + Int32.Parse(moveData[0]) + "移動到 " + Int32.Parse(moveData[2]) + "\n", infobox);
                            //判定是否相同地方
                            msg = client.Read_Data();
                            if (Int32.Parse(msg) == 1000)
                            {
                                MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                                VisableUI(ResultPic_Police, true);
                                VisableUI(Close, true);
                                GameOver();
                                return;
                            }
                        }
                    }
                }
                turn++;
            }
        }
        /*private void Game()
        {
            Ini_SetUp();
            
            String msg;
            String[] moveData;
           
            //執行回合，輪流移動
            while (true)
            {
                msg = client.Read_Data();
                if (Int32.Parse(msg)==0)
                {
                    client.DisConnect();
                    MessageBox.Show("MR.X獲勝，請現身!\n");
                    SetInfoBox("遊戲結束\n", infobox);
                    VisableUI(Close, true);
                    //所有Button消失並產生Button重新開始遊戲(未完成)
                    break;
                }
                else
                {
                    moveData = new String[3];
                    SetInfoBox("------第 " + turn + " 回合------\n", infobox);
                    if (turn == 3 || turn == 8 || turn == 13 || turn == 18)
                    {
                        if (player_ID == 1)
                        {
                            MessageBox.Show("本回合你的位置將被公佈\n");
                        }
                        else
                        {
                            MessageBox.Show("本回合MR.X的位置將被公佈");
                        }
                    }
                    //等待Player_ID-1次的玩家移動
                    for (int i = player_ID - 1; i > 0; i--)
                    {
                        msg = client.Read_Data();
                       // AppendUI(msg, infobox);
                        moveData = Decoding();
                        if (moveData[1] == "4"&&Int32.Parse(moveData[0]) == 1)
                        {
                            SetInfoBox("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "\n", infobox);
                            for (int j = 0; j < 2; j++)
                            {
                                msg = client.Read_Data();
                                moveData = Decoding();
                                map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[2]), turn);//設定遊戲記錄表位置
                                map.DeductTicket(Int32.Parse(moveData[0]), Int32.Parse(moveData[1]));//使用車票須扣除
                                if ((turn == 3 || turn == 8 || turn == 13 || turn == 18))
                                {
                                 SetInfoBox("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "移動至" + moveData[2] + "\n", infobox);
                                 SetFigure(Int32.Parse(moveData[2]), Int32.Parse(moveData[0]));
                                 VisableUI(figure[0], true);
                                }
                                else
                                {
                                 SetInfoBox("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "\n", infobox);
                                 VisableUI(figure[0], false);
                                }
                                if (j == 0)
                                {
                                    for (int l = 2; l <= player_Sum; l++)
                                    {
                                        map.SetPos(l, map.GetPos(l, turn - 1), turn);//設定遊戲記錄表位置
                                    }
                                    turn++;
                                    SetInfoBox("------第 " + turn + " 回合------\n", infobox);
                                }
                            }   
                            
                        }
                        else
                        {
                            if (Int32.Parse(moveData[0]) != 1)
                            {
                                SetFigure(Int32.Parse(moveData[2]), Int32.Parse(moveData[0]));
                                SetInfoBox("玩家 " + Int32.Parse(moveData[0]) + "移動到 " + Int32.Parse(moveData[2])+"\n", infobox);
                            }
                            map.SetPos(Int32.Parse(moveData[0]), Int32.Parse(moveData[2]), turn);//設定遊戲記錄表位置
                            map.DeductTicket(Int32.Parse(moveData[0]), Int32.Parse(moveData[1]));//使用車票須扣除
                            if (Int32.Parse(moveData[0]) == 1)
                                if ((turn == 3 || turn == 8 || turn == 13 || turn == 18))
                                {
                                    SetInfoBox("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "移動至" + moveData[2] + "\n", infobox);
                                    SetFigure(Int32.Parse(moveData[2]), Int32.Parse(moveData[0]));
                                    VisableUI(figure[0], true);
                                }
                                else
                                {
                                    SetInfoBox("MR.X使用" + transportation[Int32.Parse(moveData[1])] + "\n", infobox);
                                    VisableUI(figure[0], false);
                                }
                            //移動後判斷是否在同一個位置
                            if (is_SamePos(map.GetPos(1, turn), Int32.Parse(moveData[2])) && Int32.Parse(moveData[0]) != 1)
                            {
                                MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                                GameOver();
                                return;
                            }
                        }
                    }
                    
                    VisableUI(Input_Panel, true);
                    //顯示移動時產生的元件
                    msg = client.Read_Data();
                    moveData = Decoding();
                    
                    if (moveData[1] == "4")
                    {
                        isTwoStep = true;
                        EditUI("請輸入第一步\n",Input_TextBox);
                        msg = client.Read_Data();
                        turn++;
                        SetInfoBox("------第 " + turn + " 回合------\n", infobox);
                        EditUI("請輸入第二步\n", Input_TextBox);
                        msg = client.Read_Data();
                        isTwoStep = false;
                        
                    }
                    else
                    {
                        //判定是否抓到MR.X
                        
                        if (is_SamePos(map.GetPos(1, turn), Int32.Parse(moveData[2])) && Int32.Parse(moveData[0]) != 1)
                        {
                            MessageBox.Show("於 " + moveData[2] + " 找到MR.X，警察獲勝!");
                            GameOver();
                            return;
                            //GameOver
                        }
                    }
                    VisableUI(Input_Panel, false);
                    //關閉移動時產生的元件
                    //等待自己以後玩家移動
                    for (int i = player_Sum - player_ID; i > 0; i--)
                    {
                        msg = client.Read_Data();
                       // AppendUI(msg, infobox);
                        moveData = Decoding();
                        SetFigure(Int32.Parse(moveData[2]), Int32.Parse(moveData[0]));
                        SetInfoBox("玩家 " + Int32.Parse(moveData[0]) + "移動到 " + Int32.Parse(moveData[2]) + "\n", infobox);
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
                            GameOver();
                            return;
                            //GameOver
                        }
                    }
                    //ShowInfo();
                    turn++;
                    
                }
            }
        }*/
        private void GameOver()
        {
            //client.Send_Data("0000");
            Thread.Sleep(1000);
            client.DisConnect();
            AppendUI("遊戲結束\n", infobox);
            VisableUI(game_panel, false);
            VisableUI(GameEnd, true);
            //this.Width = GameEnd.Width;
            //this.Height = GameEnd.Height;
        }
        //遊戲按下START 後等待其他玩家入場
        private void listen()
        {
            string msg;
            msg = client.Read_Data();
            player_ID = Int32.Parse(msg[0].ToString());
            switch (player_ID)
            {
                case 1:
                    Player_Image.Image = Game_Client2._0.Properties.Resources.Theft;
                    EditUI("玩家 " + player_ID + " : MR.X\n", Player_Text);
                    break;
                case 2:
                    Player_Image.Image = Game_Client2._0.Properties.Resources.Police1;
                    EditUI("玩家 " + player_ID + " : Police\n", Player_Text);
                    break;
                case 3:
                    Player_Image.Image = Game_Client2._0.Properties.Resources.Police2;
                    EditUI("玩家 " + player_ID + " : Police\n", Player_Text);
                    break;
                case 4:
                    Player_Image.Image = Game_Client2._0.Properties.Resources.Police3;
                    EditUI("玩家 " + player_ID + " : Police\n", Player_Text);
                    break;
                case 5:
                    Player_Image.Image = Game_Client2._0.Properties.Resources.Police4;
                    EditUI("玩家 " + player_ID + " : Police\n", Player_Text);
                    break;
            }
            msg = client.Read_Data();//所有玩家已經加入遊戲
            AppendUI(msg, infobox);
            Game();
        }
        //移動時點下"MOVE"所觸發的事件
        //流程：檢查是否選擇交通方式和車票是否足夠->檢查Textbox中是否輸入非數字->->檢查是否相連->檢查是否在相同位置->移動
        //       
        private void move_Click(object sender, EventArgs e)
        {
            bool is_Number = true;
            int vertex=0;
            if (Transport.SelectedIndex != -1)//判定是否有選交通方式
            {
                if (map.CheckTicket(player_ID, Transport.SelectedIndex))//判定車票是否充足
                {
                    if (Transport.SelectedIndex == 4 && !isTwoStep)
                    {
                        //使用兩步券
                        AppendUI("你使用了兩步券!\n", infobox);
                        map.DeductTicket(player_ID, Transport.SelectedIndex);
                        String Msg = player_ID.ToString() + " " + Transport.SelectedIndex + " 0 \n";
                        client.Send_Data(Msg);
                    }
                    else
                    {
                        //使用交通方式
                        try
                        {
                            vertex = Int32.Parse(Input_TextBox.Text.ToString());//判定是否為數字
                        }
                        catch
                        {
                            is_Number = false;
                        }
                        if (is_Number)
                        {
                            //輸入數字
                            int pos = map.GetPos(player_ID, turn - 1);
                            if (pos == vertex)
                            {
                                MessageBox.Show("不得原地踏步!!");
                                //原地踏步
                            }
                            else
                            {
                                if (map.is_ConnectingVertex(pos, vertex, Transport.SelectedIndex))
                                {
                                   bool is_same = false;
                                   if (player_ID != 1)
                                   {
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
                                               if (is_SamePos(map.GetPos(i, turn - 1), vertex))
                                               {
                                                   is_same = true;
                                                   MessageBox.Show("兩個角色不得在同一點\n");
                                                   break;
                                               }
                                               //比自己晚動
                                           }
                                       }
                                   }
                                   if (!is_same)//確定沒有踩相同位置
                                   {
                                       DialogResult myResult = MessageBox.Show(player_ID + "請確認是否前往" + Input_TextBox.Text + "\n", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                       if (myResult == DialogResult.OK)
                                       {
                                           //更改現在位置並傳送資料給Server
                                           map.SetPos(player_ID, vertex, turn);
                                           SetFigure(vertex, player_ID);
                                           String Msg = player_ID.ToString() + " " + Transport.SelectedIndex + " " + Input_TextBox.Text + " \n";//Player Transportation position
                                           map.DeductTicket(player_ID, Transport.SelectedIndex);
                                           infobox.Text = infobox.Text + "你已移動到" + Input_TextBox.Text + "\n";
                                           infobox.SelectionStart = infobox.Text.Length;//將指標進行放置才可以行動
                                           infobox.ScrollToCaret();
                                           Renew_Ticket();
                                           client.Send_Data(Msg);
                                           VisableUI(Input_Panel, false);
                                       }
                                   }
                                }
                                else
                                {
                                    MessageBox.Show("請檢查位是否相聯或使用正確交通方式!!");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("請輸入數字!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("車票不足!!");
                }
            }
            else
            {
                MessageBox.Show("請選擇交通方式!!");
            }
            Transport.SelectedIndex = -1;
            Input_TextBox.Text = "";
        }                  
        /*private void move_Click(object sender, EventArgs e)
        {
            bool is_Number=true;
            int vertex;
            if (Transport.Text != "" && map.CheckTicket(player_ID, Transport.SelectedIndex))//檢查是否選擇交通方式和車票是否足夠
            {
                if (Transport.SelectedIndex == 4&&!isTwoStep)
                {
                    AppendUI("你使用了兩步券!\n", infobox);
                    map.DeductTicket(player_ID, Transport.SelectedIndex);
                    String Msg = player_ID.ToString() + " " + Transport.SelectedIndex + " 0 \n";
                    client.Send_Data(Msg);
                }
                else
                {
                    try//檢查Textbox中是否輸入非數字
                    {
                        vertex = Int32.Parse(Input_TextBox.Text.ToString());
                    }
                    catch
                    {
                        is_Number = false;
                    }
                    if (is_Number)
                    {

                        vertex = Int32.Parse(Input_TextBox.Text.ToString());//欲前往位置
                        int pos = map.GetPos(player_ID, turn - 1);//現在位置

                        if (map.is_ConnectingVertex(pos, vertex, Transport.SelectedIndex))
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
                                    if (is_SamePos(map.GetPos(i, turn - 1), vertex))
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
                                DialogResult myResult = MessageBox.Show(player_ID + "請確認是否前往" + Input_TextBox.Text + "\n", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (myResult == DialogResult.OK)
                                {
                                    //更改現在位置並傳送資料給Server
                                    map.SetPos(player_ID, vertex, turn);
                                    SetFigure(vertex, player_ID);
                                    String Msg = player_ID.ToString() + " " + Transport.SelectedIndex + " " + Input_TextBox.Text + " \n";//Player Transportation position
                                    map.DeductTicket(player_ID, Transport.SelectedIndex);
                                    infobox.Text = infobox.Text + "你已移動到" + Input_TextBox.Text + "\n";
                                    infobox.SelectionStart = infobox.Text.Length;//將指標進行放置才可以行動
                                    infobox.ScrollToCaret();
                                    Renew_Ticket();
                                    client.Send_Data(Msg);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("請檢查是否相連\n");
                        }
                    }
                    else
                    {
                        MessageBox.Show("請檢查是否發生下列錯誤：\n(1) 未輸入位置\n(2) 未選擇交通工具\n(3) 未輸入字元\n");
                    }
                }
            }
            else
            {
                MessageBox.Show("車票不足或使用正確的交通方式\n");
            }
            Transport.SelectedIndex = -1;
            Input_TextBox.Text = "";
        }*/
        //在遊戲過程中解析傳來的封包
        //------------------------------
        //| 玩家  | 交通方式 | 移動位置 |
        //------------------------------
        private String[] Decoding()
        {
            String msg;
            int positon = 0, start = 0, index = 0;
            msg = client.Read_Data();
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
            infobox.Text = "";
            Player_Text.Text = "";
            Ticket.Text = "";
            start_btn.Visible = true;
            textBox1.Visible=true;
            Close.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = Login.Width;
            this.Height = Login.Height;
        }
        //-----更新UI用
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
            msg = "計程車票 " + Taxi_Ticket + " 張\n 公車票 " + Bus_Ticket + " 張\n 地鐵票 " + Train_Ticket + " 張\n";
            if (Double_Ticket != 0 && All_Ticket != 0 || player_ID == 1)
            {
                msg = msg + " 萬用票 " + All_Ticket + " 張\n 兩步券 " + Double_Ticket + " 張\n";
            }
            EditUI(msg, Ticket);
            return;
        }
        //更新&初設棋子
        private void ini_Figure()
        {
            int[] coordinate = new int[2];
            for (int i = 0; i < player_Sum; i++)
            {
                figure[i] = new PictureBox();
                figure[i].Size = new Size(25, 25);
                figure[i].Location = new Point(10, 10);
                switch (i % player_Sum)
                {
                    case 0:
                        figure[i].Image = Game_Client2._0.Properties.Resources.Theft;//小偷顏色
                        figure[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        break;
                    case 1:
                        figure[i].Image = Game_Client2._0.Properties.Resources.Police1;//警察一顏色
                        figure[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        break;
                    case 2:
                        figure[i].Image = Game_Client2._0.Properties.Resources.Police2;//警察二顏色
                        figure[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        break;
                    case 3:
                        figure[i].Image = Game_Client2._0.Properties.Resources.Police3;//警察三顏色
                        figure[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        break;
                    case 4:
                        figure[i].Image = Game_Client2._0.Properties.Resources.Police4;//警察三顏色
                        figure[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        break;
                }
                figure[i].Visible = false;
                figure[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.Controls.Add(figure[i]);
            }
            pictureBox1.SendToBack();
        }
        private void SetFigure(int point, int Player)
        {
            int[] coordinate = map.GetCoordinate(point);
            Point tempP = new Point(coordinate[0], coordinate[1]);
            moveFig(tempP, figure[Player - 1]);
            MoveUI(pictureBox1);
        }
        //預覽車票圖片用
        private void Transport_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox list=(ListBox)sender;
            switch (list.SelectedIndex){
                case -1:
                    //預設
                    TransportPic.Image = Game_Client2._0.Properties.Resources.defaultTic;
                    break;
                case 0:
                    //計程車票
                    TransportPic.Image = Game_Client2._0.Properties.Resources.Taxi;
                    break;
                case 1:
                    //公車票
                    TransportPic.Image = Game_Client2._0.Properties.Resources.Bus;
                    break;
                case 2:
                     //地鐵票
                    TransportPic.Image = Game_Client2._0.Properties.Resources.Train;
                    break;
                case 3:
                    //萬用票
                    TransportPic.Image = Game_Client2._0.Properties.Resources.all;
                    break;
                case 4:
                    //兩步卡
                    TransportPic.Image = Game_Client2._0.Properties.Resources._double;
                    break;

            }
        }
        //更新資訊紀錄表用
        private void SetInfobox(String textBoxMsg) {
            AppendUI(textBoxMsg, infobox);
        }
        //-----遊戲製作時或Debug時使用
        private void ShowInfo()
        {
            String msg = "";
            for (int i = 1; i <= player_Sum; i++)
            {
                msg = msg + "第" + i + "玩家在 " + map.GetPos(i, turn) + "\n";
            }
            //Debug 用
            MessageBox.Show(msg, "第" + turn + "回合結果");
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //-----控制捲軸移動用
        int Mouse_DownX, Mouse_DownY;
        protected Point scrollPosition; 
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse_DownX = e.X;
            Mouse_DownY = e.Y;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                scrollPosition.X = scrollPosition.X + Mouse_DownX - e.X;
                scrollPosition.Y = scrollPosition.Y + Mouse_DownY - e.Y;
                this.Left_Panel.AutoScrollPosition = scrollPosition;
            }
        }
        
    }
}
