using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheOliveBranch.Models;

namespace TheOliveBranch.Contracts
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        void Update(MenuItem MenuItem);
        void Save();
    }
}
