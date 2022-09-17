using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Rating", "Title", "Year" },
                values: new object[] { 1, 75, "Avenger: Endgame", 2019 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Rating", "Title", "Year" },
                values: new object[] { 2, 70, "The Lion King", 2019 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Rating", "Title", "Year" },
                values: new object[] { 3, 80, "Ip Man 4", 2019 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Rating", "Title", "Year" },
                values: new object[] { 4, 40, "Gemini Man", 2019 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Rating", "Title", "Year" },
                values: new object[] { 5, 65, "Downton Abbey", 2020 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[] { 1, 1, "Tony Stark" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[] { 2, 1, "Steve Rogers" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[] { 3, 1, "Okoye" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[] { 4, 2, "Simba" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[] { 5, 2, "Nala" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[] { 6, 3, "Ip Man" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[] { 7, 4, "Henry Brogan" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[] { 8, 5, "Violet Crawley" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[] { 9, 5, "Lady Mary Crawley" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_MovieId",
                table: "Characters",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
