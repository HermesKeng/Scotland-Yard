using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Client
{
    public partial class Form1 : Form
    {
        Client client = new Client();
        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IP_num;
            IP_num = textBox1.Text;
            client.Set_Ip(IP_num);
            client.connect(this);
            
        }
    }
}
