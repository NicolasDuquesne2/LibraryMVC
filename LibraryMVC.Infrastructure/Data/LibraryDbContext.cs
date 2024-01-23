using LibraryMVC.Constraints;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Data;

public class LibraryDbContext : DbContext
{
    public DbSet<Livre> Livres => Set<Livre>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Adresse> Adresses => Set<Adresse>();
    public DbSet<Auteur> Auteurs => Set<Auteur>();
    public DbSet<Domaine> Domaines => Set<Domaine>();
    public DbSet<Emprunt> Emprunts => Set<Emprunt>();
    public DbSet<Lecteur> Lecteurs => Set<Lecteur>();

    public LibraryDbContext(
        DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {

        new AdresseConstraints().Configure(modelBuilder.Entity<Adresse>());
        new AuteurConstraints().Configure(modelBuilder.Entity<Auteur>());
        new DomaineConstraints().Configure(modelBuilder.Entity<Domaine>());
        new EmpruntConstraints().Configure(modelBuilder.Entity<Emprunt>());
        new LivreConstraints().Configure(modelBuilder.Entity<Livre>());
        new LecteurConstraints().Configure(modelBuilder.Entity<Lecteur>());
        new AdminConstraints().Configure(modelBuilder.Entity<Admin>());





        modelBuilder.Entity<Auteur>().HasData(
           new Auteur
           {
               Id = 1,
               Nom = "Carson",
               Prenom = "Alexander",
               Email = "a.Carson@domain.com",
               Telephone = "0470859578",
               Grade = "sociétaire"
           },
            new Auteur
            {
                Id = 2,
                Prenom = "Meredith",
                Nom = "Alonso",
                Email = "m.Alonson@domain.com",
                Telephone = "0470859578",
                Grade = "sociétaire adjoint"
            },
            new Auteur
            {
                Id = 3,
                Prenom = "Arturo",
                Nom = "Anand",
                Email = "a.Anand@domain.com",
                Telephone = "0470859578",
                Grade = "adhérent"
            },
            new Auteur
            {
                Id = 4,
                Prenom = "Gytis",
                Nom = "Barzdukas",
                Email = "g.Barzdukas@domain.com",
                Telephone = "0470859578",
                Grade = "adhérent"
            },
            new Auteur
            {
                Id = 5,
                Prenom = "Yan",
                Nom = "Li",
                Email = "l.Yan@domain.com",
                Telephone = "0470859578",
                Grade = "adhérent"
            },
            new Auteur
            {
                Id = 6,
                Prenom = "Peggy",
                Nom = "Justice",
                Email = "l.Yan@domain.com",
                Telephone = "0470859578",
                Grade = "adhérent"
            },
            new Auteur
            {
                Id = 7,
                Prenom = "Laura",
                Nom = "Norman",
                Email = "l.Norman@domain.com",
                Telephone = "0470859578",
                Grade = "adhérent"
            },

            new Auteur
            {
                Id = 8,
                Prenom = "Nino",
                Nom = "Olivetto",
                Email = "o.Olivetto@domain.com",
                Telephone = "0470859578",
                Grade = "adhérent"
            });


        modelBuilder.Entity<Domaine>().HasData(
            new Domaine { Id = 1, Nom = "Chemistry", Description = "" },
            new Domaine { Id = 2, Nom = "Microéconomie", Description = "" },
            new Domaine { Id = 3, Nom = "Macroéconomie", Description = "" },
            new Domaine { Id = 4, Nom = "Maths", Description = "" },
            new Domaine { Id = 5, Nom = "Litérature", Description = "" }
            );

        modelBuilder.Entity<Livre>().HasData(
            new { Id = 1, Titre = "Chemistry", NombreDePage = 300 , DomaineId = 1, AuteurId = 1},
            new { Id = 2, Titre = "Utilité marginale", NombreDePage = 250, DomaineId = 2, AuteurId = 2},
            new { Id = 3, Titre = "Equilibre général", NombreDePage = 150, DomaineId = 3, AuteurId = 3},
            new { Id = 4, Titre = "Maths pour les nuls", NombreDePage = 500, DomaineId = 4, AuteurId = 4},
            new { Id = 5, Titre = "Géométrie les bases", NombreDePage = 200, DomaineId = 4, AuteurId = 5},
            new { Id = 6, Titre = "Les chiens ne font pas des chats", NombreDePage = 100, DomaineId = 5, AuteurId = 6},
            new { Id = 7, Titre = "Le seigneur de l'aube", NombreDePage = 345, DomaineId = 5, AuteurId = 7}
            );

        modelBuilder.Entity<Adresse>().HasData(
        new Adresse { Id = 1,  Appartement="2", Rue="rue du Chambon", Ville="Lille", CodePostal="59000", Pays="France"},
        new Adresse { Id = 2, Appartement = "10", Rue = "rue des pins", Ville = "Paris", CodePostal = "75003", Pays = "France" },
        new Adresse {Id = 3, Appartement = "7", Rue = "rue des voies", Ville = "Marseille", CodePostal = "13008", Pays = "France" },
        new Adresse {Id = 4, Appartement = "9", Rue = "rue de la fibre", Ville = "Lyon", CodePostal = "69005", Pays = "France" },
        new Adresse {Id = 5, Appartement = "250", Rue = "rue Chabrior", Ville = "Les Lillas", CodePostal = "75200", Pays = "France" },
        new Adresse{ Id = 6, Appartement = "15", Rue = "rue Junio", Ville = "Poitiers", CodePostal = "86000", Pays = "France" },
        new Adresse {Id = 7, Appartement = "8", Rue = "rue Desmoulins", Ville = "La Rochelle", CodePostal = "17000", Pays = "France" }
        );

        modelBuilder.Entity<Lecteur>().HasData(
           new
           {
               Id = 1,
               Nom = "Carson",
               Prenom = "Alexander",
               Email = "a.Carson@domain.com",
               Telephone = "0470859578",
               MotDePasse = "*Azerty4587",
               AdresseId = 1
           },
            new
            {
                Id = 2,
                Prenom = "Meredith",
                Nom = "Alonso",
                Email = "m.Alonson@domain.com",
                Telephone = "0470859578",
                MotDePasse = "*Azerty4587",
                AdresseId = 2
            },
            new
            {
                Id = 3,
                Prenom = "Arturo",
                Nom = "Anand",
                Email = "a.Anand@domain.com",
                Telephone = "0470859578",
                MotDePasse = "*Azerty4587",
                AdresseId = 3
            },
            new
            {
                Id = 4,
                Prenom = "Gytis",
                Nom = "Barzdukas",
                Email = "g.Barzdukas@domain.com",
                Telephone = "0470859578",
                MotDePasse = "*Azerty4587",
                AdresseId = 4
            },
            new
            {
                Id = 5,
                Prenom = "Yan",
                Nom = "Li",
                Email = "l.Yan@domain.com",
                Telephone = "0470859578",
                MotDePasse = "*Azerty4587",
                AdresseId = 5
            },
            new
            {
                Id = 6,
                Prenom = "Peggy",
                Nom = "Justice",
                Email = "l.Yan@domain.com",
                Telephone = "0470859578",
                MotDePasse = "*Azerty4587",
                AdresseId = 6
            },
            new
            {
                Id = 7,
                Prenom = "Laura",
                Nom = "Norman",
                Email = "l.Norman@domain.com",
                Telephone = "0470859578",
                MotDePasse = "*Azerty4587",
                AdresseId = 7
            },

            new
            {
                Id = 8,
                Prenom = "Nino",
                Nom = "Olivetto",
                Email = "o.Olivetto@domain.com",
                Telephone = "0470859578",
                MotDePasse = "*Azerty4587",
                AdresseId = 1
            });


        modelBuilder.Entity<Admin>().HasData(
          new Admin
          {
              Id = 1,
              Nom = "Durand",
              Prenom = "Luc",
              Email = "l.Durand@domain.com",
              Telephone = "0470859578",
              MotDePasse = "*Azerty4587"
          },
           new Admin
           {
               Id = 2,
               Prenom = "Dupont",
               Nom = "Ulrik",
               Email = "u.Dupont@domain.com",
               Telephone = "0470859578",
               MotDePasse = "*Azerty4587"
           });

    }
}

