using System.Collections.Generic;
using System.Linq;

namespace ConferenceApp.Backend.Data
{
    public class Attendee : Domain.Attendee
    {
        public virtual IEnumerable<SessionAttendee> Sessions { get; set; } = new List<SessionAttendee>();
        public static Attendee FromDomain(Domain.Attendee domain)
        {
            return new Attendee { 
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                EmailAddress = domain.EmailAddress,
                UserName = domain.UserName,
            };
        }
        public Domain.AttendeeDTO AttendeeResponse() => new Domain.AttendeeDTO
        {
            FirstName = FirstName,
            LastName = LastName,
            EmailAddress = EmailAddress,
            UserName = UserName,
            Sessions = Sessions.Select(s => new Domain.SessionDTO 
                {
                    Title = s.Session.Title,
                    Description = s.Session.Description,
                })
        };
        
    }
}
