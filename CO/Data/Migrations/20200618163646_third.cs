using Microsoft.EntityFrameworkCore.Migrations;

namespace CO.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Associates",
                table: "Associates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b88e55a-ec4c-48f7-a202-7ff1aae2a76c");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Associates");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Associates",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssociateId",
                table: "Associates",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Associates",
                table: "Associates",
                column: "AssociateId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0bc1139f-6631-494a-8941-765dbf9987b4", "381ade7f-71cc-435f-b4ae-75ca8dc39fbe", "Asociate", "ASOCIATE" });

            migrationBuilder.CreateIndex(
                name: "IX_Associates_IdentityUserId",
                table: "Associates",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associates_AspNetUsers_IdentityUserId",
                table: "Associates",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associates_AspNetUsers_IdentityUserId",
                table: "Associates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Associates",
                table: "Associates");

            migrationBuilder.DropIndex(
                name: "IX_Associates_IdentityUserId",
                table: "Associates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bc1139f-6631-494a-8941-765dbf9987b4");

            migrationBuilder.DropColumn(
                name: "AssociateId",
                table: "Associates");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Associates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Associates",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Associates",
                table: "Associates",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b88e55a-ec4c-48f7-a202-7ff1aae2a76c", "a579629e-5b94-479c-b6a3-3a6e9b446dcd", "Asociate", "ASOCIATE" });
        }
    }
}
