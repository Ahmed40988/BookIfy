
using Bookify.Wep.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Wep.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IRepositoryCategory repositoryCategory;

        public CategoriesController(IRepositoryCategory repositoryCategory)
        {
            this.repositoryCategory = repositoryCategory;
        }
        public IActionResult Index()
        {
            var categories=repositoryCategory.GetCategories();
            return View(categories);
        }
        [HttpGet]
        [AjaxOnly]
        public IActionResult Create()
        {
            return PartialView("_form");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryformViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                if (!repositoryCategory.checkcategory(model.Name))
                {
                    Category category = new Category() { Name = model.Name };
                    repositoryCategory.CreateCategory(category);
                    return PartialView("_Categoryrow",category);
                }
                TempData["ErrorMessage"] = "Category already exists!";
                return PartialView("_form", model);

            }
        }
        [HttpGet]
        [AjaxOnly]
        public IActionResult Edit(int Id)
        {
            var category=repositoryCategory.GetCategorybyid(Id);
            if (category is null)
                return NotFound();

            var model = new CategoryformViewModel()
            {
                Id = Id,
                Name = category.Name,
            };
            return PartialView("_form",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryformViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_form",model);

            var category=repositoryCategory.GetCategorybyid(model.Id);
            if (category is null)
                return NotFound();

            category.Name = model.Name;
            category.lastupdated=DateTime.Now;
            repositoryCategory.UpdateCategory(category);
            TempData["Message"] = "Saved successfully!";
            return PartialView("_Categoryrow", category);
        }
        [HttpPost]
        public IActionResult Togglestatus(int id)
        {
            var category=repositoryCategory.GetCategorybyid(id);
            if(category is null)
                return NotFound();

            repositoryCategory.togglestatuscategory(category);
            return Ok(category.lastupdated.ToString());
        }
    }
}
