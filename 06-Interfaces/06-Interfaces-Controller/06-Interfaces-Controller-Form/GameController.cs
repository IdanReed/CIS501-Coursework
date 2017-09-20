using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfaces_CardConcepts;

namespace Interfaces_Controller_Form
{

    // class for constructing controller for game
    public class GameController
    {

        // handles to the model (entity) objects
        private Deck d;
        private Hand h;

        public GameController(Deck d, Hand h) { this.d = d; this.h = h; }

        // handles event that requests one more card be added to hand:
        public void handle() { h.add(d.deal()); }

    }
}
