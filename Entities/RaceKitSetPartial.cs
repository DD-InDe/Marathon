using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Entities
{
    partial class RaceKitSet
    {
        public int KitOptionA
        {
            get
            {
                var regEvent = DB.entities.RegistrationEvent.Where(c => c.EventId == "15_5HM" && c.Registration.RaceKitOptionId =="A").ToList();
                return regEvent.Count;
            }
        }
        public int KitOptionB
        {
            get
            {
                var regEvent = DB.entities.RegistrationEvent.Where(c => c.EventId == "15_5HM" && c.Registration.RaceKitOptionId == "B").ToList();
                return regEvent.Count;
            }
        }
        public int KitOptionC
        {
            get
            {
                var regEvent = DB.entities.RegistrationEvent.Where(c => c.EventId == "15_5HM" && c.Registration.RaceKitOptionId == "C").ToList();
                return regEvent.Count;
            }
        }
        public string FirstString
        {
            get
            {
                return "Выбрало данный вариант";
            }
        }
    }
}
