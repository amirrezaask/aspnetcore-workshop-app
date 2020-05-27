using System.Collections.Generic;

namespace ConferenceApp.Backend.Data
{
    public class Speaker : Domain.Speaker
    {
        public virtual ICollection<SessionSpeaker> Sessions { get; set; }
    }
}
