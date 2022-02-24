using System;
using System.Collections.Generic;

namespace Casino.Models
{
    class Deck
    {
        private List<Card> deck = new List<Card>();

        private string[] cardNames = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };


        public Deck()
        {
            createDeck();
        }
        public void createDeck()
        {
            for (int i = 0; i < 13; i++)
            {
                deck.Add(new Card((i + 1), cardNames[i], Card.Suit.Spades, Card.Color.Black));
                deck.Add(new Card((i + 1), cardNames[i], Card.Suit.Clubs, Card.Color.Black));
                deck.Add(new Card((i + 1), cardNames[i], Card.Suit.Hearts, Card.Color.Red));
                deck.Add(new Card((i + 1), cardNames[i], Card.Suit.Diamonds, Card.Color.Red));
            }
        }

        public void shuffleDeck()
        {
            Random random = new Random();

            for (int i = deck.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                Card value = deck[rnd];
                deck[rnd] = deck[i];
                deck[i] = value;
            }
        }

        public List<Card> getDeck()
        {
            return deck;
        }
    }
}
