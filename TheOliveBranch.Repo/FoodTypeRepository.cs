using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOliveBranch.Contracts;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace TheOliveBranch.Repo
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly OliveBranchDbContext _db;
        public FoodTypeRepository(OliveBranchDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(FoodType foodType)
        {
            var record = _db.FoodType.FirstOrDefault(u => u.Id == foodType.Id);
            record.Name = foodType.Name;
            
        }
    }
}
