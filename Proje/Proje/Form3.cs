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
    public partial class Form3 : Form
    {

        OleDbConnection Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=proje1.accdb");
        OleDbCommand Veri_Komutu = new OleDbCommand();
        OleDbDataAdapter Veri_Adaptor = new OleDbDataAdapter(); 
        DataSet tasima = new DataSet();
        DataSet Veri_Seti;

        void Listele()
        {
            Veri_Adaptor = new OleDbDataAdapter("Select * from Tablo1", Veritabani_Baglanti);
            Veri_Seti = new DataSet();

            Veritabani_Baglanti.Open();

            Veri_Adaptor.Fill(Veri_Seti, "Tablo1");
            dataGridView1.DataSource = Veri_Seti.Tables["Tablo1"];

            Veritabani_Baglanti.Close();
        }


        public Form3()
        {
            InitializeComponent();
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Listele();            
        }


        public int VarMi(string aranan)
        {
            int sonuc;
            Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=proje1.accdb");
            string sorgu = "Select COUNT(h_tc) from Tablo1 WHERE h_tc='" + aranan + "'";
            Veri_Komutu = new OleDbCommand(sorgu, Veritabani_Baglanti);
            Veritabani_Baglanti.Open();

            sonuc = Convert.ToInt32(Veri_Komutu.ExecuteScalar());

            Veritabani_Baglanti.Close();
            return sonuc;
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox13.Text !=  "")
            {
                Veri_Komutu.Connection = Veritabani_Baglanti;


                
                Veri_Komutu.CommandText = "Insert Into Tablo1(h_tc,h_adi,h_soyadi,h_telefonu,h_mail,h_adres,h_yatis_tarihi,h_cikis_tarihi,h_ucret,sehir) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox14.Text + "' )";
                Veritabani_Baglanti.Open();
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                Listele();


            }
            else
            {
                MessageBox.Show("Boş alan geçmeyiniz!");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();




        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox1.Text = "22222222222";
            textBox2.Text = "Talha";
            textBox3.Text = "Talha";
            textBox4.Text = "5555555555";
            textBox5.Text = "mail@gmail.com";
            textBox6.Text = "Ankara";
            textBox7.Text = "01.03.2022";
            textBox8.Text = "01.03.2023";
            textBox9.Text = "1000 TL";
            textBox14.Text = "Ankara";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=proje1.accdb");
            Veri_Adaptor = new OleDbDataAdapter("Select * from Tablo1", Veritabani_Baglanti);
            tasima = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(tasima, "Tablo1");
            dataGridView1.DataSource = tasima.Tables["Tablo1"];
            Listele();

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                Veritabani_Baglanti.Open();
                Veri_Komutu.Connection = Veritabani_Baglanti;
                Veri_Komutu.CommandText = "delete from Tablo1 where id=" + textBox10.Text + "";
                Veri_Komutu.ExecuteNonQuery();
                Veri_Komutu.Dispose();
                Veritabani_Baglanti.Close();
                tasima.Clear();
                Listele();
               
            }
            }

        private void button6_Click(object sender, EventArgs e)
        {
            Veri_Komutu = new OleDbCommand();
            Veritabani_Baglanti.Open();
            Veri_Komutu.Connection = Veritabani_Baglanti;
            Veri_Komutu.CommandText = "update Tablo1 set h_tc='" + textBox1.Text + "', h_adi='" + textBox2.Text + "', h_soyadi='" + textBox3.Text + "', h_telefonu='" + textBox4.Text + "', h_mail='" + textBox5.Text + "', h_adres='" + textBox6.Text + "', h_yatis_tarihi='" + textBox7.Text + "', h_cikis_tarihi='" + textBox8.Text + "',  h_ucret='" + textBox9.Text + "',  resim='" + textBox13.Text + "',  sehir='" + textBox14.Text + "'  where id=" + textBox11.Text + "";
            Veri_Komutu.ExecuteNonQuery();
            Veritabani_Baglanti.Close();
            tasima.Clear();
            Listele();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form9 form = new Form9();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

            Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=proje1.accdb");
            Veri_Adaptor = new OleDbDataAdapter("Select * from Tablo1 where h_adi like '%" + textBox12.Text + "%'", Veritabani_Baglanti);
            tasima = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(tasima, "Tablo1");
            dataGridView1.DataSource = tasima.Tables["Tablo1"];
            Veritabani_Baglanti.Close();



         

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox13.Text = openFileDialog1.FileName;
            }

            int s = 92;
            string harf = ((char)s).ToString();

            string yazi = textBox13.Text; string metin = "";
            int yaziuzunlugu = yazi.Length;
            for (int i = yaziuzunlugu; i > 0; i--)
            {
                if (yazi.Substring(i - 1, 1) == harf)
                {
                    break;
                }
                metin = metin + (yazi.Substring(i - 1, 1));
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int kayitsayisi;
            kayitsayisi = dataGridView1.RowCount;
            label16.Text = "Toplam Kayıtlı Kişi Sayısı:  " + kayitsayisi.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {
            if (VarMi(textBox1.Text) != 0)
            {
                MessageBox.Show("Bu TC Numara ile daha önce kayıt yapılmış");
            }
            else
            {
                string sorgu = "Insert into Tablo1 (h_tc,h_adi,h_soyadi,h_telefonu,h_mail,h_adres,h_yatis_tarihi,h_cikis_tarihi,h_ucret,resim,sehir) values (@tc,@ad,@soyad,@telefon,@mail,@adres,@yatis,@cikis,@ucret,@resim,@sehir)";
                Veri_Komutu = new OleDbCommand(sorgu, Veritabani_Baglanti);
                Veri_Komutu.Parameters.AddWithValue("@tc", (textBox1.Text));
                Veri_Komutu.Parameters.AddWithValue("@ad", textBox2.Text);
                Veri_Komutu.Parameters.AddWithValue("@soyad", textBox3.Text);
                Veri_Komutu.Parameters.AddWithValue("@telefon", (textBox4.Text));
                Veri_Komutu.Parameters.AddWithValue("@mail", textBox5.Text);
                Veri_Komutu.Parameters.AddWithValue("@adres", textBox6.Text);
                Veri_Komutu.Parameters.AddWithValue("@yatis", (textBox7.Text));
                Veri_Komutu.Parameters.AddWithValue("@cikis", textBox8.Text);
                Veri_Komutu.Parameters.AddWithValue("@ucret", textBox9.Text);
                Veri_Komutu.Parameters.AddWithValue("@resim", textBox13.Text);
                Veri_Komutu.Parameters.AddWithValue("@sehir", textBox14.Text);
                Veritabani_Baglanti.Open();
                Veri_Komutu.ExecuteNonQuery();
                Veritabani_Baglanti.Close();
                Listele();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=proje1.accdb");
            Veri_Adaptor = new OleDbDataAdapter("Select * from Tablo1" , Veritabani_Baglanti);
            tasima = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(tasima, "Tablo1");
            dataGridView1.DataSource = tasima.Tables["Tablo1"];
            Veritabani_Baglanti.Close();
            int i = 0;


            textBox1.Text = tasima.Tables[0].Rows[i]["h_tc"].ToString();
            textBox2.Text = tasima.Tables[0].Rows[i]["h_adi"].ToString();
            textBox3.Text = tasima.Tables[0].Rows[i]["h_soyadi"].ToString();
            textBox4.Text = tasima.Tables[0].Rows[i]["h_telefonu"].ToString();
            textBox5.Text = tasima.Tables[0].Rows[i]["h_mail"].ToString();
            textBox6.Text = tasima.Tables[0].Rows[i]["h_adres"].ToString();
            textBox7.Text = tasima.Tables[0].Rows[i]["h_yatis_tarihi"].ToString();
            textBox8.Text = tasima.Tables[0].Rows[i]["h_cikis_tarihi"].ToString();
            textBox9.Text = tasima.Tables[0].Rows[i]["h_ucret"].ToString();
            textBox13.Text = tasima.Tables[0].Rows[i]["resim"].ToString();


        }

        private void button12_Click(object sender, EventArgs e)
        {

            Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=proje1.accdb");
            Veri_Adaptor = new OleDbDataAdapter("Select * from Tablo1", Veritabani_Baglanti);
            tasima = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(tasima, "Tablo1");
            dataGridView1.DataSource = tasima.Tables["Tablo1"];
            Veritabani_Baglanti.Close();
            int i = 0;

            {
                if (i == tasima.Tables[0].Rows.Count - 1 || i != 0)
                {
                    i--;
                    textBox1.Text = tasima.Tables[0].Rows[i]["h_tc"].ToString();
                    textBox2.Text = tasima.Tables[0].Rows[i]["h_adi"].ToString();
                    textBox3.Text = tasima.Tables[0].Rows[i]["h_soyadi"].ToString();
                    textBox4.Text = tasima.Tables[0].Rows[i]["h_telefonu"].ToString();
                    textBox5.Text = tasima.Tables[0].Rows[i]["h_mail"].ToString();
                    textBox6.Text = tasima.Tables[0].Rows[i]["h_adres"].ToString();
                    textBox7.Text = tasima.Tables[0].Rows[i]["h_yatis_tarihi"].ToString();
                    textBox8.Text = tasima.Tables[0].Rows[i]["h_cikis_tarihi"].ToString();
                    textBox9.Text = tasima.Tables[0].Rows[i]["h_ucret"].ToString();
                    textBox13.Text = tasima.Tables[0].Rows[i]["resim"].ToString();

                }
                else { }
            


        }
            










        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=proje1.accdb");
            Veri_Adaptor = new OleDbDataAdapter("Select * from Tablo1", Veritabani_Baglanti);
            tasima = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(tasima, "Tablo1");
            dataGridView1.DataSource = tasima.Tables["Tablo1"];
            Veritabani_Baglanti.Close();
            int i = 0;


            i = tasima.Tables[0].Rows.Count - 1;
            
            
            
            textBox1.Text = tasima.Tables[0].Rows[i]["h_tc"].ToString();
            textBox2.Text = tasima.Tables[0].Rows[i]["h_adi"].ToString();
            textBox3.Text = tasima.Tables[0].Rows[i]["h_soyadi"].ToString();
            textBox4.Text = tasima.Tables[0].Rows[i]["h_telefonu"].ToString();
            textBox5.Text = tasima.Tables[0].Rows[i]["h_mail"].ToString();
            textBox6.Text = tasima.Tables[0].Rows[i]["h_adres"].ToString();
            textBox7.Text = tasima.Tables[0].Rows[i]["h_yatis_tarihi"].ToString();
            textBox8.Text = tasima.Tables[0].Rows[i]["h_cikis_tarihi"].ToString();
            textBox9.Text = tasima.Tables[0].Rows[i]["h_ucret"].ToString();
            textBox13.Text = tasima.Tables[0].Rows[i]["resim"].ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {

            Veritabani_Baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=proje1.accdb");
            Veri_Adaptor = new OleDbDataAdapter("Select * from Tablo1", Veritabani_Baglanti);
            tasima = new DataSet();
            Veritabani_Baglanti.Open();
            Veri_Adaptor.Fill(tasima, "Tablo1");
            dataGridView1.DataSource = tasima.Tables["Tablo1"];
            Veritabani_Baglanti.Close();
            int i = 0;

            if (i == tasima.Tables[0].Rows.Count - 1)
            {
                i = 0;
                i++; textBox1.Text = tasima.Tables[1].Rows[i]["h_tc"].ToString();
                textBox2.Text = tasima.Tables[2].Rows[i]["h_adi"].ToString();
                textBox3.Text = tasima.Tables[3].Rows[i]["h_soyadi"].ToString();
                textBox4.Text = tasima.Tables[4].Rows[i]["h_telefonu"].ToString();
                textBox5.Text = tasima.Tables[5].Rows[i]["h_mail"].ToString();
                textBox6.Text = tasima.Tables[6].Rows[i]["h_adres"].ToString();
                textBox7.Text = tasima.Tables[7].Rows[i]["h_yatis_tarihi"].ToString();
                textBox8.Text = tasima.Tables[8].Rows[i]["h_cikis_tarihi"].ToString();
                textBox9.Text = tasima.Tables[9].Rows[i]["h_ucret"].ToString();
                textBox13.Text = tasima.Tables[10].Rows[i]["resim"].ToString();
            }
            else { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label12.Left > -340)
            {
                label12.Left -= 8;

            }
            else
            {
                label12.Left = 900;
            }
        }
    }
}



     





