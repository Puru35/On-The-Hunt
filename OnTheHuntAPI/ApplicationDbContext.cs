using Microsoft.EntityFrameworkCore;
using OnTheHunt.Models; 

namespace OnTheHunt.Data
{
    public class ApplicationDbContext : DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
