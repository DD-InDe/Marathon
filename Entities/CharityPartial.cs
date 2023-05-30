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
        public int TotalSum
        {
            get
            {
                Entities.Marathon marathon = DB.entities.Marathon.ToList().Last();
                List<RegistrationEvent> regEventList = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == marathon.MarathonId).ToList();
                int total = 0;

                foreach (RegistrationEvent regEvent in regEventList)
                {
                    Registration registration = DB.entities.Registration.Where(c => c.RegistrationId == regEvent.RegistrationId && c.CharityId == CharityId).ToList().LastOrDefault();
                    if (registration != null)
                        total += Convert.ToInt32(registration.SponsorshipTarget);
                }
                return total;
            }
        }
    }
}
