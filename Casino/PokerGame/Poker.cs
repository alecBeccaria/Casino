using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Models;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Casino.PokerGame
{
    class Poker
    {
        public Deck deck { get; set; }

        public Dictionary<string, int> potValues;

        public bool[] heldCards = new bool[] { false, false, false, false, false };



        public string url { get; set; }
        public void initialize()
        {
            deck = new Deck();
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
            
      


            List<Card> cardList = deck.getDeck();
            Trace.WriteLine(cardList[0].suit.ToString());
            Trace.WriteLine(cardList[0].value.ToString());
            Trace.WriteLine(cardList[0].name.ToString());

            deck.shuffleDeck();
            



        }

    }
}
