using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void koltukSecildi(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.BackColor == Color.Red)
                btn.BackColor = Color.Aqua;
            else
                btn.BackColor = Color.Red;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Koltukların numaralandırılmasında kullanılacak
            int say = 0;

            //Panel içeriği temizleniyor
            panel1.Controls.Clear();

            //TextBox'taki satır (i) ve sütunlar (j) üzerinde hareket ediliyor
            for (int i = 0; i < textBox1.Lines.Count(); i++)
            {
                for (int j = 0; j < textBox1.Lines[i].Count(); j++)
                {
                    string satir = textBox1.Lines[i];

                    //Satır üzerinde * karakteri oluşturulası gereken koltuk anlamındadır.
                    if (satir[j] == '*')
                    {
                        //Nesne dinamik olarak oluşturuluyor
                        Button nesne = new Button();
                        nesne.Name = "buton" + i;
                        nesne.Text = (++say).ToString();
                        nesne.BackColor = Color.Red;
                        nesne.Width = nesne.Height = 30;
                        nesne.Left = 35 * j;
                        nesne.Top = 35 * i;

                        //Buton üzerine tıklandığında hangi metodun çalıştırılacağı belirtiliyor
                        nesne.Click += koltukSecildi;

                        //Oluşturulan buton nesnesi panel1 üzerine yerleştiriliyor
                        panel1.Controls.Add(nesne);
                    }
                }
            }
        }
    }
}
