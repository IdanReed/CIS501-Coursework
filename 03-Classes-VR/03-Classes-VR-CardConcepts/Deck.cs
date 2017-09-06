using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes_VR_CardConcepts
{

    // class for constructing a deck of cards
    public class Deck
    {

        private List<Card> d;  // the list of cards still in the deck

        // random number generator used to select a random card from the deck:
        private Random R = new Random();

        public Deck()
        {
            d = new List<Card>();
            // generate all combinations of Suits and Counts:
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Count c in Enum.GetValues(typeof(Count)))
                {
                    d.Add(new Card(c, s));
                }
            }
        }

        // returns a card randomly selected from the deck
        public Card deal()
        {
            if (d.Count > 0)
            {
                int index = R.Next(0, d.Count);
                Card ans = d[index];
                d.RemoveAt(index);
                return ans;
            }
            else { throw new Exception(); }
        }
    }
}
