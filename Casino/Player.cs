using Casino.Models;
using System;

namespace Casino
{
    public static class Player
    {
        public static int cash { get; set; } = 1000; 
        public static int chips { get; set; } = 1000;

        private static Deck hand = new Deck();

        public static Deck GetHand()
        {
            return hand;
        }
        public static void SetHand(Deck d)
        {
            hand = d;
        }

        public static void AddCardToHand(Card c)
        {
            hand.GetDeck().Add(c);
        }
    }
}