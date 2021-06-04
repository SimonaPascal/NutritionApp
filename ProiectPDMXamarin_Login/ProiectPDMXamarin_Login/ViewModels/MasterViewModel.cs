
using ProiectPDMXamarin.Models;
using ProiectPDMXamarin.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Windows.Input;

namespace ProiectPDMXamarin.ViewModels
{
    class MasterViewModel
    {
        
        public List<MenuItems> menu;
        public string UserName { get; set; }
        public string UserDetails {get; set;}
        public User user;
        public DaoUser daoUser;

       

        public ICommand ItemTappedCommand { get; set; }

        public MasterViewModel(User user)
        {
            daoUser = new DaoUser();
            if(user != null)
            {
                //daoUser.AddUser(user);
                //this.user = daoUser.searchUserById(user);
                AddMenuItems();
                //ItemTappedCommand = new Command(Item_Tapped);

                UpdateUI(user);
            }


        }

        public void AddMenuItems()
        {
            menu = new List<MenuItems>();

            menu.Add(new MenuItems { OptionName = "Recipes", IconName = "Images/recipes_icon.png" });
            menu.Add(new MenuItems { OptionName = "Add a meal", IconName = "Images/add_a_meal_icon.png" });
            menu.Add(new MenuItems { OptionName = "Meals", IconName = "Images/meals_icon.png" });
            menu.Add(new MenuItems { OptionName = "Profile", IconName = "Images/profile_icon.png" });
            menu.Add(new MenuItems { OptionName = "Body index", IconName = "Images/body_index_icon.png" });

        }
        public void UpdateUI(User user)
        {

            UserName = user.FirstName + " " + user.LastName;
            if(user.Birthday != null)
            {
                DateTime zeroTime = new DateTime(1, 1, 1);

                DateTime a = DateTime.Now;
                DateTime b = DateTime.Parse(user.Birthday);

                TimeSpan span = a - b;

                int years = (zeroTime + span).Year - 1;
                UserDetails = user.Gender + " - " + years + " years old";
            }

        }

  


    }

    public class MenuItems
    {
        public string OptionName { get; set; }
        public string IconName { get; set; }
    }
}
