using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using TrainingDay.Models;

namespace TrainingDay.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accomplishment = table.Column<int>(nullable: false),
                    ApplicationUserID = table.Column<int>(nullable: false),
                    Confidence = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    Focus = table.Column<string>(nullable: true),
                    ILikeNotes = table.Column<string>(nullable: true),
                    IWishNotes = table.Column<string>(nullable: true),
                    ManagerNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.ID);
                });

            migrationBuilder.AddColumn<int>(
                name: "ManagerID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MentorID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "Role",
            //    table: "AspNetUsers",
            //    nullable: false,
            //    defaultValue: Role.Learner);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MentorID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Feedbacks");
        }
    }
}
