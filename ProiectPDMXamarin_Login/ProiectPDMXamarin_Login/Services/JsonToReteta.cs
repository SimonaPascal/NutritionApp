using ProiectPDMXamarin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPDMXamarin.Services
{
    class JsonToReteta
    {
        public static string urlInitial = "https://api.edamam.com/search?q=";

        public static async Task<List<Recipe>> PreiaReteta(string ingrediente, string dieta)
        {
            string url = urlInitial + ingrediente + "&app_id=ff85071b&app_key=d3efa4ef3ec092ef2cc016bb530897f4&from=0&to=10&diet=" + dieta;
            List<Recipe> listaRetete = new List<Recipe>();
            
            HttpClient httpClient = new HttpClient();

            var uri = new Uri(url);
            Stream respStream = await httpClient.GetStreamAsync(uri);

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Rootobject));
            Rootobject feed = (Rootobject)ser.ReadObject(respStream);


            for (int i=0; i < feed.hits.Length; i++ ) {
                listaRetete.Add(feed.hits[i].recipe);
                System.Diagnostics.Debug.WriteLine(feed.hits[i].recipe.label);
            }

            return listaRetete; 
        }
    }
}
