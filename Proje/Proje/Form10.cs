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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        OleDbConnection con;


        private void Form10_Load(object sender, EventArgs e)
        {

            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=proje1.accdb");
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from Tablo1 ORDER BY id ASC ", con);
            da.Fill(dt);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "sehir";
            comboBox1.DataSource = dt;

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from Tablo3 where sehir= " + comboBox1.SelectedValue, con);
                da.Fill(dt);
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "g_yeri";
                comboBox2.DataSource = dt;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          


         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 form = new Form9();
            form.Show();
        }

    
    }  
}







