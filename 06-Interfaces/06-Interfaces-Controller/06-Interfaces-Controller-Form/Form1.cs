using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces_CardConcepts;

namespace Interfaces_Controller_Form
{
    public partial class Form1 : Form
    {
        // handles to controller and model:
        private GameController c;
        private Hand h;

        public Form1(GameController c, Hand h)
        {
            this.c = c; this.h = h;
            InitializeComponent();
        }

        // handles  button1  click: calls controller to execute algorithm
        // and then refreshes the view  (label1) with the new hand and score
        private void button1_Click(object sender, EventArgs e)
        {
            c.handle();
            label1.Text = h.ToString();
        }
    }
}
