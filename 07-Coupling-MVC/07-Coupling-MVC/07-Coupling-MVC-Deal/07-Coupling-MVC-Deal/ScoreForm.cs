using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Coupling_MVC_CardConcepts;

namespace Coupling_MVC_Deal
{
    public partial class ScoreForm : Form
    {
        Hand h;  // handle to the Model

        public ScoreForm(Hand h)
        {
            this.h = h;
            InitializeComponent();
        }

        // consults the Hand (Model) for the current score and displays it:
        public void showScore()
        {
            label1.Text = "Score = " + h.BJscore();
            Refresh();
        }
    }
}
