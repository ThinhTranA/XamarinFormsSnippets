using Onboarding.Models;
using Onboarding.Views;
using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Onboarding
{
    [AddINotifyPropertyChangedInterface]
    public class OnboardingViewModel
    {
        public string NextButtonText 
        { 
            get 
            { 
                if(PositionIndex == Boardings.Count - 1) 
                    return "DONE";
                return "NEXT";
            } 
        } 
        public bool SkipButtonVisibility { get; set; } = true;
        public ObservableCollection<Boarding> Boardings { get; set; }

        public int PositionIndex { get; set; }
        public ICommand SkipCommand { get; set; }
        public ICommand NextCommand { get; set; }

        public OnboardingViewModel()
        {
            Boardings = new ObservableCollection<Boarding>
            {
                new Boarding()
                {
                    ImagePath = "ConnectPeople.svg",
                    Header = "Connect people around the world",
                    Content = " Feelings laughing at no wondered repeated provided finished. It acceptance thoroughly my advantages everything as.",
                    CarouselItem = new WalkthroughItemPage()
                },
                new Boarding()
                {
                    ImagePath = "LiveYourLife.svg",
                    Header = "Live your life smarter with us!",
                    Content = "Boy desirous families prepared gay reserved add ecstatic say. Replied joy age visitor nothing cottage. ",
                    CarouselItem = new WalkthroughItemPage()
                },
                new Boarding()
                {
                    ImagePath = "GetNewExperience.svg",
                    Header = "Get a new experience of imagination",
                    Content = "Started several mistake joy say painful removed reached end. State burst think end are its. ",
                    CarouselItem = new WalkthroughItemPage()
                }
            };

            foreach (var boarding in Boardings)
            {
                boarding.CarouselItem.BindingContext = boarding;
            }

            SkipCommand = new Command(StartMainPage);
            NextCommand = new Command(Next);
        }

        private void Next()
        {
            if (PositionIndex < Boardings.Count - 1)
            {
                PositionIndex++;
            }
            else
            {
                StartMainPage();
            }
        }

        private void StartMainPage()
        {
            Application.Current.MainPage =new MainPage();
        }
    }
}
