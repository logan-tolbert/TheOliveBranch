using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TheOliveBranch.Contracts;
using TheOliveBranch.Data;

namespace TheOliveBranch.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OliveBranchDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(OliveBranchDbContext db)
        {
            _db = db;
            this.dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;

            if(filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }
    }
}
