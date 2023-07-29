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
namespace Proje
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=proje1.accdb");
        OleDbCommand Veri_Komutu = new OleDbCommand();
        OleDbDataAdapter Veri_Adaptor = new OleDbDataAdapter();
        DataSet tasima = new DataSet();
        DataSet Veri_Seti;
        OleDbDataReader dr;
        DataTable dt;



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Veri_Komutu.Connection = Veritabani_Baglanti;



                Veri_Komutu.CommandText = "Insert Into Tablo2(k_ad,k_sifre) Values ('" + textBox1.Text + "','" + textBox2.Text + "')";
                Veritabani_Baglanti.Open();
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                MessageBox.Show("Kayıt Tamamlandı!");

                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            
        }
    }
}
