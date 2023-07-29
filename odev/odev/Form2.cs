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
    public partial class Form2 : Form
    {
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=datados1.accdb");
        OleDbCommand km = new OleDbCommand();
        OleDbDataAdapter ar = new OleDbDataAdapter();
        DataSet dset = new DataSet();


        public Form2()
        {
            InitializeComponent();
        }

        void list()
        {
            baglan.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from veri", baglan);
            adtr.Fill(dset, "veri");
            dataGridView1.DataSource = dset.Tables["veri"];
            adtr.Dispose();
            baglan.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            list();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" )
            {
                km.Connection = baglan;
                km.CommandText = "Insert Into veri(mus_adi,cep_telefon,urun_adi,urun_sayi,brm_fiyat,top_borc,resim) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox10.Text + "')";
                baglan.Open();
                km.ExecuteNonQuery();
                km.Dispose();
                baglan.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                dset.Clear();
                list();
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
           
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            km = new OleDbCommand();
            baglan.Open();
            km.Connection = baglan;
            km.CommandText = "update veri set mus_adi='" + textBox1.Text + "', cep_telefon='" + textBox2.Text + "', urun_adi='" + textBox3.Text + "', urun_sayi='" + textBox4.Text + "', brm_fiyat='" + textBox5.Text + "', top_borc='" + textBox6.Text + "', resim='" + textBox10.Text + "'  where s_no=" + textBox7.Text + "";
            km.ExecuteNonQuery();
            baglan.Close();
            dset.Clear();
            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "deneme";
            textBox2.Text = "deneme";
            textBox3.Text = "deneme";
            textBox4.Text = "deneme";
            textBox5.Text = "deneme";
            textBox6.Text = "deneme";
            textBox10.Text = "deneme";
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult k;
            k = MessageBox.Show("Silmek İstiyor Musun ?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (k == DialogResult.Yes)
            {
                baglan.Open();
                km.Connection = baglan;
                km.CommandText = "delete from veri where s_no=" + textBox9.Text + "";
                km.ExecuteNonQuery();
                km.Dispose();
                baglan.Close();
                dset.Clear();
                list();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f2 = new Form3();
            f2.Show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            baglan = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=datados1.accdb");
            ar = new OleDbDataAdapter("Select * from veri where mus_adi like '%" + textBox8.Text + "%'", baglan);
            dset = new DataSet();
            baglan.Open();
            ar.Fill(dset, "veri");
            dataGridView1.DataSource = dset.Tables["veri"];
            baglan.Close();

            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstiyor Musun ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {

            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox7.Text = openFileDialog1.FileName;
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();




        }
    }    
}

