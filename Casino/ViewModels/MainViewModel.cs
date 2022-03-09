using Casino.Commands;
using System.Diagnostics;

namespace Casino.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public BaseCommand dashViewCommand { get; set; }

        public BaseCommand playViewCommand { get; set; }

        public BaseCommand pokerViewCommand { get; set; }

        public BaseCommand bankViewCommand { get; set; }

        public BaseCommand rouletteViewCommand { get; set; }


        public DashboardViewModel dashViewModel { get; set; }

        public PlayViewmodel playViewmodel { get; set; }

        public PokerViewModel pokerViewModel { get; set; }

        public BankViewModel bankViewModel { get; set; }

        public RouletteViewModel rouletteViewModel { get; set; }

        //NEW SLOTS CODE
        public SlotsViewModel slotsViewModel { get; set; }
        public BaseCommand slotsViewCommand { get; set; }

        /*        private ViewModels.ViewModelBase currentViewModel;
                public ViewModels.ViewModelBase CurrentViewModel
                {
                    get => currentViewModel;
                    set
                    {
                        currentViewModel = value;
                        OnPropertyChanged();
                    }
                }*/

        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {

            Instance = this;

            //currentViewModel = new ViewModelBase();
            dashViewModel = new DashboardViewModel();
            playViewmodel = new PlayViewmodel();
            pokerViewModel = new PokerViewModel();
            bankViewModel = new BankViewModel();
            rouletteViewModel = new RouletteViewModel();
            slotsViewModel = new SlotsViewModel();



            currentView = dashViewModel;

            dashViewCommand = new BaseCommand(o =>
            {
                Debug.WriteLine("DashCommand fired");
                CurrentView = dashViewModel;
            });

            playViewCommand = new BaseCommand(o =>
            {
                Debug.WriteLine("PlayCommand fired");
                CurrentView = playViewmodel;
            });

            pokerViewCommand = new BaseCommand(o =>
            {
                Debug.WriteLine("Poker Command fired");
                CurrentView = pokerViewModel;
            });

            bankViewCommand = new BaseCommand(o =>
            {
                Debug.WriteLine("Bank Command fired");
                CurrentView = bankViewModel;
            });

            rouletteViewCommand = new BaseCommand(o =>
            {
                CurrentView = rouletteViewModel;
            });
            slotsViewCommand = new BaseCommand(o =>
            {
                Debug.WriteLine("SLOTS Command fired");
                CurrentView = slotsViewModel;
            });


        }

        public static MainViewModel Instance { get; private set; }


    }
}
