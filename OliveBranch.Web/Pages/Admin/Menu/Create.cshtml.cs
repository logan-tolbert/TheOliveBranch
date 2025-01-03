using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Menu
{
    public class CreateModel : PageModel
    {
        private readonly OliveBranchDbContext _db;
        [BindProperty]
        public MenuItem MenuItem { get; set; } = default!;
        public CreateModel(OliveBranchDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        //ViewData["CategoryId"] = new SelectList(_db.Categories, "Id", "CategoryName");
        //    return Page();
        }

      

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.MenuItems.Add(MenuItem);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
