using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMachine.DataAccess.Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SchoolData");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "SchoolDistricts",
                schema: "SchoolData",
                columns: table => new
                {
                    SchoolDistrictId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolDistricts", x => x.SchoolDistrictId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolDistrictSchools",
                schema: "SchoolData",
                columns: table => new
                {
                    SchoolDistrictSchoolId = table.Column<Guid>(nullable: false),
                    SchoolDistrictId = table.Column<Guid>(nullable: false),
                    SchoolId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolDistrictSchools", x => x.SchoolDistrictSchoolId);
                });

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
                table: "SchoolDistrictSchools",
                columns: new[] { "SchoolDistrictSchoolId", "DateCreated", "EndDate", "SchoolDistrictId", "SchoolId", "StartDate" },
                values: new object[,]
                {
                    { new Guid("021ceed1-3cf1-42ec-bf51-bab34b1033d5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("603fdca0-91b4-4874-bef3-dd0791c0fa08"), new Guid("b208d6f0-18fa-4d55-8506-51f2736fc17a"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8386) },
                    { new Guid("a0038fde-9349-4f01-b128-0197d2c7c597"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("5c9cebdb-e269-4f86-9402-3528bf077152"), new Guid("e5629354-5b2f-4fce-adb3-801bb643a70f"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(6971) },
                    { new Guid("a8f3502a-1b5d-4a1e-bd3f-648cce57ded1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("27586934-ac84-4ba2-8fc1-c879c059c9dc"), new Guid("52cd27d7-50d4-4b58-b23f-eaf2b99328df"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8232) },
                    { new Guid("2eed2da9-ca85-41cd-b94f-b26cff0b6600"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("27586934-ac84-4ba2-8fc1-c879c059c9dc"), new Guid("f444b8e7-9b7a-489e-91db-3f3aedba3929"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8244) },
                    { new Guid("260324e0-0a56-40ef-ae5d-0288445319f0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("32339fb9-6cf5-4bd5-b6f8-015cf10d0d93"), new Guid("2e163b76-966e-4e5d-8ab6-267bd605055c"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8253) },
                    { new Guid("c05e7ee6-249b-4aa9-a0ff-9585f96fc727"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("32339fb9-6cf5-4bd5-b6f8-015cf10d0d93"), new Guid("076bd0ad-b1cb-4d1c-b32f-d3fadd68c1d4"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8312) },
                    { new Guid("0a0d40f7-64b6-49cd-a2a0-077c7b721a76"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2876ce59-30b2-44c9-91de-996bd2fb1bb4"), new Guid("65e5768e-e78d-478c-b1cd-82ff52d81665"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8337) },
                    { new Guid("941e7df7-05e2-40dc-b6e1-b271082d0480"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2876ce59-30b2-44c9-91de-996bd2fb1bb4"), new Guid("1d33877a-cfe0-47ab-89fa-3313b6e982de"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8328) },
                    { new Guid("8e76bc85-96b6-45f3-9efb-7ec556802716"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("44279467-a91b-43ba-979c-96b11723b286"), new Guid("9eb93fa8-294c-4f94-8f43-ec0b89302a14"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8358) },
                    { new Guid("666791ea-dd63-4753-81ab-034da14b767f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("44279467-a91b-43ba-979c-96b11723b286"), new Guid("28134d37-13cf-4632-8d86-8be74621eeaa"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8368) },
                    { new Guid("1f0a0ddc-a837-4ebd-993d-dc84ac6e7a44"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("44279467-a91b-43ba-979c-96b11723b286"), new Guid("4d8e87a1-e0a4-4770-a01f-401c111fd460"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8377) },
                    { new Guid("c8448510-f518-4f21-8534-dbf1301aed69"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("603fdca0-91b4-4874-bef3-dd0791c0fa08"), new Guid("9656faf6-f133-4ad9-ae97-48d1937f73c0"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8394) },
                    { new Guid("f6f4db6b-1da8-425c-919a-7a7e2dbd1035"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("603fdca0-91b4-4874-bef3-dd0791c0fa08"), new Guid("54f53b19-8eb0-46ac-8d09-f1ded3f3b6f7"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8405) },
                    { new Guid("39466886-488b-4675-aa17-3c20c0972628"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("603fdca0-91b4-4874-bef3-dd0791c0fa08"), new Guid("27f0980c-c946-47a3-b61b-edc2e88b6f7b"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8413) },
                    { new Guid("354f67d3-1327-4dca-8d12-a91c192bfb8f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("2876ce59-30b2-44c9-91de-996bd2fb1bb4"), new Guid("d97aec4f-0188-4bf0-b500-25ea0379e368"), new DateTime(2019, 3, 5, 22, 47, 25, 640, DateTimeKind.Utc).AddTicks(8349) }
                });

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "SchoolDistricts",
                columns: new[] { "SchoolDistrictId", "Name" },
                values: new object[,]
                {
                    { new Guid("8c12eda9-9d01-43ed-b939-7d6496d0b290"), "Trumbull County Educational Service Center" },
                    { new Guid("00d3eec9-fdb6-435a-b29c-1204afc27f8f"), "Weathersfield Local School District" },
                    { new Guid("b2c12a80-af41-4625-9305-64db7961f717"), "Warren City School District" },
                    { new Guid("f0c7c5ea-b8ba-4749-b22f-3c688f6a5f6b"), "Trumbull Career & Technical Center" },
                    { new Guid("5c9cebdb-e269-4f86-9402-3528bf077152"), "Austintown Local School District" },
                    { new Guid("ae12af4d-f465-453a-b60c-0634b60e7c68"), "Niles City School District" },
                    { new Guid("27586934-ac84-4ba2-8fc1-c879c059c9dc"), "Bloomfield-Mespo Local School District" },
                    { new Guid("32339fb9-6cf5-4bd5-b6f8-015cf10d0d93"), "Bristol Local School District" },
                    { new Guid("2876ce59-30b2-44c9-91de-996bd2fb1bb4"), "Brookfield Local School District" },
                    { new Guid("d5c9a6f0-830b-45e8-bb9d-bfea2ae0c1f6"), "Southington Local School District" },
                    { new Guid("44279467-a91b-43ba-979c-96b11723b286"), "Champion Local School District" },
                    { new Guid("603fdca0-91b4-4874-bef3-dd0791c0fa08"), "Girard City School District" },
                    { new Guid("60cc072e-c8e6-452c-93c6-880d11650036"), "Howland Local School District" },
                    { new Guid("39decac8-df26-4908-93ec-2ebe3a9aa303"), "Hubbard Exempted Village School District" },
                    { new Guid("d282ef1c-4225-46bb-ac2f-2a473d186224"), "Joseph Badger Local School District" },
                    { new Guid("581ace3d-2137-45e3-9bbe-d144606a7840"), "LaBrae Local School District" },
                    { new Guid("a8bd5091-a38c-4ac7-b069-a830f473dd38"), "Lakeview Local School District" },
                    { new Guid("691d4ae1-5156-492f-86ae-e0d276b0be98"), "Liberty Local School District" },
                    { new Guid("af4fa26f-28f6-4573-83a6-5fae83c9ff89"), "Lordstown Local School District" },
                    { new Guid("1a2b28b5-003a-4af1-bffa-247968df6228"), "Maplewood Local School District" },
                    { new Guid("67a54fa6-0613-4457-a74b-e5decf02f134"), "Mathews Local School District" },
                    { new Guid("3613fce1-1bc6-4883-97e9-4a723105c547"), "McDonald Local School District" },
                    { new Guid("12814fe4-4dd2-4924-928f-c5a5b7b564d4"), "Newton Falls Exempted Village School District" }
                });

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "SchoolStudents",
                columns: new[] { "SchoolStudentId", "DateCreated", "GradeLevel", "RegistrationDate", "SchoolId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("2b0514f3-2148-46b4-88f1-558066b3b158"), new DateTime(2019, 3, 5, 22, 47, 25, 641, DateTimeKind.Utc).AddTicks(8712), "9", new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(470), new Guid("e5629354-5b2f-4fce-adb3-801bb643a70f"), new Guid("c60fb528-5c00-4724-9eaf-5800a91d72a4") },
                    { new Guid("250809a1-f0b8-4ab5-b751-6094db3b39c6"), new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(2986), "9", new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(3000), new Guid("52cd27d7-50d4-4b58-b23f-eaf2b99328df"), new Guid("07b2ec10-397f-448f-b0fc-d73b29432659") },
                    { new Guid("59d0ed87-ed70-4ef2-863f-7a44b23b0632"), new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(3046), "9", new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(3047), new Guid("b208d6f0-18fa-4d55-8506-51f2736fc17a"), new Guid("6ae50ec6-12dd-48a8-9602-a796cd8f0d5f") },
                    { new Guid("d4a544a5-1a3c-4bf8-85cd-ccef44410a5c"), new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(3031), "9", new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(3032), new Guid("b208d6f0-18fa-4d55-8506-51f2736fc17a"), new Guid("ea34cac9-5697-42ac-bf71-f56fde284088") },
                    { new Guid("78effc37-c64e-40b9-9ffe-a751240183e4"), new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(3038), "9", new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(3039), new Guid("b208d6f0-18fa-4d55-8506-51f2736fc17a"), new Guid("322ded75-d390-4889-bc51-0fc6958fe20c") },
                    { new Guid("f1060e6e-33fc-458e-9bef-6351c3aef7cd"), new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(3025), "9", new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(3026), new Guid("52cd27d7-50d4-4b58-b23f-eaf2b99328df"), new Guid("11a9c60b-21ed-49e9-b325-ca1a8724075d") }
                });

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "Schools",
                columns: new[] { "SchoolId", "Name" },
                values: new object[,]
                {
                    { new Guid("27f0980c-c946-47a3-b61b-edc2e88b6f7b"), "Prospect Elementary" },
                    { new Guid("9656faf6-f133-4ad9-ae97-48d1937f73c0"), "Girard Intermediate" },
                    { new Guid("f444b8e7-9b7a-489e-91db-3f3aedba3929"), "Mesopatamia Elementary" },
                    { new Guid("0c5977dd-0862-40d7-bbf8-8b24d80d206b"), "Liberty High School" },
                    { new Guid("54f53b19-8eb0-46ac-8d09-f1ded3f3b6f7"), "Girard Junior High School" },
                    { new Guid("b208d6f0-18fa-4d55-8506-51f2736fc17a"), "Girard High School" },
                    { new Guid("1d33877a-cfe0-47ab-89fa-3313b6e982de"), "Brookfield Elementary School" },
                    { new Guid("28134d37-13cf-4632-8d86-8be74621eeaa"), "Champion High School" },
                    { new Guid("4d8e87a1-e0a4-4770-a01f-401c111fd460"), "Champion Middle School" },
                    { new Guid("52cd27d7-50d4-4b58-b23f-eaf2b99328df"), "Bloomfield Middle/High School" },
                    { new Guid("2e163b76-966e-4e5d-8ab6-267bd605055c"), "Bristol Elementary" },
                    { new Guid("076bd0ad-b1cb-4d1c-b32f-d3fadd68c1d4"), "Bristol Middle & High School" },
                    { new Guid("e5629354-5b2f-4fce-adb3-801bb643a70f"), "Austintown Fitch High School" },
                    { new Guid("d97aec4f-0188-4bf0-b500-25ea0379e368"), "Brookfield High School" },
                    { new Guid("807bad9c-f86f-4e27-aeab-b8f4767c9866"), "Canfield High School" },
                    { new Guid("9eb93fa8-294c-4f94-8f43-ec0b89302a14"), "Central Elementary" },
                    { new Guid("65e5768e-e78d-478c-b1cd-82ff52d81665"), "Brookfield Middle School" }
                });

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("322ded75-d390-4889-bc51-0fc6958fe20c"), new DateTime(2006, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Timkin", "Dudley" },
                    { new Guid("c60fb528-5c00-4724-9eaf-5800a91d72a4"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Abott", "Alfred" },
                    { new Guid("07b2ec10-397f-448f-b0fc-d73b29432659"), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann", "Smith", "Grace" },
                    { new Guid("11a9c60b-21ed-49e9-b325-ca1a8724075d"), new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Kriter", "Anthony" },
                    { new Guid("ea34cac9-5697-42ac-bf71-f56fde284088"), new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Carter", "Lynn" },
                    { new Guid("6ae50ec6-12dd-48a8-9602-a796cd8f0d5f"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abby", "Smart", "Darla" }
                });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Roles",
                columns: new[] { "RoleId", "DateCreated", "Description", "IsActive", "Name" },
                values: new object[] { new Guid("d517d20f-12f0-432c-af9d-3eafae7a8326"), new DateTime(2019, 3, 5, 22, 47, 25, 638, DateTimeKind.Utc).AddTicks(6265), "Total access to all other roles", true, "System Administrator" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "Users",
                columns: new[] { "UserId", "DateCreated", "EmailAddress", "FirstName", "IsActive", "LastName", "MiddleName", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[] { new Guid("8a821d4e-e70c-4cfd-8c2e-c388aa17ea9a"), new DateTime(2019, 3, 5, 22, 47, 25, 642, DateTimeKind.Utc).AddTicks(4668), "auser1@email.com", "A", true, "User1", "A", null, null, "auser1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolDistricts",
                schema: "SchoolData");

            migrationBuilder.DropTable(
                name: "SchoolDistrictSchools",
                schema: "SchoolData");

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
