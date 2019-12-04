using Onboarding.Views;
using Xamarin.Forms;

namespace Onboarding
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new OnboardingPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
