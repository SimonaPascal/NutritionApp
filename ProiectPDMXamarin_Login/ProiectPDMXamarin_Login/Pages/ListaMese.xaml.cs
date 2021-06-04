using ProiectPDMXamarin.Services;
using ProiectPDMXamarin.ViewModels;
using ProiectPDMXamarin_Login.Models;
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
    public partial class ListaMese : ContentPage
    {
        ListaViewModel vm = new ListaViewModel();

        public ListaMese(DateTime? data = null)
        {
            InitializeComponent();
            data = data ?? DateTime.Now.Date;
            AduDate(data);
        }

        private void AduDate(DateTime? data)
        {
            MasaServiciu serviciu = new MasaServiciu();
            var listaMese = serviciu.ObtineMese(data.Value);
            var listaGrupata = listaMese.GroupBy(l => l.TipMasa.ToString()).ToList();
            vm.ListaMese = new List<ListaMeseViewModel>();
            listaGrupata.ForEach(g =>
            {
                var mese = new ListaMeseViewModel();
                mese.AddRange(g.ToList());
                mese.Nume = g.Key;
                vm.ListaMese.Add(mese);
            });
            listViewMese.ItemsSource = vm.ListaMese;
            BindingContext = vm;
        }

        void OnDateChanged(object sender, DateChangedEventArgs e)
        {
            vm.DataSelectata = e.NewDate.Date;
            AduDate(vm.DataSelectata);
        }
    }
}