using Plugin.Media;
using Plugin.Media.Abstractions;
using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Services;
using ProiectPDMXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectPDMXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private User user;
        private DaoUser daoUser;
        private MediaFile mediaFile;
        private ProfileViewModel profileViewModel;
        public ProfilePage(User user)
        {
            InitializeComponent();
            this.user = user;
            daoUser = new DaoUser();
            profileViewModel = new ProfileViewModel(user);
            BindingContext = profileViewModel;
        }

        public byte[] imageToByteArray()
        {
            using (var memoryStream = new MemoryStream())
            {
                mediaFile.GetStream().CopyTo(memoryStream);
                mediaFile.Dispose();
                return memoryStream.ToArray();
            }

        }

        private async void TakePictureBtn_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":(No Camera available.)", "OK");
                return;
            }
            else
            {
                mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "myImage.jpg"
                });

                if (mediaFile != null)
                {
                    imageView.Source = ImageSource.FromStream(() => mediaFile.GetStream());
                    user.ProfileImage = imageToByteArray();
                    daoUser.saveProfileImage(user);
                }

                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };

            }
        }

        private async void SelectPictureBtn_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (mediaFile != null)
                {
                    imageView.Source = ImageSource.FromStream(() => mediaFile.GetStream());
                    user.ProfileImage = imageToByteArray();
                    daoUser.saveProfileImage(user);
                }

            }
        }
    }
}