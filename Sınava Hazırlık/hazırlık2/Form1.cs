using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yurt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            listBox1.Items.Clear();
            int sayi;
            for (int i = 0; i < 10; i++)
            {

                sayi = r.Next(1, 10);
                listBox1.Items.Add(sayi.ToString());



            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int toplam = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                toplam += Convert.ToInt32(listBox1.Items[i]);

            }
            label1.Text = "" + toplam;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int enKücük = Convert.ToInt32(listBox1.Items[0]), sayi;

            for (int a = 0; a < listBox1.Items.Count; a++)
            {
                sayi = Convert.ToInt32(listBox1.Items[a]);
                if (sayi < enKücük)
                {
                    enKücük = sayi;
                }
                label2.Text = "" + enKücük;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string yemek = null;
            string icecek = null;

            if (checkBox1.Checked == true)
            {
                yemek = yemek + "döner";
            }
            if (radioButton1.Checked == true)
            {
                icecek = icecek + "ayran";
            }
            label2.Text = icecek + "\n" + yemek;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                listBox2.Items.Add("döner");
            }
            if (comboBox1.SelectedIndex == 1)
            {
                listBox2.Items.Add("köfte");
            }
            if (comboBox1.SelectedIndex == 2)
            {
                listBox2.Items.Add("pide");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 1)
                {
                    listBox3.Items.Add(i);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            while (a <= 44)
            {
                MessageBox.Show("kaldınız");
                break;
            }
            while (a >= 45 && a <= 100)
            {
                MessageBox.Show("Geçtiniz");
                break;
            }
            while (a > 100)
            {
                MessageBox.Show("HATALI BİR SAYI GİRDİNİZ");
                break;
            }




        }

        private void button8_Click(object sender, EventArgs e)
        {





        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox2.Text);
            int b = Convert.ToInt32(textBox3.Text);

            for (int i = a; i <= b; i++)
            {
                listBox5.Items.Add(i);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox4.Text);
            listBox6.Items.Clear();
            for (int i = 0; i <= a; i++)
            {
                listBox6.Items.Add(i);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int a, b,s;
            a = Convert.ToInt32(textBox5.Text);
            b = Convert.ToInt32(textBox6.Text);

            if (comboBox2.SelectedIndex==0)
            {
                s = a + b;
                label1.Text = "" + s;

            }
            if (comboBox2.SelectedIndex==1)
            {
                s = a - b;
                label1.Text = "" + s;
            }
            if (comboBox2.SelectedIndex==2)
            {
                s = a * b;
                label1.Text = "" + s;
            }
            if (comboBox2.SelectedIndex==3)
            {
                s = a / b;
                label1.Text = "" + s;
            }
            
            
        }
    }
}
    



                   
    

