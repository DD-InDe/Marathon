using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Entities
{
    public partial class SpeedObjects
    {
        public string Description
        {
            get
            {
                double timeHours = 42/Convert.ToDouble(Speed);
                string description = $"Максимальная скорость {ObjectName} {Speed} км/ч. Это займет {Convert.ToInt32(timeHours)} ч. и {TimeSpan.FromHours(timeHours).Minutes} мин. чтобы завершить 42 км марафон.";
                return description;
            }
        }
    }
}
