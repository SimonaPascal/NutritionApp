using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Pages;
using ProiectPDMXamarin.Services;
using ProiectPDMXamarin_Login.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProiectPDMXamarin.ViewModels
{
    class RegistrationViewModel
    {
        private User user;
        private DaoUser daoUser;

        public string FirstNameReg { get; set; }
        public string LastNameReg { get; set; }
    
        public string EmailAddressReg { get; set; }
        public string PasswordReg{ get; set; }
        public string PhoneNumberReg { get; set; }
        public DateTime BirthdayReg { get; set; }
        public string GenderReg { get; set; }
        public INavigation Navigation { get; set; }
        public ICommand RegisterCmd{ get; set; }


        public RegistrationViewModel()
        {
            


            RegisterCmd = new Command(Register_Button_Pressed);
           
        }

        async public void Register_Button_Pressed()
        {
            User user = new User();
            user.FirstName = FirstNameReg;
            user.LastName = LastNameReg;
            user.EmailAddress = EmailAddressReg;
            user.Password = PasswordReg;
            user.PhoneNumber = PhoneNumberReg;
            user.Birthday = BirthdayReg.Date.ToString();
            user.Gender = GenderReg;
            user.ProfileImage = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            daoUser = new DaoUser();
            if (daoUser.AddUser(user)== true)
            {
                await Navigation.PushAsync(new MasterPage(user, true));
            }
            
           
            

        }

 

    }
}
