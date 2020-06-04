using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using CheckPort;

namespace CheckPort2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            label2.Text = "";
            toolStripStatusLabel1.Text = "";
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                toolStripStatusLabel1.Text = "请输入检测端口号！";
                return;
            }
            else
            {
                try
                {
                    CheckPort.CheckPort port = new CheckPort.CheckPort();
                    if (port.TportGpid(int.Parse(textBox1.Text)) == "")
                    {
                        label6.Text = "端口： " + textBox1.Text + " 未被占用，可以使用！";
                    }
                    else
                    {
                        label6.Text = "端口： " + textBox1.Text + " 已被占用，不可以使用！";
                        label2.Text = port.TportGpid(int.Parse(textBox1.Text));
                    }
                }
                catch (Exception err)
                {
                    toolStripStatusLabel1.Text = err.Message;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
