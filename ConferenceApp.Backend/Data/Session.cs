using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Backend.Data
{
    public class Session : Domain.Session
    {
        public virtual IEnumerable<SessionAttendee> Attendees { get; set; }
        public virtual IEnumerable<SessionSpeaker> Speakers { get; set; }

    }
}
