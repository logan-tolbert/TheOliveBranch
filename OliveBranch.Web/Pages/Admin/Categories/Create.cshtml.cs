using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Contracts;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Categories
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            _unitOfWork.Category.Add(Category);
            _unitOfWork.Category.Save();
            return RedirectToPage("Index");
        }
    }
}
