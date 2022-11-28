using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addBookingName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingName",
                table: "Bookings");
        }
    }
}
