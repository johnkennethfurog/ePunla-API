using Microsoft.EntityFrameworkCore.Migrations;

namespace ePunla.Common.Database.Migrations
{
    public partial class addedBarangayAndBarangayAreas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Farmers");

            migrationBuilder.AlterColumn<int>(
                name: "BarangayId",
                table: "Farmers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BarangayAreaId",
                table: "Farmers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Barangays",
                columns: table => new
                {
                    BarangayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barangays", x => x.BarangayId);
                });

            migrationBuilder.CreateTable(
                name: "BarangayAreas",
                columns: table => new
                {
                    BarangayAreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarangayId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarangayAreas", x => x.BarangayAreaId);
                    table.ForeignKey(
                        name: "FK_BarangayAreas_Barangays_BarangayId",
                        column: x => x.BarangayId,
                        principalTable: "Barangays",
                        principalColumn: "BarangayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_BarangayAreaId",
                table: "Farmers",
                column: "BarangayAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Farmers_BarangayId",
                table: "Farmers",
                column: "BarangayId");

            migrationBuilder.CreateIndex(
                name: "IX_BarangayAreas_BarangayId",
                table: "BarangayAreas",
                column: "BarangayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Farmers_BarangayAreas_BarangayAreaId",
                table: "Farmers",
                column: "BarangayAreaId",
                principalTable: "BarangayAreas",
                principalColumn: "BarangayAreaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Farmers_Barangays_BarangayId",
                table: "Farmers",
                column: "BarangayId",
                principalTable: "Barangays",
                principalColumn: "BarangayId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Farmers_BarangayAreas_BarangayAreaId",
                table: "Farmers");

            migrationBuilder.DropForeignKey(
                name: "FK_Farmers_Barangays_BarangayId",
                table: "Farmers");

            migrationBuilder.DropTable(
                name: "BarangayAreas");

            migrationBuilder.DropTable(
                name: "Barangays");

            migrationBuilder.DropIndex(
                name: "IX_Farmers_BarangayAreaId",
                table: "Farmers");

            migrationBuilder.DropIndex(
                name: "IX_Farmers_BarangayId",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "BarangayAreaId",
                table: "Farmers");

            migrationBuilder.AlterColumn<int>(
                name: "BarangayId",
                table: "Farmers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "Farmers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
