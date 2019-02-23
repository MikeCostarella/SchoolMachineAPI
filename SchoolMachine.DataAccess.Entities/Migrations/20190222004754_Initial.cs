using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMachine.DataAccess.Entities.Migrations
{
    public partial class Initial : Migration
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
                    IsActive = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
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
                    { new Guid("d70fd257-92c8-4ccd-8be8-0e714bd73c1b"), "Girard High School" },
                    { new Guid("78dfb0f0-8eee-44ad-a39f-0b39a2321e99"), "Liberty High School" }
                });

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("f651b400-280e-490b-bbe8-a910bb76c834"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Abott", "Alfred" },
                    { new Guid("db087aaa-020f-4f51-8667-aab99fa034bb"), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann", "Smith", "Grace" },
                    { new Guid("bc91ae8f-b26d-45da-82d4-1cde3f760488"), new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Kriter", "Anthony" },
                    { new Guid("60bf103e-3b3d-4f26-8fcc-420d9f3f6134"), new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Carter", "Lynn" },
                    { new Guid("b0a877e7-d97b-4f30-b630-ca3308549b69"), new DateTime(2006, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Timkin", "Dudley" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Roles",
                columns: new[] { "RoleId", "DateCreated", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("4744bebe-3539-4cba-935a-2caabe0e19b5"), new DateTime(2019, 2, 22, 0, 47, 54, 495, DateTimeKind.Utc).AddTicks(4134), "Total access to all other roles", true, "System Administrator" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Users",
                columns: new[] { "UserId", "DateCreated", "EmailAddress", "FirstName", "IsActive", "LastName", "MiddleName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("c7cfac53-dcf9-4af8-b5c4-6588f6dfffe3"), new DateTime(2019, 2, 22, 0, 47, 54, 496, DateTimeKind.Utc).AddTicks(6547), "auser1@email.com", "A", true, "User1", "A", null, null, "auser1" });
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
