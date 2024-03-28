using Microsoft.AspNetCore.Mvc;
using Nonny.DataAccess.Data;
using Nonny.Model;

namespace NonnyLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            List<Product> ObjProduct = _db.Product.ToList();
            return View(ObjProduct);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Product Obj) //This will create an object of the parameter
        {
           
            if (ModelState.IsValid)
            {
                _db.Product.Add(Obj); // this will go to the categories list and Add the Obj of the parameters(Category)
                _db.SaveChanges(); //This will save changes to the database
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index"); // This will return to Index view after saving
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id) // To check the Id of the parameters you want to edit
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            Product? productFromDb = _db.Product.Find(id); // this will find the id from the Category list in the database and assigned it to CategoryFromDb
                                                                // Category? CategoryFromDb1 = _db.Categories.FirstOrDefault(c => c.Id == id);
                                                                // Category? CategoryFromDb2 = _db.Categories.Where(c =>c.Id==id).FirstOrDefault(); Multiple ways toretriev one of the Id
            if (productFromDb == null)// This will check  if the CategoryFromDb is null
            {
                return NotFound();
            }

            return View(productFromDb);

        }
        [HttpPost]
        public IActionResult Edit(Product Obj) //This will create an object of the parameter
        {

            {
                _db.Product.Update(Obj); // this will go to the categories list and Add the Obj of the parameters(Category)
                _db.SaveChanges(); //This will save changes to the database
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index"); // This will return to Index view after saving
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id) // To check the Id of the parameters you want to edit
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            Product? productFromDb = _db.Product.Find(id); // this will find the id from the Category list in the database and assigned it to CategoryFromDb
                                                                // Category? CategoryFromDb1 = _db.Categories.FirstOrDefault(c => c.Id == id);
                                                                // Category? CategoryFromDb2 = _db.Categories.Where(c =>c.Id==id).FirstOrDefault(); Multiple ways toretriev one of the Id
            if (productFromDb == null)// This will check  if the CategoryFromDb is null
            {
                return NotFound();
            }

            return View(productFromDb);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) //This will create an object of the parameter
        {
            Product? obj = _db.Product.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Product.Remove(obj); // this will go to the categories list and Add the Obj of the parameters(Category)
            _db.SaveChanges(); //This will save changes to the database
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index"); // This will return to Index view after saving
        }

    }

}

