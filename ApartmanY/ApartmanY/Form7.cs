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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        OleDbConnection Veritabani_Baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=apartman1.accdb");
        OleDbCommand Veri_Km = new OleDbCommand();
        OleDbDataAdapter Veri_Adtr = new OleDbDataAdapter();
        DataSet dset = new DataSet();
        DataSet veri_set;

        private void iTalk_ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Veritabani_Baglan= new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=apartman1.accdb");
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from kisi ORDER BY K_ID ASC ", Veritabani_Baglan);
            da.Fill(dt);
            iTalk_ComboBox1.ValueMember = "K_ID";
            iTalk_ComboBox1.DisplayMember = "K_baglan";
            iTalk_ComboBox1.DataSource = dt;
        }

        private void iTalk_Button_11_Click(object sender, EventArgs e)
        {

        }

        private void iTalk_ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (iTalk_ComboBox1.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from bilgi where K_baglan like '%" + iTalk_ComboBox1.SelectedValue + "%'", Veritabani_Baglan);
                da.Fill(dt);
                iTalk_ComboBox2.ValueMember = "K_ID";
                iTalk_ComboBox2.DisplayMember = "K_borc";
                iTalk_ComboBox2.DataSource = dt;
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
            Form4 form = new Form4();
            form.Show();
        }
    }
}
