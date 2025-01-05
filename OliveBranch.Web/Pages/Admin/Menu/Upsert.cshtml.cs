using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheOliveBranch.Contracts;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Menu
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public MenuItem MenuItem { get; set; } = default!;
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> FoodTypes { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            MenuItem = new MenuItem();
        }

        public void OnGet()
        {
            Categories = _unitOfWork.Category.GetAll().Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.Id.ToString()
            });

            FoodTypes = _unitOfWork.FoodType.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _unitOfWork.MenuItem.Add(MenuItem);
            _unitOfWork.MenuItem.Save();
            return RedirectToPage("./Index");
        }
    }
}
