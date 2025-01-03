﻿using Microsoft.EntityFrameworkCore;
using TheOliveBranch.Models;

namespace TheOliveBranch.Data
{
    public class OliveBranchDbContext : DbContext
    {
        public OliveBranchDbContext(DbContextOptions<OliveBranchDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
