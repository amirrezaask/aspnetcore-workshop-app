using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceApp.Domain
{
    public class SessionDTO: Session
    {
        public IEnumerable<Attendee> Attendees { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }

        
    }
}
