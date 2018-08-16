using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IITCoreJobs.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmploymentStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AgeLimit = table.Column<double>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: true),
                    EducationDetails = table.Column<string>(nullable: true),
                    EmploymentStatusID = table.Column<Guid>(nullable: true),
                    JobDescription = table.Column<string>(nullable: false),
                    JobExperience = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    LastDate = table.Column<DateTime>(nullable: true),
                    Salary = table.Column<double>(nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "Date", nullable: true),
                    TagID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Job_JobCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "JobCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_EmploymentStatus_EmploymentStatusID",
                        column: x => x.EmploymentStatusID,
                        principalTable: "EmploymentStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_JobTag_TagID",
                        column: x => x.TagID,
                        principalTable: "JobTag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Job_CategoryID",
                table: "Job",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_EmploymentStatusID",
                table: "Job",
                column: "EmploymentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Job_TagID",
                table: "Job",
                column: "TagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "EmploymentStatus");
        }
    }
}
