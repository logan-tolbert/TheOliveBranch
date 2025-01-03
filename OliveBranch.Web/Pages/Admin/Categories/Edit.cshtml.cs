using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        private readonly OliveBranchDbContext _db;
        public EditModel(OliveBranchDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Category Category { get; set; }

        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
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

            _db.Categories.Update(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
