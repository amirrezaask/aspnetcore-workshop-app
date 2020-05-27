using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Backend.Data
{
    public class Session : Domain.Session
    {
        public virtual ICollection<SessionAttendee> Attendees { get; set; }
        public virtual ICollection<SessionSpeaker> Speakers { get; set; }

    }
}
