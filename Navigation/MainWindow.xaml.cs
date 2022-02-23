using System.Windows;

namespace Navigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void btnClickP1(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
            Main.Content = new Page1();
            
        }

        private void btnClickP2(object sender, RoutedEventArgs e)
        {
            Main.Content = null;
            Main.Content = new Page2();
        }
    }
}
