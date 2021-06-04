using ProiectPDMXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProiectPDMXamarin.Services
{
    class DaoUser
    {
        SQLiteConnection connection;
        SQLiteCommand comand;
        public DaoUser()
        {
            string caleBazaDeDate = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "nutrition_database.db");
            connection = new SQLiteConnection(caleBazaDeDate);
            connection.CreateTable<User>();

        }

        public bool AddUser(User user)
        {
           
            bool ok = false;
            try
            {
                connection.Insert(user);
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
            }

            return ok;
        }



        public bool updateUser(User user)
        {
            var data = connection.Table<User>();
            var d1 = (from values in data where values.Id == user.Id select values).Single();
            if (true)
            {

                d1.FirstName = user.FirstName;
                d1.LastName = user.LastName;
                d1.Gender = user.Gender;
                d1.Birthday = user.Birthday;
                d1.Password = user.Password;
                d1.PhoneNumber = user.PhoneNumber;
                d1.ProfileImage = user.ProfileImage;
                connection.Update(d1);
                return true;
            }
            else
                return false;
        }

        public bool saveProfileImage(User user)
        {
            var data = connection.Table<User>();
            var d1 = (from values in data where values.Id == user.Id select values).Single();
            if (true)
            {

                d1.ProfileImage = user.ProfileImage;

                connection.Update(d1);
                return true;
            }
            else
                return false;
        }

      

        public User LoginValidate(User u)
        {
            var data = connection.Table<User>();
            var d1 = data.Where(x => x.EmailAddress == u.EmailAddress && x.Password == u.Password).FirstOrDefault();
            if (d1 != null)
            {

                d1.Id = u.Id;
                User user = new User();
                user.FirstName = d1.FirstName;
                user.LastName = d1.LastName;
                user.Gender = d1.Gender;
                user.Birthday = d1.Birthday;
                user.Password = d1.Password;
                user.PhoneNumber = d1.PhoneNumber;
                user.ProfileImage = d1.ProfileImage;
                user.EmailAddress = d1.EmailAddress;
                return user;
            }
            else
                return null;
        }

    }
}
