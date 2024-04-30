using Microsoft.EntityFrameworkCore;
using WebApi_MVCMediateRApp.Data.Models;

namespace WebApi_MVCMediateRApp.Data.MediatRWebApiDbContext
{


    public class MediatRWebApiDbContext : DbContext
    {
        public MediatRWebApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }
    }

}
