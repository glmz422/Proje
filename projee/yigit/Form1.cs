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

namespace yigit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {




        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                string ad = textBox1.Text;
                string sifre = textBox2.Text;
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=demirbas.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Tablo2 where k_adi='" + textBox1.Text + "' AND k_sifre='" + textBox2.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f = new Form6();
            f.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult cik;
            cik = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cik == DialogResult.No)
            {

            }
            if (cik == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "admin";
            textBox2.Text = "12345";
        }
    }
}
