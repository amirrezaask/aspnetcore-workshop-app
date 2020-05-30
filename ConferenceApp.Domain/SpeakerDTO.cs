using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceApp.Domain
{
    public class SpeakerDTO: Speaker
    {
        public IEnumerable<SessionDTO> Sessions { get; set; }
    }
}
