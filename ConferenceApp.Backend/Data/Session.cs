using ConferenceApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceApp.Backend.Data
{
    public class Session : Domain.Session
    {
        public virtual ICollection<SessionAttendee> Attendees { get; set; }  = new List<SessionAttendee>();
        public virtual ICollection<SessionSpeaker> Speakers { get; set; }  = new List<SessionSpeaker>();

        public SessionDTO SessionResponse()
            => new SessionDTO
            {
                Title = Title,
                Description = Description,
                Attendees = Attendees.Select(a => new AttendeeDTO
                { UserName = a.Attendee.UserName, EmailAddress = a.Attendee.EmailAddress })
            };

    }
}
