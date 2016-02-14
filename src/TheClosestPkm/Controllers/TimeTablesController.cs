using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using TheClosestPkm.Models;

namespace TheClosestPkm.Controllers
{
    public class TimeTablesController : Controller
    {
        private ApplicationDbContext _context;

        public TimeTablesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TimeTables
        public IActionResult Index()
        {
            var applicationDbContext = _context.TimeTable.Include(t => t.Station);
            return View(applicationDbContext.ToList());
        }

        // GET: TimeTables/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TimeTable timeTable = _context.TimeTable.Single(m => m.TimeTableId == id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }

            return View(timeTable);
        }

        // GET: TimeTables/Create
        public IActionResult Create()
        {
            ViewData["StationsTableId"] = new SelectList(_context.Set<StationsTable>(), "StationSTableId", "Station");
            return View();
        }

        // POST: TimeTables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                _context.TimeTable.Add(timeTable);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["StationsTableId"] = new SelectList(_context.Set<StationsTable>(), "StationSTableId", "Station", timeTable.StationsTableId);
            return View(timeTable);
        }

        // GET: TimeTables/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TimeTable timeTable = _context.TimeTable.Single(m => m.TimeTableId == id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }
            ViewData["StationsTableId"] = new SelectList(_context.Set<StationsTable>(), "StationSTableId", "Station", timeTable.StationsTableId);
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                _context.Update(timeTable);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["StationsTableId"] = new SelectList(_context.Set<StationsTable>(), "StationSTableId", "Station", timeTable.StationsTableId);
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TimeTable timeTable = _context.TimeTable.Single(m => m.TimeTableId == id);
            if (timeTable == null)
            {
                return HttpNotFound();
            }

            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TimeTable timeTable = _context.TimeTable.Single(m => m.TimeTableId == id);
            _context.TimeTable.Remove(timeTable);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
