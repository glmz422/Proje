using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace başlangıç2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label4.Visible)
                label4.Visible = false;
            else
                label4.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Saat.Text = "" + DateTime.Now.ToShortTimeString();
            ;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("alarm çalıyor");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("Devam etmek istiyor musun?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] isimler = { "Talha", "Gaye", "Mehmet", "Ali" };

            textBox4.Text = isimler[0];
            textBox4.Text = isimler[1];
            textBox4.Text = isimler[2];
            textBox4.Text = isimler[3];
            MessageBox.Show(textBox4.Text);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int v, f, s;
            v = Convert.ToInt32(textBox2.Text);
            f = Convert.ToInt32(textBox3.Text);
            s = Convert.ToInt32(v * 0.4 + f * 0.6);
            label9.Text = Convert.ToString(s);

            if (s <= 45)
                label10.Text = "Kaldınız-FF";
            if (s > 45 && s <= 75)
                label10.Text = "Geçtiniz-CC";
            if (s > 75 && s <= 85)
                label10.Text = "Geçtiniz-BB";
            if (s > 85 && s <= 100)
                label10.Text = "Geçtiniz-AA";
            if (s > 100)
                MessageBox.Show("Hatalı Bir Sayı Giriniz...");



        }

        private void button7_Click(object sender, EventArgs e)
        {
            string karsilamaMesaji = "";
            int saat = DateTime.Now.Hour;

            if ((9 <= saat && saat < 12))
            {
                karsilamaMesaji = karsilamaMesaji.Insert(0, "Güno");
            }
            else if (12 <= saat && saat < 16)
            {
                karsilamaMesaji = karsilamaMesaji.Insert(0, "İyi Günler");
            }
            else if (16 <= saat && saat < 18)
            {
                karsilamaMesaji = karsilamaMesaji.Insert(0, "İyi Akşamlar");
            }

                this.Text = karsilamaMesaji;


            }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string karsilama = "";
            int saaat = DateTime.Now.Hour;
            switch(saaat)
            {
                case 16:
                case 17:
                case 18:

                    karsilama = karsilama.Insert(0, "İyi Akşamlar");
                    break;
            }
 }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            for (int x = 1; x <= 10; x++)
            {
                listBox1.Items.Add("Item " + x.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int sayi = 1;
            int a, b;

            a = Convert.ToInt32(textBox5.Text);
            b = Convert.ToInt32(textBox6.Text);
            while (sayi <= 10)
            {

                listBox1.Items.Add(sayi);
                sayi++;


            }
        }
    }
    }


