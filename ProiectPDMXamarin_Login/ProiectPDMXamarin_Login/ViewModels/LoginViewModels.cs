using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Pages;
using ProiectPDMXamarin.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
namespace ProiectPDMXamarin_Login.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string email;
        DaoUser daoUser;
        public INavigation Navigation { get; set; }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }
        public async void OnSubmit()
        {
            daoUser = new DaoUser();
            User user = new User();
            user.EmailAddress = email;

            user.Password = password;
            user = daoUser.LoginValidate(user);
            if (user != null)
            {
                
                await Navigation.PushAsync(new MasterPage(user));
            }
  
        }
    }
}