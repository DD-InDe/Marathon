using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Entities
{
    partial class Charity
    {
        public string ShortDescription
        {
            get
            {
                return CharityDescription.Split('\r')[0];
            }
        }
    }
}
