using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces_CardConcepts
{
    // enumerations of the Suits and Counts that a playing card can have
    public enum Suit { Spades, Hearts, Diamonds, Clubs };
    public enum Count { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };


    // class for constructing a playing card
    public class Card
    {
        public readonly Count count;
        public readonly Suit suit;

        public Card(Count a, Suit b) { count = a; suit = b; }

        // returns the int value of a card in Blackjack
        public int BJvalue()
        {
            int i = (int)count + 1;
            if (i > 10) { i = 10; }
            return i;
        }

        // returns the string value of a card
        public override string ToString() { return count + " of " + suit; }
    }


    // class for constructing a deck of cards
    public class Deck
    {
        private List<Card> d;  // the list of cards still in the deck
        // random number generator used to select a random card from the deck:
        static Random R = new Random();

        public Deck()
        {
            d = new List<Card>();
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
        public int BJscore()
        {
            int result = 0;
            foreach (Card c in h)
            {
                result += c.BJvalue();
            }
            return result;
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
