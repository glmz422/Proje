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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection Veritabani_Baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=apartman1.accdb");
        OleDbCommand Veri_Km = new OleDbCommand();
        OleDbDataAdapter Veri_Adtr = new OleDbDataAdapter();
        DataSet dset = new DataSet();
        DataSet veri_set;

        void gstr()
        {
            Veri_Adtr = new OleDbDataAdapter("Select * from kisi", Veritabani_Baglan);
            veri_set = new DataSet();

            Veritabani_Baglan.Open();

            Veri_Adtr.Fill(veri_set, "kisi");
            dataGridView1.DataSource = veri_set.Tables["kisi"];

            Veritabani_Baglan.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            gstr();
            iTalk_TextBox_Small11.Text = iTalk_TextBox_Small1.Text + " " + iTalk_TextBox_Small2.Text;
        }

        private void iTalk_ThemeContainer1_Click(object sender, EventArgs e)
        {
            
        }

        private void iTalk_Button_11_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void iTalk_Button_11_Click_1(object sender, EventArgs e)
        {
            if (iTalk_TextBox_Small1.Text != "" && iTalk_TextBox_Small1.Text != "" && iTalk_TextBox_Small2.Text != "" && iTalk_TextBox_Small3.Text != "" && iTalk_TextBox_Small4.Text != "" && iTalk_TextBox_Small5.Text != "" && iTalk_TextBox_Small6.Text != "")
            {
                Veri_Km.Connection = Veritabani_Baglan;



                Veri_Km.CommandText = "Insert Into kisi(K_isim,K_soyisim,K_telefon,K_mail,K_cinsiyet,K_dogum_t,K_resim,K_baglan,K_ID) Values ('" + iTalk_TextBox_Small1.Text + "','" + iTalk_TextBox_Small2.Text + "','" + iTalk_TextBox_Small3.Text + "','" + iTalk_TextBox_Small4.Text + "','" + iTalk_TextBox_Small5.Text + "','" + iTalk_TextBox_Small6.Text + "','" + iTalk_TextBox_Small10.Text + "','" + iTalk_TextBox_Small11.Text + "','" + iTalk_TextBox_Small12.Text + "' )";
                Veritabani_Baglan.Open();
                Veri_Km.ExecuteNonQuery();
                Veri_Km.Dispose();
                Veritabani_Baglan.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                gstr();


            }
            else
            {
                MessageBox.Show("Boş alan geçmeyiniz!");
            }
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            gstr();
            iTalk_TextBox_Small11.Text = iTalk_TextBox_Small1.Text + " " + iTalk_TextBox_Small2.Text;


        }

        private void iTalk_Button_12_Click(object sender, EventArgs e)
        {
            Veri_Km = new OleDbCommand();
            Veritabani_Baglan.Open();
            Veri_Km.Connection = Veritabani_Baglan;
            Veri_Km.CommandText = "update kisi set K_isim='" + iTalk_TextBox_Small1.Text + "', K_soyisim='" + iTalk_TextBox_Small2.Text + "', K_telefon='" + iTalk_TextBox_Small3.Text + "', K_mail='" + iTalk_TextBox_Small4.Text + "', K_cinsiyet='" + iTalk_TextBox_Small5.Text + "', K_dogum_t='" + iTalk_TextBox_Small6.Text + "', K_resim='" + iTalk_TextBox_Small10.Text + "', K_ID='" + iTalk_TextBox_Small12.Text + "', K_baglan='" + iTalk_TextBox_Small11.Text + "'  where ID=" + iTalk_TextBox_Small7.Text + "";
            Veri_Km.ExecuteNonQuery();
            Veritabani_Baglan.Close();
            dset.Clear();
            gstr();
        }

        private void iTalk_Button_13_Click(object sender, EventArgs e)
        {
            DialogResult s;
            s = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (s == DialogResult.Yes)
            {
                Veritabani_Baglan.Open();
                Veri_Km.Connection = Veritabani_Baglan;
                Veri_Km.CommandText = "delete from kisi where ID=" + iTalk_TextBox_Small8.Text + "";
                Veri_Km.ExecuteNonQuery();
                Veri_Km.Dispose();
                Veritabani_Baglan.Close();
                dset.Clear();
                gstr();

            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            iTalk_TextBox_Small1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            iTalk_TextBox_Small2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            iTalk_TextBox_Small3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            iTalk_TextBox_Small4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            iTalk_TextBox_Small5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            iTalk_TextBox_Small6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            iTalk_TextBox_Small7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            iTalk_TextBox_Small8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            iTalk_TextBox_Small10.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            iTalk_TextBox_Small11.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            iTalk_TextBox_Small12.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();


        }

        private void iTalk_TextBox_Small9_TextChanged(object sender, EventArgs e)
        {
            Veritabani_Baglan = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=apartman1.accdb");
            Veri_Adtr = new OleDbDataAdapter("Select * from kisi where K_isim like '%" + iTalk_TextBox_Small9.Text + "%'", Veritabani_Baglan);
            dset = new DataSet();
            Veritabani_Baglan.Open();
            Veri_Adtr.Fill(dset, "kisi");
            dataGridView1.DataSource = dset.Tables["kisi"];
            Veritabani_Baglan.Close();
        }

        private void iTalk_Button_14_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                iTalk_TextBox_Small10.Text = openFileDialog1.FileName;
            }

            int s = 92;
            string harf = ((char)s).ToString();

            string yazi = iTalk_TextBox_Small10.Text; string metin = "";
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

        private void iTalk_TextBox_Small5_TextChanged(object sender, EventArgs e)
        {

        }

        private void iTalk_Button_15_Click(object sender, EventArgs e)
        {
            DialogResult cık;
            cık = MessageBox.Show("Çıkmak İstiyor Musunuz ?", "Çık", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cık == DialogResult.No)
            {

            }
            if (cık == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void iTalk_Button_16_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
        }

        private void iTalk_Button_17_Click(object sender, EventArgs e)
        {
            iTalk_TextBox_Small1.Text = "";
            iTalk_TextBox_Small2.Text = "";
            iTalk_TextBox_Small3.Text = "";
            iTalk_TextBox_Small4.Text = "";
            iTalk_TextBox_Small5.Text = "";
            iTalk_TextBox_Small6.Text = "";
            iTalk_TextBox_Small7.Text = "";
            iTalk_TextBox_Small8.Text = "";
        }

        private void iTalk_TextBox_Small11_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void iTalk_TextBox_Small1_TextChanged(object sender, EventArgs e)
        {
            iTalk_TextBox_Small11.Text = iTalk_TextBox_Small1.Text + " " + iTalk_TextBox_Small2.Text;
        }

        private void iTalk_TextBox_Small2_TextChanged(object sender, EventArgs e)
        {
            iTalk_TextBox_Small11.Text = iTalk_TextBox_Small1.Text + " " + iTalk_TextBox_Small2.Text;
        }

        private void iTalk_ThemeContainer1_Click_1(object sender, EventArgs e)
        {

        }
    }

}
