using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Contracts;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<FoodType> FoodList { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            FoodList = _unitOfWork.FoodType.GetAll();
        }
    }
}
