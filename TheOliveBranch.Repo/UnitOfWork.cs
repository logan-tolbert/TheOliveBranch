using TheOliveBranch.Contracts;
using TheOliveBranch.Data;

namespace TheOliveBranch.Repo;

public class UnitOfWork : IUnitOfWork
{
    private readonly OliveBranchDbContext _db;
    public ICategoryRepository Category { get; private set; }
    public IMenuItemRepository MenuItem { get; private set; }
    public UnitOfWork(OliveBranchDbContext db)
    {
        _db = db;
        Category = new CategoryRepository(_db);
        MenuItem = new MenuItemRepository(_db);
    }

    public void Dispose()
    {
        _db.Dispose();
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
