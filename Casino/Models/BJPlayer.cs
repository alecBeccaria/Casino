using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Models
{
    class BJPlayer : Player
    {
        private Deck hand = new Deck();

        public Deck GetHand()
        {
            return hand;
        }
        public void SetHand(Deck d)
        {
            hand = d;
        }

        public void AddCardToHand(Card c)
        {
            hand.GetDeck().Add(c);
        }

        public int GetHandValue()
        {
            int score = 0;
            foreach(Card c in hand.GetDeck())
            {
                int val = c.GetValue();
                //  Ace conditions
                if (c.GetValue() == 1)
                {
                    if ((score + 11) > 21)
                    {
                        score += 1;
                    } else
                    {
                        score += 11;
                    }
                } else
                {
                    score += c.GetValue();
                }
            }
            return score;
        }

        public void PrintHand()
        {
            foreach (Card c in hand.GetDeck())
            {
                Console.WriteLine(c.PrintCard());
            }
        }
    }
}
