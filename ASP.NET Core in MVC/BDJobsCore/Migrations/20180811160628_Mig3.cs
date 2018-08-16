using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BDJobsCore.Migrations
{
    public partial class Mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmploymentStatusID",
                table: "Job",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobResponsibility",
                table: "Job",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDate",
                table: "Job",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitDate",
                table: "Job",
                type: "Date",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobCategory_CategoryID",
                table: "Job",
                column: "CategoryID",
                principalTable: "JobCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_EmploymentStatus_EmploymentStatusID",
                table: "Job",
                column: "EmploymentStatusID",
                principalTable: "EmploymentStatus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobTag_TagID",
                table: "Job",
                column: "TagID",
                principalTable: "JobTag",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobCategory_CategoryID",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_EmploymentStatus_EmploymentStatusID",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobTag_TagID",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_CategoryID",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_EmploymentStatusID",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_TagID",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "EmploymentStatusID",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "JobResponsibility",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "LastDate",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "SubmitDate",
                table: "Job");
        }
    }
}
