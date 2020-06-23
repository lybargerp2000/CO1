using Microsoft.EntityFrameworkCore.Migrations;

namespace CO.Data.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bc1139f-6631-494a-8941-765dbf9987b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28c6486d-8b1a-47d5-8677-994336988cb5", "953f95f9-430a-413d-bfdd-84b86367fb23", "Associate", "ASSOCIATE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28c6486d-8b1a-47d5-8677-994336988cb5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0bc1139f-6631-494a-8941-765dbf9987b4", "381ade7f-71cc-435f-b4ae-75ca8dc39fbe", "Asociate", "ASOCIATE" });
        }
    }
}
