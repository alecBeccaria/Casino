using System;
using System.Collections.Generic;
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
    /// Interaction logic for SuperRoulette.xaml
    /// </summary>
    public partial class SuperRoulette : UserControl
    {
        int numChoice = 0;
        int[] betChoices = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Random rng = new Random();
        public SuperRoulette()
        {
            InitializeComponent();
            chipTXT.Text = "Chips: " + Player.chips;
        }

        private void onBetClick(object sender, RoutedEventArgs e)
        {
            Button bet = (Button)sender;

            switch (bet.Name)
            {
                case "_1Button":
                    numChoice = 1;
                    break;
                case "_5Button":
                    numChoice = 5;
                    break;
                case "_10Button":
                    numChoice = 10;
                    break;
                case "_20Button":
                    numChoice = 20;
                    break;
                case "_50Button":
                    numChoice = 50;
                    break;
                case "_100Button":
                    numChoice = 100;
                    break;
                case "_500Button":
                    numChoice = 500;
                    break;
                case "_1000Button":
                    numChoice = 1000;
                    break;
                case "_5000Button":
                    numChoice = 5000;
                    break;
            }

        }

        private void ClickAddBetAmt(object sender, RoutedEventArgs e)
        {
            if (numChoice == 0)
            {
                Button button = (Button)sender;
                button.Content = null;
                switch (button.Name)
                {
                    case "_0Bet":
                        betChoices[0] = numChoice;
                        break;
                    case "_1Bet":
                        betChoices[1] = numChoice;
                        break;
                    case "_2Bet":
                        betChoices[2] = numChoice;
                        break;
                    case "_3Bet":
                        betChoices[3] = numChoice;
                        break;
                    case "_4Bet":
                        betChoices[4] = numChoice;
                        break;
                    case "_5Bet":
                        betChoices[5] = numChoice;
                        break;
                    case "_6Bet":
                        betChoices[6] = numChoice;
                        break;
                    case "_7Bet":
                        betChoices[7] = numChoice;
                        break;
                    case "_8Bet":
                        betChoices[8] = numChoice;
                        break;
                    case "_9Bet":
                        betChoices[9] = numChoice;
                        break;
                    case "_10Bet":
                        betChoices[10] = numChoice;
                        break;
                    case "_11Bet":
                        betChoices[11] = numChoice;
                        break;
                    case "_12Bet":
                        betChoices[12] = numChoice;
                        break;
                    case "_13Bet":
                        betChoices[13] = numChoice;
                        break;
                    case "_14Bet":
                        betChoices[14] = numChoice;
                        break;
                    case "_15Bet":
                        betChoices[15] = numChoice;
                        break;
                    case "_16Bet":
                        betChoices[16] = numChoice;
                        break;
                    case "_17Bet":
                        betChoices[17] = numChoice;
                        break;
                    case "_18Bet":
                        betChoices[18] = numChoice;
                        break;
                    case "_19Bet":
                        betChoices[19] = numChoice;
                        break;
                    case "_20Bet":
                        betChoices[20] = numChoice;
                        break;
                    case "_21Bet":
                        betChoices[21] = numChoice;
                        break;
                    case "_22Bet":
                        betChoices[22] = numChoice;
                        break;
                    case "_23Bet":
                        betChoices[23] = numChoice;
                        break;
                    case "_24Bet":
                        betChoices[24] = numChoice;
                        break;
                    case "_25Bet":
                        betChoices[25] = numChoice;
                        break;
                    case "_26Bet":
                        betChoices[26] = numChoice;
                        break;
                    case "_27Bet":
                        betChoices[27] = numChoice;
                        break;
                    case "_28Bet":
                        betChoices[28] = numChoice;
                        break;
                    case "_29Bet":
                        betChoices[29] = numChoice;
                        break;
                    case "_30Bet":
                        betChoices[30] = numChoice;
                        break;
                    case "_31Bet":
                        betChoices[31] = numChoice;
                        break;
                    case "_32Bet":
                        betChoices[32] = numChoice;
                        break;
                    case "_33Bet":
                        betChoices[33] = numChoice;
                        break;
                    case "_34Bet":
                        betChoices[34] = numChoice;
                        break;
                    case "_35Bet":
                        betChoices[35] = numChoice;
                        break;
                    case "_36Bet":
                        betChoices[36] = numChoice;
                        break;
                    case "_2TO1Bet1":
                        betChoices[37] = numChoice;
                        break;
                    case "_2TO1Bet2":
                        betChoices[38] = numChoice;
                        break;
                    case "_2TO1Bet3":
                        betChoices[39] = numChoice;
                        break;
                    case "_12Bet1":
                        betChoices[40] = numChoice;
                        break;
                    case "_12Bet2":
                        betChoices[41] = numChoice;
                        break;
                    case "_12Bet3":
                        betChoices[42] = numChoice;
                        break;
                    case "_HalfBet1":
                        betChoices[43] = numChoice;
                        break;
                    case "_HalfBet2":
                        betChoices[44] = numChoice;
                        break;
                    case "_EvenBet":
                        betChoices[45] = numChoice;
                        break;
                    case "_OddBet":
                        betChoices[46] = numChoice;
                        break;
                    case "_RedBet":
                        betChoices[47] = numChoice;
                        break;
                    case "_BlackBet":
                        betChoices[48] = numChoice;
                        break;
                }
            }
            else
            {
                Button button = (Button)sender;
                Image image = new Image();

                image.Source = new BitmapImage(
                    new Uri($"pack://application:,,,/Resources/Overall UI/Chip{numChoice.ToString()}.png"));
                button.Content = image;

                switch (button.Name)
                {
                    case "_0Bet":
                        betChoices[0] = numChoice;
                        break;
                    case "_1Bet":
                        betChoices[1] = numChoice;
                        break;
                    case "_2Bet":
                        betChoices[2] = numChoice;
                        break;
                    case "_3Bet":
                        betChoices[3] = numChoice;
                        break;
                    case "_4Bet":
                        betChoices[4] = numChoice;
                        break;
                    case "_5Bet":
                        betChoices[5] = numChoice;
                        break;
                    case "_6Bet":
                        betChoices[6] = numChoice;
                        break;
                    case "_7Bet":
                        betChoices[7] = numChoice;
                        break;
                    case "_8Bet":
                        betChoices[8] = numChoice;
                        break;
                    case "_9Bet":
                        betChoices[9] = numChoice;
                        break;
                    case "_10Bet":
                        betChoices[10] = numChoice;
                        break;
                    case "_11Bet":
                        betChoices[11] = numChoice;
                        break;
                    case "_12Bet":
                        betChoices[12] = numChoice;
                        break;
                    case "_13Bet":
                        betChoices[13] = numChoice;
                        break;
                    case "_14Bet":
                        betChoices[14] = numChoice;
                        break;
                    case "_15Bet":
                        betChoices[15] = numChoice;
                        break;
                    case "_16Bet":
                        betChoices[16] = numChoice;
                        break;
                    case "_17Bet":
                        betChoices[17] = numChoice;
                        break;
                    case "_18Bet":
                        betChoices[18] = numChoice;
                        break;
                    case "_19Bet":
                        betChoices[19] = numChoice;
                        break;
                    case "_20Bet":
                        betChoices[20] = numChoice;
                        break;
                    case "_21Bet":
                        betChoices[21] = numChoice;
                        break;
                    case "_22Bet":
                        betChoices[22] = numChoice;
                        break;
                    case "_23Bet":
                        betChoices[23] = numChoice;
                        break;
                    case "_24Bet":
                        betChoices[24] = numChoice;
                        break;
                    case "_25Bet":
                        betChoices[25] = numChoice;
                        break;
                    case "_26Bet":
                        betChoices[26] = numChoice;
                        break;
                    case "_27Bet":
                        betChoices[27] = numChoice;
                        break;
                    case "_28Bet":
                        betChoices[28] = numChoice;
                        break;
                    case "_29Bet":
                        betChoices[29] = numChoice;
                        break;
                    case "_30Bet":
                        betChoices[30] = numChoice;
                        break;
                    case "_31Bet":
                        betChoices[31] = numChoice;
                        break;
                    case "_32Bet":
                        betChoices[32] = numChoice;
                        break;
                    case "_33Bet":
                        betChoices[33] = numChoice;
                        break;
                    case "_34Bet":
                        betChoices[34] = numChoice;
                        break;
                    case "_35Bet":
                        betChoices[35] = numChoice;
                        break;
                    case "_36Bet":
                        betChoices[36] = numChoice;
                        break;
                    case "_2TO1Bet1":
                        betChoices[37] = numChoice;
                        break;
                    case "_2TO1Bet2":
                        betChoices[38] = numChoice;
                        break;
                    case "_2TO1Bet3":
                        betChoices[39] = numChoice;
                        break;
                    case "_12Bet1":
                        betChoices[40] = numChoice;
                        break;
                    case "_12Bet2":
                        betChoices[41] = numChoice;
                        break;
                    case "_12Bet3":
                        betChoices[42] = numChoice;
                        break;
                    case "_HalfBet1":
                        betChoices[43] = numChoice;
                        break;
                    case "_HalfBet2":
                        betChoices[44] = numChoice;
                        break;
                    case "_EvenBet":
                        betChoices[45] = numChoice;
                        break;
                    case "_OddBet":
                        betChoices[46] = numChoice;
                        break;
                    case "_RedBet":
                        betChoices[47] = numChoice;
                        break;
                    case "_BlackBet":
                        betChoices[48] = numChoice;
                        break;
                }
                numChoice = 0;
            }
        }

        private void Spin_Click(object sender, RoutedEventArgs e)
        {
            int num = rng.Next(36);
            int amountWon = 0;

            //Check for Single Numbers
            for (int i = 0; i < 37; i++)
            {
                if (betChoices[i] != 0)
                {
                    if (num == i)
                    {
                        amountWon += 36 * betChoices[i];
                    }
                    else
                    {
                        amountWon -= betChoices[i];
                    }
                }
            }

            //Check for Every Number Combo

            //Check For Reds & Blacks
            if (betChoices[47] != 0)
            {
                if (num == 1 || num == 3 || num == 5 || num == 7 || num == 9 || num == 12 || num == 14 || num == 16 || num == 18 || num == 19 || num == 21 || num == 23 || num == 25 || num == 27 || num == 30 || num == 32 || num == 34 || num == 36)
                {
                    amountWon += betChoices[47];
                }
                else
                {
                    amountWon -= betChoices[47];
                }
            }

            if (betChoices[47] != 0)
            {
                if (num == 2 || num == 4 || num == 6 || num == 8 || num == 10 || num == 11 || num == 13 || num == 15 || num == 17 || num == 20 || num == 22 || num == 24 || num == 26 || num == 28 || num == 29 || num == 31 || num == 33 || num == 35)
                {
                    amountWon += betChoices[48];
                }
                else
                {
                    amountWon -= betChoices[48];
                }
            }

            //Check For Evens Or Odds
            if (betChoices[45] != 0)
            {
                if ((num % 2) == 0)
                {
                    amountWon += betChoices[45];
                }
                else
                {
                    amountWon -= betChoices[45];
                }
            }

            if (betChoices[46] != 0)
            {
                if ((num % 2) == 1)
                {
                    amountWon += betChoices[46];
                }
                else
                {
                    amountWon -= betChoices[46];
                }
            }

            //Check for halves
            if (betChoices[43] != 0)
            {
                if (num <= 18)
                {
                    amountWon += betChoices[43];
                }
                else
                {
                    amountWon += betChoices[43];
                }
            }

            if (betChoices[44] != 0)
            {
                if (num >= 19)
                {
                    amountWon += betChoices[44];
                }
                else
                {
                    amountWon += betChoices[44];
                }
            }

            //Check for thirds
            if (betChoices[40] != 0)
            {
                if (num <= 12)
                {
                    amountWon += 3 * betChoices[40];
                }
                else
                {
                    amountWon -= betChoices[40];
                }
            }

            if (betChoices[41] != 0)
            {
                if (num >= 13 && num <= 24)
                {
                    amountWon += 3 * betChoices[41];
                }
                else
                {
                    amountWon -= betChoices[41];
                }
            }

            if (betChoices[42] != 0)
            {
                if (num >= 25 && num <= 36)
                {
                    amountWon += 3 * betChoices[42];
                }
                else
                {
                    amountWon -= betChoices[42];
                }
            }

            MessageBox.Show("Congratulations, you have won: " + amountWon + " chips!!!");
            Player.chips += amountWon;
            chipTXT.Text = "Chips: " + Player.chips;
        }
    }
}
