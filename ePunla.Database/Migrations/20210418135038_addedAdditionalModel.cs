using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ePunla.Common.Database.Migrations
{
    public partial class addedAdditionalModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    FarmId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerId = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    BarangayId = table.Column<int>(nullable: true),
                    BarangayAreaId = table.Column<int>(nullable: true),
                    AreaSize = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.FarmId);
                    table.ForeignKey(
                        name: "FK_Farms_BarangayAreas_BarangayAreaId",
                        column: x => x.BarangayAreaId,
                        principalTable: "BarangayAreas",
                        principalColumn: "BarangayAreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farms_Barangays_BarangayId",
                        column: x => x.BarangayId,
                        principalTable: "Barangays",
                        principalColumn: "BarangayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Farms_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "FarmerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    CropId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.CropId);
                    table.ForeignKey(
                        name: "FK_Crops_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FarmCrops",
                columns: table => new
                {
                    FarmCropId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropId = table.Column<int>(nullable: true),
                    FarmId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    EstimatedHarvestDate = table.Column<DateTime>(nullable: false),
                    PlantedDate = table.Column<DateTime>(nullable: false),
                    AreaSize = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    HarvestDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmCrops", x => x.FarmCropId);
                    table.ForeignKey(
                        name: "FK_FarmCrops_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmCrops_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "CropId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FarmCrops_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "FarmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmCropId = table.Column<int>(nullable: true),
                    FarmId = table.Column<int>(nullable: true),
                    FilingDate = table.Column<DateTime>(nullable: false),
                    DamagedArea = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true),
                    PhotoId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    ValidationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claims_FarmCrops_FarmCropId",
                        column: x => x.FarmCropId,
                        principalTable: "FarmCrops",
                        principalColumn: "FarmCropId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claims_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "FarmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimCauses",
                columns: table => new
                {
                    ClaimCauseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(nullable: true),
                    DamageType = table.Column<string>(nullable: true),
                    DamagedAreaSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimCauses", x => x.ClaimCauseId);
                    table.ForeignKey(
                        name: "FK_ClaimCauses_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimCauses_ClaimId",
                table: "ClaimCauses",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_FarmCropId",
                table: "Claims",
                column: "FarmCropId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_FarmId",
                table: "Claims",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_CategoryId",
                table: "Crops",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmCrops_CategoryId",
                table: "FarmCrops",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmCrops_CropId",
                table: "FarmCrops",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmCrops_FarmId",
                table: "FarmCrops",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_BarangayAreaId",
                table: "Farms",
                column: "BarangayAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_BarangayId",
                table: "Farms",
                column: "BarangayId");

            migrationBuilder.CreateIndex(
                name: "IX_Farms_FarmerId",
                table: "Farms",
                column: "FarmerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimCauses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "FarmCrops");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
