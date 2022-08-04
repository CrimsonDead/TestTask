using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataLayer.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Email", "UniqNumber" },
                values: new object[] { 1, "mal1@gmail.com", 100582333L });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Email", "UniqNumber" },
                values: new object[] { 2, "mal2@gmail.com", 140582313L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
