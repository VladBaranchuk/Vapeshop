using System.Linq;
using System.Windows.Media;
using System;
using System.Windows.Media.Imaging;
using System.Security.Cryptography;
using System.Windows;

namespace Veipshop.Model
{
    public static class UserModel
    {
        public static int UserId;
        public static string Name;
        public static string Surname;

        private static string GetHashString(string s)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(s);

            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }

        public static bool CheckLogin(string login)
        {
            using(VapeEntities db = new VapeEntities())
            {
                bool CheckIsExist = db.Users.Any(el => el.login == login);

                if (CheckIsExist) return true;
            }
            return false;
        }

        public static bool CheckPassword(string login, string password)
        {
            string pas = GetHashString(password);

            using (VapeEntities db = new VapeEntities())
            {
                bool CheckIsExist = db.Users.Where(el => el.login == login).Any(el => el.password == pas);

                if (CheckIsExist) return true;
            }
            return false;
        }

        public static void Autorization(string login)
        {
            using (VapeEntities db = new VapeEntities())
            {
                Users user = db.Users.Where(el => el.login == login).FirstOrDefault();

                UserId = user.user_id;
                Name = user.name;
                Surname = user.surname;
                
            }
        }

        public static void Registration(string Name, string Surname, string Login, string Password)
        {
          
            using (VapeEntities db = new VapeEntities())
            {
                Users newUser = new Users()
                {
                    name = Name,
                    surname = Surname,
                    login = Login,
                    password = GetHashString(Password)
                };

                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public static ImageBrush getPhoto(string Name, string Surname)
        {
            ImageBrush Image;

            try
            {
                Image = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/Images/Profiles/" + Name + "_" + Surname + ".png")));
            }
            catch
            {
                Image = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/Images/Profiles/Administrator_.png")));
            }

            return Image;
        }

        public static bool checkLogin(string login)
        {
            using (VapeEntities db = new VapeEntities())
            {
                bool loginIsExist = db.Users.Any(el => el.login == login);

                return !loginIsExist;
            }
        }
    }
}
