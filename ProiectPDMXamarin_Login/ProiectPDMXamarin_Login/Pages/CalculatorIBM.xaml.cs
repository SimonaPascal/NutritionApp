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
    public partial class CalculatorIBM : ContentPage
    {
        public CalculatorIBM()
        {
            InitializeComponent();
            CalculatorIndexViewModel calculatorIndexViewModel = new CalculatorIndexViewModel();
            calculatorIndexViewModel.Navigation = Navigation;
            BindingContext = calculatorIndexViewModel;
        }
    }
}