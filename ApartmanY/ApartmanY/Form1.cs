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

namespace ApartmanY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection conn;
        OleDbCommand cmmd;
        OleDbDataReader adtr;

        private void iTalk_Button_11_Click(object sender, EventArgs e)
        {
            string ad = iTalk_TextBox_Small1.Text;
            string sifre = iTalk_TextBox_Small2.Text;
            conn = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=apartman1.accdb");
            cmmd = new OleDbCommand();
            conn.Open();
            cmmd.Connection = conn;
            cmmd.CommandText = "SELECT * FROM sifre where k_adi='" + iTalk_TextBox_Small1.Text + "' AND k_sifre='" + iTalk_TextBox_Small2.Text + "'";

            adtr = cmmd.ExecuteReader();



            if (adtr.Read())

            {
                this.Hide();
                Form4 f2 = new Form4();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }


        }

        private void iTalk_TextBox_Small1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void iTalk_ThemeContainer1_Click(object sender, EventArgs e)
        {
           
        }

        private void iTalk_Button_12_Click(object sender, EventArgs e)
        {
            iTalk_TextBox_Small1.Text = "deneme";
            iTalk_TextBox_Small2.Text = "123";
        }

        private void iTalk_Button_13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f2 = new Form6();
            f2.Show();
        }
    }
}

