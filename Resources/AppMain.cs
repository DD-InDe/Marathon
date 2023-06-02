using Marathon.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Marathon.Resources
{
    public static class AppMain
    {
        public static bool PasswordCheck(string password)
        {
            if (PasswordCharCheck() && PasswordNumCheck() && PasswordSymCheck() && PasswordLengthCheck())
                return true;
            return false;

            bool PasswordCharCheck()
            {
                for (int i = 0; i < password.Length; i++)
                    if (char.IsUpper(password[i])) return true;

                MessageBox.Show("Пароль должен содержать хотя бы одну заглавную букву.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            bool PasswordNumCheck()
            {
                for (int i = 0; i < password.Length; i++)
                    if (char.IsDigit(password[i])) return true;

                MessageBox.Show("Пароль должен содержать хотя бы одну цифру.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            bool PasswordLengthCheck()
            {
                if (password.Length > 6)
                    return true;

                MessageBox.Show("Пароль должен содержать минимум из 6 символов.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            bool PasswordSymCheck()
            {
                if (password.Contains("!") || password.Contains("@") || password.Contains("#") ||
                    password.Contains("$") || password.Contains("%") || password.Contains("^"))
                    return true;
                MessageBox.Show("Пароль должен содержать один из символов: !@#$%^", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
        }
        public static bool AgeCheck(DateTime birth)
        {
            if ((DateTime.Now - birth).TotalDays / 365.25 < 10)
            {
                MessageBox.Show("Минимальный возраст для регистрации - 10 лет.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            return true;
        }
        public static bool EmailCheck(string email)
        {
            try { var addr = new System.Net.Mail.MailAddress(email); }
            catch
            {
                MessageBox.Show("Некорректный адрес электронный почты!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public static AgeCategory AgeCategoryCheck(DateTime birth)
        {
            List<AgeCategory> categoryList = DB.entities.AgeCategory.ToList();
            AgeCategory category;
            int age = (int)((DateTime.Now - birth).TotalDays / 365.25);

            if (age < 18)
                category = categoryList.Where(c => c.AgeCategoryId == 1) as AgeCategory;
            else if (age < 30)
                category = categoryList.Where(c => c.AgeCategoryId == 2) as AgeCategory;
            else if (age < 40)
                category = categoryList.Where(c => c.AgeCategoryId == 3) as AgeCategory;
            else if (age < 55)
                category = categoryList.Where(c => c.AgeCategoryId == 4) as AgeCategory;
            else if (age < 70)
                category = categoryList.Where(c => c.AgeCategoryId == 5) as AgeCategory;
            else
                category = categoryList.Where(c => c.AgeCategoryId == 6) as AgeCategory;

            return category;
        }
        public static bool PasswordSameCheck(string password, string passwordRepeat)
        {
            if (password == passwordRepeat)
                return true;

            MessageBox.Show("Пароли не совпадают!", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            return false; 
        }
    }
}
