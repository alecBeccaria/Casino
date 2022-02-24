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
using Casino.Models;
using Casino.PokerGame;

namespace Casino
{
    /// <summary>
    /// Interaction logic for PokerControl.xaml
    /// </summary>
    public partial class PokerControl : UserControl
    {
        Poker pokerGame;
        public PokerControl()
        {
            InitializeComponent();
            pokerGame = new Poker();
            pokerGame.initialize();
            List<Card> deck = pokerGame.deck.getDeck();
            card1.Source = deck[0].image.Source;
            card2.Source = deck[1].image.Source;
            card3.Source = deck[2].image.Source;
            card4.Source = deck[3].image.Source;
            card5.Source = deck[4].image.Source;
            txtBalance.Content = "Balance: Add bank connection";
            

        }

        private void btnHold1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHold2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHold3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHold4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnHold5_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
