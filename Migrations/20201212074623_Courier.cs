using Microsoft.EntityFrameworkCore.Migrations;

namespace CourierAPI.Migrations
{
    public partial class Courier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromName = table.Column<string>(nullable: false),
                    FromAddress = table.Column<string>(nullable: false),
                    FromContactNumber = table.Column<string>(nullable: false),
                    ToName = table.Column<string>(nullable: false),
                    ToAddress = table.Column<string>(nullable: false),
                    ToContactNumber = table.Column<string>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    Insured = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couriers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Couriers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chandigarh" },
                    { 2, "Delhi" },
                    { 3, "Amritsar" },
                    { 4, "Shimla" },
                    { 5, "Mohali" },
                    { 6, "Panchkula" },
                    { 7, "Manali" }
                });

            migrationBuilder.InsertData(
                table: "Couriers",
                columns: new[] { "Id", "FromAddress", "FromContactNumber", "FromName", "Insured", "LocationId", "ToAddress", "ToContactNumber", "ToName" },
                values: new object[] { 1, "111, Sector 11, chandigarh", "9876543210", "Ravi Sharma", "Yes", 1, "1232/A, Pahadganj, New Delhi", "011-4345632", "Saroj Sharma" });

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_LocationId",
                table: "Couriers",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Couriers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
