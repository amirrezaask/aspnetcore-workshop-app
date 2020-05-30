using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Backend.Data {
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<SessionAttendee>().HasKey(sa => new { sa.AttendeeId, sa.SessionId });
            modelBuilder.Entity<SessionSpeaker>().HasKey(ss => new { ss.SpeakerId, ss.SessionId });

            // seeding data
            modelBuilder.Entity<Speaker>().HasData(new Speaker
            {
                ID = 1,
                Name = "Scott hanselman",
                Bio = "Awesome Scott",
                Website = "hanselman.com",
            });
            modelBuilder.Entity<Session>().HasData(new Session
            {
                ID = 1,
                Title = "Keynote",
            });
            modelBuilder.Entity<SessionSpeaker>().HasData(new SessionSpeaker 
            {
                SpeakerId = 1,
                SessionId = 1,
            });
            modelBuilder.Entity<Attendee>().HasData(new Attendee 
            {
                Id = 1,
                FirstName = "Amirreza",
                LastName = "Askarpour",
                EmailAddress = "raskarpour@gmail.com",
                UserName = "amirrezaask"
            });
            modelBuilder.Entity<SessionAttendee>().HasData(new SessionAttendee
            {
                AttendeeId = 1,
                SessionId = 1,
            });
        }
        public DbSet<Speaker> Speakers {get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

    }

    
}