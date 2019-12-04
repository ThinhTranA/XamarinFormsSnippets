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
                    ImagePath = "ChooseGradient.svg",
                    Header = "CHOOSE",
                    Content = "Pick the item that is right for you",
                    RotatorItem = new WalkthroughItemPage()
                },
                new Boarding()
                {
                    ImagePath = "ConfirmGradient.svg",
                    Header = "ORDER CONFIRMED",
                    Content = "Your order is confirmed and will be on its way soon",
                    RotatorItem = new WalkthroughItemPage()
                },
                new Boarding()
                {
                    ImagePath = "DeliverGradient.svg",
                    Header = "DELIVERY",
                    Content = "Your item will arrive soon. Email us if you have any issues",
                    RotatorItem = new WalkthroughItemPage()
                }
            };
        }
    }
}
