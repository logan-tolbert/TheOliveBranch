using Microsoft.EntityFrameworkCore;
using OliveBranch.Web.Models;

namespace OliveBranch.Web.Data
{
    public class OliveBranchDbContext : DbContext
    {
        public OliveBranchDbContext(DbContextOptions<OliveBranchDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
