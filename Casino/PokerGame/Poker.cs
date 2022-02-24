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

        

        public string url { get; set; }
        public void initialize()
        {
            deck = new Deck();
            List<Card> cardList = deck.getDeck();
            Trace.WriteLine(cardList[0].suit.ToString());
            Trace.WriteLine(cardList[0].value.ToString());
            Trace.WriteLine(cardList[0].name.ToString());

            deck.shuffleDeck();
            

        }

    }
}
