using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class Todo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Provinces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 11, 12, 22, 12, 20, DateTimeKind.Local).AddTicks(4279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 11, 9, 51, 17, 910, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Provinces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 11, 12, 22, 12, 20, DateTimeKind.Local).AddTicks(3887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 11, 9, 51, 17, 910, DateTimeKind.Local).AddTicks(3471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 11, 12, 22, 12, 20, DateTimeKind.Local).AddTicks(799),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 11, 9, 51, 17, 910, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 11, 12, 22, 12, 19, DateTimeKind.Local).AddTicks(9919),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 11, 9, 51, 17, 910, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.CreateTable(
                name: "TodoEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoEntity_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoEntity_UserId",
                table: "TodoEntity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoEntity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Provinces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 11, 9, 51, 17, 910, DateTimeKind.Local).AddTicks(3856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 11, 12, 22, 12, 20, DateTimeKind.Local).AddTicks(4279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Provinces",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 11, 9, 51, 17, 910, DateTimeKind.Local).AddTicks(3471),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 11, 12, 22, 12, 20, DateTimeKind.Local).AddTicks(3887));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 11, 9, 51, 17, 910, DateTimeKind.Local).AddTicks(1184),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 11, 12, 22, 12, 20, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 11, 9, 51, 17, 910, DateTimeKind.Local).AddTicks(793),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 11, 12, 22, 12, 19, DateTimeKind.Local).AddTicks(9919));
        }
    }
}
