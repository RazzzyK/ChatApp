using ChatApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace ChatApp.Persistance
{
    public class YourDbContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }

        private readonly IConfiguration _configuration;

        public YourDbContext(DbContextOptions<YourDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public bool IsDatabaseConnected()
        {
            try
            {
                //Database.EnsureCreated(); // Ensure that the database is created (optional)
                Database.OpenConnection(); // Open a connection to the database
                Database.CloseConnection(); // Close the connection
                return true; // Connection is successful
            }
            catch
            {
                return false; // Connection failed
            }
        }

    }
}
