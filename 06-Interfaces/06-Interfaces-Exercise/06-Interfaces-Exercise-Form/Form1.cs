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
        

        public Form1(EventHandler f, Hand h)
        {
            this.f = f; 
            InitializeComponent();
        }

        // handles  button1  click: calls controller to execute algorithm
        // and then resets the view  (label1)
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = f(sender, e);  // call Eventhandler  f  to do its work
            
        }
    }
}
