using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingDay.Data.Migrations
{
    public partial class NameFieldsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerName",
                table: "Feedbacks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MentorName",
                table: "Feedbacks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerName",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "MentorName",
                table: "Feedbacks");
        }
    }
}
