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
    public partial class Form9 : Form
    {
        public Form9()
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

        void Listele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from Tablo3", Veritabani_Baglanti);
            Veri_Seti = new DataSet();

            Veritabani_Baglanti.Open();

            Veri_Adaptor.Fill(Veri_Seti, "Tablo3");
            dataGridView1.DataSource = Veri_Seti.Tables["Tablo3"];

            Veritabani_Baglanti.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            
            Listele();           
        }

      




            private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }


        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox7.Text = openFileDialog1.FileName;
            }

           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=proje1.accdb");
            Veri_Adaptor = new OleDbDataAdapter("Select * from Tablo3 where d_adi like '%" + textBox8.Text + "%'", Veritabani_Baglanti);
            
            tasima = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(tasima, "Tablo3");
            dataGridView1.DataSource = tasima.Tables["Tablo3"];
            Veritabani_Baglanti.Close();






        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int kayitsayisi;
            kayitsayisi = dataGridView1.RowCount;
            label10.Text = "Toplam Kayıtlı Kişi Sayısı:  " + kayitsayisi.ToString();


        }




        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("KULLANILMAYAN ID'LER");
            listBox1.Items.Add("====================");
            for (int i = 1; i <= 20; i++)
            {
                if (RafKontrol(i) == false)
                {
                    listBox1.Items.Add(i);
                }
            }
        }

        public bool RafKontrol(int numara)
        {
            bool bosmu = false;
            string bagla = "SELECT *FROM Tablo3 WHERE id=" + numara + "";
            Veritabani_Baglanti.Open();
            Veri_Komutu = new OleDbCommand(bagla, Veritabani_Baglanti);
            dr = Veri_Komutu.ExecuteReader();
            if (dr.Read())
            {
                bosmu = true;
            }
            Veritabani_Baglanti.Close();
            return bosmu;
        }
        
        
        void Yukle()
        {
            Veri_Adaptor = new OleDbDataAdapter("SELECT * FROM Tablo3", Veritabani_Baglanti);
            dt = new DataTable();
            Veri_Adaptor.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sorgu = "Update Tablo3 Set d_adi=@Ad,d_soyadi=@Soyad,d_bolumu=@Bolum,d_unvan=@Unvan,resim=@Resim,sehir=@sehir,g_yeri=@g_yeri Where id=@Id";
            Veri_Komutu = new OleDbCommand(sorgu, Veritabani_Baglanti);
            Veri_Komutu.Parameters.AddWithValue("@Ad", textBox1.Text);
            Veri_Komutu.Parameters.AddWithValue("@Soyad", textBox2.Text);
            Veri_Komutu.Parameters.AddWithValue("@Bolum", textBox3.Text);
            Veri_Komutu.Parameters.AddWithValue("@Unvan", textBox4.Text);
            Veri_Komutu.Parameters.AddWithValue("@Resim", textBox7.Text);
            Veri_Komutu.Parameters.AddWithValue("@sehir", textBox5.Text);
            Veri_Komutu.Parameters.AddWithValue("@g_yeri", textBox6.Text);
            Veri_Komutu.Parameters.AddWithValue("@Id", (dataGridView1.CurrentRow.Cells[0].Value));
            Veritabani_Baglanti.Open();
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            Listele();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string sorgu = "Delete From Tablo3 Where id=@Id";
            Veri_Komutu = new OleDbCommand(sorgu, Veritabani_Baglanti);
            Veri_Komutu.Parameters.AddWithValue("@Id", (dataGridView1.CurrentRow.Cells[0].Value));
            Veritabani_Baglanti.Open();
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            Listele();
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";


        }

        void datarenk()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) == "EVET")
                {

                    renk.BackColor = Color.Red;
                    renk.ForeColor = Color.White;
                }

                dataGridView1.Rows[i].DefaultCellStyle = renk;

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into Tablo3 (d_adi,d_soyadi,d_bolumu,d_unvan,resim,sehir,g_yeri) values (@Ad,@Soyad,@Bolum,@Unvan,@Resim,@sehir,@g_yeri)";
            Veri_Komutu = new OleDbCommand(sorgu, Veritabani_Baglanti);
            Veri_Komutu.Parameters.AddWithValue("@Ad", textBox1.Text);
            Veri_Komutu.Parameters.AddWithValue("@Soyad", textBox2.Text);
            Veri_Komutu.Parameters.AddWithValue("@Bolum", textBox3.Text);
            Veri_Komutu.Parameters.AddWithValue("@Unvan", textBox4.Text);
            Veri_Komutu.Parameters.AddWithValue("@Resim", textBox7.Text);
            Veri_Komutu.Parameters.AddWithValue("@sehir", textBox5.Text);
            Veri_Komutu.Parameters.AddWithValue("@g_yeri", textBox6.Text);
            Veritabani_Baglanti.Open();
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            Listele();
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Form10 form = new Form10();
            form.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}


    


