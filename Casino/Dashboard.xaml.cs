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
using System.Windows.Shapes;

namespace Casino
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        Player player = new Player();

        public Dashboard()
        {
            InitializeComponent();
            LblChips.Text = "Casino Chips: " + player.chips;
            LblBank.Text = "Bank Chips: " + player.cash;
        }

        private void OnDeposit(object sender, RoutedEventArgs e)
        {
            int numChips = player.chips;
            int numCash = player.cash;

            int value;
            bool success = int.TryParse(txtChips.Text, out value);
            Console.WriteLine(success);
            if (success)
            {
                value = int.Parse(txtChips.Text);
                numChips = numChips - value; ;
                numCash = numCash + value;

                player.cash = numCash;
                player.chips = numChips;
            }
            else
            {
                MessageBox.Show("Please enter number only!");
            }
        }

        private void OnWithdraw(object sender, RoutedEventArgs e)
        {
            int numChips = player.chips;
            int numCash = player.cash;

            int value;
            bool success = int.TryParse(txtChips.Text, out value);
            Console.WriteLine(success);
            if (success)
            {
                value = int.Parse(txtChips.Text);
                numChips = numChips + value;
                numCash = numCash - value;

                player.cash = numCash;
                player.chips = numChips;

                LblChips.Text = "Casino Chips: " + numCash;
                LblBank.Text = "Bank Chips: " + numChips;
            }
            else
            {
                MessageBox.Show("Please enter number only!");
            }
        }
    }
}
