using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nucleus.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeEntryCalculatedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStart",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 1, 12, 15, 4, 0, 545, DateTimeKind.Utc).AddTicks(2171));

            migrationBuilder.AddColumn<decimal>(
                name: "HoursActual",
                table: "TimeEntries",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HoursDeduct",
                table: "TimeEntries",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeDelta",
                table: "TimeEntries",
                type: "time",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoursActual",
                table: "TimeEntries");

            migrationBuilder.DropColumn(
                name: "HoursDeduct",
                table: "TimeEntries");

            migrationBuilder.DropColumn(
                name: "TimeDelta",
                table: "TimeEntries");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeStart",
                table: "TimeEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 12, 15, 4, 0, 545, DateTimeKind.Utc).AddTicks(2171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
