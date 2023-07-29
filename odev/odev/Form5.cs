using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        int tic = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tic += 2;
            progressBar1.Value = tic;
            if (tic == 100)
            {
                timer1.Enabled = false;
                tic = 0;

                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 1;
            progressBar1.Step = 10;
            timer1.Start();
            progressBar1.Hide();
        }
    }
}
