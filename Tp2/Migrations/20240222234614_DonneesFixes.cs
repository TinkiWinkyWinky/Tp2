using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tp2.Migrations
{
    /// <inheritdoc />
    public partial class DonneesFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cours",
                columns: new[] { "Id", "CoursPrealableId", "Description", "DurreeDuCoursMinutes", "NombreMaximalSuggere", "Titre" },
                values: new object[] { 1, null, "Ces nageurs débutants deviendront confortables à sauter dans l’eau.", 30, 5, "Nageur 1" });

            migrationBuilder.InsertData(
                table: "Piscines",
                columns: new[] { "Id", "Adresse", "CapaciteMaximale", "CodePostal", "Nom", "Ville" },
                values: new object[,]
                {
                    { 1, "560, rue LéonHarmel", 350, "J2G3G7", "Centre aquatique Desjardins de Granby", "Granby" },
                    { 2, "220, place Municipale", 220, "J2K1T4", "Centre aquatique de Cowansville", "Cowansville" },
                    { 3, "850, rue Turcot", 350, "J2S1M2", "Centre aquatique Desjardins de Saint-Hyacinthe", "Saint-Hyacinthe" }
                });

            migrationBuilder.InsertData(
                table: "Cours",
                columns: new[] { "Id", "CoursPrealableId", "Description", "DurreeDuCoursMinutes", "NombreMaximalSuggere", "Titre" },
                values: new object[,]
                {
                    { 2, 1, "Ces débutants aux habiletés plus avancées sauteront en eau plus profonde.", 30, 5, "Nageur 2" },
                    { 3, 2, "Ces jeunes nageurs feront des plongeons, des roulades avant dans l’eau et des appuis renversés.", 30, 5, "Nageur 3" },
                    { 4, 3, "Ces nageurs intermédiaires nageront 5 m sous l’eau et ils feront des longueurs au crawl.", 50, 6, "Nageur 4" },
                    { 5, 4, "Ces nageurs maîtriseront les plongeons à fleur d'eau, les sauts groupés (en boule)", 50, 6, "Nageur 5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cours",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Piscines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Piscines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Piscines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cours",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cours",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cours",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
