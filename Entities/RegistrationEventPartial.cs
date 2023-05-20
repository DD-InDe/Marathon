using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marathon.Entities
{
    partial class RegistrationEvent
    {
        public string GeneralPlace // метод для страницы с результатами конкретного бегуна
        {
            get
            {
                RegistrationEvent eventList = DB.entities.RegistrationEvent.Where(c => c.Registration.RunnerId == Registration.RunnerId && c.EventId == EventId).FirstOrDefault();
                List<RegistrationEvent> marathonList = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == eventList.Event.MarathonId).ToList();
                marathonList.OrderBy(c => c.RaceTime);
                string number = "#" + Convert.ToString(marathonList.IndexOf(eventList) + 1);
                return number;
            }
        }

        public string CategoryPlace // метод для страницы с результатами конкретного бегуна
        {
            get
            {
                List<RegistrationEvent> runnerList = new List<RegistrationEvent>(); /*лист всех бегунов*/
                RegistrationEvent eventList = DB.entities.RegistrationEvent.Where(c => c.Registration.RunnerId == Registration.RunnerId && c.EventId == EventId).FirstOrDefault();
                int ageCategory = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(Registration.Runner.DateOfBirth)).TotalDays / 365.35);
                int min, max;

                if (ageCategory < 18)
                {
                    min = 0;
                    max = 18;
                }
                else if (ageCategory < 30)
                {
                    min = 18;
                    max = 30;
                }
                else if (ageCategory < 40)
                {
                    min = 30;
                    max = 40;
                }
                else if (ageCategory < 56)
                {
                    min = 40;
                    max = 55;
                }
                else if (ageCategory < 70)
                {
                    min = 55;
                    max = 70;
                }
                else
                {
                    min = 70;
                    max = int.MaxValue;
                }

                foreach (var runner in DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == eventList.Event.MarathonId).ToList())
                {
                    int runnerAge = Convert.ToInt32((DateTime.Now - Convert.ToDateTime(runner.Registration.Runner.DateOfBirth)).TotalDays / 365.35);
                    if (min <= runnerAge && runnerAge < max && runner.Registration.Runner.Gender == Registration.Runner.Gender)
                        runnerList.Add(runner);
                }
                runnerList.OrderBy(c => c.RaceTime);
                string number = "#" + Convert.ToString(runnerList.IndexOf(eventList) + 1);

                return number;
            }
        }

        public string Time
        {
            get
            {
                RegistrationEvent regEvent = DB.entities.RegistrationEvent.Where(c => c.Registration.RunnerId == Registration.RunnerId && c.EventId == EventId && c.Registration.Runner.AgeId == Registration.Runner.AgeId && Registration.Runner.Gender1.Gender1 == Registration.Runner.Gender1.Gender1).FirstOrDefault();
                var f = TimeSpan.FromSeconds(Convert.ToInt32(regEvent.RaceTime));
                string time = $"{f.Hours}h {f.Minutes}m {f.Seconds}s";

                return time;
            }
        }

        public string FullName
        {
            get
            {
                return Registration.Runner.User.FirstName + " " + Registration.Runner.User.LastName;
            }
        }
    }
}
