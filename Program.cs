using ges_dette_csharpApp.Models;
using ges_ecole_csharpApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services au conteneur
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Ajouter les services nécessaires pour les contrôleurs et les vues
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurer le pipeline de requêtes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Sécuriser les connexions HTTP
}

app.UseHttpsRedirection(); // Redirection vers HTTPS
app.UseStaticFiles(); // Permet d'utiliser les fichiers statiques (comme CSS, JS, images)

app.UseRouting(); // Permet le routage des requêtes

app.UseAuthorization(); // Activer l'autorisation

// Définir la route par défaut pour les contrôleurs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Etudiant}/{action=MesCours}/{id?}");
});



app.Run();

