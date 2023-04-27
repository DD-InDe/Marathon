using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Resources
{
    public static class AppMain
    {
        public static bool MD(string password)
        {
            if (PasswordCharCheck(password) && PasswordNumCheck(password) && PasswordSymCheck(password))
                return true;
            return false;
        }

        private static bool PasswordCharCheck(string password)
        {
            for (int i = 0; i < password.Length; i++)
                if (char.IsUpper(password[i])) return true;
            return false;
        }
        private static bool PasswordNumCheck(string password)
        {
            for (int i = 0; i < password.Length; i++)
                if (char.IsDigit(password[i])) return true;
            return false;
        }
        private static bool PasswordSymCheck(string password)
        {
            if (password.Contains("!") || password.Contains("@") || password.Contains("#") ||
                password.Contains("$") || password.Contains("%") || password.Contains("^"))
                return true;
            return false;
        }
    }
}
