using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addingRoomProperity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Rooms");
        }
    }
}
