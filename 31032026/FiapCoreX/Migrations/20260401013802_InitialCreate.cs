using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapCoreX.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbAluno",
                columns: table => new
                {
                    idAluno = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAluno", x => x.idAluno);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAluno");
        }
    }
}
