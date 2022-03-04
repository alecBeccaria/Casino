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

        public int pot { get; set; } = 0;

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
            //fixFaceCardValues();
            deck.shuffleDeck();
            List<Card> cardList = deck.getDeck();
            for (int i = 0; i < cardList.Count; i++)
            {
                Trace.WriteLine($"{i+1} " + cardList[i].value.ToString() +" " + cardList[i].suit.ToString()+ " " + cardList[i].name.ToString());

            }
        }

        

        public List<Card> getNextHand(int numberOfCards)
        {
            List<Card> hand = new List<Card>();
            int toAddToDeckIndex = 0;

            for(int i = deckIndex; i < deckIndex+numberOfCards; i++)
            {
                if(i == deck.getDeck().Count)
                {
                    deck.shuffleDeck();
                    deckIndex = 0;
                    i = 0;
                }
                hand.Add(deck.getDeck()[i]);
                toAddToDeckIndex++;
            }
            deckIndex += toAddToDeckIndex;

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
