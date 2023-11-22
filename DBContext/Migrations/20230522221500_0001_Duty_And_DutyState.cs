using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBContext.Migrations
{
    /// <inheritdoc />
    public partial class _0001_Duty_And_DutyState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DutyStates",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyStates", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "DutyStates",
                columns: new[] { "Id", "Name" },
                values: new object[] { (byte)1, "Done" });

            migrationBuilder.InsertData(
                table: "DutyStates",
                columns: new[] { "Id", "Name" },
                values: new object[] { (byte)2, "Canceled" });

            migrationBuilder.CreateTable(
                name: "Duties",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateKey = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Duties_DutyStates_StateKey",
                        column: x => x.StateKey,
                        principalTable: "DutyStates",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Duties_StateKey",
                table: "Duties",
                column: "StateKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duties");

            migrationBuilder.DropTable(
                name: "DutyStates");
        }
    }
}
