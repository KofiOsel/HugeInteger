using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HugeInteger
{
    public partial class Form1 : Form
    {
        HugeInteger num1 = new HugeInteger();
        HugeInteger num2 = new HugeInteger();
        HugeInteger num3 = new HugeInteger();
       

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            if(radioButton1.Checked)
            {
                string text = textBox1.Text;
                string text2 = textBox2.Text;
                num1.Input(text);
                num2.Input(text2);
                string r = num1.Add(num2);
                textBox3.Text = r;
            }
            else if (radioButton2.Checked)
            {
                string text = textBox1.Text;
                string text2 = textBox2.Text;
                num1.Input(text);
                num2.Input(text2);
                string r = num1.Substract(num2);
                textBox3.Text = r;
            }
            else if (radioButton3.Checked)
            {
                string text = textBox1.Text;
                string text2 = textBox2.Text;
                num1.Input(text);
                num2.Input(text2);
                string r = num1.Divide(num2);
                textBox3.Text = r;
            }
            else if (radioButton4.Checked)
            {
                string text = textBox1.Text;
                string text2 = textBox2.Text;
                num1.Input(text);
                num2.Input(text2);
                string r = num1.Multiple(num2);
                textBox3.Text = r;
            }
            else if (radioButton5.Checked)
            {
                string text = textBox1.Text;
                string text2 = textBox2.Text;
                num1.Input(text);
                num2.Input(text2);
                string r = num1.Remainder(num2);
                textBox3.Text = r;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            num3.Input(textBox1.Text);
            num1.Input(textBox1.Text);
            num2.Input(textBox2.Text);

            if(checkBox1.Checked)
            {
                bool ans = num1.isEqualTo(num2);
                if (ans == true)
                {
                    textBox4.Text = "true";
                } else
                {
                    textBox4.Text = "false";
                }
            }

            if (checkBox2.Checked)
            {
                bool ans1 = num1.isNotEqualTo(num2);
                if (ans1 == true)
                {
                    textBox4.Text = "true";
                }
                else
                {
                    textBox4.Text = "false";
                }
            }

            if (checkBox3.Checked)
            {
                bool ans2 = num1.IsGreaterThan(num2);
                if (ans2 == true)
                {
                    textBox4.Text = "true";
                }
                else
                {
                    textBox4.Text = "false";
                }
            }

            if (checkBox4.Checked)
            {
                bool ans3 = num1.IsLessThan(num2);
                if (ans3 == true)
                {
                    textBox4.Text = "true";
                }
                else
                {
                    textBox4.Text = "false";
                }
            }

            if (checkBox5.Checked)
            {
                bool ans4 = num1.IsGreaterThanOrEqualTo(num2);
                if (ans4 == true)
                {
                    textBox4.Text = "true";
                }
                else
                {
                    textBox4.Text = "false";
                }
            }

            if (checkBox6.Checked)
            {
                bool ans5 = num1.IsLessThanOrEqualTo(num2);
                if (ans5 == true)
                {
                    textBox4.Text = "true";
                }
                else
                {
                    textBox4.Text = "false";
                }
            }

            if (checkBox7.Checked)
            {
                bool ans6 = num1.isZero(num2);
                if (ans6 == true)
                {
                    textBox4.Text = "true";
                }
                else
                {
                    textBox4.Text = "false";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
