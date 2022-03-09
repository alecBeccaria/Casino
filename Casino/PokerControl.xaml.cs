using Casino.Models;
using Casino.PokerGame;
using System.Collections.Generic;
using System.Linq;
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
        private Poker pokerGame;

        private List<Card> nextHand;

        private List<Card> currentHand;

        private bool betPlaced = false;

        private bool newRound = true;

        int amountWon = 0;

        int modInc = 0;







        public PokerControl()
        {
            InitializeComponent();
            pokerGame = new Poker();
            pokerGame.initialize();
            DataContext = this;
            txtBalance.Content = $"Balance: {Player.chips}";
            btnHold1.IsEnabled = false;
            btnHold2.IsEnabled = false;
            btnHold3.IsEnabled = false;
            btnHold4.IsEnabled = false;
            btnHold5.IsEnabled = false;

        }

        private void btnPlaceBet_Click(object sender, RoutedEventArgs e)
        {




            if (newRound)
            {
                currentHand = pokerGame.getNextHand(5);
                setCurrentHand();
            }
            betPlaced = true;
            btnHold1.IsEnabled = true;
            btnHold2.IsEnabled = true;
            btnHold3.IsEnabled = true;
            btnHold4.IsEnabled = true;
            btnHold5.IsEnabled = true;
            btnPlaceBet.IsEnabled = false;


        }


        private void resetPot()
        {
            pokerGame.pot = 0;
            pokerGame.PotValues["1"] = 0;
            pokerGame.PotValues["5"] = 0;
            pokerGame.PotValues["10"] = 0;
            pokerGame.PotValues["20"] = 0;
            pokerGame.PotValues["50"] = 0;
            pokerGame.PotValues["100"] = 0;
            pokerGame.PotValues["500"] = 0;
            pokerGame.PotValues["1K"] = 0;
            pokerGame.PotValues["5K"] = 0;

            txtChip1.Content = "0";
            txtChip5.Content = "0";
            txtChip10.Content = "0";
            txtChip20.Content = "0";
            txtChip50.Content = "0";
            txtChip100.Content = "0";
            txtChip500.Content = "0";
            txtChip1K.Content = "0";
            txtChip5K.Content = "0";

            updateBalance(0);
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {

            if (betPlaced)
            {



                if (modInc % 2 == 1)
                {
                    if (checkWin())
                    {
                        txtBalance.Content = $"Balance: {Player.chips}";
                        txtPot.Content = $"Bet: {pokerGame.pot}";
                        resetPot();
                        MessageBox.Show("Congratulations, you have won: " + amountWon + " chips!!!");
                        betPlaced = false;
                        newRound = true;

                    }
                    else
                    {

                        txtBalance.Content = $"Balance: {Player.chips}";
                        MessageBox.Show($"You lost {pokerGame.pot} chips");
                        resetPot();
                        betPlaced = false;
                        newRound = true;

                    }
                    btnDraw.Content = "Draw";


                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (!currentHand[i].isHeld)
                        {
                            List<Card> nextHand = pokerGame.getNextHand(1);

                            pokerGame.discardDeck.Add(currentHand[i]);
                            currentHand[i] = nextHand[0];
                        }
                        else
                        {
                            currentHand[i].isHeld = false;

                        }
                        nextHand.Clear();
                    }

                    setCurrentHand();
                    btnDraw.Content = "Check Win";
                    newRound = false;
                }



                modInc++;


                //setCurrentHand();
                btnHold1.Content = "Hold";
                btnHold2.Content = "Hold";
                btnHold3.Content = "Hold";
                btnHold4.Content = "Hold";
                btnHold5.Content = "Hold";
                btnHold1.IsEnabled = false;
                btnHold2.IsEnabled = false;
                btnHold3.IsEnabled = false;
                btnHold4.IsEnabled = false;
                btnHold5.IsEnabled = false;

            }


        }



        private void setCurrentHand()
        {
            currentHand = currentHand.OrderBy(x => x.value).ToList();
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        card1.Source = currentHand[i].image.Source;
                        break;
                    case 1:
                        card2.Source = currentHand[i].image.Source;
                        break;
                    case 2:
                        card3.Source = currentHand[i].image.Source;
                        break;
                    case 3:
                        card4.Source = currentHand[i].image.Source;
                        break;
                    case 4:
                        card5.Source = currentHand[i].image.Source;
                        break;
                }
            }
        }

        private void updateBalance(int value)
        {
            pokerGame.pot += value;
            Player.chips -= value;
            txtBalance.Content = $"Balance: {Player.chips}";
            txtPot.Content = $"Bet: {pokerGame.pot}";
        }

        private void btnHold1_Click(object sender, RoutedEventArgs e)
        {
            if (btnHold1.Content.Equals("Hold"))
            {
                currentHand[0].isHeld = true;
                btnHold1.Content = "un-hold";
            }
            else
            {
                currentHand[0].isHeld = false;
                btnHold1.Content = "Hold";
            }
        }

        private void btnHold2_Click(object sender, RoutedEventArgs e)
        {
            if (btnHold2.Content.Equals("Hold"))
            {
                currentHand[1].isHeld = true;
                btnHold2.Content = "un-hold";
            }
            else
            {
                currentHand[1].isHeld = false;
                btnHold2.Content = "Hold";
            }
        }

        private void btnHold3_Click(object sender, RoutedEventArgs e)
        {
            if (btnHold3.Content.Equals("Hold"))
            {
                currentHand[2].isHeld = true;
                btnHold3.Content = "un-hold";
            }
            else
            {
                currentHand[2].isHeld = false;
                btnHold3.Content = "Hold";
            }
        }

        private void btnHold4_Click(object sender, RoutedEventArgs e)
        {
            if (btnHold4.Content.Equals("Hold"))
            {
                currentHand[3].isHeld = true;
                btnHold4.Content = "un-hold";
            }
            else
            {
                currentHand[3].isHeld = false;
                btnHold4.Content = "Hold";
            }
        }

        private void btnHold5_Click(object sender, RoutedEventArgs e)
        {
            if (btnHold5.Content.Equals("Hold"))
            {
                currentHand[4].isHeld = true;
                btnHold5.Content = "un-hold";
            }
            else
            {
                currentHand[4].isHeld = false;
                btnHold5.Content = "Hold";
            }
        }

        private void chip1Click(object sender, MouseButtonEventArgs e)
        {
            if (!betPlaced)
            {
                pokerGame.PotValues["1"]++;
                updateBalance(1);
                txtChip1.Content = pokerGame.PotValues["1"].ToString();
            }

        }

        private void chip5Click(object sender, MouseButtonEventArgs e)
        {
            if (!betPlaced)
            {
                pokerGame.PotValues["5"]++;
                updateBalance(5);
                txtChip5.Content = pokerGame.PotValues["5"].ToString();
            }


        }

        private void chip10Click(object sender, MouseButtonEventArgs e)
        {
            if (!betPlaced)
            {
                pokerGame.PotValues["10"]++;
                updateBalance(10);
                txtChip10.Content = pokerGame.PotValues["10"].ToString();
            }
        }

        private void chip20Click(object sender, MouseButtonEventArgs e)
        {
            if (!betPlaced)
            {
                pokerGame.PotValues["20"]++;
                updateBalance(20);
                txtChip20.Content = pokerGame.PotValues["20"].ToString();
            }
        }


        private void chip50Click(object sender, MouseButtonEventArgs e)
        {
            if (!betPlaced)
            {
                pokerGame.PotValues["50"]++;
                updateBalance(50);
                txtChip50.Content = pokerGame.PotValues["50"].ToString();
            }
        }

        private void chip100Click(object sender, MouseButtonEventArgs e)
        {
            if (!betPlaced)
            {
                pokerGame.PotValues["100"]++;
                updateBalance(100);
                txtChip100.Content = pokerGame.PotValues["100"].ToString();
            }
        }

        private void chip500Click(object sender, MouseButtonEventArgs e)
        {
            if (!betPlaced)
            {
                pokerGame.PotValues["500"]++;
                updateBalance(500);
                txtChip500.Content = pokerGame.PotValues["500"].ToString();
            }
        }

        private void chip1KClick(object sender, MouseButtonEventArgs e)
        {
            if (!betPlaced)
            {
                pokerGame.PotValues["1K"]++;
                updateBalance(1000);
                txtChip1K.Content = pokerGame.PotValues["1K"].ToString();
            }
        }

        private void chip5KClick(object sender, MouseButtonEventArgs e)
        {
            if (!betPlaced)
            {
                pokerGame.PotValues["5K"]++;
                updateBalance(5000);
                txtChip5K.Content = pokerGame.PotValues["5K"].ToString();
            }
        }


        private void btnRemoveChip1_Click(object sender, MouseButtonEventArgs e)
        {
            if (pokerGame.PotValues["1"] != 0 && !betPlaced)
            {
                pokerGame.PotValues["1"]--;
                updateBalance(-1);
                txtChip1.Content = pokerGame.PotValues["1"].ToString();
            }

        }

        private void btnRemoveChip5_Click(object sender, MouseButtonEventArgs e)
        {
            if (pokerGame.PotValues["5"] != 0 && !betPlaced)
            {
                pokerGame.PotValues["5"]--;
                updateBalance(-5);
                txtChip5.Content = pokerGame.PotValues["5"].ToString();
            }

        }

        private void btnRemoveChip10_Click(object sender, MouseButtonEventArgs e)
        {
            if (pokerGame.PotValues["10"] != 0 && !betPlaced)
            {
                pokerGame.PotValues["10"]--;
                updateBalance(-10);
                txtChip10.Content = pokerGame.PotValues["10"].ToString();
            }

        }

        private void btnRemoveChip20_Click(object sender, MouseButtonEventArgs e)
        {
            if (pokerGame.PotValues["20"] != 0 && !betPlaced)
            {
                pokerGame.PotValues["20"]--;
                updateBalance(-20);
                txtChip20.Content = pokerGame.PotValues["20"].ToString();
            }

        }

        private void btnRemoveChip50_Click(object sender, MouseButtonEventArgs e)
        {
            if (pokerGame.PotValues["50"] != 0 && !betPlaced)
            {
                pokerGame.PotValues["50"]--;
                updateBalance(-50);
                txtChip50.Content = pokerGame.PotValues["50"].ToString();
            }

        }

        private void btnRemoveChip100_Click(object sender, MouseButtonEventArgs e)
        {
            if (pokerGame.PotValues["100"] != 0 && !betPlaced)
            {
                pokerGame.PotValues["100"]--;
                updateBalance(-100);
                txtChip100.Content = pokerGame.PotValues["100"].ToString();
            }

        }

        private void btnRemoveChip500_Click(object sender, MouseButtonEventArgs e)
        {
            if (pokerGame.PotValues["500"] != 0 && !betPlaced)
            {
                pokerGame.PotValues["500"]--;
                updateBalance(-500);
                txtChip500.Content = pokerGame.PotValues["500"].ToString();
            }

        }

        private void btnRemoveChip1K_Click(object sender, MouseButtonEventArgs e)
        {
            if (pokerGame.PotValues["1K"] != 0 && !betPlaced)
            {
                pokerGame.PotValues["1K"]--;
                updateBalance(-1000);
                txtChip1K.Content = pokerGame.PotValues["1K"].ToString();
            }

        }

        private void btnRemoveChip5K_Click(object sender, MouseButtonEventArgs e)
        {
            if (pokerGame.PotValues["5K"] != 0 && !betPlaced)
            {
                pokerGame.PotValues["5K"]--;
                updateBalance(-5000);
                txtChip5K.Content = pokerGame.PotValues["5K"].ToString();
            }
        }

        private bool checkWin()
        {

            amountWon = 0;
            bool win = false;

            int handValue = 0;

            foreach (Card card in currentHand)
            {
                handValue += card.value;
            }
            //Royal Flush
            if (currentHand[0].value == 10
                && currentHand[1].value == 11
                && currentHand[2].value == 12
                && currentHand[3].value == 13)
            {
                win = true;
                amountWon = pokerGame.pot * 100000 + pokerGame.pot; ;
                Player.chips += amountWon;
            }

            //Straight Flush
            else if (currentHand[0].value + 1 == currentHand[1].value
                && currentHand[1].value + 1 == currentHand[2].value
                && currentHand[2].value + 1 == currentHand[3].value
                && currentHand[3].value + 1 == currentHand[4].value
                && currentHand[0].suit == currentHand[1].suit
                && currentHand[1].suit == currentHand[2].suit
                && currentHand[2].suit == currentHand[3].suit
                && currentHand[3].suit == currentHand[4].suit)
            {
                win = true;
                amountWon = pokerGame.pot * 10000 + pokerGame.pot; ;
                Player.chips += amountWon;
            }

            //Four of a kind
            else if ((currentHand[0].name == currentHand[1].name
                    && currentHand[1].name == currentHand[2].name
                    && currentHand[2].name == currentHand[3].name)
                ||
                (currentHand[1].name == currentHand[2].name
                    && currentHand[2].name == currentHand[3].name
                    && currentHand[3].name == currentHand[4].name))
            {
                win = true;
                amountWon = pokerGame.pot * 1000 + pokerGame.pot; ;
                Player.chips += amountWon;
            }

            //Full House
            else if ((currentHand[0].name == currentHand[1].name
                    && currentHand[1].name == currentHand[2].name
                    && currentHand[3].name == currentHand[4].name)
                ||
                (currentHand[0].name == currentHand[1].name
                    && currentHand[2].name == currentHand[3].name
                    && currentHand[3].name == currentHand[4].name))
            {
                win = true;
                amountWon = pokerGame.pot * 100 + pokerGame.pot; ;
                Player.chips += amountWon;
            }

            //Flush
            else if (currentHand[0].suit == currentHand[1].suit
                    && currentHand[1].suit == currentHand[2].suit
                    && currentHand[2].suit == currentHand[3].suit
                    && currentHand[3].suit == currentHand[4].suit)
            {
                win = true;
                amountWon = pokerGame.pot * 50 + pokerGame.pot; ;
                Player.chips += amountWon;
            }

            //Straight
            else if (currentHand[0].value + 1 == currentHand[1].value
                && currentHand[1].value + 1 == currentHand[2].value
                && currentHand[2].value + 1 == currentHand[3].value
                && currentHand[3].value + 1 == currentHand[4].value)
            {
                win = true;
                amountWon = pokerGame.pot * 20 + pokerGame.pot;
                Player.chips += amountWon;
            }

            //Three of a kind
            else if ((currentHand[0].name == currentHand[1].name
                    && currentHand[1].name == currentHand[2].name)
                ||
                (currentHand[2].name == currentHand[3].name
                    && currentHand[3].name == currentHand[4].name)
                ||
                (currentHand[1].name == currentHand[2].name
                    && currentHand[2].name == currentHand[3].name))
            {
                win = true;
                amountWon = pokerGame.pot * 10 + pokerGame.pot; ;
                Player.chips += amountWon;
            }

            //Two Pair
            else if ((currentHand[0].name == currentHand[1].name
                    && currentHand[2].name == currentHand[3].name)
                ||
                (currentHand[1].name == currentHand[2].name
                    && currentHand[3].name == currentHand[4].name)
                ||
                (currentHand[0].name == currentHand[1].name
                    && currentHand[3].name == currentHand[4].name))
            {
                win = true;
                amountWon = pokerGame.pot * 5 + pokerGame.pot;
                Player.chips += amountWon;

            }

            //One Pair
            else if ((currentHand[0].name == currentHand[1].name)
                ||
                (currentHand[1].name == currentHand[2].name)
                ||
                (currentHand[2].name == currentHand[3].name)
                ||
                (currentHand[3].name == currentHand[4].name))
            {
                win = true;
                amountWon = pokerGame.pot + pokerGame.pot;
                Player.chips += amountWon;
            }
            newRound = true;
            btnPlaceBet.IsEnabled = true;
            return win;
        }
    }
}
