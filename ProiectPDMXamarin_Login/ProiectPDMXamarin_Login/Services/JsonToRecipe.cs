using ProiectPDMXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPDMXamarin.Services
{
    class JsonToRecipe
    {
        public static string initialUrl = "https://api.edamam.com/search";

        public static async Task<ObservableCollection<Recipe>> getRecipes(string searchTerm)
        {
            string url = initialUrl + "?app_id=3d308855&app_key=160ffe693ed5581ff5d165f4f6255b95&from=0&to=10&q=" + searchTerm;
            ObservableCollection<Recipe> recipeList = new ObservableCollection<Recipe>();

            HttpClient httpClient = new HttpClient();

            var uri = new Uri(url);
            Stream respStream = await httpClient.GetStreamAsync(uri);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Rootobject));
            Rootobject feed = (Rootobject)serializer.ReadObject(respStream);


            for (int i = 0; i < feed.hits.Length; i++)
            {
                recipeList.Add(feed.hits[i].recipe);
                System.Diagnostics.Debug.WriteLine(feed.hits[i].recipe.label);
            }

            return recipeList;
        }
    }
}
