using Microsoft.EntityFrameworkCore;
using TP2_EFCORE.Models1;

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
            modelBuilder.Entity<OccurrenceCours>().HasKey(sc => new {sc.CoursId, sc.OccurencesId});
            modelBuilder.Entity<CoursGroupe>().HasKey(sc => new {sc.CoursId, sc.GroupeId});
            modelBuilder.Entity<PresenceCours>().HasKey(sc => new { sc.OccurrenceDuCoursId, sc.ParticipantId });

            //Delete
            modelBuilder.Entity<Occurence>()
            .HasOne(o => o.Moniteur)
            .WithMany()
            .HasForeignKey(o => o.Moniteur)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inscription>()
            .HasOne(i => i.Utilisateur)
            .WithMany()
            .HasForeignKey(i => i.UtilisateurId)
            .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<Occurence> Occurences { get; set; }
        public DbSet<Cours> Cours   { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }
        public DbSet<Moniteur> Moniteurs { get; set; }
        public DbSet<Piscine>  Piscines { get; set; }
        public DbSet<PresenceCours> PresenceCours { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
        
}

