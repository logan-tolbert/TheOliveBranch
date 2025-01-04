
using TheOliveBranch.Models;

namespace TheOliveBranch.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        void Save();
    }
}
