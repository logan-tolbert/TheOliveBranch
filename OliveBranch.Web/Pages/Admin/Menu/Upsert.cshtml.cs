using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Security.Principal;
using TheOliveBranch.Contracts;
using TheOliveBranch.Models;

namespace OliveBranch.Web.Pages.Admin.Menu
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
   

        [BindProperty]
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> FoodTypes { get; set; }
        private static string ImagePath { get; set; } = "n/a";
        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            MenuItem = new MenuItem();
        }

        public void OnGet([FromRoute] int id)
        {
            if(id == 0)
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
            else
            {
                MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(m => m.Id == id);
                ImagePath = MenuItem.Image;
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

        }
       
        public async Task<IActionResult> OnPost()
        {
            
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;


            if (files.Count() == 0)
            {
                throw new ArgumentNullException();


            }

            if (MenuItem.Id == 0)
            {
                // create
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\menu-items");
                var extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }

                MenuItem.Image = @"\images\menuItems\" + fileName_new + extension;

                _unitOfWork.MenuItem.Add(MenuItem);
                _unitOfWork.Save();
                return RedirectToPage("./Index");
            }
            MenuItem.Image = ImagePath;
            _unitOfWork.MenuItem.Update(MenuItem);
            _unitOfWork.Save();
            return RedirectToPage("./Index");




        }
    }
}
