using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.Models
{
    public class BlackJack
    {
        private Deck deck = new Deck();
        private BJPlayer player = new BJPlayer();
        private BJPlayer house = new BJPlayer();
        private bool playerActive = true;
        private bool houseActive = true;

        public void NewGame()
        {
            //  Clear Deck and Hands
            deck.ClearDeck();
            player.GetHand().ClearDeck();
            house.GetHand().ClearDeck();

            //  New Deck
            deck.CreateDeck();
            deck.ShuffleDeck();
        }

        public void PlayGame()
        {
            do
            {
                PlayerTakeTurn();
            } while (playerActive);

            do
            {
                HouseTakeTurn();
            } while (houseActive);
        }

        public void PlayerTakeTurn()
        {
            //int play = GetConsoleInt("Hit? ", 0, 1);
            
            //if (play == 1) {
                Card current = deck.GetDeck()[deck.GetDeck().Count() - 1];
                deck.GetDeck().Remove(current);
                player.AddCardToHand(current);
                //player.PrintHand();
            //} else
            //{
                //playerActive = false;
            //}

        }

        private void HouseTakeTurn()
        {

        }

        private static int GetConsoleInt(string message, int min, int max)
        {
            bool success = false;

            int typedValue;
            do
            {
                Console.Write(message);
                //  Attempt to parse it.
                success = int.TryParse(Console.ReadLine(), out typedValue);

                //  If parse was successful, validate its in range. If any fail, it will stop evaluating
                success = success && typedValue >= min && typedValue <= max;

                //  Check if all was good.
                if (!success)
                {
                    Console.WriteLine("You entered an invalid value. Must be between {0} and {1} and a valid integer.", min, max);
                }


            } while (!success);

            return typedValue;
        }

        public Deck GetDeck()
        {
            return deck;
        }

        public BJPlayer GetPlayer()
        {
            return player;
        }
    }
}
