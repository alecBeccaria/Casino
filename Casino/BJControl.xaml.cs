using Casino.BlackJackGame;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Casino
{
    /// <summary>
    /// Interaction logic for BJControl.xaml
    /// </summary>
    public partial class BJControl : UserControl
    {
        BlackJack bJ = new BlackJack();
        int playerCardCount = 1;
        int houseCardCount = 1;
        int bet;

        public BJControl()
        {
            InitializeComponent();
            imgDeck.IsEnabled = false;
            btnPlayHand.IsEnabled = false;
            chipState(false);
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            //  Reset images
            playerCardCount = 1;
            houseCardCount = 1;
            imgHouseCard1.SetValue(System.Windows.Controls.Image.SourceProperty, null);
            imgHouseCard2.SetValue(System.Windows.Controls.Image.SourceProperty, null);
            imgHouseCard3.SetValue(System.Windows.Controls.Image.SourceProperty, null);
            imgHouseCard4.SetValue(System.Windows.Controls.Image.SourceProperty, null);
            imgHouseCard5.SetValue(System.Windows.Controls.Image.SourceProperty, null);
            imgPlayerCard1.SetValue(System.Windows.Controls.Image.SourceProperty, null);
            imgPlayerCard2.SetValue(System.Windows.Controls.Image.SourceProperty, null);
            imgPlayerCard3.SetValue(System.Windows.Controls.Image.SourceProperty, null);
            imgPlayerCard4.SetValue(System.Windows.Controls.Image.SourceProperty, null);
            imgPlayerCard5.SetValue(System.Windows.Controls.Image.SourceProperty, null);

            bJ.NewGame();
            chipState(true);

            //  Reset hand and bet
            bet = 0;
            bJ.playerHand.GetDeck().Clear();

            //  Play starting cards
            bJ.DrawCard(bJ.playerHand);
            playerCardImage(playerCardCount, bJ.playerHand.GetDeck()[^1].image.Source);
            bJ.DrawCard(bJ.playerHand);
            playerCardImage(playerCardCount, bJ.playerHand.GetDeck()[^1].image.Source);

            bJ.DrawCard(bJ.houseHand);
            houseCardImage(houseCardCount, imgDeck.Source);
            bJ.DrawCard(bJ.houseHand);
            houseCardImage(houseCardCount, bJ.houseHand.GetDeck()[^1].image.Source);

            btnNewGame.IsEnabled = false;
            btnGoBack.IsEnabled = false;
            imgDeck.IsEnabled = true;
            btnPlayHand.IsEnabled = true;
        }

        public void CheckWin(string state)
        {
            switch (state)
            {
                case "pBust":
                    MessageBox.Show("You busted!");
                    btnGoBack.IsEnabled = true;
                    bet = 0;
                    break;
                case "p21":
                    MessageBox.Show("You got Black Jack!");
                    btnGoBack.IsEnabled = true;
                    Player.cash += bet * 2;
                    break;
                case "hWin":
                    MessageBox.Show("You lose!");
                    btnGoBack.IsEnabled = true;
                    bet = 0;
                    break;
                case "5card":
                    MessageBox.Show("5 card Charlie!");
                    btnGoBack.IsEnabled = true;
                    Player.cash += bet * 3;
                    bet = 0;
                    break;
                case "pWin":
                    MessageBox.Show("You Win!");
                    btnGoBack.IsEnabled = true;
                    Player.cash += bet;
                    bet = 0;
                    break;
                case "draw":
                    MessageBox.Show("Draw!");
                    btnGoBack.IsEnabled = true;
                    Player.cash += bet;
                    break;
            }
            Debug.WriteLine(Player.cash);
            resetChipLabels();
            btnNewGame.IsEnabled = true;
            btnGoBack.IsEnabled = true;
            imgDeck.IsEnabled = false;
            btnPlayHand.IsEnabled = false;
        }

        private void btnPlayHand_Click(object sender, RoutedEventArgs e)
        {
            int houseVal = 0;
            while ((houseVal < 17) && (houseCardCount <= 5))
            {
                bJ.DrawCard(bJ.houseHand);
                houseCardImage(houseCardCount, bJ.houseHand.GetDeck()[^1].image.Source);
                houseVal = bJ.GetHandValue(bJ.houseHand);
            }
            if (houseVal > 21)
            {
                CheckWin("pWin");
            } else if (houseVal > bJ.GetHandValue(bJ.playerHand))
            {
                CheckWin("hWin");
            } else if (houseVal < bJ.GetHandValue(bJ.playerHand))
            {
                CheckWin("pWin");
            } else
            {
                CheckWin("draw");
            }
        }
        private void updateBalance(int value)
        {
            Player.chips -= value;
            lblBalance.Content = $"Balance: {Player.chips}";
        }
        private void imgDeck_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bJ.DrawCard(bJ.playerHand);
            //for (int i = 0; i < bJ.playerHand.GetDeck().Count; i++)
            //{
            //    Debug.WriteLine(bJ.playerHand.GetDeck()[i].name + bJ.playerHand.GetDeck()[i].suit);
            //}
            
            playerCardImage(playerCardCount, bJ.playerHand.GetDeck()[^1].image.Source);
            if (bJ.GetHandValue(bJ.playerHand) > 21)
            {
                CheckWin("pBust");
            }
            if (playerCardCount == 6 && bJ.GetHandValue(bJ.playerHand) < 22)
            {
                CheckWin("5card");
            }
            Debug.WriteLine(bJ.playerHand.GetDeck()[^1].image.Source.ToString());
        }

        private void playerCardImage(int card, ImageSource iS)
        {
            switch (card)
            {
                case 1:
                    imgPlayerCard1.Source = iS;
                    Debug.WriteLine("path: " + iS.ToString());
                    playerCardCount++;
                    break;
                case 2:
                    imgPlayerCard2.Source = iS;
                    Debug.WriteLine("path: " + iS.ToString());
                    playerCardCount++;
                    break;
                case 3:
                    imgPlayerCard3.Source = iS;
                    Debug.WriteLine("path: " + iS.ToString());
                    playerCardCount++;
                    break;
                case 4:
                    imgPlayerCard4.Source = iS;
                    Debug.WriteLine("path: " + iS.ToString());
                    playerCardCount++;
                    break;
                case 5:
                    imgPlayerCard5.Source = iS;
                    Debug.WriteLine("path: " + iS.ToString());
                    playerCardCount++;
                    break;
            }
        }
        private void resetChipLabels()
        {
            txtChip1.Content = 0;
            txtChip5.Content = 0;
            txtChip10.Content = 0;
            txtChip20.Content = 0;
            txtChip50.Content = 0;
            txtChip100.Content = 0;
            txtChip500.Content = 0;
            txtChip1K.Content = 0;
            txtChip5K.Content = 0;
        }

        private void houseCardImage(int card, ImageSource iS)
        {
            switch (card)
            {
                case 1:
                    imgHouseCard1.Source = iS;
                    Debug.WriteLine("path: " + iS.ToString());
                    houseCardCount++;
                    break;
                case 2:
                    imgHouseCard2.Source = iS;
                    Debug.WriteLine("path: " + iS.ToString());
                    houseCardCount++;
                    break;
                case 3:
                    imgHouseCard3.Source = iS;
                    Debug.WriteLine("path: " + iS.ToString());
                    houseCardCount++;
                    break;
                case 4:
                    imgHouseCard4.Source = iS;
                    Debug.WriteLine("path: " + iS.ToString());
                    houseCardCount++;
                    break;
                case 5:
                    imgHouseCard5.Source = iS;
                    Debug.WriteLine("path: " + iS.ToString());
                    houseCardCount++;
                    break;
            }
        }

        private void chipState(bool enabled)
        {
            chip1.IsEnabled = enabled;
            chip5.IsEnabled = enabled;
            chip10.IsEnabled = enabled;
            chip20.IsEnabled = enabled;
            chip50.IsEnabled = enabled;
            chip100.IsEnabled = enabled;
            chip500.IsEnabled = enabled;
            chip1000.IsEnabled = enabled;
            chip5000.IsEnabled = enabled;
        }

        private void chip1Click(object sender, MouseButtonEventArgs e)
        {
            if (Player.cash > 1)
            {
                bet += 1;
                bJ.potValues["1"]++;
                updateBalance(1);
                txtChip1.Content = bJ.potValues["1"].ToString();
            }
        }

        private void btnRemoveChip1_Click(object sender, MouseButtonEventArgs e)
        {
            if (bet >= 0)
            {
                bet -= 1;
            }
        }

        private void chip5Click(object sender, MouseButtonEventArgs e)
        {
            bet += 5;
            bJ.potValues["5"]++;
            updateBalance(5);
            txtChip5.Content = bJ.potValues["5"].ToString();
        }

        private void btnRemoveChip5_Click(object sender, MouseButtonEventArgs e)
        {
            if (bet >= 5)
            {
                bet -= 5;
            }
        }

        private void chip10Click(object sender, MouseButtonEventArgs e)
        {
            bet += 10;
            bJ.potValues["10"]++;
            updateBalance(10);
            txtChip10.Content = bJ.potValues["10"].ToString();
        }

        private void btnRemoveChip10_Click(object sender, MouseButtonEventArgs e)
        {
            if (bet >= 10)
            {
                bet -= 10;
            }
        }

        private void chip20Click(object sender, MouseButtonEventArgs e)
        {
            bet += 20;
            bJ.potValues["20"]++;
            updateBalance(20);
            txtChip1.Content = bJ.potValues["20"].ToString();
        }

        private void btnRemoveChip20_Click(object sender, MouseButtonEventArgs e)
        {
            if (bet >= 20)
            {
                bet -= 20;
            }
        }

        private void chip50Click(object sender, MouseButtonEventArgs e)
        {
            bet += 50;
            bJ.potValues["50"]++;
            updateBalance(50);
            txtChip1.Content = bJ.potValues["50"].ToString();
        }

        private void btnRemoveChip50_Click(object sender, MouseButtonEventArgs e)
        {
            if (bet >= 50)
            {
                bet -= 50;
            }
        }

        private void chip100Click(object sender, MouseButtonEventArgs e)
        {
            bet += 100;
            bJ.potValues["100"]++;
            updateBalance(100);
            txtChip1.Content = bJ.potValues["100"].ToString();
        }

        private void btnRemoveChip100_Click(object sender, MouseButtonEventArgs e)
        {
            if (bet >= 100)
            {
                bet -= 100;
            }
        }

        private void chip500Click(object sender, MouseButtonEventArgs e)
        {
            bet += 500;
            bJ.potValues["500"]++;
            updateBalance(500);
            txtChip1.Content = bJ.potValues["500"].ToString();
        }

        private void btnRemoveChip500_Click(object sender, MouseButtonEventArgs e)
        {
            if (bet >= 500)
            {
                bet -= 500;
            }
        }

        private void chip1KClick(object sender, MouseButtonEventArgs e)
        {
            bet += 1000;
            bJ.potValues["1000"]++;
            updateBalance(1000);
            txtChip1.Content = bJ.potValues["1000"].ToString();
        }

        private void btnRemoveChip1K_Click(object sender, MouseButtonEventArgs e)
        {
            if (bet >= 1000)
            {
                bet -= 1000;
            }
        }

        private void chip5KClick(object sender, MouseButtonEventArgs e)
        {
            bet += 5000;
            bJ.potValues["5000"]++;
            updateBalance(5000);
            txtChip1.Content = bJ.potValues["5000"].ToString();
        }

        private void btnRemoveChip5K_Click(object sender, MouseButtonEventArgs e)
        {
            if (bet >= 5000)
            {
                bet -= 5000;
            }
        }
    }
}
