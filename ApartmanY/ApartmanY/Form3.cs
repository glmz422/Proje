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
    public partial class Form3 : Form
    {
        public Form3()
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
            Veri_Adtr = new OleDbDataAdapter("Select * from bilgi", Veritabani_Baglan);
            veri_set = new DataSet();

            Veritabani_Baglan.Open();

            Veri_Adtr.Fill(veri_set, "bilgi");
            dataGridView1.DataSource = veri_set.Tables["bilgi"];

            Veritabani_Baglan.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            iTalk_TextBox_Small1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            iTalk_TextBox_Small2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            iTalk_TextBox_Small3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            iTalk_TextBox_Small4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            iTalk_TextBox_Small5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            iTalk_TextBox_Small6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            iTalk_TextBox_Small7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            gstr();
        }

        private void iTalk_Button_11_Click(object sender, EventArgs e)
        {
            if (iTalk_TextBox_Small1.Text != "" && iTalk_TextBox_Small2.Text != "" && iTalk_TextBox_Small3.Text != "" && iTalk_TextBox_Small4.Text != "" && iTalk_TextBox_Small7.Text != "" )
            {
                Veri_Km.Connection = Veritabani_Baglan;



                Veri_Km.CommandText = "Insert Into bilgi(K_kat,K_daire,K_borc,K_kisi_sayi,K_baglan) Values ('" + iTalk_TextBox_Small1.Text + "','" + iTalk_TextBox_Small2.Text + "','" + iTalk_TextBox_Small3.Text + "','" + iTalk_TextBox_Small4.Text + "','" + iTalk_TextBox_Small7.Text + "' )";
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

        private void iTalk_Button_16_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
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

        private void iTalk_Button_12_Click(object sender, EventArgs e)
        {
            Veri_Km = new OleDbCommand();
            Veritabani_Baglan.Open();
            Veri_Km.Connection = Veritabani_Baglan;
            Veri_Km.CommandText = "update bilgi set K_kat='" + iTalk_TextBox_Small1.Text + "', K_daire='" + iTalk_TextBox_Small2.Text + "', K_borc='" + iTalk_TextBox_Small3.Text + "', K_kisi_sayi='" + iTalk_TextBox_Small4.Text + "', K_baglan='" + iTalk_TextBox_Small7.Text + "'  where Id=" + iTalk_TextBox_Small5.Text + "";
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
                Veri_Km.CommandText = "delete from bilgi where Id=" + iTalk_TextBox_Small6.Text + "";
                Veri_Km.ExecuteNonQuery();
                Veri_Km.Dispose();
                Veritabani_Baglan.Close();
                dset.Clear();
                gstr();

            }
        }

        private void iTalk_TextBox_Small9_TextChanged(object sender, EventArgs e)
        {
            Veritabani_Baglan = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=apartman1.accdb");
            Veri_Adtr = new OleDbDataAdapter("Select * from bilgi where K_kat like '%" + iTalk_TextBox_Small9.Text + "%'", Veritabani_Baglan);
            dset = new DataSet();
            Veritabani_Baglan.Open();
            Veri_Adtr.Fill(dset, "bilgi");
            dataGridView1.DataSource = dset.Tables["bilgi"];
            Veritabani_Baglan.Close();
        }

        private void iTalk_Button_14_Click(object sender, EventArgs e)
        {
            iTalk_TextBox_Small1.Text = "";
            iTalk_TextBox_Small2.Text = "";
            iTalk_TextBox_Small3.Text = "";
            iTalk_TextBox_Small4.Text = "";
        }

        private void iTalk_ThemeContainer1_Click(object sender, EventArgs e)
        {

        }
    }
}
