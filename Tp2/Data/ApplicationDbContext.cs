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

            modelBuilder.Entity<Piscines>().HasData(
                new Piscines()
                {
                    Id = 1,
                    Nom = "Centre aquatique Desjardins de Granby",
                    Adresse = "560, rue LéonHarmel",
                    Ville = "Granby",
                    CodePostal = "J2G3G7",
                    CapaciteMaximale = 350
                },
                new Piscines()
                {
                    Id = 2,
                    Nom = "Centre aquatique de Cowansville",
                    Adresse = "220, place Municipale",
                    Ville = "Cowansville",
                    CodePostal = "J2K1T4",
                    CapaciteMaximale = 220
                },
                new Piscines()
                {
                    Id = 3,
                    Nom = "Centre aquatique Desjardins de Saint-Hyacinthe",
                    Adresse = "850, rue Turcot",
                    Ville = "Saint-Hyacinthe",
                    CodePostal = "J2S1M2",
                    CapaciteMaximale = 350
                }
                );

            modelBuilder.Entity<Cours>().HasData(
                new Cours()
                {
                    Id = 1,
                    Titre = "Nageur 1",
                    DurreeDuCoursMinutes = 30,
                    NombreMaximalSuggere = 5,
                    Description = "Ces nageurs débutants deviendront confortables à sauter dans l’eau."
                },
                new Cours()
                {
                    Id = 2,
                    Titre = "Nageur 2",
                    DurreeDuCoursMinutes = 30,
                    NombreMaximalSuggere = 5,
                    CoursPrealableId = 1,
                    Description = "Ces débutants aux habiletés plus avancées sauteront en eau plus profonde."
                },
                new Cours()
                {
                    Id = 3,
                    Titre = "Nageur 3",
                    DurreeDuCoursMinutes = 30,
                    NombreMaximalSuggere = 5,
                    CoursPrealableId = 2,
                    Description = "Ces jeunes nageurs feront des plongeons, des roulades avant dans l’eau et des appuis renversés."
                },
                new Cours()
                {
                    Id = 4,
                    Titre = "Nageur 4",
                    DurreeDuCoursMinutes = 50,
                    NombreMaximalSuggere = 6,
                    CoursPrealableId = 3,
                    Description = "Ces nageurs intermédiaires nageront 5 m sous l’eau et ils feront des longueurs au crawl."
                },
                new Cours()
                {
                    Id = 5,
                    Titre = "Nageur 5",
                    DurreeDuCoursMinutes = 50,
                    NombreMaximalSuggere = 6,
                    CoursPrealableId = 4,
                    Description = "Ces nageurs maîtriseront les plongeons à fleur d'eau, les sauts groupés (en boule)"
                }
                );
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
