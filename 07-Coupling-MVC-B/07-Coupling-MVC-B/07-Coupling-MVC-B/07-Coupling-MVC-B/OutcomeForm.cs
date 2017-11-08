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
{   // displays if the player's hand is still winning or losing
    public partial class OutcomeForm : Form
    {
        private Hand myhand;  // handle to the model object, Hand
        public OutcomeForm(Hand h)
        {
            myhand = h;
            InitializeComponent();
        }

        // updates the display of this Form:
        public void checkScore()
        {
            if (myhand.BJscore() <= 21)
            {
                label2.Text = "WINNING";
            }
            else { label2.Text = "LOST  )-:"; }
        }
    }
}
