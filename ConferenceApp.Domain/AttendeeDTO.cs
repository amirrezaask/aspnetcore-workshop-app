using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceApp.Domain
{
    public class AttendeeDTO: Attendee
    {
        public IEnumerable<SessionDTO> Sessions { get; set; }
    }
}
