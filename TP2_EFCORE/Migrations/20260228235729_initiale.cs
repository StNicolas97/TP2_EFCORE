using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP2_EFCORE.Migrations
{
    /// <inheritdoc />
    public partial class initiale : Migration
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
                    DureeDuCoursMinutes = table.Column<int>(type: "int", nullable: false),
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
                    NoLicence = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
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
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoursId = table.Column<int>(type: "int", nullable: false),
                    PiscineId = table.Column<int>(type: "int", nullable: false),
                    MoniteurParDefautId = table.Column<int>(type: "int", nullable: false),
                    MoniteurId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Groupes_Moniteurs_MoniteurId",
                        column: x => x.MoniteurId,
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
                    CoursGroupeId = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Occurences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GroupeId = table.Column<int>(type: "int", nullable: false),
                    MoniteurDeCoursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occurences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occurences_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occurences_Moniteurs_MoniteurDeCoursId",
                        column: x => x.MoniteurDeCoursId,
                        principalTable: "Moniteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresenceCours",
                columns: table => new
                {
                    OccurenceDuCoursId = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresenceCours", x => new { x.OccurenceDuCoursId, x.ParticipantId });
                    table.ForeignKey(
                        name: "FK_PresenceCours_Occurences_OccurenceDuCoursId",
                        column: x => x.OccurenceDuCoursId,
                        principalTable: "Occurences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresenceCours_Utilisateurs_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cours",
                columns: new[] { "Id", "CoursPrealableId", "Description", "DureeDuCoursMinutes", "NombreMaximalSuggere", "Titre" },
                values: new object[] { 1, null, "Ces nageurs débutants deviendront confortables à sauter dans l’eau.", 30, 5, "Nageur 1" });

            migrationBuilder.InsertData(
                table: "Piscines",
                columns: new[] { "Id", "Adresse", "CapaciteMaximale", "CodePostal", "Nom", "Ville" },
                values: new object[,]
                {
                    { 1, "560, rue Léon-Harmel", 350, "J2G3G7", "Centre aquatique Desjardins de Granby", "Granby" },
                    { 2, "220, place Municipale", 220, "J2K1T4", "Centre aquatique de Cowansville", "Cowansville" },
                    { 3, "850, rue Turcot", 350, "J2S1M2", "Centre aquatique Desjardins de Saint-Hyacinthe", "Saint-Hyacinthe" }
                });

            migrationBuilder.InsertData(
                table: "Cours",
                columns: new[] { "Id", "CoursPrealableId", "Description", "DureeDuCoursMinutes", "NombreMaximalSuggere", "Titre" },
                values: new object[,]
                {
                    { 2, 1, "Ces débutants aux habiletés plus avancées sauteront en eau plus profonde.", 30, 5, "Nageur 2" },
                    { 3, 2, "Ces jeunes nageurs feront des plongeons, des roulades avant dans l’eau et des appuis renversés.", 30, 5, "Nageur 3" },
                    { 4, 3, "Ces nageurs intermédiaires nageront 5 m sous l’eau et ils feront des longueurs au crawl.", 50, 6, "Nageur 4" },
                    { 5, 4, "Ces nageurs maîtriseront les plongeons à fleur d'eau, les sauts groupés (en boule)", 50, 6, "Nageur 5" }
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
                name: "IX_Groupes_MoniteurId",
                table: "Groupes",
                column: "MoniteurId");

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
                column: "UtilisateurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Occurences_GroupeId",
                table: "Occurences",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Occurences_MoniteurDeCoursId",
                table: "Occurences",
                column: "MoniteurDeCoursId");

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
                name: "Occurences");

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
