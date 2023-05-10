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
    }
}
