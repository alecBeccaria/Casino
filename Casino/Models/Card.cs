using System.Collections.Generic;
using System.Windows.Controls;


namespace Casino.Models
{
    class Card
    {
        public int value { get; set; }
        public string name { get; set; }
        public Suit suit { get; set; }
        public Color color { get; set; }
        public enum Suit { Hearts, Spades, Diamonds, Clubs }
        public enum Color { Black, Red }

        public Image image { get; set; }

       


        public Card()
        {

        }

        public Card(int value, string name, Suit suit, Color color)
        {
            this.value = value;
            this.name = name;
            this.suit = suit;
            this.color = color;
        }




    }
}
