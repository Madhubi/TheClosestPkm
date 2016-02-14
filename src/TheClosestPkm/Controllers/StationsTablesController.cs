using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using TheClosestPkm.Models;

namespace TheClosestPkm.Controllers
{
    public class StationsTablesController : Controller
    {
        private ApplicationDbContext _context;

        public StationsTablesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: StationsTables
        public IActionResult Index()
        {
            return View(_context.StationsTable.ToList());
        }

        // GET: StationsTables/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StationsTable stationsTable = _context.StationsTable.Single(m => m.StationsTableId == id);
            if (stationsTable == null)
            {
                return HttpNotFound();
            }

            return View(stationsTable);
        }

        // GET: StationsTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StationsTables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StationsTable stationsTable)
        {
            if (ModelState.IsValid)
            {
                _context.StationsTable.Add(stationsTable);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stationsTable);
        }

        // GET: StationsTables/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StationsTable stationsTable = _context.StationsTable.Single(m => m.StationsTableId == id);
            if (stationsTable == null)
            {
                return HttpNotFound();
            }
            return View(stationsTable);
        }

        // POST: StationsTables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StationsTable stationsTable)
        {
            if (ModelState.IsValid)
            {
                _context.Update(stationsTable);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stationsTable);
        }

        // GET: StationsTables/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            StationsTable stationsTable = _context.StationsTable.Single(m => m.StationsTableId == id);
            if (stationsTable == null)
            {
                return HttpNotFound();
            }

            return View(stationsTable);
        }

        // POST: StationsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            StationsTable stationsTable = _context.StationsTable.Single(m => m.StationsTableId == id);
            _context.StationsTable.Remove(stationsTable);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
