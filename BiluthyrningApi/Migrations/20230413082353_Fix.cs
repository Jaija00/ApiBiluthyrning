using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiluthyrningApi.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableCars_Bookings_BookingId",
                table: "AvailableCars");

            migrationBuilder.DropForeignKey(
                name: "FK_AvailableCars_Cars_CarId",
                table: "AvailableCars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableCars",
                table: "AvailableCars");

            migrationBuilder.RenameTable(
                name: "AvailableCars",
                newName: "AvailableCarsViewModel");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableCars_CarId",
                table: "AvailableCarsViewModel",
                newName: "IX_AvailableCarsViewModel_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableCars_BookingId",
                table: "AvailableCarsViewModel",
                newName: "IX_AvailableCarsViewModel_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableCarsViewModel",
                table: "AvailableCarsViewModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableCarsViewModel_Bookings_BookingId",
                table: "AvailableCarsViewModel",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableCarsViewModel_Cars_CarId",
                table: "AvailableCarsViewModel",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableCarsViewModel_Bookings_BookingId",
                table: "AvailableCarsViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_AvailableCarsViewModel_Cars_CarId",
                table: "AvailableCarsViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvailableCarsViewModel",
                table: "AvailableCarsViewModel");

            migrationBuilder.RenameTable(
                name: "AvailableCarsViewModel",
                newName: "AvailableCars");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableCarsViewModel_CarId",
                table: "AvailableCars",
                newName: "IX_AvailableCars_CarId");

            migrationBuilder.RenameIndex(
                name: "IX_AvailableCarsViewModel_BookingId",
                table: "AvailableCars",
                newName: "IX_AvailableCars_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvailableCars",
                table: "AvailableCars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableCars_Bookings_BookingId",
                table: "AvailableCars",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableCars_Cars_CarId",
                table: "AvailableCars",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
