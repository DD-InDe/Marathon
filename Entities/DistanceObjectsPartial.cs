using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Entities
{
    public partial class DistanceObjects
    {
        public string Description
        {
            get
            {
                double count = 42000 / Convert.ToDouble(Distance);
                string description = $"Длина {ObjectName} {Distance} м. Это займет {Convert.ToInt32(count)} из них, чтобы покрыть расстояние в 42 км марафона.";
                return description;
            }
        }
    }
}
