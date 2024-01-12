using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nucleus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExpectedResultPropertytoTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpectedResult",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedResult",
                table: "Tickets");
        }
    }
}
