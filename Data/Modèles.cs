public class Etudiant
{
    public int Id { get; set; }
    public string Matricule { get; set; }
    public string NomComplet { get; set; }
    public string Adresse { get; set; }
    public virtual ICollection<Cours> Cours { get; set; }
}

public class Cours
{
    public int Id { get; set; }
    public string Intitule { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime DateFin { get; set; }
    public int ProfesseurId { get; set; }
    public virtual ICollection<Etudiant> Etudiants { get; set; }
}

public class Absence
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int EtudiantId { get; set; }
    public int CoursId { get; set; }
    public virtual Etudiant Etudiant { get; set; }
    public virtual Cours Cours { get; set; }
}
