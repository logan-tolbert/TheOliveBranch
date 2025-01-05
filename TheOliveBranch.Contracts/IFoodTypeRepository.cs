
using TheOliveBranch.Models;

namespace TheOliveBranch.Contracts;

public interface IFoodTypeRepository : IRepository<FoodType>
{
    void Update(FoodType foodType);
    void Save();
}
