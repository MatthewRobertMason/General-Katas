using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLInventorySystem.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts",
                columns: new[] { "ItemId", "InventoryId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCounts",
                table: "ItemCounts",
                column: "ItemId");
        }
    }
}
