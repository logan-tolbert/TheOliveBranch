using TheOliveBranch.Contracts;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace TheOliveBranch.Repo;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly OliveBranchDbContext _db;
    public CategoryRepository(OliveBranchDbContext db) : base (db)
    {
        _db = db;
    }

    public void Save()
    {
        _db.SaveChanges();
    }

    public void Update(Category category)
    {
        var record = _db.Categories.FirstOrDefault(u => u.Id == category.Id);
        record.CategoryName = category.CategoryName;
        record.DisplayOrder = category.DisplayOrder;
    }
}
