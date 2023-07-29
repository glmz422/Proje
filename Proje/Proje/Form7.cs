using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        
        private void Form7_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 1;         
            progressBar1.Hide();
            progressBar1.Step = 10;
            timer1.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        int ticks = 0;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks+=2;
            progressBar1.Value = ticks;
            if(ticks==100)
            {
                timer1.Enabled = false;
                ticks = 0;

                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
