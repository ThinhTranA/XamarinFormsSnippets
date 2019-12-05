using Onboarding.Models;
using Onboarding.Views;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace Onboarding
{
    [AddINotifyPropertyChangedInterface]
    public class OnboardingViewModel
    {
        public ObservableCollection<Boarding> Boardings { get; set; }

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

            foreach(var boarding in Boardings)
            {
                boarding.CarouselItem.BindingContext = boarding;
            }
        }
    }
}
