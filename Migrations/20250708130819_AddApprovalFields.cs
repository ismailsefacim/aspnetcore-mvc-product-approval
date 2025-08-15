using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddApprovalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedByUserId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Products",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApprovedByUserId",
                table: "Products",
                column: "ApprovedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_ApprovedByUserId",
                table: "Products",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_ApprovedByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ApprovedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Products");
        }
    }
}
