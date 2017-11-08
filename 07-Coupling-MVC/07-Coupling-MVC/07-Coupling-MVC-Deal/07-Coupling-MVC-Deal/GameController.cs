using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Coupling_MVC_CardConcepts;

namespace Coupling_MVC_Deal
{
    // controls the operation of the "game":
    public class GameController
    {
        private List<Observer> observers = new List<Observer>();  // registry of event handlers
        private Deck d; private Hand h;  // handles to Model objects

        public GameController(Deck d, Hand h) { this.d = d; this.h = h; }

        // register(f) adds event-handler method  f  to the registry:
        public void register(Observer f) { observers.Add(f); }

        // handles request to deal another card from the deck to the hand and show the results:
        public void handle(object sender, EventArgs e)
        {
            h.add(d.deal());
            foreach (Observer m in observers) { m(); }
        }
    }
}
