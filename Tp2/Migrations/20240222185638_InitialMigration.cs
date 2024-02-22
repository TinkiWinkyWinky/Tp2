using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tp2.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreMaximalSuggere = table.Column<int>(type: "int", nullable: false),
                    DurreeDuCoursMinutes = table.Column<int>(type: "int", nullable: false),
                    CoursPrealableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cours_Cours_CoursPrealableId",
                        column: x => x.CoursPrealableId,
                        principalTable: "Cours",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Piscines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CapaciteMaximale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piscines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreationCompte = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moniteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    NoLicence = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moniteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moniteurs_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroGroupe = table.Column<int>(type: "int", nullable: false),
                    CoursId = table.Column<int>(type: "int", nullable: false),
                    MoniteurParDefaultId = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PiscineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groupes_Cours_CoursId",
                        column: x => x.CoursId,
                        principalTable: "Cours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groupes_Moniteurs_MoniteurParDefaultId",
                        column: x => x.MoniteurParDefaultId,
                        principalTable: "Moniteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groupes_Piscines_PiscineId",
                        column: x => x.PiscineId,
                        principalTable: "Piscines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    CoursGroupeId = table.Column<int>(type: "int", nullable: false),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Groupes_CoursGroupeId",
                        column: x => x.CoursGroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscriptions_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Occurrences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    MoniteurDeCeCoursId = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurrences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occurrences_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occurrences_Moniteurs_MoniteurDeCeCoursId",
                        column: x => x.MoniteurDeCeCoursId,
                        principalTable: "Moniteurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PresenceCours",
                columns: table => new
                {
                    OccurrenceDuCoursId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresenceCours", x => new { x.OccurrenceDuCoursId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_PresenceCours_Occurrences_OccurrenceDuCoursId",
                        column: x => x.OccurrenceDuCoursId,
                        principalTable: "Occurrences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PresenceCours_Utilisateurs_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cours_CoursPrealableId",
                table: "Cours",
                column: "CoursPrealableId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_CoursId",
                table: "Groupes",
                column: "CoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_MoniteurParDefaultId",
                table: "Groupes",
                column: "MoniteurParDefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_PiscineId",
                table: "Groupes",
                column: "PiscineId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_CoursGroupeId",
                table: "Inscriptions",
                column: "CoursGroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriptions_UtilisateurId",
                table: "Inscriptions",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Moniteurs_UtilisateurId",
                table: "Moniteurs",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Occurrences_GroupeId",
                table: "Occurrences",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Occurrences_MoniteurDeCeCoursId",
                table: "Occurrences",
                column: "MoniteurDeCeCoursId");

            migrationBuilder.CreateIndex(
                name: "IX_PresenceCours_ParticipantId",
                table: "PresenceCours",
                column: "ParticipantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "PresenceCours");

            migrationBuilder.DropTable(
                name: "Occurrences");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Cours");

            migrationBuilder.DropTable(
                name: "Moniteurs");

            migrationBuilder.DropTable(
                name: "Piscines");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
