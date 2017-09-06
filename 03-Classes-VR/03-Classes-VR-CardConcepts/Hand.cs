using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes_VR_CardConcepts
{

    // class for constructing a player's hand of cards
    public class Hand
    {

        private List<Card> h;  // the cards in the hand

        public Hand() { h = new List<Card>(); }

        // adds Card c to the hand
        public void add(Card c) { h.Add(c); }

        // removes the Card with Suit s and Count c from the hand (if it's there)
        public bool remove(Count c, Suit s)
        {
            bool ok = false;
            foreach (Card cd in h)
            {
                if (cd.count == c && cd.suit == s)
                {
                    h.Remove(cd); ok = true;
                    break;
                }
            }
            return ok;
        }

        // returns the count of how many cards are in the hand
        public int howManyCards() { return h.Count; }

        // returns the Blackjack score of the hand
        public int BJscore() {
            int sum = 0;
            foreach(Card card in h)
            {
                sum += card.BJvalue();
            }
            return sum;
        }

        // returns a string that lists the cards in the hahd
        public override string ToString()
        {
            string ans = "";
            foreach (Card c in h)
            {
                ans = ans + c.ToString() + "\n";
            }
            return ans;
        }
    }
}
