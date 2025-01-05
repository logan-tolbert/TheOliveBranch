namespace TheOliveBranch.Contracts;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Category { get; }
    IMenuItemRepository MenuItem { get; }
    IFoodTypeRepository FoodType { get; }
    void Save();
}
