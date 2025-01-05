using TheOliveBranch.Contracts;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace TheOliveBranch.Repo;

public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
{
    private readonly OliveBranchDbContext _db;
    public MenuItemRepository(OliveBranchDbContext db) : base (db)
    {
        _db = db;
    }

    public void Save()
    {
        _db.SaveChanges();
    }

    public void Update(MenuItem menuItem)
    {
        var record = _db.MenuItems.FirstOrDefault(m => m.Id == menuItem.Id);
        record.Name = menuItem.Name;
        record.Description = menuItem.Description;
        record.Price = menuItem.Price;
        record.DisplayOrder = menuItem.DisplayOrder;
        record.FoodTypeId = menuItem.FoodTypeId;
        record.CategoryId = menuItem.CategoryId;
        record.Image = (record != null) ? menuItem.Image : record.Image;
    }
}
