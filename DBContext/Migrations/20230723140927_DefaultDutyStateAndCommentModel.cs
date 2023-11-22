using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class DefaultDutyStateAndCommentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Duties");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DutyKey = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Comments_Duties_DutyKey",
                        column: x => x.DutyKey,
                        principalTable: "Duties",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DutyKey",
                table: "Comments",
                column: "DutyKey");

            migrationBuilder.InsertData(
                table: "DutyStates",
                columns: new string[] { "Key", "Id", "Name" },
                values: new object[] { 0, 0, "None" }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Duties",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.DeleteData(
                table: "DutyStates",
                keyColumn: "Key",
                keyValue: 0
                );
        }
    }
}
