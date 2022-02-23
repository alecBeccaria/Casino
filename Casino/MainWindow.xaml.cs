using Casino.ViewModels;
using System.Windows;

namespace Casino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainViewModel model = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void mainViewButton_Click(object sender, RoutedEventArgs e)
        {
            model.CurrentView = new DashboardViewModel();
        }

        private void playViewButton_Click(object sender, RoutedEventArgs e)
        {
            model.CurrentView = new PlayViewmodel();
        }
    }
}
