using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLInventorySystem.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCounts_Items_Id",
                table: "ItemCounts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ItemCounts",
                newName: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCounts_Items_ItemId",
                table: "ItemCounts",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCounts_Items_ItemId",
                table: "ItemCounts");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItemCounts",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCounts_Items_Id",
                table: "ItemCounts",
                column: "Id",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
