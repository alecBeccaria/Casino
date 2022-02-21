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


    }
}
