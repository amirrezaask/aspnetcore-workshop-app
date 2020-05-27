using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Backend.Data {
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<SessionAttendee>()
                .HasKey(sa => new { sa.SessionId, sa.AttendeeId });
            
            modelBuilder.Entity<SessionSpeaker>()
                .HasKey(sa => new { sa.SessionId, sa.SpeakerId });

        }
        public DbSet<Speaker> Speakers {get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

    }

    
}