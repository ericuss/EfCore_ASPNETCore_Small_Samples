using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Creating.From.ConsoleApp.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Authors_AuthorId",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("64c3d8f1-723f-4a05-a8a6-af6329ea5781"), "Santiago Posteguillo" },
                    { new Guid("8ef6815b-ebf8-4f2f-b25f-fd7530025723"), "Simon Scarrow" },
                    { new Guid("b343ac23-0e8d-4abf-88a0-7beacaf8caff"), "Steven Pressfiel" },
                    { new Guid("b3dbb82a-5387-466a-a99d-4b9d83903bdb"), "Orson Scott" },
                    { new Guid("7aba4e5e-309a-49b7-a8f4-f5fb64ad09cd"), "John Scalzi" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Name" },
                values: new object[] { new Guid("c3c64f20-e40e-437c-8952-b6dab6b4513a"), new Guid("64c3d8f1-723f-4a05-a8a6-af6329ea5781"), "Africanus" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Name" },
                values: new object[] { new Guid("41fad579-629f-49ff-855e-36b88cf29cb9"), new Guid("64c3d8f1-723f-4a05-a8a6-af6329ea5781"), "Las legiones malditas" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("7aba4e5e-309a-49b7-a8f4-f5fb64ad09cd"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("8ef6815b-ebf8-4f2f-b25f-fd7530025723"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("b343ac23-0e8d-4abf-88a0-7beacaf8caff"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("b3dbb82a-5387-466a-a99d-4b9d83903bdb"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("41fad579-629f-49ff-855e-36b88cf29cb9"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c3c64f20-e40e-437c-8952-b6dab6b4513a"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("64c3d8f1-723f-4a05-a8a6-af6329ea5781"));

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "Book",
                newName: "IX_Book_AuthorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AuthorId",
                table: "Book",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Authors_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
