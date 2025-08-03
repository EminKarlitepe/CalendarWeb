using System.Linq;
using System.Web.Mvc;
using CalendarWeb.Context;
using CalendarWeb.Entities;
using System.Data.Entity;

namespace CalendarWeb.Controllers
{
    public class CategoryController : Controller
    {
        private CalendarContext db = new CalendarContext();

        // GET: Category
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                // AJAX ile çaðrýldýðý için JSON sonucu dön
                return Json(new { success = true, categoryId = category.CategoryId, categoryName = category.CategoryName, categoryColor = category.CategoryColor });
            }
            // Hata durumunda JSON hata mesajý dön
            return Json(new { success = false, message = "Kategori eklenirken bir hata oluþtu." });
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
            {
                return Json(new { success = false, message = "Kategori bulunamadý." });
            }

            // Kategoriye baðlý etkinlik var mý kontrolü yapýn
            var hasEvents = db.Events.Any(e => e.CategoryId == id);
            if (hasEvents)
            {
                return Json(new { success = false, message = "Bu kategoriye ait etkinlikler olduðu için silinemez." });
            }

            db.Categories.Remove(category);
            db.SaveChanges();

            return Json(new { success = true });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}