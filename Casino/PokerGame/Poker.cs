using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Models;

namespace Casino.PokerGame
{
    class Poker
    {
        private Deck deck { get; set; } 
        public void initialize()
        {
            deck = new Deck();
            deck.shuffleDeck();
        }
    }
}
