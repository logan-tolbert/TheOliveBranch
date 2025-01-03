using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OliveBranch.Web.Data;
using OliveBranch.Web.Models;

namespace OliveBranch.Web.Pages.Categories
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
            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
