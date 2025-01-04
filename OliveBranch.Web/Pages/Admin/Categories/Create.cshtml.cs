using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Contracts;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryRepository _dbCategory;

        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ICategoryRepository dbCategory)
        {
            _dbCategory = dbCategory;
        }

        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("Index");
            }

            if (Category.CategoryName == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(Category.CategoryName, "The 'Category Name' cannot be a number.");
                return RedirectToPage("Index");
            }

            _dbCategory.Add(Category);
            _dbCategory.Save();
            return RedirectToPage("Index");
        }
    }
}
