using System.Collections.Generic;

namespace ConferenceApp.Backend.Data
{
    public class Speaker : Domain.Speaker
    {
        public virtual IEnumerable<SessionSpeaker> Sessions { get; set; }
    }
}
