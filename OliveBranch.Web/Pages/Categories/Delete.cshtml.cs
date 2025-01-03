using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OliveBranch.Web.Data;
using OliveBranch.Web.Models;

namespace OliveBranch.Web.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly OliveBranchDbContext _db;
        public DeleteModel(OliveBranchDbContext db)
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

            var category = _db.Categories.Find(Category.Id);

            if (category != null)
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
