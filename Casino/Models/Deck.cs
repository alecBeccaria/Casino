using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Casino.Models
{
    class Deck
    {
        private List<Card> deck = new List<Card>();

        private string[] cardNames = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };




        public Deck()
        {
            createDeck();
            setCardImages();
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

        public void setCardImages()
        {

            foreach (Card card in deck)
            {

                Image image = new Image();

                if (card.name.Equals("Ace"))
                {
                    image.Source = new BitmapImage(
                    new Uri($"pack://application:,,,/Resources/BlackJack/Cards/card{card.suit.ToString()}A.png"));
                }
                else if (card.name.Equals("Jack"))
                {
                    image.Source = new BitmapImage(
                    new Uri($"pack://application:,,,/Resources/BlackJack/Cards/card{card.suit.ToString()}J.png"));
                }
                else if (card.name.Equals("King"))
                {
                    image.Source = new BitmapImage(
                    new Uri($"pack://application:,,,/Resources/BlackJack/Cards/card{card.suit.ToString()}K.png"));
                }
                else if (card.name.Equals("Queen"))
                {
                    image.Source = new BitmapImage(
                    new Uri($"pack://application:,,,/Resources/BlackJack/Cards/card{card.suit.ToString()}Q.png"));
                }
                else
                {
                    string suit = card.suit.ToString();
                    
                    image.Source = new BitmapImage(
                    new Uri($"pack://application:,,,/Resources/BlackJack/Cards/card{suit}{card.value.ToString()}.png"));

                }

                card.image = image;


            }
        }

        public List<Card> getDeck()
        {
            return deck;
        }
    }


}
