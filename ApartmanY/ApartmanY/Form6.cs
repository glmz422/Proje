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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection Veritabani_Baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=apartman1.accdb");
        OleDbCommand Veri_Km = new OleDbCommand();
        OleDbDataAdapter Veri_Adtr = new OleDbDataAdapter();
        DataSet dset = new DataSet();
        DataSet veri_set;

        private void iTalk_Button_11_Click(object sender, EventArgs e)
        {
            if (iTalk_TextBox_Small1.Text!= "" && iTalk_TextBox_Small2.Text != "")
            {
                Veri_Km.Connection = Veritabani_Baglan;



                Veri_Km.CommandText = "Insert Into sifre(k_adi,k_sifre) Values ('" + iTalk_TextBox_Small1.Text + "','" + iTalk_TextBox_Small2.Text + "')";
                Veritabani_Baglan.Open();
                Veri_Km.ExecuteNonQuery();
                Veri_Km.Dispose();
                Veritabani_Baglan.Close();
                MessageBox.Show("Kayıt Tamamlandı!");

                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
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
            Form1 form = new Form1();
            form.Show();
        }
    }
}
