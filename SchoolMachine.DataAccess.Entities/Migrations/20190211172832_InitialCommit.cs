using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMachine.DataAccess.Entities.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.EnsureSchema(
                name: "SchoolData");

            migrationBuilder.CreateTable(
                name: "Schools",
                schema: "SchoolData",
                columns: table => new
                {
                    SchoolId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolStudents",
                schema: "SchoolData",
                columns: table => new
                {
                    SchoolStudentId = table.Column<Guid>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
                    GradeLevel = table.Column<string>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolStudents", x => x.SchoolStudentId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "SchoolData",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 60, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Security",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TeamRoles",
                schema: "Security",
                columns: table => new
                {
                    TeamRoleId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRoles", x => x.TeamRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                schema: "Security",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "TeamUsers",
                schema: "Security",
                columns: table => new
                {
                    TeamUserId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamUsers", x => x.TeamUserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Security",
                columns: table => new
                {
                    UserRoleId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 150, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "Schools",
                columns: new[] { "SchoolId", "Name" },
                values: new object[,]
                {
                    { new Guid("eb9cd9f6-b98f-4ca0-a895-50c5270b2847"), "Girard High School" },
                    { new Guid("21042f07-0295-4be3-8a42-b268a85c824c"), "Liberty High School" }
                });

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("026e3e0d-b851-45cd-abc6-f8e31c5849e0"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Abott", "Alfred" },
                    { new Guid("6f08ff4c-f9c3-485a-bb9c-2063b70cb6b6"), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann", "Smith", "Grace" },
                    { new Guid("600f8d50-765b-4d9f-ac4e-41636cf92fa9"), new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Kriter", "Anthony" },
                    { new Guid("249743a4-208e-41fe-8d95-18eab906fb41"), new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Carter", "Lynn" },
                    { new Guid("602d3eb8-2d1a-4849-abab-7b8a4c5581b2"), new DateTime(2006, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Timkin", "Dudley" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Roles",
                columns: new[] { "RoleId", "DateCreated", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("5771357e-8085-4dfb-a8ca-b9e8b4468f54"), new DateTime(2019, 2, 11, 17, 28, 32, 454, DateTimeKind.Utc).AddTicks(1619), "Total access to all other roles", true, "System Administrator" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Users",
                columns: new[] { "UserId", "DateCreated", "EmailAddress", "FirstName", "IsActive", "LastName", "MiddleName", "UserName" },
                values: new object[] { new Guid("4b53cd37-935b-492d-a16f-175cb51ef2ad"), new DateTime(2019, 2, 11, 17, 28, 32, 455, DateTimeKind.Utc).AddTicks(2514), "auser1@email.com", "A", true, "User1", "A", "auser1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schools",
                schema: "SchoolData");

            migrationBuilder.DropTable(
                name: "SchoolStudents",
                schema: "SchoolData");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "SchoolData");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "TeamRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Teams",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "TeamUsers",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Security");
        }
    }
}
