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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=demirbas.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from Tablo1", baglanti);
            adtr.Fill(ds, "Tablo1");
            dataGridView1.DataSource = ds.Tables["Tablo1"];
            adtr.Dispose();
            baglanti.Close();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (c == DialogResult.Yes)
            {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "delete from Tablo1 where s_no=" + textBox10.Text + "";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                ds.Clear();
                listele();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into Tablo1(urun_kodu,urun_adi,alan_kisi,a_tarihi,g_suresi,durum,miktar,demirbas_no,b_fiyati,resim) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox13.Text + "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                ds.Clear();
                listele();
            }
            else
            {
                MessageBox.Show("Boş alan geçmeyiniz!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update Tablo1 set urun_kodu='" + textBox1.Text + "', urun_adi='" + textBox2.Text + "', alan_kisi='" + textBox3.Text + "', a_tarihi='" + textBox4.Text + "', g_suresi='" + textBox5.Text + "', durum='" + textBox6.Text + "', miktar='" + textBox7.Text + "', demirbas_no='" + textBox8.Text + "',  b_fiyati='" + textBox9.Text + "',  resim='" + textBox13.Text + "'  where s_no=" + textBox11.Text + "";
            komut.ExecuteNonQuery();
            baglanti.Close();
            ds.Clear();
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "deneme";
            textBox2.Text = "deneme";
            textBox3.Text = "deneme";
            textBox4.Text = "deneme";
            textBox5.Text = "deneme";
            textBox6.Text = "deneme";
            textBox7.Text = "deneme";
            textBox8.Text = "deneme";
            textBox9.Text = "deneme";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
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
            textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[10].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=demirbas.accdb");
            adtr = new OleDbDataAdapter("Select * from Tablo1 where urun_adi like '%" + textBox12.Text + "%'", baglanti);

            ds = new DataSet();
            baglanti.Open();
            adtr.Fill(ds, "Tablo1");
            dataGridView1.DataSource = ds.Tables["Tablo1"];
            baglanti.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox7.Text = openFileDialog1.FileName;
            }
        }
    }
}
