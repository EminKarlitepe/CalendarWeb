using CalendarWeb.Context;
using CalendarWeb.Entities;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CalendarWeb.Controllers
{
    public class CalendarController : Controller
    {
        private CalendarContext db = new CalendarContext();

        // GET: Calendar
        public ActionResult Index()
        {
            var events = db.Events.Include("Category").ToList();
            ViewBag.Categories = db.Categories.ToList();
            return View(events);
        }

        // POST: Calendar/UpdateDate
        [HttpPost]
        public ActionResult UpdateDate(int id, string start, string end)
        {
            var ev = db.Events.Find(id);
            if (ev != null)
            {
                if (DateTime.TryParse(start, out DateTime startDate))
                {
                    ev.StartDate = startDate;
                }

                if (DateTime.TryParse(end, out DateTime endDate))
                {
                    ev.EndDate = endDate;
                }
                else
                {
                    ev.EndDate = ev.StartDate;
                }

                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // POST: Calendar/AddEvent
        [HttpPost]
        public JsonResult AddEvent(string title, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(title) || categoryId <= 0)
            {
                return Json(new { success = false, error = "Başlık ve kategori zorunludur." });
            }
            var ev = new Event
            {
                Title = title,
                CategoryId = categoryId,
                StartDate = null,
                EndDate = null
            };
            db.Events.Add(ev);
            db.SaveChanges();

            var cat = db.Categories.Find(categoryId);
            return Json(new { success = true, id = ev.EventId, title = ev.Title, color = cat?.CategoryColor ?? "#3c8dbc" });
        }

        // POST: Calendar/DeleteEvent
        [HttpPost]
        public ActionResult DeleteEvent(int id)
        {
            var ev = db.Events.Find(id);
            if (ev != null)
            {
                db.Events.Remove(ev);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // GET: Calendar/GetEvents
        public JsonResult GetEvents()
        {
            var events = db.Events.Include("Category")
                .Where(e => e.StartDate != null)
                .ToList();

            var calendarEvents = events.Select(e => new
            {
                id = e.EventId,
                title = e.Title,
                start = e.StartDate?.ToString("o"),
                end = e.EndDate?.ToString("o"),
                backgroundColor = e.Category?.CategoryColor ?? "#3c8dbc",
                borderColor = e.Category?.CategoryColor ?? "#3c8dbc",
                allDay = false
            });

            return Json(calendarEvents, JsonRequestBehavior.AllowGet);
        }
    }
}