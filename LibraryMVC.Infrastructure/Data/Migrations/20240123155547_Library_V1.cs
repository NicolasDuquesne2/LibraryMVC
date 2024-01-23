using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class Library_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appartement = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Domaines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domaines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lecteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotDePasse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresseId = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecteurs_Adresses_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreDePage = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    DomaineId = table.Column<int>(type: "int", nullable: false),
                    AuteurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livres_Auteurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livres_Domaines_DomaineId",
                        column: x => x.DomaineId,
                        principalTable: "Domaines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprunts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEmprunt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRetour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LecteurId = table.Column<int>(type: "int", nullable: false),
                    LivreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprunts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprunts_Lecteurs_LecteurId",
                        column: x => x.LecteurId,
                        principalTable: "Lecteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprunts_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "MotDePasse", "Nom", "Prenom", "Telephone" },
                values: new object[,]
                {
                    { 1, "l.Durand@domain.com", "*Azerty4587", "Durand", "Luc", "0470859578" },
                    { 2, "u.Dupont@domain.com", "*Azerty4587", "Ulrik", "Dupont", "0470859578" }
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "Appartement", "CodePostal", "Pays", "Rue", "Ville" },
                values: new object[,]
                {
                    { 1, "2", "59000", "France", "rue du Chambon", "Lille" },
                    { 2, "10", "75003", "France", "rue des pins", "Paris" },
                    { 3, "7", "13008", "France", "rue des voies", "Marseille" },
                    { 4, "9", "69005", "France", "rue de la fibre", "Lyon" },
                    { 5, "250", "75200", "France", "rue Chabrior", "Les Lillas" },
                    { 6, "15", "86000", "France", "rue Junio", "Poitiers" },
                    { 7, "8", "17000", "France", "rue Desmoulins", "La Rochelle" }
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "Id", "Email", "Grade", "Nom", "Prenom", "Telephone" },
                values: new object[,]
                {
                    { 1, "a.Carson@domain.com", "sociétaire", "Carson", "Alexander", "0470859578" },
                    { 2, "m.Alonson@domain.com", "sociétaire adjoint", "Alonso", "Meredith", "0470859578" },
                    { 3, "a.Anand@domain.com", "adhérent", "Anand", "Arturo", "0470859578" },
                    { 4, "g.Barzdukas@domain.com", "adhérent", "Barzdukas", "Gytis", "0470859578" },
                    { 5, "l.Yan@domain.com", "adhérent", "Li", "Yan", "0470859578" },
                    { 6, "l.Yan@domain.com", "adhérent", "Justice", "Peggy", "0470859578" },
                    { 7, "l.Norman@domain.com", "adhérent", "Norman", "Laura", "0470859578" },
                    { 8, "o.Olivetto@domain.com", "adhérent", "Olivetto", "Nino", "0470859578" }
                });

            migrationBuilder.InsertData(
                table: "Domaines",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[,]
                {
                    { 1, "", "Chemistry" },
                    { 2, "", "Microéconomie" },
                    { 3, "", "Macroéconomie" },
                    { 4, "", "Maths" },
                    { 5, "", "Litérature" }
                });

            migrationBuilder.InsertData(
                table: "Lecteurs",
                columns: new[] { "Id", "AdresseId", "Email", "MotDePasse", "Nom", "Prenom", "Telephone" },
                values: new object[,]
                {
                    { 1, 1, "a.Carson@domain.com", "*Azerty4587", "Carson", "Alexander", "0470859578" },
                    { 2, 2, "m.Alonson@domain.com", "*Azerty4587", "Alonso", "Meredith", "0470859578" },
                    { 3, 3, "a.Anand@domain.com", "*Azerty4587", "Anand", "Arturo", "0470859578" },
                    { 4, 4, "g.Barzdukas@domain.com", "*Azerty4587", "Barzdukas", "Gytis", "0470859578" },
                    { 5, 5, "l.Yan@domain.com", "*Azerty4587", "Li", "Yan", "0470859578" },
                    { 6, 6, "l.Yan@domain.com", "*Azerty4587", "Justice", "Peggy", "0470859578" },
                    { 7, 7, "l.Norman@domain.com", "*Azerty4587", "Norman", "Laura", "0470859578" },
                    { 8, 1, "o.Olivetto@domain.com", "*Azerty4587", "Olivetto", "Nino", "0470859578" }
                });

            migrationBuilder.InsertData(
                table: "Livres",
                columns: new[] { "Id", "AuteurId", "DomaineId", "NombreDePage", "Titre" },
                values: new object[,]
                {
                    { 1, 1, 1, 300, "Chemistry" },
                    { 2, 2, 2, 250, "Utilité marginale" },
                    { 3, 3, 3, 150, "Equilibre général" },
                    { 4, 4, 4, 500, "Maths pour les nuls" },
                    { 5, 5, 4, 200, "Géométrie les bases" },
                    { 6, 6, 5, 100, "Les chiens ne font pas des chats" },
                    { 7, 7, 5, 345, "Le seigneur de l'aube" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprunts_LecteurId",
                table: "Emprunts",
                column: "LecteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunts_LivreId",
                table: "Emprunts",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecteurs_AdresseId",
                table: "Lecteurs",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Livres_AuteurId",
                table: "Livres",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Livres_DomaineId",
                table: "Livres",
                column: "DomaineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Emprunts");

            migrationBuilder.DropTable(
                name: "Lecteurs");

            migrationBuilder.DropTable(
                name: "Livres");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "Domaines");
        }
    }
}
