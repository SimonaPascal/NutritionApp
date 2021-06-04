using ProiectPDMXamarin.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProiectPDMXamarin.ViewModels
{
    class CalculatorIndexViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CalculeazaCommand { get; set; }
        public ICommand PornesteActivitate { get; set; }
        public String ValoareGreutate { get; set; }
        public String ValoareInaltime { get; set; }
        public String ValoareIngrediente { get; set; }
        private string valoareAnaliza = string.Empty;
        public INavigation Navigation { get; set; }
        public string tipDieta = "";
        public string ValoareAnaliza
        {
            get
            {
                return valoareAnaliza;
            }
            set
            {
                valoareAnaliza = value;
                OnPropertyChanged("ValoareAnaliza");
            }
        }
        private bool isvisible;
        public bool isVisible
        {
            get
            {
                return isvisible;
            }

            set
            {
                if (isvisible != value)
                {
                    isvisible = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string rezultat = string.Empty;
        public string Rezultat
        {
            get
            {
                return rezultat;
            }
            set
            {
                rezultat = value;
                OnPropertyChanged("Rezultat");
            }
        }

        public CalculatorIndexViewModel()
        {
            CalculeazaCommand = new Command(Calculeaza_Click);
            PornesteActivitate = new Command(porneste_activitate);
            isVisible = false;
        }


        async public void porneste_activitate()
        {
            //the other type i could try to parse data is by inserting the string into the constructor of the 2nd page
            string ingrediente = ValoareIngrediente;
            var listaDeRetete = new ListaDeRetete(ingrediente, tipDieta);
            await Navigation.PushAsync(listaDeRetete);
        }

        public void Calculeaza_Click()
        {
            double greutate = 0;
            double.TryParse(ValoareGreutate, out greutate);

            double intaltime = 0;
            double.TryParse(ValoareInaltime, out intaltime);



            double ibm = greutate / (intaltime / 100 * intaltime / 100);
            ibm = Math.Round(ibm, 1);
            Rezultat = ibm.ToString();
            isVisible = true;

            if (ibm >= 18.5d)
            {
                ValoareAnaliza = "Sub 18,5 – Un risc ridicat de sănătate dacă nu alegi o dietă sănătoasă, bogată în nutrienţi. Poţi consulta un nutriţionist pentru sfaturi legate de mâncare, fără să fie nevoie să te îngraşi.";
                tipDieta = "high-fiber";
            }
            if (ibm > 18.5d && ibm < 24.999d)
            {
                tipDieta = "high-protein";
                ValoareAnaliza = "18,5 – 24,9 – Un risc mic pentru sănătate. O dietă echilibrată te va ajuta să te bucuri de nutrienţi.";
            }
            if (ibm > 24.999d && ibm < 29.999d)
            {
                ValoareAnaliza = "25 – 29,9 – Ai o greutate moderată, nu trebuie să îţi faci griji.";
                tipDieta = "balanced";
            }
            if (ibm > 29.999d && ibm < 34.999d)
            {
                tipDieta = "low-carb";
                ValoareAnaliza = "30 – 34,9 – Îţi recomandăm să elimini dulciurile şi alimentele nesănătoase din dietă.";
            }
            if (ibm > 35d)
            {
                tipDieta = "low-fat";
                ValoareAnaliza = "Peste 35 – Acest rezultant arată că greutatea îţi afectează sănătatea. Vorbeşte cu un nutriţionist şi găseşte o cale să elimini kg în plus.";
            }


        }
    }
}
