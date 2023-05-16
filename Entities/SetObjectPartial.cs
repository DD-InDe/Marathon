using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Entities
{
    partial class SetObjects
    {
        public int KitOptionA
        {
            get
            {
                if (DB.entities.RaceKitSet.Where(c => c.SetObjects1.ObjectId == ObjectId && c.RaceKitOption1.RaceKitOptionId == "A").ToList().Count == 0)
                {
                    return 0;
                }
                else
                {
                    var regEvent = DB.entities.RegistrationEvent.Where(c => c.EventId == "15_5HM" && c.Registration.RaceKitOptionId == "A").ToList();
                    return regEvent.Count;
                }
            }
        }
        public int KitOptionB
        {
            get
            {
                if (DB.entities.RaceKitSet.Where(c => c.SetObjects1.ObjectId == ObjectId && c.RaceKitOption1.RaceKitOptionId == "B").ToList().Count == 0)
                {
                    return 0;
                }
                else
                {
                    var regEvent = DB.entities.RegistrationEvent.Where(c => c.EventId == "15_5HM" && c.Registration.RaceKitOptionId == "B").ToList();
                    return regEvent.Count;
                }
            }
        }
        public int KitOptionC
        {
            get
            {
                if (DB.entities.RaceKitSet.Where(c => c.SetObjects1.ObjectId == ObjectId && c.RaceKitOption1.RaceKitOptionId == "C").ToList().Count == 0)
                {
                    return 0;
                }
                else
                {
                    var regEvent = DB.entities.RegistrationEvent.Where(c => c.EventId == "15_5HM" && c.Registration.RaceKitOptionId == "C").ToList();
                    return regEvent.Count;
                }
            }
        }
        public int Sum
        {
            get
            {
                return KitOptionA + KitOptionB + KitOptionC;
            }
        }
        public int Total
        {
            get
            {
                if (Convert.ToInt32(Sum - ObjectStock) > 0)
                    return Convert.ToInt32(Sum - ObjectStock);
                else
                    return 0;
            }
        }
        int? GetSetValue=0;
        public int? EditStock
        {
            get
            {
                return GetSetValue;
            }

            set
            {
                GetSetValue = value;
                ObjectStock += GetSetValue;
            }
        }
    }
}
