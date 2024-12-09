using ges_ecole_csharpApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace ges_dette_csharpApp.Controllers
{
    public class CoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Afficher la vue pour créer un cours
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Soumettre les données pour créer un cours
        [HttpPost]
        public async Task<IActionResult> Create(Cours cours)
        {
            if (ModelState.IsValid)
            {
                _context.Cours.Add(cours);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cours);
        }

        // Liste des cours
        public IActionResult Index()
        {
            var cours = _context.Cours.ToList();
            return View(cours);
        }
    }
}
