using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoreLife.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class JwtSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JwtSettings",
                columns: table => new
                {
                    Secret = table.Column<string>(type: "TEXT", nullable: false),
                    Issuer = table.Column<string>(type: "TEXT", nullable: false),
                    Audience = table.Column<string>(type: "TEXT", nullable: false),
                    ExpirationInMinutes = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JwtSettings", x => x.Secret);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JwtSettings");
        }
    }
}
