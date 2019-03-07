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
                    table.ForeignKey(
                        name: "FK_district_school_district_district_id",
                        column: x => x.district_id,
                        principalSchema: "schooldata",
                        principalTable: "district",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_district_school_school_school_id",
                        column: x => x.school_id,
                        principalSchema: "schooldata",
                        principalTable: "school",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_school_student_school_school_id",
                        column: x => x.school_id,
                        principalSchema: "schooldata",
                        principalTable: "school",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_school_student_student_student_id",
                        column: x => x.student_id,
                        principalSchema: "schooldata",
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_team_role_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "security",
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_team_role_team_team_id",
                        column: x => x.team_id,
                        principalSchema: "security",
                        principalTable: "team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_team_user_team_team_id",
                        column: x => x.team_id,
                        principalSchema: "security",
                        principalTable: "team",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_team_user_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "security",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_user_role_role_role_id",
                        column: x => x.role_id,
                        principalSchema: "security",
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "security",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "district",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("ac112e56-9409-422e-8e5d-2bc9ac5ab05b"), "Austintown Local School District" },
                    { new Guid("f61479af-1ef2-451c-a624-44149eb85db6"), "Mathews Local School District" },
                    { new Guid("9f2df305-1d70-4c82-9e0f-8498ddeca2df"), "McDonald Local School District" },
                    { new Guid("b3df86d3-1345-40d0-9edc-ecb978ff9356"), "Newton Falls Exempted Village School District" },
                    { new Guid("9aca2523-779d-47f8-a1df-3c5db0b5b7a4"), "Niles City School District" },
                    { new Guid("37892e5e-f6b8-4dd6-abd6-a61c84923002"), "Sebring Local School District" },
                    { new Guid("6fb4e100-a0db-495c-9322-5acea50bbadc"), "Southington Local School District" },
                    { new Guid("d500c683-6b0d-405a-a433-09d8006753a8"), "South Range Local School District" },
                    { new Guid("936d451e-800d-4149-bc69-347dcb2b817a"), "Springfield Local School District" },
                    { new Guid("2836f926-6fdb-441b-8bef-b07092e2b2e6"), "Struthers City School District" },
                    { new Guid("689be0e3-d639-46d7-803d-78322debf360"), "Trumbull Career & Technical Center" },
                    { new Guid("f26c3c96-42cc-4990-96e2-e61a586cee5f"), "Trumbull County Educational Service Center" },
                    { new Guid("c1c05dc2-bff7-4f3f-a779-be43c205a24f"), "Warren City School District" },
                    { new Guid("627708e4-3165-4381-9092-92c735bf119e"), "Weathersfield Local School District" },
                    { new Guid("4bb93135-e5eb-4ead-b6f9-f17a76eccea8"), "Western Reserve Local School District" },
                    { new Guid("b93c127b-6944-436f-9449-5603d777cc2a"), "Youngstown City School District" },
                    { new Guid("da9f6314-5dad-4442-a919-088612be16de"), "Maplewood Local School District" },
                    { new Guid("31777f11-332d-4083-a01c-4e4fdaa03d48"), "Lowellville Local School District" },
                    { new Guid("0daaa034-31dd-4b03-adbc-ba3cd6d7e5b1"), "West Branch Local School District" },
                    { new Guid("a502223e-927f-4d66-a811-0197ea69c8e4"), "Liberty Local School District" },
                    { new Guid("9c74ed78-e932-4d4f-bdd8-c39fcf172995"), "Bloomfield-Mespo Local School District" },
                    { new Guid("98c8b304-ec0a-42cc-9842-57624fe6e3a8"), "Boardman Local School District" },
                    { new Guid("23abe574-14d1-4b99-8c75-977be6c0bce8"), "Bristol Local School District" },
                    { new Guid("3648ed8f-f71c-4b97-bebc-75f4ba32c7d9"), "Brookfield Local School District" },
                    { new Guid("568baef0-8f0c-454e-adb8-858857a1ce57"), "Canfield Local School District" },
                    { new Guid("0a7b30b9-844d-4f40-bc05-7228cccc1ee9"), "Lordstown Local School District" },
                    { new Guid("6f6c792e-eda8-44b4-acc3-7cafa6753700"), "Girard City School District" },
                    { new Guid("0f4aac48-2179-4e3e-8036-71157353cfe8"), "Champion Local School District" },
                    { new Guid("080e36da-d385-4134-9cb2-37828dbbf64f"), "Hubbard Exempted Village School District" },
                    { new Guid("2096d914-933d-4794-9cf4-d0d589a6fc60"), "Howland Local School District" },
                    { new Guid("0be7b00a-c3eb-4660-bdac-789284fed347"), "Hubbard Exempted Village School District" },
                    { new Guid("255945ec-8f13-44cc-b3e0-5e6971bb6819"), "Jackson-Milton Local School District" },
                    { new Guid("278dd3a4-d13f-4d5d-b521-8d2d300bde5d"), "Joseph Badger Local School District" },
                    { new Guid("5bdfb4a0-ebe7-4a9a-89d6-db4abe1ca2f2"), "LaBrae Local School District" },
                    { new Guid("462dd80c-80ba-4772-b9db-725b37761e63"), "Lakeview Local School District" },
                    { new Guid("06a9e290-17f6-44ac-b879-2c92c29cc7c5"), "Howland Local School District" }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "school",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("f226e0ad-af8d-4dc7-bc71-517dfd3752a5"), "Girard Junior High School" },
                    { new Guid("d1004426-cbe3-4b82-bbe5-ff054065f290"), "Glen Primary School" },
                    { new Guid("552c37e8-d58e-4bd9-bbe5-84904b93c1b4"), "H.C. Mines Elementary" },
                    { new Guid("f769f34d-81c0-4f72-9f1e-7604f2754dce"), "Howland High School" },
                    { new Guid("149fc309-51e7-4fd0-bc28-076373e400f0"), "Springs Primary School" },
                    { new Guid("c868b914-de91-4fe0-b2df-acc76573094a"), "Liberty High School" },
                    { new Guid("cbc08341-7a0d-4acf-a5e7-6960c68b813b"), "Mesopatamia Elementary" },
                    { new Guid("11671033-1aa8-4ac8-9ed0-2a0a4878047a"), "North Road Intermediate" },
                    { new Guid("b17919e5-9077-4379-a7c7-7d79a93a6179"), "Prospect Elementary" },
                    { new Guid("81aa83c9-a7b5-4993-b896-a017ef4e64a9"), "Girard Intermediate" },
                    { new Guid("b996f4c2-58ee-49e2-b9b8-ab185c616222"), "Howland Middle School" },
                    { new Guid("b7c65e6a-5581-4ce9-b8d6-dddf4aff0552"), "Girard High School" },
                    { new Guid("1d580cde-3263-493f-be4b-760de01713e6"), "Brookfield Elementary School" },
                    { new Guid("e6f5652d-30c9-4e5d-975c-f63dbe97ed7b"), "Champion High School" },
                    { new Guid("4c402f06-7e83-454d-9c57-286de97816f9"), "Champion Middle School" },
                    { new Guid("add594cf-b745-485a-ac80-54a6dc50d5d1"), "Bloomfield Middle/High School" },
                    { new Guid("f95acc0c-78c7-4a2a-8dcb-da5a40ac1041"), "Bristol Elementary" },
                    { new Guid("6c9536d4-a77d-450e-aeef-8f3d1936d59f"), "Bristol Middle & High School" },
                    { new Guid("e2bf738c-c3e1-4b3f-bb5e-e9b39916a101"), "Austintown Fitch High School" },
                    { new Guid("4b8bee85-3673-4ee6-8f2e-f5535f5f04ca"), "Brookfield High School" },
                    { new Guid("b821dc6f-0c54-43c4-beaf-823df2afedab"), "Canfield High School" },
                    { new Guid("eb5f060c-6df2-4eb2-b9a5-5acf85b02088"), "Central Elementary" },
                    { new Guid("012bc14a-396e-4074-b1a3-1b4d027fd53e"), "Brookfield Middle School" }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "student",
                columns: new[] { "id", "birth_date", "first_name", "last_name", "middle_name" },
                values: new object[,]
                {
                    { new Guid("13bc301d-929a-43c8-893f-a939abbbf145"), new DateTime(2006, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Timkin", "Dudley" },
                    { new Guid("1b254eff-dc80-4908-a0f9-d1e4ea092e42"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Abott", "Alfred" },
                    { new Guid("93299e96-c240-4c64-89c5-3734edd8e0ce"), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann", "Smith", "Grace" },
                    { new Guid("cc051008-6703-4e00-b096-88f70e7309eb"), new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Kriter", "Anthony" },
                    { new Guid("1010d7a6-a45f-410b-9a39-9eb01123de24"), new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Carter", "Lynn" },
                    { new Guid("975199a3-a6fd-487c-8687-2248c1989b0b"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abby", "Smart", "Darla" }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "role",
                columns: new[] { "id", "date_created", "description", "is_active", "name" },
                values: new object[] { new Guid("4b8acc42-896b-4637-83b8-e153d647a974"), new DateTime(2019, 3, 7, 0, 44, 49, 564, DateTimeKind.Utc).AddTicks(9373), "Total access to all other roles", true, "System Administrator" });

            migrationBuilder.InsertData(
                schema: "security",
                table: "user",
                columns: new[] { "id", "date_created", "email_address", "first_name", "is_active", "last_name", "middle_name", "password_hash", "password_salt", "user_name" },
                values: new object[] { new Guid("2f09d6c4-424c-4333-be6c-d0510e3bd51a"), new DateTime(2019, 3, 7, 0, 44, 49, 568, DateTimeKind.Utc).AddTicks(124), "auser1@email.com", "A", true, "User1", "A", null, null, "auser1" });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "district_school",
                columns: new[] { "id", "date_created", "district_id", "end_date", "school_id", "start_date" },
                values: new object[,]
                {
                    { new Guid("d04ea3d4-759b-4127-a748-ccbe1d1225e6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ac112e56-9409-422e-8e5d-2bc9ac5ab05b"), null, new Guid("e2bf738c-c3e1-4b3f-bb5e-e9b39916a101"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(6905) },
                    { new Guid("0454cb94-67d9-4595-ba1b-ef74c78ca84a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f6c792e-eda8-44b4-acc3-7cafa6753700"), null, new Guid("b17919e5-9077-4379-a7c7-7d79a93a6179"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7598) },
                    { new Guid("33141cf3-5b93-4190-9c7e-7c8dd35aec78"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9c74ed78-e932-4d4f-bdd8-c39fcf172995"), null, new Guid("cbc08341-7a0d-4acf-a5e7-6960c68b813b"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7488) },
                    { new Guid("a9304f5f-0b24-4cd1-ade6-42c72606e53c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f6c792e-eda8-44b4-acc3-7cafa6753700"), null, new Guid("f226e0ad-af8d-4dc7-bc71-517dfd3752a5"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7588) },
                    { new Guid("096866ca-1831-4ddf-8822-e9c05512d254"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f6c792e-eda8-44b4-acc3-7cafa6753700"), null, new Guid("81aa83c9-a7b5-4993-b896-a017ef4e64a9"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7580) },
                    { new Guid("383dc10e-bf4c-4da0-a5b9-d4b048ef8873"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0f4aac48-2179-4e3e-8036-71157353cfe8"), null, new Guid("4c402f06-7e83-454d-9c57-286de97816f9"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7563) },
                    { new Guid("afdb099c-081c-4e44-9914-573b19d98505"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0f4aac48-2179-4e3e-8036-71157353cfe8"), null, new Guid("e6f5652d-30c9-4e5d-975c-f63dbe97ed7b"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7555) },
                    { new Guid("dae221d5-5baf-47e8-894f-3751ba879e37"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6f6c792e-eda8-44b4-acc3-7cafa6753700"), null, new Guid("b7c65e6a-5581-4ce9-b8d6-dddf4aff0552"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7572) },
                    { new Guid("e15d9f80-1122-4052-8b2d-e7d338ac5b9e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3648ed8f-f71c-4b97-bebc-75f4ba32c7d9"), null, new Guid("4b8bee85-3673-4ee6-8f2e-f5535f5f04ca"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7537) },
                    { new Guid("d8ed4439-6d8f-42b2-bac5-56186b0baa6f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3648ed8f-f71c-4b97-bebc-75f4ba32c7d9"), null, new Guid("012bc14a-396e-4074-b1a3-1b4d027fd53e"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7529) },
                    { new Guid("cfca42da-8562-4df2-8950-6d54c410ca64"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3648ed8f-f71c-4b97-bebc-75f4ba32c7d9"), null, new Guid("1d580cde-3263-493f-be4b-760de01713e6"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7515) },
                    { new Guid("1529f759-156d-47b7-9b27-b6b6422e3113"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("23abe574-14d1-4b99-8c75-977be6c0bce8"), null, new Guid("6c9536d4-a77d-450e-aeef-8f3d1936d59f"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7505) },
                    { new Guid("771f5f0b-1a39-4d1c-860a-dd8d04258a2c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("23abe574-14d1-4b99-8c75-977be6c0bce8"), null, new Guid("f95acc0c-78c7-4a2a-8dcb-da5a40ac1041"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7496) },
                    { new Guid("1a4b1bee-d5e7-47bd-8e7c-514b67fb132d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("9c74ed78-e932-4d4f-bdd8-c39fcf172995"), null, new Guid("add594cf-b745-485a-ac80-54a6dc50d5d1"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7475) },
                    { new Guid("dfec2780-1ff7-408b-b412-10fe8d8df115"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0f4aac48-2179-4e3e-8036-71157353cfe8"), null, new Guid("eb5f060c-6df2-4eb2-b9a5-5acf85b02088"), new DateTime(2019, 3, 7, 0, 44, 49, 566, DateTimeKind.Utc).AddTicks(7546) }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "school_student",
                columns: new[] { "id", "date_created", "grade_level", "registration_date", "school_id", "student_id" },
                values: new object[,]
                {
                    { new Guid("4674f7e6-3c8c-4185-8452-bcc55882011a"), new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(8859), "9", new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(8861), new Guid("b7c65e6a-5581-4ce9-b8d6-dddf4aff0552"), new Guid("13bc301d-929a-43c8-893f-a939abbbf145") },
                    { new Guid("eee0f271-a2a7-473e-88eb-cb0a6bae05db"), new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(4752), "9", new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(6168), new Guid("e2bf738c-c3e1-4b3f-bb5e-e9b39916a101"), new Guid("1b254eff-dc80-4908-a0f9-d1e4ea092e42") },
                    { new Guid("ff543df7-139a-4c02-8d25-f2103e076afa"), new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(8802), "9", new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(8823), new Guid("add594cf-b745-485a-ac80-54a6dc50d5d1"), new Guid("93299e96-c240-4c64-89c5-3734edd8e0ce") },
                    { new Guid("7bd896b1-709e-493b-afca-f69aa11a53f1"), new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(8846), "9", new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(8848), new Guid("add594cf-b745-485a-ac80-54a6dc50d5d1"), new Guid("cc051008-6703-4e00-b096-88f70e7309eb") },
                    { new Guid("014772bd-8e4b-4837-a057-53918472ff97"), new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(8852), "9", new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(8854), new Guid("b7c65e6a-5581-4ce9-b8d6-dddf4aff0552"), new Guid("1010d7a6-a45f-410b-9a39-9eb01123de24") },
                    { new Guid("53939f7f-729a-416d-9483-8ea9d5e26f52"), new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(8867), "9", new DateTime(2019, 3, 7, 0, 44, 49, 567, DateTimeKind.Utc).AddTicks(8868), new Guid("b7c65e6a-5581-4ce9-b8d6-dddf4aff0552"), new Guid("975199a3-a6fd-487c-8687-2248c1989b0b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_district_school_district_id",
                schema: "schooldata",
                table: "district_school",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_district_school_school_id",
                schema: "schooldata",
                table: "district_school",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_school_student_school_id",
                schema: "schooldata",
                table: "school_student",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_school_student_student_id",
                schema: "schooldata",
                table: "school_student",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_role_role_id",
                schema: "security",
                table: "team_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_role_team_id",
                schema: "security",
                table: "team_role",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_team_id",
                schema: "security",
                table: "team_user",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_team_user_user_id",
                schema: "security",
                table: "team_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_role_id",
                schema: "security",
                table: "user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_user_id",
                schema: "security",
                table: "user_role",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "district_school",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "school_student",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "team_role",
                schema: "security");

            migrationBuilder.DropTable(
                name: "team_user",
                schema: "security");

            migrationBuilder.DropTable(
                name: "user_role",
                schema: "security");

            migrationBuilder.DropTable(
                name: "district",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "school",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "student",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "team",
                schema: "security");

            migrationBuilder.DropTable(
                name: "role",
                schema: "security");

            migrationBuilder.DropTable(
                name: "user",
                schema: "security");
        }
    }
}
