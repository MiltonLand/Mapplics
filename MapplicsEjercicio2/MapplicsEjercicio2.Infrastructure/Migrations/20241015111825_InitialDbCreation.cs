using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapplicsEjercicio2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");


            //Products Stored Procedures
            migrationBuilder.Sql(
                @"CREATE PROCEDURE [dbo].[spProduct_GetAll]
                  AS
                  BEGIN
                      SELECT Id, Name, Price, Quantity, Description, CategoryId
                      FROM dbo.[Products]
                  END");
            migrationBuilder.Sql(
                @"CREATE PROCEDURE [dbo].[spProduct_Get]
                      @Id int
                  AS
                  BEGIN
                      SELECT Id, Name, Price, Quantity, Description, CategoryId
                      FROM dbo.[Products]
                      WHERE Id = @Id;
                  END");

            //Categories Stored Procedures
            migrationBuilder.Sql(
                @"CREATE PROCEDURE [dbo].[spCategory_GetAll]
                  AS
                  BEGIN
                      SELECT Id, Name, Description
                      FROM dbo.[Categories]
                  END");
            migrationBuilder.Sql(
                @"CREATE PROCEDURE [dbo].[spCategory_Get]
                      @Id int
                  AS
                  BEGIN
                      SELECT Id, Name, Description
                      FROM dbo.[Categories]
                      WHERE Id = @Id;
                  END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
