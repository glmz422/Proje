using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yurt2
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
            int a;

            for (int i = 0; i < 15; i++)
            {
                a = r.Next(0, 10);
                listBox1.Items.Add(a);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kücük = Convert.ToInt32(listBox1.Items[0]), sayi;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                sayi = Convert.ToInt32(listBox1.Items[i]);
                if (sayi < kücük)
                {
                    kücük = sayi;
                }
                listBox2.Items.Add(kücük);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {



        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox2.Text);
            bool bayrak = false;

            for (int i = 2; i < x; i++)
            {
                if (i % 2 == 0) bayrak = false;
                if (bayrak == true) label1.Text = "sayı asal değil";
                else label1.Text = "sayı asaldır";
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            int enkücük = Convert.ToInt32(listBox1.Items[0]), sayi;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                sayi = Convert.ToInt32(listBox1.Items[i]);
                if (sayi < enkücük)
                {
                    enkücük = sayi;
                }
                label1.Text = ("en kücük" + enkücük.ToString());

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            int toplam = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                toplam += Convert.ToInt32(listBox1.Items[i]);

            }
            label1.Text = "" + toplam;


        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        string[] personeller;
        int[] maas;

        private void button8_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            personeller = new string[] { "talha", "gaye", "cafer", "abbas" };
            maas = new int[] { 7000, 10000, 5000, 6000 };

            for (int i = 0; i < personeller.Length; i++)
            {
                listBox1.Items.Add(personeller[i]);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button10_Click(object sender, EventArgs e)
        {


        }

        private void button11_Click(object sender, EventArgs e)
        {


        }

        private void button12_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            listBox3.Items.Clear();
            int[] sayi = new int[10];
            for (int i = 0; i < 10; i++)

            {
                sayi[i] = r.Next(0, 10);

            }
            Array.Sort(sayi);
            foreach (int eleman in sayi)
            {
                listBox3.Items.Add(eleman);
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int sayac1, sayac2, sayac3;
            int[] sayi = new int[10];

            sayac1 = 0;
            sayac2 = 0;
            sayac3 = 0;

            for (int i = 0; i < 10; i++)
            {
                sayi[i] = r.Next(-10, 10);
                if (sayi[i] > 0)
                {
                    sayac1++;
                }
                if (sayi[i] < 0)
                {
                    sayac2++;
                }
                if (sayi[i] == 0)
                {
                    sayac3++;
                }
            }
            listBox3.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                listBox3.Items.Add(sayi[i].ToString());
            }
            label2.Text = "" + sayac1;
            label3.Text = "" + sayac2;
            label4.Text = "" + sayac3;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Blue;
            label5.BackColor = Color.Black;
            label5.Text = "helo";

        }

        private void button15_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox3.Text);
            int sayac = 0;

            for (int i=1; i<=a; i++ )
            {
                if (a % i == 0)
                {
                    sayac++;
                }
                    if(sayac==2)
                    {
                        label6.Text = "asaldır";
                    }
                
            }
        }


        private void button16_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox4.Text);
            int sayac = 0;

            for (int i=1; i<a; i++)
            {
                if (a % i ==0)
                {
                    sayac += i;

                }
                if (sayac==a)
                {
                    label7.Text = "mükemmeldir";
                }
            }
            }

        private void button17_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            int a, b = 1,sonuc=0;

            for (int i=0; i<8; i++)
            {
                a = b;
                b = sonuc;
                sonuc = a + b;
                listBox4.Items.Add (sonuc.ToString());
            }
        }
    }
    }


        
    

    


       

