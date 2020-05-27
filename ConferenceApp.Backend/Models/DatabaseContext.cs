using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Backend.Models {
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Speaker> Speakers {get; set; }
        
    }

    
}