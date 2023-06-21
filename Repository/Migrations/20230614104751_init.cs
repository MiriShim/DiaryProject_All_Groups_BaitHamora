using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateTable(
        //        name: "Schools",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "integer", nullable: false)
        //                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
        //            Name = table.Column<string>(type: "text", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_dbo.Schools", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Units",
        //        columns: table => new
        //        {
        //            UnitId = table.Column<int>(type: "integer", nullable: false)
        //                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
        //            UnitName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
        //            Comments = table.Column<string>(type: "text", nullable: true),
        //            ParentUnitId = table.Column<int>(type: "integer", nullable: true),
        //            EstimatedHours = table.Column<int>(type: "integer", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_dbo.Units", x => x.UnitId);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Users",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "integer", nullable: false)
        //                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
        //            FirstName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
        //            LastName = table.Column<string>(type: "text", nullable: true),
        //            Password = table.Column<string>(type: "text", nullable: true),
        //            Email = table.Column<string>(type: "text", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Users", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Groups",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "integer", nullable: false)
        //                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
        //            GroupName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
        //            SchoolId = table.Column<int>(type: "integer", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_dbo.Groups", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_dbo.Groups_dbo.Schools_SchoolId",
        //                column: x => x.SchoolId,
        //                principalTable: "Schools",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Teachers",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "integer", nullable: false),
        //            Specialization = table.Column<string>(type: "text", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Teachers", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Teachers_Users_Id",
        //                column: x => x.Id,
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "LessonsTbl",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "integer", nullable: false)
        //                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
        //            DateOfLesson = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
        //            Group_Id = table.Column<int>(type: "integer", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_dbo.Lessons", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_dbo.Lessons_dbo.Groups_Group_Id",
        //                column: x => x.Group_Id,
        //                principalTable: "Groups",
        //                principalColumn: "Id");
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Students",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "integer", nullable: false),
        //            GroupId = table.Column<int>(type: "integer", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Students", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Students_Groups_GroupId",
        //                column: x => x.GroupId,
        //                principalTable: "Groups",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Students_Users_Id",
        //                column: x => x.Id,
        //                principalTable: "Users",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "UnitLessons",
        //        columns: table => new
        //        {
        //            Unit_Id = table.Column<int>(type: "integer", nullable: false),
        //            Lesson_Id = table.Column<int>(type: "integer", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_dbo.UnitLessons", x => new { x.Unit_Id, x.Lesson_Id });
        //            table.ForeignKey(
        //                name: "FK_dbo.UnitLessons_dbo.Lessons_Lesson_Id",
        //                column: x => x.Lesson_Id,
        //                principalTable: "LessonsTbl",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_dbo.UnitLessons_dbo.Units_Unit_Id",
        //                column: x => x.Unit_Id,
        //                principalTable: "Units",
        //                principalColumn: "UnitId",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "StudentExistances",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "integer", nullable: false)
        //                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
        //            StudentId = table.Column<int>(type: "integer", nullable: false),
        //            LessonId = table.Column<int>(type: "integer", nullable: false),
        //            ExistanceType = table.Column<int>(type: "integer", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_dbo.StudentExistances", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_dbo.StudentExistances_dbo.Lessons_LessonId",
        //                column: x => x.LessonId,
        //                principalTable: "LessonsTbl",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_dbo.StudentExistances_dbo.Students_StudentId",
        //                column: x => x.StudentId,
        //                principalTable: "Students",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_SchoolId",
        //        table: "Groups",
        //        column: "SchoolId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Group_Id",
        //        table: "LessonsTbl",
        //        column: "Group_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_LessonId",
        //        table: "StudentExistances",
        //        column: "LessonId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_StudentId",
        //        table: "StudentExistances",
        //        column: "StudentId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Students_GroupId",
        //        table: "Students",
        //        column: "GroupId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Lesson_Id",
        //        table: "UnitLessons",
        //        column: "Lesson_Id");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Unit_Id",
        //        table: "UnitLessons",
        //        column: "Unit_Id");
        //}

        ///// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "StudentExistances");

        //    migrationBuilder.DropTable(
        //        name: "Teachers");

        //    migrationBuilder.DropTable(
        //        name: "UnitLessons");

        //    migrationBuilder.DropTable(
        //        name: "Students");

        //    migrationBuilder.DropTable(
        //        name: "LessonsTbl");

        //    migrationBuilder.DropTable(
        //        name: "Units");

        //    migrationBuilder.DropTable(
        //        name: "Users");

        //    migrationBuilder.DropTable(
        //        name: "Groups");

        //    migrationBuilder.DropTable(
        //        name: "Schools");
       }
    }
}
