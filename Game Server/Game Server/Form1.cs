using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Game_Server
{
    public partial class Form1 : Form
    {
        Server server = new Server();
        TcpClient[] client=new TcpClient[4];
        Thread[] thread=new Thread[4];
        ParameterizedThreadStart ts;
        private delegate void callbUI(String message,Control ctl);
        private void UpdateUI(string value, Control ctl)
        {
            if (this.InvokeRequired)
            {
                callbUI cb = new callbUI(UpdateUI);
                this.Invoke(cb,value,ctl);
            }
            else
            {
                ctl.Text += value;
            }
        }
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            server.Start(this);
            for (int i = 0; i < 4; i++)
            {
                ts = new ParameterizedThreadStart(Create_Connection);
                thread[i] = new Thread(ts);
                thread[i].Start(i);
            }
            for (int i = 0; i < 4; i++)
            {
                while (!thread[i].IsAlive) ;
            }

        }
        public void Create_Connection(object str){

            string msg;
            int i = Int32.Parse(str.ToString());
            msg = "Thread" + i + "start\n";
            UpdateUI(msg, infobox);
            client[i]=server.Wait_Client(this, client[i]);
            msg = "玩家" + (i + 1) + "成功連線\n" + "還需等待 " + (3 - i) + " 名玩家\n";
            UpdateUI(msg, infobox);
        }

    }
}
