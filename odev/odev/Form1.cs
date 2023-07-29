using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace odev
{
    public partial class Form1 : Form
    {
       



        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan;
        OleDbCommand km;
        OleDbDataReader rd;





        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string ad = textBox1.Text;
                string sifre = textBox2.Text;
                baglan = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=datados1.accdb");
                km = new OleDbCommand();
                baglan.Open();
                km.Connection = baglan;
                km.CommandText = "SELECT * FROM sifre where kul_ad='" + textBox1.Text + "' AND kul_sif='" + textBox2.Text + "'";
                rd = km.ExecuteReader();
                if (rd.Read())
                {
                    this.Hide();
                    Form3 f2 = new Form3();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 a = new Form6();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {

            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}
