using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Contracts;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Category Category { get; set; }
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
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

            _unitOfWork.Category.Update(Category);
            _unitOfWork.Category.Save();
            return RedirectToPage("Index");
        }
    }
}
