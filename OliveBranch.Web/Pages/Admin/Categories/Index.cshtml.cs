using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly OliveBranchDbContext _db;
        public IEnumerable<Category>Categories { get; set; }
        public IndexModel(OliveBranchDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categories = _db.Categories;
        }
    }
}
