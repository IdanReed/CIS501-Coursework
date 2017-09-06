using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intro_SoftwareArch_GUI
{
    public partial class Form1 : Form
    {
        int m;
        int n;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(uxTextBox1.Text);
            if (val > 10 || val < 0)
            {
                MessageBox.Show("Input is out of range");
                Application.Exit();
            }
            m = val;

            Random r = new Random();
            int min = 0;
            int max = 10 - Convert.ToInt32(m);
            n = r.Next(min, max + 1);

            MessageBox.Show("I guess int, N, in range 0.." + Convert.ToString(max));
            uxTextBox1.Enabled = false;
            uxButton1.Enabled = false;

            uxTextBox2.Enabled = true;
            uxButton2.Enabled = true;

        }

        private void uxButton2_Click(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(uxTextBox2.Text);
            int sum = m + n + p;

            if (sum == 10)
            {
                MessageBox.Show("You win! (n = " + n + ")");
            }
            else
            {
                MessageBox.Show("You lose! (n = " + n + ")");
            }
            Application.Exit();
        }
    }
}
