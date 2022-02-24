using Casino.Commands;
using Casino.NavStore;
using System;
using System.Diagnostics;

namespace Casino.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public BaseCommand dashViewCommand { get; set; }

        public BaseCommand playViewCommand { get; set; }

        public BaseCommand pokerViewCommand { get; set; }

        public BaseCommand bankViewCommand { get; set; }



        public DashboardViewModel dashViewModel { get; set; } 

        public PlayViewmodel playViewmodel { get; set; }

        public PokerViewModel pokerViewModel { get; set; }

        public BankViewModel bankViewModel { get; set; }

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
            


            currentView = dashViewModel;

            dashViewCommand = new BaseCommand(o => {
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



        }

        public static MainViewModel Instance { get; private set; }


    }
}
