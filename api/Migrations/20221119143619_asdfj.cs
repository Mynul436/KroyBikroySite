using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class asdfj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UsedTime",
                table: "Products",
                newName: "BuyingDate");

            migrationBuilder.RenameColumn(
                name: "Discription",
                table: "Products",
                newName: "SubDistrict");

            migrationBuilder.RenameColumn(
                name: "BiddingDuration",
                table: "Products",
                newName: "BiddingEndDate");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SubDistrict",
                table: "Products",
                newName: "Discription");

            migrationBuilder.RenameColumn(
                name: "BuyingDate",
                table: "Products",
                newName: "UsedTime");

            migrationBuilder.RenameColumn(
                name: "BiddingEndDate",
                table: "Products",
                newName: "BiddingDuration");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
