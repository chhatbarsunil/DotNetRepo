
using Core_MVCMediatRApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_MVCMediatRApp.Context
{

    public class MVCMediatRAppDbContext:DbContext
    {
        private readonly IConfiguration _configuration;

        //public MVCMediatRAppDbContext(DbContextOptions<MVCMediatRAppDbContext> options) : base(options)
        //{

        //}
        public MVCMediatRAppDbContext(DbContextOptions options,IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {// Connection String (replace with your actual connection string)
            string connectionString = _configuration.GetConnectionString("MVCMediatRAppDefault");
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MVCMediatRAppDb;Trusted_Connection=false;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<User>? Users { get; set; }
    }
}
