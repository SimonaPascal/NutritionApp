using ProiectPDMXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectPDMXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        RegistrationViewModel registrationViewModel;
        public RegistrationPage()
        {
            InitializeComponent();
            registrationViewModel = new RegistrationViewModel();
            registrationViewModel.Navigation = Navigation;
            BindingContext = registrationViewModel;
        }
    }
}