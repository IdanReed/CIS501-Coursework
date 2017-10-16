using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Multi_Threaded_B
{
    public partial class Intruder : Form
    {
        private FileController c;

        public Intruder(FileController c)
        {
            this.c = c;
            InitializeComponent();
            button1.Text = "Make Trouble!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.close(this);
            
            label1.Text = "I closed someone else's file\n(and they don't know it)!";
        }
    }
}
