using Microsoft.EntityFrameworkCore.Migrations;

namespace FIzzBuzz_Ext.Migrations
{
    public partial class AddingAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "FizzBuzz",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "FizzBuzz");
        }
    }
}
