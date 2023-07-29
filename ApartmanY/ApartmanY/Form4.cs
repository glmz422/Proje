using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmanY
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
            
        }

        private void iTalk_Button_22_Click(object sender, EventArgs e)
        {
           
        }

        private void iTalk_Button_23_Click(object sender, EventArgs e)
        {
            
        }

        private void iTalk_Button_15_Click(object sender, EventArgs e)
        {
           
        }

        private void iTalk_Button_15_Click_1(object sender, EventArgs e)
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

        private void iTalk_Button_21_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void iTalk_Button_22_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f2 = new Form3();
            f2.Show();
        }

        private void iTalk_Button_23_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f2 = new Form7();
            f2.Show();
        }
    }
}
