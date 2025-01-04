using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOliveBranch.Contracts;
using TheOliveBranch.Data;

namespace TheOliveBranch.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OliveBranchDbContext _db;
        public UnitOfWork(OliveBranchDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
