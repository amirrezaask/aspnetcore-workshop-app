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
        }
        public DbSet<Speaker> Speakers {get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

    }

    
}