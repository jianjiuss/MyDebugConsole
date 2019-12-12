using DebugConsole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private MyConsole myConsole;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConsole = new MyConsole();
            myConsole.FormClosed += MyConsole_FormClosed;
            myConsole.Show();
        }

        private void MyConsole_FormClosed(object sender, FormClosedEventArgs e)
        {
            myConsole = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(myConsole == null)
            {
                MessageBox.Show("先打开日志窗口");
                return;
            }

            myConsole.Log(textBox1.Text, MsgType.Error, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (myConsole == null)
            {
                MessageBox.Show("先打开日志窗口");
                return;
            }

            myConsole.Log(textBox1.Text, MsgType.Warning);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (myConsole == null)
            {
                MessageBox.Show("先打开日志窗口");
                return;
            }

            myConsole.Log(textBox1.Text, MsgType.Normal);
        }
    }
}
