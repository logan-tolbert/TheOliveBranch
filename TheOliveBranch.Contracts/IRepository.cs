using System.Linq.Expressions;

namespace TheOliveBranch.Contracts
{
    public interface IRepository<T> where T : class 
    {
        void Add(T entity);
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);
        IEnumerable<T> GetAll();
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);  
    }
}
