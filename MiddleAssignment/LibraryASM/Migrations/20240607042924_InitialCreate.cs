using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryASM.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    PageSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequests",
                columns: table => new
                {
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    PageSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequestDetails",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageNumber = table.Column<int>(type: "int", nullable: false),
                    PageSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequestDetails", x => new { x.RequestId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetails_BookBorrowingRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "BookBorrowingRequests",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetails_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Romance" },
                    { 2, "Fiction" },
                    { 3, "Mystery" },
                    { 4, "Thriller" },
                    { 5, "Science Fiction" },
                    { 6, "Fantasy" },
                    { 7, "Horror" },
                    { 8, "Adventure" },
                    { 9, "Historical Fiction" },
                    { 10, "Biography" },
                    { 11, "Self-Help" },
                    { 12, "Business" },
                    { 13, "Cooking" },
                    { 14, "Travel" },
                    { 15, "Art" },
                    { 16, "Music" },
                    { 17, "Sports" },
                    { 18, "History" },
                    { 19, "Religion" },
                    { 20, "Philosophy" },
                    { 21, "Psychology" },
                    { 22, "Science" },
                    { 23, "Technology" },
                    { 24, "Education" },
                    { 25, "Politics" },
                    { 26, "Law" },
                    { 27, "Medicine" },
                    { 28, "Fashion" },
                    { 29, "Design" },
                    { 30, "Gardening" },
                    { 31, "Parenting" },
                    { 32, "Psychology" },
                    { 33, "Science" },
                    { 34, "Technology" },
                    { 35, "Education" },
                    { 36, "Politics" },
                    { 37, "Law" },
                    { 38, "Medicine" },
                    { 39, "Fashion" },
                    { 40, "Design" },
                    { 41, "Gardening" },
                    { 42, "Parenting" },
                    { 43, "Psychology" },
                    { 44, "Science" },
                    { 45, "Technology" },
                    { 46, "Education" },
                    { 47, "Politics" },
                    { 48, "Law" },
                    { 49, "Medicine" },
                    { 50, "Fashion" },
                    { 51, "Design" },
                    { 52, "Gardening" },
                    { 53, "Parenting" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "PageNumber", "PageSize", "Password", "Role", "RoleId", "UserEmail", "UserName", "UserPhone" },
                values: new object[,]
                {
                    { new Guid("18574f89-3fa6-4f1e-8c4c-1e4d060822d7"), 1, 20, "2", 0, 0, "jane@gmail.com", "Jane Smith", "135098123" },
                    { new Guid("531850a0-06d8-4188-a5d7-ac258e05ca05"), 1, 20, "3", 0, 0, "jake@gmail.com", "Jake Brown", "135123534" },
                    { new Guid("a9743a8a-b7ca-438a-8a5a-90c2333b3f5d"), 1, 20, "1", 1, 0, "john@gmail.com", "John Doe", "0912345678" }
                });

            migrationBuilder.InsertData(
                table: "BookBorrowingRequests",
                columns: new[] { "RequestId", "DateRequested", "PageNumber", "PageSize", "RequestStatus", "UserId" },
                values: new object[,]
                {
                    { new Guid("5981ee3f-b7e2-411d-be49-1c3ed02f5881"), new DateTime(2024, 6, 7, 11, 29, 21, 748, DateTimeKind.Local).AddTicks(6038), 1, 20, 1, new Guid("531850a0-06d8-4188-a5d7-ac258e05ca05") },
                    { new Guid("d48eabbc-0ea8-49f4-b8ca-6815a7caa172"), new DateTime(2024, 6, 7, 11, 29, 21, 748, DateTimeKind.Local).AddTicks(6019), 1, 20, 0, new Guid("18574f89-3fa6-4f1e-8c4c-1e4d060822d7") }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "BookAuthor", "BookDescription", "BookQuantity", "BookTitle", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("2024a4ad-2a91-46af-b718-efb96cbb521b"), "Tao", "lorem ipsum", 3, "Book 1", 1 },
                    { new Guid("285baf57-3905-4da8-a709-2ff5e0db950c"), "Josh", "irem lopsum", 7, "Book 5", 39 },
                    { new Guid("3d2a6fc8-ca32-42f6-9c08-48828dd2604a"), "Josh", "irem lopsum", 5, "Book 6", 12 },
                    { new Guid("54614055-b280-445c-a68a-52c471580bdc"), "Josh", "irem lopsum", 4, "Book 7", 4 },
                    { new Guid("99521204-7f4b-41e0-adfe-95ec32ed5cb5"), "Josh", "irem lopsum", 5, "Book 3", 43 },
                    { new Guid("9e0a589d-9011-485e-8ce7-47ea37d63cad"), "Josh", "irem lopsum", 8, "Book 4", 24 },
                    { new Guid("be18f8e3-555f-47f4-81fd-4649bfdcb459"), "Josh", "irem lopsum", 2, "Book 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "BookBorrowingRequestDetails",
                columns: new[] { "BookId", "RequestId", "PageNumber", "PageSize" },
                values: new object[,]
                {
                    { new Guid("be18f8e3-555f-47f4-81fd-4649bfdcb459"), new Guid("5981ee3f-b7e2-411d-be49-1c3ed02f5881"), 1, 20 },
                    { new Guid("2024a4ad-2a91-46af-b718-efb96cbb521b"), new Guid("d48eabbc-0ea8-49f4-b8ca-6815a7caa172"), 1, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequestDetails_BookId",
                table: "BookBorrowingRequestDetails",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequests_UserId",
                table: "BookBorrowingRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrowingRequestDetails");

            migrationBuilder.DropTable(
                name: "BookBorrowingRequests");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
