using ProiectPDMXamarin_Login.Enums;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectPDMXamarin_Login.Models
{
    public class Masa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string TipMasa { get; set; }

        public int Calorii { get; set; }

        public string Nume { get; set; }
    }
}
