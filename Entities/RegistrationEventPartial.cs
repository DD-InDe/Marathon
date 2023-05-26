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
                List<RegistrationEvent> runnersList = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == eventList.Event.MarathonId && c.RaceTime != null && c.RaceTime != 0).ToList();
                runnersList = runnersList.OrderBy(c => c.RaceTime).ToList();

                runnersList.AddRange(DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == eventList.Event.MarathonId && c.RaceTime == 0 || c.Event.MarathonId == eventList.Event.MarathonId && c.RaceTime == null).ToList());
                string number = "#" + Convert.ToString(runnersList.IndexOf(eventList) + 1);
                return number;
            }
        }

        public string CategoryPlace // метод для страницы с результатами конкретного бегуна
        {
            get
            {
                RegistrationEvent runner = DB.entities.RegistrationEvent.Where(c => c.Registration.RunnerId == Registration.RunnerId && c.EventId == EventId).FirstOrDefault();
                List<RegistrationEvent> runnersList = DB.entities.RegistrationEvent.Where(c => c.Event.MarathonId == runner.Event.MarathonId && c.RaceTime != null && c.RaceTime != 0 && c.Registration.Runner.AgeId == runner.Registration.Runner.AgeId && c.Registration.Runner.Gender == runner.Registration.Runner.Gender).ToList();

                runnersList = runnersList.OrderBy(c => c.RaceTime).ToList();

                runnersList.AddRange(DB.entities.RegistrationEvent.Where(c =>
                    c.Event.MarathonId == runner.Event.MarathonId &&
                    c.RaceTime == null &&
                    c.Registration.Runner.AgeId == runner.Registration.Runner.AgeId &&
                    c.Registration.Runner.Gender == runner.Registration.Runner.Gender
                    ||
                    c.Event.MarathonId == runner.Event.MarathonId &&
                    c.RaceTime == 0 &&
                    c.Registration.Runner.AgeId == runner.Registration.Runner.AgeId &&
                    c.Registration.Runner.Gender == runner.Registration.Runner.Gender).ToList());

                string number = "#" + Convert.ToString(runnersList.IndexOf(runner) + 1);
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
