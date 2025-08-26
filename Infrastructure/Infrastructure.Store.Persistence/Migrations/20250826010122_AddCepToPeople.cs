using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Store.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCepToPeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "TB_PEOPLE",
                schema: "rm556480",
                newName: "TB_PEOPLE");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "TB_PEOPLE",
                type: "NVARCHAR2(8)",
                maxLength: 8,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "TB_PEOPLE");

            migrationBuilder.EnsureSchema(
                name: "rm556480");

            migrationBuilder.RenameTable(
                name: "TB_PEOPLE",
                newName: "TB_PEOPLE",
                newSchema: "rm556480");
        }
    }
}
