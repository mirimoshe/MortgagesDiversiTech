using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.Entities;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class Db : DbContext, IContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<CustomerTasks>  CustomerTasks { get; set; }
        public DbSet<DocumentTypes> DocumentTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Leads> Leads { get; set; }

        public async Task save()
        {
            await SaveChangesAsync();
        }
        private readonly IConfiguration _configuration;

        public Db(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
      
    }
}
