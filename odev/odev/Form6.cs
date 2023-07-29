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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=datados1.accdb");
        OleDbCommand km = new OleDbCommand();
        OleDbDataAdapter ar = new OleDbDataAdapter();
        DataSet dset = new DataSet();

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                km.Connection = baglan;



                km.CommandText = "Insert Into sifre(kul_ad,kul_sif) Values ('" + textBox1.Text + "','" + textBox2.Text + "')";
                baglan.Open();
                km.ExecuteNonQuery();
                km.Dispose();
                baglan.Close();
                MessageBox.Show("Kayıt Tamamlandı!");

                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }

        }
    }
}
