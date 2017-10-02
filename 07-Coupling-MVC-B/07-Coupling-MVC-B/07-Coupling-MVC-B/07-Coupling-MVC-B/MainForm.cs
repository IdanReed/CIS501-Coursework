using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Coupling_MVC_CardConcepts;

namespace Coupling_MVC_B
{   // holds the input button and displays the current hand of cards:
    public partial class MainForm : Form
    {
        Hand h;  // handle to model
        InputHandler han;

        public MainForm(InputHandler han, Hand h)
        {
            this.h = h;
            this.han = han;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        // called when button clicked:
        public void button1_Click(object sender, EventArgs e)
        {
            han(sender, e);
        }

        // updates the display of the cards in the Hand:
        public void showCards()
        { label1.Text = "My hand:\n" + h.ToString(); Refresh(); }
    }
}
