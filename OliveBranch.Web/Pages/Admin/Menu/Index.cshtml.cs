using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Contracts;
using TheOliveBranch.Data;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Menu
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<MenuItem> Menu { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            Menu = _unitOfWork.MenuItem.GetAll();
        }
    }
}
