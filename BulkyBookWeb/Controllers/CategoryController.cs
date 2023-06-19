using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BulkyDbContext _dbContext;
        public CategoryController(BulkyDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        // GET
        public IActionResult Index()
        {
            IEnumerable<Category> objCategory = _dbContext.Categories;
            return View(objCategory);
        }
        
        // POST
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {
            if(cat.Name == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if(ModelState .IsValid)
            {
                _dbContext.Categories.Add(cat);
                _dbContext.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
                return NotFound();
            var categoryFromDb = _dbContext.Categories.Find(id);

            if(categoryFromDb == null)
                return NotFound();
            return View(categoryFromDb);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category cat)
        {
            if (cat.Name == cat.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(cat);
                _dbContext.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var categoryFromDb = _dbContext.Categories.Find(id);

            if (categoryFromDb == null)
                return NotFound();
            return View(categoryFromDb);
        }

        // POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _dbContext.Categories.Find(id);
            if (obj == null)
                return NotFound();

                _dbContext.Categories.Remove(obj);
                _dbContext.SaveChanges();
                TempData["Success"] = "Category Deleted Successfully";
                return RedirectToAction("Index");
        }

    }
}
