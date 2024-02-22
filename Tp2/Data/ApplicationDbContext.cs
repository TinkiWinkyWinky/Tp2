using Microsoft.EntityFrameworkCore;
using Tp2.Models;

namespace Tp2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Inscriptions>()
            .HasOne(i => i.Utilisateur)
            .WithMany(u => u.Inscriptions)
            .HasForeignKey(i => i.UtilisateurId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OccurrenceCours>()
            .HasOne(i => i.MoniteurDeCeCours)
            .WithMany()
            .HasForeignKey(i => i.MoniteurDeCeCoursId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PresenceCours>().HasKey(x => new { x.OccurrenceDuCoursId, x.ParticipantId });

            modelBuilder.Entity<OccurrenceCours>()
            .HasMany(x => x.Utilisateurs)
            .WithMany(x => x.Occurrences)
            .UsingEntity<PresenceCours>();

            modelBuilder.Entity<Utilisateurs>()
            .HasMany(x => x.Occurrences)
            .WithMany(x => x.Utilisateurs)
            .UsingEntity<PresenceCours>();

            modelBuilder.Entity<PresenceCours>()
            .HasOne(x => x.OccurrenceDuCours)
            .WithMany(x => x.PresenceCours)
            .HasForeignKey(x => x.OccurrenceDuCoursId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PresenceCours>()
            .HasOne(x => x.Participant)
            .WithMany(x => x.PresenceCours)
            .HasForeignKey(x => x.ParticipantId)
            .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Utilisateurs> Utilisateurs { get; set; }
        public DbSet<Moniteurs> Moniteurs { get; set; }
        public DbSet<Cours> Cours { get; set; }
        public DbSet<Piscines> Piscines { get; set; }
        public DbSet<CoursGroupe> Groupes { get; set; }
        public DbSet<Inscriptions> Inscriptions { get; set; }
        public DbSet<OccurrenceCours> Occurrences { get; set; }
    }
}
