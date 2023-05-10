using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Entities
{
    public partial class Runner
    {
        public string AgeCategory
        {
            get
            {
                int ageCategory = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(DateOfBirth)).TotalDays / 365.35);
                string category;

                if (ageCategory < 18)
                    category = "до 18";
                else if (ageCategory < 30)
                    category = "от 18 до 29";
                else if (ageCategory < 40)
                    category = "от 30 до 39";
                else if (ageCategory < 56)
                    category = "от 40 до 55";
                else if (ageCategory < 70)
                    category = "от 56 до 70";
                else
                    category = "более 70";
                return category;
            }

            set { }
        }
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
    }
}
