using Microsoft.EntityFrameworkCore;
using TheOliveBranch.Models;

namespace TheOliveBranch.Data
{
    public class OliveBranchDbContext : DbContext
    {
        public OliveBranchDbContext(DbContextOptions<OliveBranchDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
    }
}
