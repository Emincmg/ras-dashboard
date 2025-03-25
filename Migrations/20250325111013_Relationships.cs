using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RhsDashboard.Migrations
{
    /// <inheritdoc />
    public partial class Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "TaskItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoomTaskItem",
                columns: table => new
                {
                    RoomsId = table.Column<int>(type: "int", nullable: false),
                    TaskItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTaskItem", x => new { x.RoomsId, x.TaskItemsId });
                    table.ForeignKey(
                        name: "FK_RoomTaskItem_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomTaskItem_TaskItems_TaskItemsId",
                        column: x => x.TaskItemsId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_EmployeeId",
                table: "TaskItems",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoomId",
                table: "AspNetUsers",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTaskItem_TaskItemsId",
                table: "RoomTaskItem",
                column: "TaskItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Rooms_RoomId",
                table: "AspNetUsers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_AspNetUsers_EmployeeId",
                table: "TaskItems",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Rooms_RoomId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_AspNetUsers_EmployeeId",
                table: "TaskItems");

            migrationBuilder.DropTable(
                name: "RoomTaskItem");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_EmployeeId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoomId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "AspNetUsers");
        }
    }
}
