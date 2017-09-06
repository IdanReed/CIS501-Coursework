using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes_VR_CardConcepts;

namespace Classes_VR_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Card c1 = new Card(Count.Ace, Suit.Hearts);
            Assert.AreEqual(Count.Ace, c1.count);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Card c1 = new Card(Count.Ace, Suit.Hearts);
            Assert.AreEqual(Suit.Hearts, c1.suit);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Card c1 = new Card(Count.Ace, Suit.Hearts);
            Assert.AreEqual(1, c1.BJvalue());
            Console.WriteLine(c1.ToString());
        }
        [TestMethod]
        public void TestMethod4()
        {
            Deck deck = new Deck();
            for(int count = 0; count < 24; count++)
            {
                Console.WriteLine(deck.deal());
            }
        }
        [TestMethod]
        public void TestMethod5()
        {
            Deck deck = new Deck();
            Hand hand = new Hand();
            for (int count = 0; count < 5; count++)
            {
                hand.add(deck.deal());
            }
            hand.ToString();
        }
        [TestMethod]
        public void TestMethod6()
        {
            Deck deck = new Deck();
            Hand hand = new Hand();
            for (int count = 0; count < 5; count++)
            {
                hand.add(deck.deal());
            }
            Console.WriteLine(hand.ToString());
            Console.WriteLine(hand.BJscore());
        }





    }
}
