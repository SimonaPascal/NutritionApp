using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Services;
using ProiectPDMXamarin.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectPDMXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public User user;
        MasterViewModel masterViewModel;
        DaoUser daoUser;
        public MasterPage(User user, bool initialLoad = true)
        {
            InitializeComponent();
            daoUser = new DaoUser();
            this.user = user;
            masterViewModel = new MasterViewModel(user);
            BindingContext = masterViewModel;
            navigationList.ItemsSource = masterViewModel.menu;

            if(initialLoad)
                Detail = new NavigationPage(new ProfilePage(user));
            else
                Detail = new NavigationPage(new ListaMese());
        }

        private void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var item = e.Item as MenuItems;
                masterViewModel.UpdateUI(user);
                switch (item.OptionName)
                {
                    case "Add a meal":
                        {
                            
                            Detail = new NavigationPage(new AdaugaMasa());
                            IsPresented = false;
                        }
                        break;
                    case "Profile":
                        {

                            Detail.Navigation.PushAsync(new ProfilePage(user));
                            IsPresented = false;
                        }
                        break;
                    case "Meals":
                        {

                            Detail.Navigation.PushAsync(new ListaMese());
                            IsPresented = false;
                        }
                        break;
                    case "Recipes":
                        {

                            Detail.Navigation.PushAsync(new RecipeListPage());
                            IsPresented = false;
                        }
                        break;
                    case "Body index":
                        {

                            Detail.Navigation.PushAsync(new CalculatorIBM());
                            IsPresented = false;
                        }
                        break;
                        
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}