using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        private readonly OliveBranchDbContext _db;

        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(OliveBranchDbContext db)
        {
            _db = db;
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

            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
