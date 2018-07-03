using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 


namespace test2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private string textbox1;
        private string textbox2;

        private static bool time_first = true;

        private DateTime dt = DateTime.Now;  //定义一个成员函数用于保存每次的时间点
        public void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
            TextBox1.MaxLength = 100;
            DateTime tempDt = DateTime.Now;          //保存按键按下时刻的时间点
            TimeSpan ts = tempDt.Subtract(dt);     //获取时间间隔

            string text_temp = TextBox1.Text.ToString();
            long target = 0;                           //这里如果用int会不够长
            if (long.TryParse(text_temp, out target) == true) //是不是整形
            {
                if (ts.Milliseconds > 1025 && time_first == false)  //判断时间间隔，如果时间间隔大于???毫秒，则将TextBox清空
                {
                    TextBox1.Text = "";
                }
                else
                {
                    time_first = false;
                    dt = tempDt;
                    textbox1 = TextBox1.Text;
                    textbox2 += textbox1[textbox1.Length - 1];
                    textbox2 += "  ";
                    textbox2 += ts.Milliseconds;
                    textbox2 += "\r\n";
                }
            }
            else
            {
                TextBox1.Text = "";
            }
        }



        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

            if (textbox2.Length >= 16)//到时候改 因为测试阶段有时间差等等内容
            {
                TextBox2.Text = textbox2;

            }
            else
                TextBox2.Text = "";
            //TextBox2.Text=textbox2;
        }

        private void TextBox2_ParentChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void TextBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar>'9'|| e.KeyChar < '0')
            {
                MessageBox.Show("Wrong Input");
                 
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox2.Text = TextBox1.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            form1.Show();
            this.Hide();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
