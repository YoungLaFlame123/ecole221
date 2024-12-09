// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace ges_ecole_csharpApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cours> Cours { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Absence> Absences { get; set; }
    }
}
