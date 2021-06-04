using ProiectPDMXamarin.Models;
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
    public partial class RecipeDetails : ContentPage
    {
        public RecipeDetails(Recipe recipe)
        {
            InitializeComponent();

            ItemTitle.Text = recipe.label;
            ItemImage.Source = new UriImageSource()
            {
                Uri = new Uri(recipe.image)
            };
            ItemQuantity.Text = recipe.totalWeight.ToString();
            ItemCalories.Text = recipe.calories.ToString();
            ItemTime.Text = recipe.totalTime.ToString();
        }
    }
}