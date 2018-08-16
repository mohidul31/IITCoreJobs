using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BDJobsCore.Migrations
{
    public partial class Mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmploymentStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LocationName = table.Column<string>(nullable: false)
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
                    JobDescription = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    TagID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobTag",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TagName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTag", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploymentStatus");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "JobTag");
        }
    }
}
