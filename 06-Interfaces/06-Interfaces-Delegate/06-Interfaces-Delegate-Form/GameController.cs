using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces_CardConcepts;

namespace Interfaces_Delegate_Form
{
    class GameController
    {
        // handles to model (entity) objects
        private Deck d; private Hand h;

        public GameController(Deck d, Hand h) { this.d = d; this.h = h; }

        // handles event that requests one more card be added to hand:
        public void handle(object sender, EventArgs e)
        {
            h.add(d.deal());
        }
    }
}
