using Microsoft.EntityFrameworkCore;
using RecruiterApi.Models;

namespace RecruiterApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Candidate>()
                .Property(o => o.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
