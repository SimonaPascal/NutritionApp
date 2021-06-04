using ProiectPDMXamarin_Login.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProiectPDMXamarin.Services
{
    public class MasaServiciu
    {

        SQLiteConnection connection;
        public MasaServiciu()
        {
            string connectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "fitness.db");
            connection = new SQLiteConnection(connectionString);
            connection.CreateTable<Masa>();

        }

        public int AdaugaMasa(Masa masa)
        {
            return connection.Insert(masa);
        }

        public int AdaugaListaMasa(List<Masa> mese)
        {
            return connection.InsertAll(mese);
        }

        public List<Masa> ObtineMese(DateTime data)
        {
            return connection.Query<Masa>("Select * from Masa where Data = ?", data);

        }
    }
}
