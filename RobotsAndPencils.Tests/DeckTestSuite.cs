using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RobotsAndPencils.Model;
using System.Collections.Generic;

namespace RobotsAndPencils.Tests
{
    [TestClass]
    public class DeckTestSuite
    {
        const int NUM_CARDS_IN_DECK = 52;

        [TestMethod]
        public void DoesTheDeckContain52Cards()
        {
            //Deck
            Deck testDeck = new Deck();

            Assert.AreEqual(NUM_CARDS_IN_DECK, testDeck.Available.Count);
        }

        [TestMethod]
        public void DoesTheDeckDealACard()
        {
            //Deck
            Deck testDeck = new Deck();

            //Unshuffled deck deals 2 Clubs 
            Card expectedCard = new Card(Suit.Club, Face.Two);

            Assert.AreEqual(expectedCard, testDeck.Deal());
        }

        [TestMethod]
        public void DoesTheDeckDealMultipleCards()
        {
            const int NUM_CARDS_TO_DEAL = 4;
            //Deck
            Deck testDeck = new Deck();

            //Unsuffled deck deals 2,3,4,5 clubs
            Card twoClubs = new Card(Suit.Club, Face.Two);
            Card threeClubs = new Card(Suit.Club, Face.Three);
            Card fourClubs = new Card(Suit.Club, Face.Four);
            Card fiveClubs = new Card(Suit.Club, Face.Five);

            List<Card> dealtHand = testDeck.Deal(NUM_CARDS_TO_DEAL);

            Assert.AreEqual(NUM_CARDS_TO_DEAL, dealtHand.Count);
            Assert.AreEqual(twoClubs, dealtHand[0]);
            Assert.AreEqual(threeClubs, dealtHand[1]);
            Assert.AreEqual(fourClubs, dealtHand[2]);
            Assert.AreEqual(fiveClubs, dealtHand[3]);
        }

        [TestMethod]
        public void DoesTheDeckDeal52Cards()
        {
            //Deck
            Deck testDeck = new Deck();
            List<Card> dealtHand = testDeck.Deal(NUM_CARDS_IN_DECK);

            Assert.AreEqual(testDeck.Available.Count, 0);
            Assert.AreEqual(testDeck.Dealt.Count, NUM_CARDS_IN_DECK);
            Assert.AreEqual(NUM_CARDS_IN_DECK, dealtHand.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "there are no cards left to deal")]
        public void DoesTheDeckPreventDealingMoreThan52CardsSingleDeal()
        {
            //Deck
            Deck testDeck = new Deck();
            List<Card> dealtHand = testDeck.Deal(NUM_CARDS_IN_DECK);

            //throw
            testDeck.Deal();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "there are not enough cards left to deal 2")]
        public void DoesTheDeckPreventDealingMoreThan52CardsMultiDeal()
        {
            //Deck
            Deck testDeck = new Deck();
            List<Card> dealtHand = testDeck.Deal(NUM_CARDS_IN_DECK);

            //throw
            testDeck.Deal(2);
        }

        [TestMethod]
        public void DoesTheDeckDealARandomCard()
        {
            //Deck
            Deck testDeck = new Deck();
            testDeck.Shuffle();

            //Unshuffled deck deals 2 Clubs 
            Card twoClubs = new Card(Suit.Club, Face.Two);
            Card dealtCard = testDeck.Deal();


            //Non-deterministic, but it will be rare
            Assert.AreNotEqual(twoClubs, dealtCard);
        }
    }
}
