using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Backend.Data {
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Speaker> Speakers {get; set; }
        
    }

    
}