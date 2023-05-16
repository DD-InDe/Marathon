using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Entities
{
    partial class Gender
    {
        public string GenderName
        {
            get
            {
                if (Gender1 == "Female")
                    return "Женский";
                return "Мужской";
            }
        }
    }
}
