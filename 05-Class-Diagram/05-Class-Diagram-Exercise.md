# Exercise: Class Diagram

## Tasks

Open the provided card concepts UML class diagram. Modify the diagram and do
the following:

1. Finish class Deck

   ```c#
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
   ```

2. Define class Hand

   ```c#
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
   ```

3. Define enumeration Count

   ```c#
    public enum Count { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
   ```

4. Attach dependencies

5. Generate code
   (right-click on diagram and select "Generate Code";
    you need to select "Yes" when asked for code template)

6. Look at the generated code and adjust it


## Submission

To submit, copy the folder containing this file to your local GitHub repository
for the course, and then commit and push your modified solutions to GitHub
(see the  
[course note on Git/GitHub](http://softwarearch.santoslab.org/01-tooling/index.html#git-github)).
