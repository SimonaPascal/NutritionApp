using ProiectPDMXamarin_Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProiectPDMXamarin.ViewModels
{
    public class ListaViewModel
    {
        public DateTime DataSelectata { get; set; } = DateTime.Now.Date;
        public DateTime DataMinima { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public DateTime DataMaxima { get; set; } = DateTime.Now.Date.AddDays(7);

        public List<ListaMeseViewModel> ListaMese { get; set; }
    }

    public class ListaMeseViewModel: List<Masa>
    {
        public string Nume { get; set; }

        public int TotalCalorii
        {
            get
            {
                return Mese.Sum(m => m.Calorii);
            }
        }

        public string Titlu
        {
            get
            {
                return $"{Nume} - {TotalCalorii} calorii";
            }
        }

        public List<Masa> Mese => this;
    }
}
