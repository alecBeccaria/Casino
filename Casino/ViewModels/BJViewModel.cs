using Casino.Commands;
using Casino.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Casino.ViewModels
{
    public class BJViewModel : ViewModelBase
    {
        public BlackJack bjGame = new BlackJack();
        public BJViewModel()
        {
            bjGame.NewGame();
            CardGetCommand = new BaseCommand(o => {
                bjGame.PlayerTakeTurn();
                Card1 = bjGame.GetPlayer().GetHandValue().ToString();
            });
            DrawCardCommand = new BaseCommand(o => {
                bjGame.PlayerTakeTurn();
                bool bust = bjGame.GetPlayer().GetHandValue() > 21;
                if (!bust) 
                { 
                    Card2 = bjGame.GetPlayer().GetHandValue().ToString();
                    string strCardImage = bjGame.GetPlayer().GetHand().GetDeck()[bjGame.GetPlayer().GetHand().GetDeck().Count() - 1].GetCardImage();
                    Debug.WriteLine("!!!!!!Card image: " + bjGame.GetPlayer().GetHand().GetDeck()[bjGame.GetPlayer().GetHand().GetDeck().Count() - 1].GetCardImage());
                    ImageCard = strCardImage;
                }
                else
                {
                    Card2 = "Bust";
                }
            });
            CardImageCommand = new BaseCommand(o =>
            {
                Debug.WriteLine(bjGame.GetPlayer().GetHand().GetDeck()[bjGame.GetPlayer().GetHand().GetDeck().Count() - 1].GetCardImage());
                string strCardImage = strCardImage = bjGame.GetPlayer().GetHand().GetDeck()[bjGame.GetPlayer().GetHand().GetDeck().Count() - 1].GetCardImage();
                ImageCard = strCardImage;
            });
        }

        private ImageSource imageCard;
        public ImageSource ImageCard
        {
            get { return @imageCard; }
            set
            {
                imageCard = value;
                OnPropertyChanged();
            }
        }

        private string card1;
        public string Card1
        {
            get { return card1; } set
            {
                card1 = value;
                OnPropertyChanged();
            }
        }
        private string card2;
        public string Card2
        {
            get { return card2; }
            set
            {
                card2 = value;
                OnPropertyChanged();
            }
        }


        public BaseCommand CardGetCommand { get; set; }
        public BaseCommand CardImageCommand { get; set; }
        public BaseCommand DrawCardCommand { get; set; }






    }
}
