using Archive.Data;
using Archive.Models;
using Archive.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Archive.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ArchiveDbContext _db;

        public HomeController(ILogger<HomeController> logger, ArchiveDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<ArchiveModel> objList = _db.Archives;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ArchiveModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Archives.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(Guid? id)
        {
            var obj = _db.Archives.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(ArchiveModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Archives.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(Guid? id)
        {
            
                _db.Archives.Remove(_db.Archives.Find(id));
                _db.SaveChanges();
                return RedirectToAction("Index");
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
