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
                table: "SchoolStudents",
                columns: new[] { "SchoolStudentId", "DateCreated", "GradeLevel", "RegistrationDate", "SchoolId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("ca46cb70-34e7-4f5a-9043-b9fd7ccabc2e"), new DateTime(2019, 3, 3, 15, 55, 41, 381, DateTimeKind.Utc).AddTicks(2751), "9", new DateTime(2019, 3, 3, 15, 55, 41, 381, DateTimeKind.Utc).AddTicks(4997), new Guid("6b77d52b-d051-4a0a-8887-5a9ab8cc5135"), new Guid("8eb4056f-7dc0-46cf-ba91-a7a45f6c2e72") },
                    { new Guid("c8765f5d-ab61-4568-b636-7a5467643502"), new DateTime(2019, 3, 3, 15, 55, 41, 381, DateTimeKind.Utc).AddTicks(7414), "9", new DateTime(2019, 3, 3, 15, 55, 41, 381, DateTimeKind.Utc).AddTicks(7429), new Guid("e48eaa8b-ceee-4072-b980-c58fad81dbe2"), new Guid("194bb537-38ea-4bd3-901b-2eda9ff1e2ae") },
                    { new Guid("c446c0af-baf7-4cc3-955f-4d3824e852d5"), new DateTime(2019, 3, 3, 15, 55, 41, 381, DateTimeKind.Utc).AddTicks(7445), "9", new DateTime(2019, 3, 3, 15, 55, 41, 381, DateTimeKind.Utc).AddTicks(7447), new Guid("e48eaa8b-ceee-4072-b980-c58fad81dbe2"), new Guid("039545ed-ef84-4e4b-a6fa-c96566fdbb9e") }
                });

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "Schools",
                columns: new[] { "SchoolId", "Name" },
                values: new object[,]
                {
                    { new Guid("6b77d52b-d051-4a0a-8887-5a9ab8cc5135"), "Austintown Fitch High School" },
                    { new Guid("e48eaa8b-ceee-4072-b980-c58fad81dbe2"), "Canfield High School" },
                    { new Guid("009a3c04-aec4-4ac6-ae28-dda69ea49d99"), "Girard High School" },
                    { new Guid("a4cccd64-2b80-417a-ab3f-471a677a6459"), "Liberty High School" }
                });

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("8eb4056f-7dc0-46cf-ba91-a7a45f6c2e72"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Abott", "Alfred" },
                    { new Guid("194bb537-38ea-4bd3-901b-2eda9ff1e2ae"), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann", "Smith", "Grace" },
                    { new Guid("039545ed-ef84-4e4b-a6fa-c96566fdbb9e"), new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Kriter", "Anthony" },
                    { new Guid("eacced0f-57bc-4d3c-a646-b469e4792ead"), new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Carter", "Lynn" },
                    { new Guid("95ec2b04-9ddb-46c1-81e9-be1f4c2ea665"), new DateTime(2006, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Timkin", "Dudley" },
                    { new Guid("049579e8-6b69-4a02-a41c-4209af03fa53"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abby", "Smart", "Darla" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Roles",
                columns: new[] { "RoleId", "DateCreated", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("a2e6f3ab-bfb1-4521-b061-6774f4be0008"), new DateTime(2019, 3, 3, 15, 55, 41, 380, DateTimeKind.Utc).AddTicks(2612), "Total access to all other roles", true, "System Administrator" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Users",
                columns: new[] { "UserId", "DateCreated", "EmailAddress", "FirstName", "IsActive", "LastName", "MiddleName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("e0033060-e8f3-40a4-acc0-813ea7adadd0"), new DateTime(2019, 3, 3, 15, 55, 41, 381, DateTimeKind.Utc).AddTicks(8652), "auser1@email.com", "A", true, "User1", "A", null, null, "auser1" });
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
