using FreeCodeCampWeb.Controllers.Data;
using FreeCodeCampWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeCodeCampWeb.Controllers
{

    
    
    public class CategoryController : Controller
    {

        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()

        {
            IEnumerable<Category> objCategoryList = _db.Categories;

            return View(objCategoryList);
        }
        //get
        public IActionResult Create()

        {
   

            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Create(Category obj)
        {
           
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created SucessFully";
                return RedirectToAction("Index"); 
            }

            return View(obj);
        }



        //get
        public IActionResult Edit(int?Id)

        {
            if(Id == null ||Id == 0)
            {
                return NotFound();
            }
            var categoryFromDB = _db.Categories.Find(Id);

            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Edit (Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            TempData["success"] = "Category Updated SucessFully";
            return View(obj);
        }

        public IActionResult Delete(int? Id)

        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var categoryFromDB = _db.Categories.Find(Id);

            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }
        //post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted SucessFully";
            return RedirectToAction("Index");
        }
    }
}
