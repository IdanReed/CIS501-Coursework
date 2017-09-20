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

namespace Interfaces_Delegate_Form
{

    public partial class Form1 : Form
    {
        // handles to event handler and model:
        private EventHandler f;   // method  f  has type  Eventhandler
        private Hand h;

        public Form1(EventHandler f, Hand h)
        {
            this.f = f; this.h = h;
            InitializeComponent();
        }

        // handles  button1  click: calls controller to execute algorithm
        // and then resets the view  (label1)
        private void button1_Click(object sender, EventArgs e)
        {
            f(sender, e);  // call Eventhandler  f  to do its work
            label1.Text = h.ToString();
        }
    }
}
