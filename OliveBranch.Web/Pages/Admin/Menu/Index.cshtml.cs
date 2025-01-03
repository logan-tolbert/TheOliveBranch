using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Menu
{
    public class IndexModel : PageModel
    {
        private readonly OliveBranchDbContext _db;
        public IEnumerable<MenuItem> Menu { get; set; }
        public IndexModel(OliveBranchDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Menu = _db.MenuItems;
        }
    }
}
