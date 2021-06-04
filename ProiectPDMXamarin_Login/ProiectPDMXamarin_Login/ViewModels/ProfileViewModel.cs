using Plugin.Media.Abstractions;
using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProiectPDMXamarin.ViewModels
{
    class ProfileViewModel
    {
        private User user;
        private DaoUser daoUser;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserDetails { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string URL { get; set; }
        public ImageSource ImageView { get; set; }

        public ICommand SaveCommand { get; set; }
 
        public ProfileViewModel(User user)
        {
            this.user = user;
            daoUser = new DaoUser();
            SaveCommand = new Command(Save_Button_Pressed);


            UpdateUI(user);
        }

        private void UpdateUI(User user)
        {
            //ImageView = "Images/profile_icon.png";
            FirstName = user.FirstName;
            LastName = user.LastName;
            EmailAddress = user.EmailAddress;
            PhoneNumber = user.PhoneNumber;
            if(user.Birthday != null)
            {
                DateTime date = DateTime.Parse(user.Birthday);
                Birthday = date;
            }

            Gender = user.Gender;
            var array = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            if (user.ProfileImage != array && user.ProfileImage != null)
            {
                Stream stream = new MemoryStream(user.ProfileImage);
                ImageView = ImageSource.FromStream(() => stream);
            }

        }


        private void Save_Button_Pressed()
        {
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.PhoneNumber = PhoneNumber;
            user.Gender = Gender;
            user.Birthday = Birthday.Date.ToString();
            user.EmailAddress = EmailAddress;
            daoUser.updateUser(user);

        }


       
        

    }
}
