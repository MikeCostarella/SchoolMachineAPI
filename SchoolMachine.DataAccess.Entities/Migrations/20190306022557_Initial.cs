using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMachine.DataAccess.Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "schooldata");

            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "district",
                schema: "schooldata",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_district", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "district_school",
                schema: "schooldata",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    district_id = table.Column<Guid>(nullable: false),
                    school_id = table.Column<Guid>(nullable: false),
                    start_date = table.Column<DateTime>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: true),
                    date_created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_district_school", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "school",
                schema: "schooldata",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "school_student",
                schema: "schooldata",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    school_id = table.Column<Guid>(nullable: false),
                    student_id = table.Column<Guid>(nullable: false),
                    grade_level = table.Column<string>(nullable: false),
                    registration_date = table.Column<DateTime>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school_student", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "student",
                schema: "schooldata",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    first_name = table.Column<string>(maxLength: 60, nullable: false),
                    last_name = table.Column<string>(maxLength: 60, nullable: false),
                    middle_name = table.Column<string>(maxLength: 60, nullable: false),
                    birth_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "team",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "team_role",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false),
                    team_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "team_user",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    team_id = table.Column<Guid>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(maxLength: 50, nullable: false),
                    last_name = table.Column<string>(maxLength: 50, nullable: false),
                    user_name = table.Column<string>(maxLength: 50, nullable: false),
                    email_address = table.Column<string>(maxLength: 150, nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    password_hash = table.Column<byte[]>(nullable: true),
                    password_salt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "district",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("c8fc6579-e494-4411-99ab-f5fb439909b5"), "Austintown Local School District" },
                    { new Guid("2b67c814-1219-4305-ae33-1282fffa3a59"), "Weathersfield Local School District" },
                    { new Guid("9104b325-a47a-478b-8d95-c8996b7d687b"), "Warren City School District" },
                    { new Guid("1c161f87-77f9-4675-b21b-1709c1b4929b"), "Trumbull County Educational Service Center" },
                    { new Guid("61deae70-ff2a-484d-95cf-bb62f30f13bf"), "Trumbull Career & Technical Center" },
                    { new Guid("25da421f-f3db-402a-b3f0-036c9a9e3b13"), "Southington Local School District" },
                    { new Guid("8be82cb1-9441-4e8d-b30c-09237dba679a"), "Niles City School District" },
                    { new Guid("d6eac52f-8ef9-48c1-b88c-501fb09e563a"), "Newton Falls Exempted Village School District" },
                    { new Guid("3211bf6c-c485-4980-94e4-8a4bf6dab8d6"), "McDonald Local School District" },
                    { new Guid("5f9ad000-650d-4085-a83b-6182840e305a"), "Maplewood Local School District" },
                    { new Guid("1b90fffb-e650-4926-91b2-35829652cbee"), "Lordstown Local School District" },
                    { new Guid("c9cc0282-7822-4642-9694-6e8746c31035"), "Mathews Local School District" },
                    { new Guid("4897cc7d-42d7-4b5e-a8ba-7de49223b516"), "Lakeview Local School District" },
                    { new Guid("f5558c9d-31eb-40b0-b773-0e42e7da8651"), "Bloomfield-Mespo Local School District" },
                    { new Guid("fec73575-6c3b-47bd-ae3d-2d734dfea065"), "Bristol Local School District" },
                    { new Guid("a347a369-07cb-4bd8-bc3d-97735d70b9cf"), "Liberty Local School District" },
                    { new Guid("16581226-ce81-485a-b9d5-5206faa378cb"), "Champion Local School District" },
                    { new Guid("4b824776-b8ac-42d3-bae6-5ff7f327c820"), "Girard City School District" },
                    { new Guid("ae223b5c-ce69-4d7e-a54b-663e88492b3a"), "Brookfield Local School District" },
                    { new Guid("10ca26bc-b7b8-4098-8f0c-daa5b3fbcb44"), "Hubbard Exempted Village School District" },
                    { new Guid("27b328a9-6da6-47d2-bd6d-5e85f2932eb8"), "Joseph Badger Local School District" },
                    { new Guid("29957dcd-5d63-4b13-a864-200668f64681"), "LaBrae Local School District" },
                    { new Guid("59cdfda0-4c73-4152-8932-c445b6bb2038"), "Howland Local School District" }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "district_school",
                columns: new[] { "id", "date_created", "end_date", "district_id", "school_id", "start_date" },
                values: new object[,]
                {
                    { new Guid("2640aa01-8495-44ce-b5e2-82b5d1a586a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("16581226-ce81-485a-b9d5-5206faa378cb"), new Guid("326543e7-c44d-4fb0-b8a9-5c8a4e39948a"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(1010) },
                    { new Guid("90d74afe-d12c-40dc-b509-f8fe1ed8386f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4b824776-b8ac-42d3-bae6-5ff7f327c820"), new Guid("28947f13-714a-4632-b37f-15e7998ef5b6"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(1724) },
                    { new Guid("59b61399-9f3b-4473-a087-9251b7dabaa4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4b824776-b8ac-42d3-bae6-5ff7f327c820"), new Guid("9c8e0b6b-3e1a-43fd-9f8f-78650c9c2721"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(1701) },
                    { new Guid("6129b260-e73d-46f6-95df-77366307f3d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4b824776-b8ac-42d3-bae6-5ff7f327c820"), new Guid("95b82ac5-e02a-4cf0-9697-d358e8824461"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(1433) },
                    { new Guid("67864c95-8bef-4685-980d-7b11a644b58f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("16581226-ce81-485a-b9d5-5206faa378cb"), new Guid("24df0003-1c8f-4e37-9eff-c15fad7bde9e"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(1039) },
                    { new Guid("f25d7df0-1bf5-42e5-b026-939b3878e3a8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("16581226-ce81-485a-b9d5-5206faa378cb"), new Guid("34b36d71-d675-4aa7-ae4e-7ad1ed927079"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(1025) },
                    { new Guid("304990a5-e81f-4aa6-a5b6-a6b58dbc1018"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ae223b5c-ce69-4d7e-a54b-663e88492b3a"), new Guid("a4a97876-7a5e-4d3c-bf2b-90365ad91933"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(996) },
                    { new Guid("d5ffec95-e5f8-4a67-a84c-5274bb09c9a7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("4b824776-b8ac-42d3-bae6-5ff7f327c820"), new Guid("cd675587-e635-43c1-a687-8d1aac5bc486"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(1061) },
                    { new Guid("4c5f57dc-33a4-4bfc-b60b-0c27cd373f04"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ae223b5c-ce69-4d7e-a54b-663e88492b3a"), new Guid("256455db-2b76-41e7-a100-7b125a54f0ae"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(971) },
                    { new Guid("ae3eac8c-6f1b-410a-a7da-631a6aaeb0ee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("fec73575-6c3b-47bd-ae3d-2d734dfea065"), new Guid("f6f4bbf8-1267-4b56-ac8c-4cbf8f5772d7"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(952) },
                    { new Guid("cccb9a69-7e47-43c3-b58a-95c7e12b840d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("fec73575-6c3b-47bd-ae3d-2d734dfea065"), new Guid("3b54eeb1-45fa-48d9-b0e9-ad821fe0d681"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(931) },
                    { new Guid("ab19bdd6-c18c-456f-bbb1-5fc942f7313c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f5558c9d-31eb-40b0-b773-0e42e7da8651"), new Guid("01567500-88e8-4fa6-8bdc-879886992a58"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(915) },
                    { new Guid("623de670-d068-428d-bb15-7c3b81e650d6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("f5558c9d-31eb-40b0-b773-0e42e7da8651"), new Guid("1607c072-1239-4cb3-8815-a02e066ace85"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(891) },
                    { new Guid("163a8e57-ad99-4ba6-aae7-55037bbff189"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c8fc6579-e494-4411-99ab-f5fb439909b5"), new Guid("d2fee5e8-ba1a-41a7-918f-68e43ee74c1d"), new DateTime(2019, 3, 6, 2, 25, 57, 486, DateTimeKind.Utc).AddTicks(7905) },
                    { new Guid("96749bf1-08b1-49c6-b0e6-e6130340c134"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("ae223b5c-ce69-4d7e-a54b-663e88492b3a"), new Guid("559ebcd9-c37f-4ed5-ab3d-18a0ca104115"), new DateTime(2019, 3, 6, 2, 25, 57, 487, DateTimeKind.Utc).AddTicks(984) }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "school",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("28947f13-714a-4632-b37f-15e7998ef5b6"), "Prospect Elementary" },
                    { new Guid("01567500-88e8-4fa6-8bdc-879886992a58"), "Mesopatamia Elementary" },
                    { new Guid("c35d9c52-798a-41d0-b07b-77a44b92a425"), "Liberty High School" },
                    { new Guid("9c8e0b6b-3e1a-43fd-9f8f-78650c9c2721"), "Girard Junior High School" },
                    { new Guid("95b82ac5-e02a-4cf0-9697-d358e8824461"), "Girard Intermediate" },
                    { new Guid("cd675587-e635-43c1-a687-8d1aac5bc486"), "Girard High School" },
                    { new Guid("24df0003-1c8f-4e37-9eff-c15fad7bde9e"), "Champion Middle School" },
                    { new Guid("326543e7-c44d-4fb0-b8a9-5c8a4e39948a"), "Central Elementary" },
                    { new Guid("0d5c4e84-d8b9-44ab-a230-0fa0dbe77a68"), "Canfield High School" },
                    { new Guid("34b36d71-d675-4aa7-ae4e-7ad1ed927079"), "Champion High School" },
                    { new Guid("559ebcd9-c37f-4ed5-ab3d-18a0ca104115"), "Brookfield Middle School" },
                    { new Guid("256455db-2b76-41e7-a100-7b125a54f0ae"), "Brookfield Elementary School" },
                    { new Guid("f6f4bbf8-1267-4b56-ac8c-4cbf8f5772d7"), "Bristol Middle & High School" },
                    { new Guid("3b54eeb1-45fa-48d9-b0e9-ad821fe0d681"), "Bristol Elementary" },
                    { new Guid("1607c072-1239-4cb3-8815-a02e066ace85"), "Bloomfield Middle/High School" },
                    { new Guid("d2fee5e8-ba1a-41a7-918f-68e43ee74c1d"), "Austintown Fitch High School" },
                    { new Guid("a4a97876-7a5e-4d3c-bf2b-90365ad91933"), "Brookfield High School" }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "school_student",
                columns: new[] { "id", "date_created", "grade_level", "registration_date", "school_id", "student_id" },
                values: new object[,]
                {
                    { new Guid("0ebb7454-7172-431f-baa4-cfa4aa7fc21c"), new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(6126), "9", new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(6127), new Guid("cd675587-e635-43c1-a687-8d1aac5bc486"), new Guid("ccabdf1c-f90f-48fa-badf-3ffc1bcbe86f") },
                    { new Guid("bcbb2ef2-ec31-4859-a527-f919b6a177fe"), new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(6119), "9", new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(6120), new Guid("cd675587-e635-43c1-a687-8d1aac5bc486"), new Guid("d2c9f9da-2cd2-410d-a02b-5519f0319ecd") },
                    { new Guid("6f2d2d82-cb22-4e6e-b2de-c75fc28b933d"), new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(6113), "9", new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(6114), new Guid("cd675587-e635-43c1-a687-8d1aac5bc486"), new Guid("58a0bad2-ce5f-475d-9411-c178dfd2c8a0") },
                    { new Guid("2cda2e27-abbc-47c9-9833-b37bde3fb8b7"), new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(6106), "9", new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(6108), new Guid("1607c072-1239-4cb3-8815-a02e066ace85"), new Guid("d709c06b-1f38-486e-86f1-18618db08644") },
                    { new Guid("3ad06bdc-6141-4ebc-9df5-e73615ec4b91"), new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(6058), "9", new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(6082), new Guid("1607c072-1239-4cb3-8815-a02e066ace85"), new Guid("ace50818-c996-4370-a261-71e054db2aa4") },
                    { new Guid("2c053dea-70be-46ff-b2f0-b123eff04f09"), new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(2097), "9", new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(4157), new Guid("d2fee5e8-ba1a-41a7-918f-68e43ee74c1d"), new Guid("4e069b58-747c-4172-ad76-4509bfa88e52") }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "student",
                columns: new[] { "id", "birth_date", "first_name", "last_name", "middle_name" },
                values: new object[,]
                {
                    { new Guid("d2c9f9da-2cd2-410d-a02b-5519f0319ecd"), new DateTime(2006, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Timkin", "Dudley" },
                    { new Guid("4e069b58-747c-4172-ad76-4509bfa88e52"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Abott", "Alfred" },
                    { new Guid("ace50818-c996-4370-a261-71e054db2aa4"), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann", "Smith", "Grace" },
                    { new Guid("d709c06b-1f38-486e-86f1-18618db08644"), new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Kriter", "Anthony" },
                    { new Guid("58a0bad2-ce5f-475d-9411-c178dfd2c8a0"), new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Carter", "Lynn" },
                    { new Guid("ccabdf1c-f90f-48fa-badf-3ffc1bcbe86f"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abby", "Smart", "Darla" }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "role",
                columns: new[] { "id", "date_created", "description", "is_active", "name" },
                values: new object[] { new Guid("8e8b8103-d18e-46e5-92a2-209474a5579f"), new DateTime(2019, 3, 6, 2, 25, 57, 484, DateTimeKind.Utc).AddTicks(7594), "Total access to all other roles", true, "System Administrator" });

            migrationBuilder.InsertData(
                schema: "security",
                table: "user",
                columns: new[] { "id", "date_created", "email_address", "first_name", "is_active", "last_name", "middle_name", "password_hash", "password_salt", "user_name" },
                values: new object[] { new Guid("73364710-53ce-48d0-bd89-621abd0aedea"), new DateTime(2019, 3, 6, 2, 25, 57, 488, DateTimeKind.Utc).AddTicks(7380), "auser1@email.com", "A", true, "User1", "A", null, null, "auser1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "district",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "district_school",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "school",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "school_student",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "student",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "role",
                schema: "security");

            migrationBuilder.DropTable(
                name: "team",
                schema: "security");

            migrationBuilder.DropTable(
                name: "team_role",
                schema: "security");

            migrationBuilder.DropTable(
                name: "team_user",
                schema: "security");

            migrationBuilder.DropTable(
                name: "user",
                schema: "security");

            migrationBuilder.DropTable(
                name: "user_role",
                schema: "security");
        }
    }
}
