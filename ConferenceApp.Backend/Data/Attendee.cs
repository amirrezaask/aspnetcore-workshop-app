﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApp.Backend.Data
{
    public class Attendee : Domain.Attendee
    {
        public virtual IEnumerable<SessionAttendee> Sessions { get; set; }
    }
}
