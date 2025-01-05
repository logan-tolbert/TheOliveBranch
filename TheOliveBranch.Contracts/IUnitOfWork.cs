namespace TheOliveBranch.Contracts;

public interface IUnitOfWork : IDisposable
{
    ICategoryRepository Category { get; }
    IMenuItemRepository MenuItem { get; }
    void Save();
}
