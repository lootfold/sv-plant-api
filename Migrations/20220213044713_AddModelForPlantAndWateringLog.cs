using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SVPlant.Migrations
{
    public partial class AddModelForPlantAndWateringLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    IsGettingWatered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WateringLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlantId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: true),
                    StopTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WateringLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WateringLogs_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "IsGettingWatered", "Name" },
                values: new object[] { 1, false, "Plant1" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "IsGettingWatered", "Name" },
                values: new object[] { 2, false, "Plant2" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "IsGettingWatered", "Name" },
                values: new object[] { 3, false, "Plant3" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "IsGettingWatered", "Name" },
                values: new object[] { 4, false, "Plant4" });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "IsGettingWatered", "Name" },
                values: new object[] { 5, false, "Plant5" });

            migrationBuilder.CreateIndex(
                name: "IX_WateringLogs_PlantId",
                table: "WateringLogs",
                column: "PlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WateringLogs");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
