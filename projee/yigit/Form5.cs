using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yigit
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        int tik = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tik += 2;
            progressBar1.Value = tik;
            if (tik == 100)
            {
                timer1.Enabled = false;
                tik = 0;

                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 1;
            progressBar1.Hide();
            progressBar1.Step = 10;
            timer1.Start();
        }
    }
}
