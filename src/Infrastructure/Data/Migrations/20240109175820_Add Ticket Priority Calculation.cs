using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nucleus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketPriorityCalculation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Tickets",
                type: "int",
                nullable: false,
                computedColumnSql: "[Impact] * [Urgency]",
                stored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Tickets");
        }
    }
}
