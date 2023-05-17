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
    }
}
