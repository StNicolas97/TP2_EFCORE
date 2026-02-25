using Microsoft.EntityFrameworkCore;
using TP2_EFCORE.Models;

namespace TP2_EFCORE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                 base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PresenceCours>().HasKey(sc => new { sc.OccurenceDuCoursId, sc.ParticipantId });
            modelBuilder.Entity<PresenceCours>().HasOne(sc => sc.Occurence)
                .WithMany(sc => sc.PresencesCours)
                .HasForeignKey(sc => sc.OccurenceDuCoursId)
                ;
            modelBuilder.Entity<PresenceCours>().HasOne(sc => sc.Utilisateur)
                .WithMany(sc => sc.PresencesCours)
                .HasForeignKey(sc => sc.ParticipantId);


            //Delete
            modelBuilder.Entity<OccurenceCours>()
            .HasOne(o => o.Moniteur)
            .WithMany()
            .HasForeignKey(o => o.MoniteurDeCoursId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PresenceCours>()
            .HasOne(pc => pc.Utilisateur)
            .WithMany(u => u.PresencesCours)
            .HasForeignKey(pc => pc.ParticipantId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PresenceCours>()
            .HasOne(pc => pc.Occurence)
            .WithMany(o => o.PresencesCours)
            .HasForeignKey(pc => pc.OccurenceDuCoursId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inscription>()
            .HasOne(i => i.Utilisateur)
            .WithMany()
            .HasForeignKey(i => i.UtilisateurId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OccurenceCours>().HasOne(o => o.Moniteur)
            .WithMany(o => o.Occurences)
            .HasForeignKey(f => f.MoniteurDeCoursId);


            modelBuilder.Entity<PresenceCours>().HasOne(o => o.Occurence)
            .WithMany(o => o.PresencesCours)
            .HasForeignKey(f => f.OccurenceDuCoursId);


            modelBuilder.Entity<Cours>().HasOne(o => o.CoursPrealable)
            .WithMany()
            .HasForeignKey(f => f.CoursPrealableId);


            //Ajout des datas
            modelBuilder.Entity<Piscine>()
            .HasData(
            new Piscine()
            {
                Id = 1,
                Nom = "Centre aquatique Desjardins de Granby",
                Adresse = "560, rue Léon-Harmel",
                Ville = "Granby",
                CodePostal = "J2G3G7",
                CapaciteMaximale = 350
            },
            new Piscine()
            {
                Id = 2,
                Nom = "Centre aquatique de Cowansville",
                Adresse = "220, place Municipale",
                Ville = "Cowansville",
                CodePostal = "J2K1T4",
                CapaciteMaximale = 220
            }
            ,
            new Piscine()
            {
                Id = 3,
                Nom = "Centre aquatique Desjardins de Saint-Hyacinthe",
                Adresse = "850, rue Turcot",
                Ville = "Saint-Hyacinthe",
                CodePostal = "J2S1M2",
                CapaciteMaximale = 350
            });

            modelBuilder.Entity<Cours>().HasData(
                new Cours()
                {
                    Id = 1,
                    Titre = "Nageur 1",
                    DureeDuCoursMinutes = 30,
                    NombreMaximalSuggere = 5,
                    Description = "Ces nageurs débutants deviendront confortables à sauter dans l’eau."
                },
                new Cours()
                {
                    Id = 2,
                    Titre = "Nageur 2",
                    DureeDuCoursMinutes = 30,
                    NombreMaximalSuggere = 5,
                    CoursPrealableId = 1,
                    Description = "Ces débutants aux habiletés plus avancées sauteront en eau plus profonde."
                },
                new Cours()
                {
                    Id = 3,
                    Titre = "Nageur 3",
                    DureeDuCoursMinutes = 30,
                    NombreMaximalSuggere = 5,
                    CoursPrealableId = 2,
                    Description = "Ces jeunes nageurs feront des plongeons, des roulades avant dans l’eau et des appuis renversés."
                },
                new Cours()
                {
                    Id = 4,
                    Titre = "Nageur 4",
                    DureeDuCoursMinutes = 50,
                    NombreMaximalSuggere = 6,
                    CoursPrealableId = 3,
                    Description = "Ces nageurs intermédiaires nageront 5 m sous l’eau et ils feront des longueurs au crawl."
                },
                new Cours()
                {
                    Id = 5,
                    Titre = "Nageur 5",
                    DureeDuCoursMinutes = 50,
                    NombreMaximalSuggere = 6,
                    CoursPrealableId = 4,
                    Description = "Ces nageurs maîtriseront les plongeons à fleur d'eau, les sauts groupés (en boule)"
                }

                );

        }

        public DbSet<OccurenceCours> Occurences { get; set; }
        public DbSet<Cours> Cours   { get; set; }
        public DbSet<CoursGroupe> Groupes { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Moniteur> Moniteurs { get; set; }
        public DbSet<Piscine>  Piscines { get; set; }
        public DbSet<PresenceCours> PresenceCours { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
        
}

