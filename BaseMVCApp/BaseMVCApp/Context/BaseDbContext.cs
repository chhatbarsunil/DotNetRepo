using BaseMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseMVCApp.Context
{
    public class BaseDbContext: DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<BaseMVCApp.Models.Product>? Product { get; set; }
    }
}
