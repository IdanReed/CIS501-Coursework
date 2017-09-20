using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces_CardConcepts; // link to model classes

namespace Interfaces_Naive_Form
{
    // The main Form:
    public partial class Form1 : Form
    {
        // the data structures:
        private Deck d = new Deck();
        private Hand h = new Hand();

        public Form1()
        {
            InitializeComponent();
        }

        // the algorithm:
        // handles  button1  click by computing a new card to add to hand, h.
        private void button1_Click(object sender, EventArgs e)
        {
            h.add(d.deal());
            label1.Text = h.ToString();
            //Refresh();                 // show what was done
        }
    }
}
