using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Contracts;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository _dbCategory;
        public IEnumerable<Category>Categories { get; set; }
        public IndexModel(ICategoryRepository dbCategory)
        {
            _dbCategory = dbCategory;
        }

        public void OnGet()
        {
            Categories = _dbCategory.GetAll();
        }
    }
}
