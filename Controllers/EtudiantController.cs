using ges_ecole_csharpApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EtudiantController : Controller
{
    private readonly ApplicationDbContext _context;

    public EtudiantController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Action pour lister les cours
    public IActionResult MesCours(int etudiantId)
    {
        var cours = _context.Cours
            .Where(c => c.Etudiants.Any(e => e.Id == etudiantId))
            .ToList();

        return View(cours);
    }

    // Action pour lister les absences
    public IActionResult MesAbsences(int etudiantId)
    {
        var absences = _context.Absences
            .Where(a => a.EtudiantId == etudiantId)
            .Include(a => a.Cours)
            .ToList();

        return View(absences);
    }
}
