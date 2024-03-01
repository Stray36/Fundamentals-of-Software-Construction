using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator1
{
    public partial class Form1 : Form
    {
        double num1;
        double num2;
        string optType;
        bool flag = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(button1.Text);
            Button btn  = (Button)sender;
            //Console.WriteLine(btn.Text);
            string txt = btn.Text;

            if (txt == "+" || txt == "-" || txt == "*" || txt == "/")
            {
                if (textBox1.Text != "")
                {
                    optType = txt;
                    textBox4.Text = optType;
                    flag = false;
                }
            }
            else if (txt == "delete")
            {
                if (flag && textBox1.Text != "")
                {
                    string tempStr1 = textBox1.Text;
                    tempStr1 = tempStr1.Substring(0, tempStr1.Length - 1);
                    textBox1.Text = tempStr1;
                }
                else if (textBox2.Text != "")
                {
                    string tempStr2 = textBox2.Text;
                    tempStr2 = tempStr2.Substring(0, tempStr2.Length - 1);
                    textBox2.Text = tempStr2;
                }
            }
            else if (txt == "clear")
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                num1 = 0;
                num2 = 0;
                optType = "";
            }
            else if (txt == "=")
            {
                //num1 = Convert.ToDouble(textBox1.Text);
                //num2 = Convert.ToDouble(textBox2.Text);
                num1 = double.Parse(textBox1.Text);
                num2 = double.Parse(textBox2.Text);
                double result = 0;
                if (optType == "+")
                {
                    result = num1 + num2;
                }
                else if (optType == "-")
                {
                    result = num1 - num2;
                }
                else if (optType == "*")
                {
                    result = num1 * num2;
                }
                else if (optType == "/")
                {
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }   
                }
                flag = true;
                textBox3.Text = result.ToString();
            }
            else
            {
                if (flag)
                {
                    string tempStr1 = textBox1.Text;
                    tempStr1 = tempStr1 + txt;
                    textBox1.Text = tempStr1;
                }
                else
                {
                    string tempStr2 = textBox2.Text;
                    tempStr2 = tempStr2 + txt;
                    textBox2.Text = tempStr2;
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.button2.Click += new System.EventHandler(this.button1_Click);
            this.button3.Click += new System.EventHandler(this.button1_Click);
            this.button4.Click += new System.EventHandler(this.button1_Click);
            this.button5.Click += new System.EventHandler(this.button1_Click);
            this.button6.Click += new System.EventHandler(this.button1_Click);
            this.button7.Click += new System.EventHandler(this.button1_Click);
            this.button8.Click += new System.EventHandler(this.button1_Click);
            this.button9.Click += new System.EventHandler(this.button1_Click);
            this.button10.Click += new System.EventHandler(this.button1_Click);
            this.button11.Click += new System.EventHandler(this.button1_Click);
            this.button12.Click += new System.EventHandler(this.button1_Click);
            this.button13.Click += new System.EventHandler(this.button1_Click);
            this.button14.Click += new System.EventHandler(this.button1_Click);
            this.button15.Click += new System.EventHandler(this.button1_Click);
            this.button16.Click += new System.EventHandler(this.button1_Click);
            this.button17.Click += new System.EventHandler(this.button1_Click);
            this.button18.Click += new System.EventHandler(this.button1_Click);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
