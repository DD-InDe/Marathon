using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Entities
{
    public partial class Runner
    {
        public string RunnerGender
        {
            get
            {
                switch (Gender)
                {
                    case "Female":
                        return "женский";
                    case "Male":
                        return "мужской";
                }

                return null;
            }

            set { }
        }
        public string FullName
        {
            get
            {
                User user = DB.entities.User.First(c => c.Email == Email);
                return user.FirstName + " " + user.LastName;
            }

            set { }
        }
        public string Age
        {
            get
            {
                return Convert.ToString(Convert.ToInt32(((DateTime.Now - Convert.ToDateTime(DateOfBirth)).TotalDays / 365.35)));
            }

            set
            {

            }
        }
        public string Date
        {
            get
            {
                DateTime date = Convert.ToDateTime(DateOfBirth);
                return date.ToString("D");
            }
        }
    }
}
