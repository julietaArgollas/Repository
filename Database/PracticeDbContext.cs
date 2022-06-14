using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class PracticeDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Product> Products { get; set; }
        public DbSet<ListProducts> ListProducts { get; set; }

        public PracticeDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetSection("Database").GetSection("ConnectionString").Value;
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}