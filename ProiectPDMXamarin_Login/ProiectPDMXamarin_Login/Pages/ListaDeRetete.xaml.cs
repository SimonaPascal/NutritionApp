using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Services;
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
    public partial class ListaDeRetete : ContentPage
    {
        List<Recipe> listaRetete = new List<Recipe>();
        string ingrediente { get; set; }
        string tipDieta { get; set; }
        public ListaDeRetete(string ingrediente, string tipDieta)
        {
            InitializeComponent();
            this.ingrediente = ingrediente;
            this.tipDieta = tipDieta;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listaRetete = await JsonToReteta.PreiaReteta(ingrediente, tipDieta);

            listViewRetete.ItemsSource = listaRetete;

        }
    }
}