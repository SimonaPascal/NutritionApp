using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Pages;
using ProiectPDMXamarin_Login.Pages;
using Xamarin.Forms;
namespace ProiectPDMXamarin_Login
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts  
        }
        protected override void OnSleep()
        {
            // Handle when your app sleeps  
        }
        protected override void OnResume()
        {
            // Handle when your app resumes  
        }
    }
}