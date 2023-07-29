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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=proje1.accdb");
        OleDbCommand Veri_Komutu = new OleDbCommand();
        OleDbDataAdapter Veri_Adaptor = new OleDbDataAdapter();
        DataSet tasima = new DataSet();
        

        private void button1_Click(object sender, EventArgs e)
        {
           
            string anket;
            if (radioButton1.Checked) anket = "Çok İyi";
            else if (radioButton2.Checked)anket = "İyi";
            else if (radioButton3.Checked)anket = "Fena Değil";
            else if (radioButton4.Checked) anket = "Kötü";
            else if (radioButton5.Checked) anket = "Leş";
            else anket = "";

            string sorgu = "Insert into Tablo4 (sonuc) values (@sonuc)";
            Veri_Komutu = new OleDbCommand(sorgu, Veritabani_Baglanti);
            Veri_Komutu.Parameters.AddWithValue("sonuc", anket);
            Veritabani_Baglanti.Open();

            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            MessageBox.Show("Anketimize katıldığınız için teşekkür ederiz...");

            
            {
                this.Close();
                Application.Exit();
            }





        }

        private void button2_Click(object sender, EventArgs e)
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

        private void Form12_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 form = new Form9();
            form.Show();
        }
    }
}
