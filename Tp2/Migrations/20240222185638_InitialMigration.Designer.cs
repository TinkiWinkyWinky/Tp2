﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tp2.Data;

#nullable disable

namespace Tp2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240222185638_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tp2.Models.Cours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CoursPrealableId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurreeDuCoursMinutes")
                        .HasColumnType("int");

                    b.Property<int>("NombreMaximalSuggere")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoursPrealableId");

                    b.ToTable("Cours");
                });

            modelBuilder.Entity("Tp2.Models.CoursGroupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoursId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("MoniteurParDefaultId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroGroupe")
                        .HasColumnType("int");

                    b.Property<int>("PiscineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoursId");

                    b.HasIndex("MoniteurParDefaultId");

                    b.HasIndex("PiscineId");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("Tp2.Models.Inscriptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoursGroupeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateInscription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoursGroupeId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Inscriptions");
                });

            modelBuilder.Entity("Tp2.Models.Moniteurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NoLicence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("Moniteurs");
                });

            modelBuilder.Entity("Tp2.Models.OccurrenceCours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupeId")
                        .HasColumnType("int");

                    b.Property<int>("MoniteurDeCeCoursId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupeId");

                    b.HasIndex("MoniteurDeCeCoursId");

                    b.ToTable("Occurrences");
                });

            modelBuilder.Entity("Tp2.Models.Piscines", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CapaciteMaximale")
                        .HasColumnType("int");

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Piscines");
                });

            modelBuilder.Entity("Tp2.Models.PresenceCours", b =>
                {
                    b.Property<int>("OccurrenceDuCoursId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.HasKey("OccurrenceDuCoursId", "ParticipantId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("PresenceCours");
                });

            modelBuilder.Entity("Tp2.Models.Utilisateurs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreationCompte")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("Tp2.Models.Cours", b =>
                {
                    b.HasOne("Tp2.Models.Cours", "CoursPrealable")
                        .WithMany()
                        .HasForeignKey("CoursPrealableId");

                    b.Navigation("CoursPrealable");
                });

            modelBuilder.Entity("Tp2.Models.CoursGroupe", b =>
                {
                    b.HasOne("Tp2.Models.Cours", "Cours")
                        .WithMany()
                        .HasForeignKey("CoursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tp2.Models.Moniteurs", "MoniteurParDefault")
                        .WithMany()
                        .HasForeignKey("MoniteurParDefaultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tp2.Models.Piscines", "Piscine")
                        .WithMany()
                        .HasForeignKey("PiscineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cours");

                    b.Navigation("MoniteurParDefault");

                    b.Navigation("Piscine");
                });

            modelBuilder.Entity("Tp2.Models.Inscriptions", b =>
                {
                    b.HasOne("Tp2.Models.CoursGroupe", "CoursGroupe")
                        .WithMany()
                        .HasForeignKey("CoursGroupeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tp2.Models.Utilisateurs", "Utilisateur")
                        .WithMany("Inscriptions")
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CoursGroupe");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("Tp2.Models.Moniteurs", b =>
                {
                    b.HasOne("Tp2.Models.Utilisateurs", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("Tp2.Models.OccurrenceCours", b =>
                {
                    b.HasOne("Tp2.Models.CoursGroupe", "Groupe")
                        .WithMany()
                        .HasForeignKey("GroupeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tp2.Models.Moniteurs", "MoniteurDeCeCours")
                        .WithMany()
                        .HasForeignKey("MoniteurDeCeCoursId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Groupe");

                    b.Navigation("MoniteurDeCeCours");
                });

            modelBuilder.Entity("Tp2.Models.PresenceCours", b =>
                {
                    b.HasOne("Tp2.Models.OccurrenceCours", "OccurrenceDuCours")
                        .WithMany("PresenceCours")
                        .HasForeignKey("OccurrenceDuCoursId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Tp2.Models.Utilisateurs", "Participant")
                        .WithMany("PresenceCours")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("OccurrenceDuCours");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Tp2.Models.OccurrenceCours", b =>
                {
                    b.Navigation("PresenceCours");
                });

            modelBuilder.Entity("Tp2.Models.Utilisateurs", b =>
                {
                    b.Navigation("Inscriptions");

                    b.Navigation("PresenceCours");
                });
#pragma warning restore 612, 618
        }
    }
}
