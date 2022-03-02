using Casino.Models;
using Casino.PokerGame;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Casino
{
    /// <summary>
    /// Interaction logic for PokerControl.xaml
    /// </summary>
    public partial class PokerControl : UserControl
    {
        Poker pokerGame;

        string keyValue;




        public PokerControl()
        {

            InitializeComponent();


            pokerGame = new Poker();
            pokerGame.initialize();
            DataContext = pokerGame;
            List<Card> deck = pokerGame.deck.getDeck();
            updateBalance(0);
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        card1.Source = deck[i].image.Source;
                        break;
                    case 1:
                        card2.Source = deck[i].image.Source;
                        break;
                    case 2:
                        card3.Source = deck[i].image.Source;
                        break;
                    case 3:
                        card4.Source = deck[i].image.Source;
                        break;
                    case 4:
                        card5.Source = deck[i].image.Source;
                        break;

                }
            }
        }

        private void updateBalance(int value)
        {
            Player.chips -= value;
            txtBalance.Content = $"Balance: {Player.chips}";
        }

        private void btnHold1_Click(object sender, RoutedEventArgs e)
        {
            if (btnHold1.Content.Equals("Hold"))
            {
                pokerGame.heldCards[0] = true;
                btnHold1.Content = "un-hold";
            }
            else
            {
                pokerGame.heldCards[0] = false;
                btnHold1.Content = "Hold";
            }
        }

        private void btnHold2_Click(object sender, RoutedEventArgs e)
        {
            if (btnHold2.Content.Equals("Hold"))
            {
                pokerGame.heldCards[1] = true;
                btnHold2.Content = "un-hold";
            }
            else
            {
                pokerGame.heldCards[1] = false;
                btnHold2.Content = "Hold";
            }
        }

        private void btnHold3_Click(object sender, RoutedEventArgs e)
        {
            if (btnHold3.Content.Equals("Hold"))
            {
                pokerGame.heldCards[2] = true;
                btnHold3.Content = "un-hold";
            }
            else
            {
                pokerGame.heldCards[2] = false;
                btnHold3.Content = "Hold";
            }
        }

        private void btnHold4_Click(object sender, RoutedEventArgs e)
        {
            if (btnHold4.Content.Equals("Hold"))
            {
                pokerGame.heldCards[3] = true;
                btnHold4.Content = "un-hold";
            }
            else
            {
                pokerGame.heldCards[3] = false;
                btnHold4.Content = "Hold";
            }
        }

        private void btnHold5_Click(object sender, RoutedEventArgs e)
        {
            if (btnHold5.Content.Equals("Hold"))
            {
                pokerGame.heldCards[4] = true;
                btnHold5.Content = "un-hold";
            }
            else
            {
                pokerGame.heldCards[4] = false;
                btnHold5.Content = "Hold";
            }
        }

        private void chip1Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["1"]++;

            updateBalance(1);
            txtChip1.Content = pokerGame.PotValues["1"].ToString();
        }

        private void chip5Click(object sender, MouseButtonEventArgs e)
        {

            pokerGame.PotValues["5"]++;
            updateBalance(5);
            txtChip5.Content = pokerGame.PotValues["5"].ToString();

        }

        private void chip10Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["10"]++;
            updateBalance(10);
            txtChip10.Content = pokerGame.PotValues["10"].ToString();
        }

        private void chip20Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["20"]++;
            updateBalance(20);
            txtChip20.Content = pokerGame.PotValues["20"].ToString();
        }


        private void chip50Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["50"]++;
            updateBalance(50);
            txtChip50.Content = pokerGame.PotValues["50"].ToString();
        }

        private void chip100Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["100"]++;
            updateBalance(100);
            txtChip100.Content = pokerGame.PotValues["100"].ToString();
        }

        private void chip500Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["500"]++;
            updateBalance(500);
            txtChip500.Content = pokerGame.PotValues["500"].ToString();
        }

        private void chip1KClick(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["1K"]++;
            updateBalance(1000);
            txtChip1K.Content = pokerGame.PotValues["1K"].ToString();
        }

        private void chip5KClick(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["5K"]++;
            updateBalance(5000);
            txtChip5K.Content = pokerGame.PotValues["5K"].ToString();
        }

        private void btnHold_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveChip1_Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["1"]--;
            updateBalance(-1);
            txtChip1.Content = pokerGame.PotValues["1"].ToString();
        }

        private void btnRemoveChip5_Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["5"]--;
            updateBalance(-5);
            txtChip5.Content = pokerGame.PotValues["5"].ToString();
        }

        private void btnRemoveChip10_Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["10"]--;
            updateBalance(-10);
            txtChip10.Content = pokerGame.PotValues["10"].ToString();
        }

        private void btnRemoveChip20_Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["20"]--;
            updateBalance(-20);
            txtChip20.Content = pokerGame.PotValues["20"].ToString();
        }

        private void btnRemoveChip50_Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["50"]--;
            updateBalance(-50);
            txtChip50.Content = pokerGame.PotValues["50"].ToString();
        }

        private void btnRemoveChip100_Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["100"]--;
            updateBalance(-100);
            txtChip100.Content = pokerGame.PotValues["100"].ToString();
        }

        private void btnRemoveChip500_Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["500"]--;
            updateBalance(-500);
            txtChip500.Content = pokerGame.PotValues["500"].ToString();
        }

        private void btnRemoveChip1K_Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["1K"]--;
            updateBalance(-1000);
            txtChip1K.Content = pokerGame.PotValues["1K"].ToString();
        }

        private void btnRemoveChip5K_Click(object sender, MouseButtonEventArgs e)
        {
            pokerGame.PotValues["5K"]--;
            updateBalance(-5000);
            txtChip5K.Content = pokerGame.PotValues["5K"].ToString();
        }





    }
}
