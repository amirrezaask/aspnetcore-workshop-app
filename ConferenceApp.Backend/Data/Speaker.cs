using ConferenceApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceApp.Backend.Data
{
    public class Speaker : Domain.Speaker
    {
        public virtual ICollection<SessionSpeaker> Sessions { get; set; } = new List<SessionSpeaker>();

        public SpeakerDTO SpeakerRespone()
            => new SpeakerDTO
            {
                Name = Name,
                Bio = Bio,
                Sessions = Sessions.Select(s => new SessionDTO
                {
                    Title = s.Session.Title,
                    Description = s.Session.Description,
                })

            };
    }
}
