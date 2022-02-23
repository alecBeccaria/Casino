using System.Windows;

namespace Casino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SlotsGame.SlotsGame game = new SlotsGame.SlotsGame();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            //Randomize the slots
            game.Spin();
            titleLabel.Content = game.GetSlotsText();
        }

        private void Settings(object sender, RoutedEventArgs e)
        {

        }

        private void Exit(object sender, RoutedEventArgs e)
        {

        }
    }
}
