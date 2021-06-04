using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectPDMXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeListPage : ContentPage
    {
        ObservableCollection<Recipe> recipeList = new ObservableCollection<Recipe>();
        public RecipeListPage()
        {
            InitializeComponent();
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs evArgs)
        {
            var details = evArgs.Item as Recipe;
            await Navigation.PushAsync(new RecipeDetails(details));
        }

        private async void onButtonSearch(Object sender, EventArgs e)
        {
            recipeList = await JsonToRecipe.getRecipes(wordInput.Text);
            recipeListUI.ItemsSource = recipeList;
        }
    }
}