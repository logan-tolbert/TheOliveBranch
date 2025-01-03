using Microsoft.AspNetCore.Mvc.RazorPages;
using OliveBranch.Web.Data;
using OliveBranch.Web.Models;

namespace OliveBranch.Web.Pages.Categories
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
