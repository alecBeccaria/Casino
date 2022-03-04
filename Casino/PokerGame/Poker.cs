using Casino.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Casino.PokerGame
{
    class Poker : INotifyPropertyChanged
    {
        public Deck deck { get; set; }

        public Deck discardDeck { get; set; }

        public int deckIndex { get; set; } = 0;

        private Dictionary<string, int> potValues;

        

        public Dictionary<string, int> PotValues
        {
            get { return potValues; }
            set
            {
                potValues = value;
                OnPropertyChanged("potValues");
            }
        }

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

        public List<Card> getNextHand()
        {
            
            List<Card> hand = new List<Card>();
            for(int i = deckIndex; i < deckIndex+5; i++)
            {
                hand.Add(deck.getDeck()[i]);
            }

            return hand;
        }

        public void draw()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
