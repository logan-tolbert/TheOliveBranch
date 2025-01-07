using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.FoodTypes
{
    public class CreateModel : PageModel
    {
        public FoodType FoodType { get; set; }
        public void OnGet()
        {
        }
    }
}
