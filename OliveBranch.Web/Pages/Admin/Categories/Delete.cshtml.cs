using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Contracts;
using TheOliveBranch.Data;
using TheOliveBranch.Models;
using TheOliveBranch.Repo;

namespace OliveBranch.Web.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {

            var category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == Category.Id);

            if (category != null)
            {
                _unitOfWork.Category.Remove(category);
                _unitOfWork.Category.Save();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
