using Casino.Commands;
using System.Diagnostics;

namespace Casino.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public BaseCommand dashViewCommand { get; set; }

        public BaseCommand playViewCommand { get; set; }

        public BaseCommand pokerViewCommand { get; set; }

        public DashboardViewModel dashViewModel { get; set; }

        public PlayViewmodel playViewmodel { get; set; }

        public PokerViewModel pokerViewModel { get; set; }

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
            //currentViewModel = new ViewModelBase();
            dashViewModel = new DashboardViewModel();
            playViewmodel = new PlayViewmodel();
            pokerViewModel = new PokerViewModel();



            currentView = dashViewModel;

            dashViewCommand = new BaseCommand(o =>
            {
                Debug.WriteLine("Select Game Command fired");
                CurrentView = dashViewModel;
            });

            playViewCommand = new BaseCommand(o =>
            {
                Debug.WriteLine("Play Command fired");
                CurrentView = playViewmodel;
            });

            pokerViewCommand = new BaseCommand(o =>
            {
                Debug.WriteLine("Poker Command fired");
                CurrentView = playViewmodel;
            });



        }




    }
}
