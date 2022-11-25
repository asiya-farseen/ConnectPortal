using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FWS.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    custId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.custId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectManagers",
                columns: table => new
                {
                    pmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    pmPhone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    pmEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    pmAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    pmPinCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    pmPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectManagers", x => x.pmId);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    jobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SkillSet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    StartDateOfJob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateOfJob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfResource = table.Column<int>(type: "int", nullable: false),
                    CustomercustId = table.Column<int>(type: "int", nullable: false),
                    projectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.jobId);
                    table.ForeignKey(
                        name: "FK_Resources_Customers_CustomercustId",
                        column: x => x.CustomercustId,
                        principalTable: "Customers",
                        principalColumn: "custId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomercustId = table.Column<int>(type: "int", nullable: false),
                    ProjectManagerpmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projId);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CustomercustId",
                        column: x => x.CustomercustId,
                        principalTable: "Customers",
                        principalColumn: "custId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectManagers_ProjectManagerpmId",
                        column: x => x.ProjectManagerpmId,
                        principalTable: "ProjectManagers",
                        principalColumn: "pmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomercustId",
                table: "Projects",
                column: "CustomercustId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerpmId",
                table: "Projects",
                column: "ProjectManagerpmId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CustomercustId",
                table: "Resources",
                column: "CustomercustId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "ProjectManagers");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
