using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectPDMXamarin_Login.ViewModels;
using ProiectPDMXamarin.Pages;

namespace ProiectPDMXamarin_Login.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var vm = new LoginViewModel();
            vm.Navigation = Navigation;
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error!", "Invalid Login. Please try again!", "OK");
            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}