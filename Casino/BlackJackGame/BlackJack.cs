using Casino.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BlackJackGame
{
    public class BlackJack
    {
        public Deck houseHand = new Deck();
        public Deck deck = new Deck();
        public Deck playerHand = new Deck();
        public Dictionary<string, int> potValues;

        public void NewGame()
        {
            deck.CreateDeck();
            deck.ShuffleDeck();
            houseHand.GetDeck().Clear();
            playerHand.GetDeck().Clear();

            potValues = new Dictionary<string, int>()
            {
                {"1", 0},
                {"5", 0},
                {"10", 0},
                {"20", 0},
                {"50", 0},
                {"100", 0},
                {"500", 0},
                {"1K", 0},
                {"5K", 0}

            };
            Debug.WriteLine("New Game Started");
        }

        public void DrawCard(Deck d)
        {
            Card temp = deck.GetDeck()[^1];
            d.GetDeck().Add(temp);
            deck.GetDeck().Remove(temp);
        }


        public bool isPlayerBust()
        {
            bool bust = false;
            if (GetHandValue(playerHand) > 21)
            {
                bust = true;
            }

            return bust;
        }

        public int GetHandValue(Deck d)
        {
            int score = 0;
            foreach (Card c in d.GetDeck())
            {
                int val = c.value;
                //  Ace conditions
                if (c.value == 1)
                {
                    if ((score + 11) > 21)
                    {
                        score += 1;
                    }
                    else
                    {
                        score += 11;
                    }
                } else if (c.value == 11 || c.value == 12 || c.value == 13)
                {
                    score += 10;
                } 
                else
                {
                    score += c.value;
                }
            }
            return score;
        }
    }
}
