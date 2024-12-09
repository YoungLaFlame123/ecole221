using ges_dette_csharpApp.Models;
using ges_ecole_csharpApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class AbsenceController : Controller
{
    private readonly ApplicationDbContext _context;

    public AbsenceController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Liste des absences
    public IActionResult Index()
    {
        var absences = _context.Absences
            .Include(a => a.Etudiant)
            .Include(a => a.Cours)
            .ToList();
        return View(absences);
    }

    // Marquer une absence (GET)
    public IActionResult Create()
    {
        ViewBag.Etudiants = new SelectList(_context.Etudiants, "Id", "NomComplet");
        ViewBag.Cours = new SelectList(_context.Cours, "Id", "Intitule");
        return View();
    }

    // Marquer une absence (POST)
    [HttpPost]
    public IActionResult Create(Absence absence)
    {
        if (ModelState.IsValid)
        {
            _context.Absences.Add(absence);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(absence);
    }
}
