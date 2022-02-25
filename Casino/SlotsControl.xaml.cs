using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Casino.Models;
using Casino.SlotsGame;

namespace Casino
{
    /// <summary>
    /// Interaction logic for SlotsControl.xaml
    /// </summary>
    public partial class SlotsControl : UserControl
    {
        SlotsGame.SlotsGame game = new SlotsGame.SlotsGame();
        int slotGameBet = 0;
        public SlotsControl()
        {
            InitializeComponent();
            lblBalance.Content = Player.chips.ToString();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("([^0-9]+)");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (slotGameBet == 0)
            {
                lblActiveBet.Content = "You need to make a bet to play!";
                return;
            }
            else
            {
                lblActiveBet.Content = "Make a New Bet";
            }
            game.Spin();
            SlotType slot1 = game.Slots[0];
            SlotType slot2 = game.Slots[1];
            SlotType slot3 = game.Slots[2];
            lblSlotOne.Content = slot1.ToString();
            lblSlotTwo.Content = slot2.ToString();
            lblSlotThree.Content = slot3.ToString();
            if (game.CheckSlotsWin())
            {
                lblWin.Content = "You Won!";
                Player.chips = game.GetWinnings(slotGameBet);
            }
            else
            {
                lblWin.Content = "You Lost Try Again";
            }
            slotGameBet = 0;
            lblBalance.Content = Player.chips.ToString();
        }

        private void onBetClick(object sender, RoutedEventArgs e)
        {
            if(txtBet.Text.Length > 0)
            {
                slotGameBet = int.Parse(txtBet.Text);
                lblActiveBet.Content = slotGameBet.ToString();
                Player.chips -= slotGameBet;
                lblBalance.Content = Player.chips.ToString();
            }
        }
    }
}
