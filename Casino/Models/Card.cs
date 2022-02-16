using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Models
{
    class Card
    {
        private int value { get; set; }
        private string name { get; set; }
        private Suit suit { get; set; }
        private Color color { get; set; }
        public enum Suit { Hearts, Spades, Diamonds, Clubs }
        public enum Color { Black, Red }

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

        public string getCardImage()
        {
            string image = "Resources/Cards/card" + suit;
            if (value == 13)
            {
                image += "K";
            } else if (value == 12) 
            {
                image += "Q";
            } else if (value == 11)
            {
                image += "J";
            } else if (value == 1)
            {
                image += "A";
            } else
            {
                image += value.ToString();
            }
            image += ".png";
            
            return image;
        }
    }
}
