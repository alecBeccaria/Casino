using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("([^0-9]+)");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OnWithdrawBank(object sender, RoutedEventArgs e)
        {
            if (txtBank.Text.Length != 0)
            {
                Button button = (Button)sender;
                int result = int.Parse(txtBank.Text);
                MessageBox.Show(result.ToString());
                player.chips = player.chips - result;
                player.cash = player.cash + result;
                LblChips.Text = "Casino Chips: " + player.chips;
                LblBank.Text = "Bank Chips: " + player.cash;

                txtBank.Clear();
            }
        }

        private void OnDepositChips(object sender, RoutedEventArgs e)
        {
            if (txtChips.Text.Length != 0)
            {
                Button button = (Button)sender;
                int result = int.Parse(txtChips.Text);
                MessageBox.Show(result.ToString());
                player.chips = player.chips + result;
                player.cash = player.cash - result;
                LblChips.Text = "Casino Chips: " + player.chips;
                LblBank.Text = "Bank Chips: " + player.cash;

                txtChips.Clear();
            }
        }
    }
}
