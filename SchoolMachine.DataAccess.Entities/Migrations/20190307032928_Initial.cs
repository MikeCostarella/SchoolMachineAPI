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
                    { new Guid("5b3626ac-3c35-4f96-8359-54d63575b85b"), "Austintown Local School District" },
                    { new Guid("602870c5-fafd-4475-9992-c0a5f0b880d1"), "Mathews Local School District" },
                    { new Guid("9b9ef436-fa5c-40f1-98df-130f73000e79"), "McDonald Local School District" },
                    { new Guid("5a535a2d-3035-43d2-8152-3c3aea30c19b"), "Newton Falls Exempted Village School District" },
                    { new Guid("46c2ea4c-c9d6-4f66-b9e6-32d8f4b0bf0f"), "Niles City School District" },
                    { new Guid("b60bc7d2-c856-4eea-a0ba-1b8dfb919cc9"), "Sebring Local School District" },
                    { new Guid("9d67650e-16b3-476c-ba43-f00541248449"), "South Range Local School District" },
                    { new Guid("ac8c4fd7-634c-4976-846e-0f9795e27829"), "Springfield Local School District" },
                    { new Guid("72d1624d-e640-49e0-939a-ccf9c26a101e"), "Struthers City School District" },
                    { new Guid("a17aa059-dd0e-473d-8fac-5c37b5dc54f8"), "Trumbull Career & Technical Center" },
                    { new Guid("10d4e953-6e54-425b-91e6-baacb9aa9d81"), "Trumbull County Educational Service Center" },
                    { new Guid("fd5316ff-e0a4-42c0-be2f-8a6b880c8079"), "Warren City School District" },
                    { new Guid("c1ec7599-2959-4a57-b40f-f218b97b698e"), "Weathersfield Local School District" },
                    { new Guid("6d4c3a42-88ec-47ac-824e-909cc305cfd4"), "West Branch Local School District" },
                    { new Guid("5c53bf1e-b3e9-4cf0-9f2e-61174cf0f5be"), "Western Reserve Local School District" },
                    { new Guid("4e132621-0bdc-4f22-99c9-fc1e6fccf23e"), "Youngstown City School District" },
                    { new Guid("2835d992-9dee-4f8a-a651-4b730063d4ac"), "Maplewood Local School District" },
                    { new Guid("2db5c452-4e9d-4fb4-a161-0db622f08806"), "Lowellville Local School District" },
                    { new Guid("ab0d7b1f-cf44-448c-a681-dc7fde617daf"), "Southington Local School District" },
                    { new Guid("b6b578bb-8ea5-497f-801c-f746b44b602a"), "Liberty Local School District" },
                    { new Guid("d52a80de-32dc-45e6-bfab-17d8a728aa3e"), "Bloomfield-Mespo Local School District" },
                    { new Guid("0a300aa0-0641-42f2-9148-63aef49fccdb"), "Lordstown Local School District" },
                    { new Guid("f2040b11-abec-4213-92a4-fc99e0661d5a"), "Bristol Local School District" },
                    { new Guid("44f4cc1a-ed6c-41f9-b039-dce3caebf79d"), "Brookfield Local School District" },
                    { new Guid("2cc3d707-32f5-410f-86f0-439a99e72196"), "Canfield Local School District" },
                    { new Guid("d5a9eddc-a8b1-4026-afa8-f0fa7d44a718"), "Champion Local School District" },
                    { new Guid("e1da01bd-2b5a-41b3-bf90-9a7f1942d1ba"), "Girard City School District" },
                    { new Guid("f4ade358-111d-4cff-a997-51481aacce84"), "Howland Local School District" },
                    { new Guid("4f922b67-5c87-4d8d-aa69-a35630dc856c"), "Boardman Local School District" },
                    { new Guid("e24ac45e-eed5-4d19-bbe8-df35b069805a"), "Howland Local School District" },
                    { new Guid("de3d40aa-1a9d-43d6-9830-85d520e736fa"), "Hubbard Exempted Village School District" },
                    { new Guid("ed8f6867-4583-4620-b6cc-e44e86f15652"), "Jackson-Milton Local School District" },
                    { new Guid("e0ad009b-49d6-4e9c-8760-885840da91ff"), "Joseph Badger Local School District" },
                    { new Guid("46a19247-a6c1-4ca0-ba8c-364d0366c452"), "LaBrae Local School District" },
                    { new Guid("b5da0527-6b38-4cd4-80f3-4ee85b903c9a"), "Lakeview Local School District" },
                    { new Guid("6b70156c-bce5-47b2-8edd-ebca1dea2386"), "Hubbard Exempted Village School District" }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "school",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("039a995a-53bd-47b3-87de-89e5f0381f7b"), "Girard Junior High School" },
                    { new Guid("38e2336d-aa9a-4cf6-acfa-89849119bcbe"), "Glen Primary School" },
                    { new Guid("24ed2193-e1bc-469a-ac3a-e4f54543e798"), "H.C. Mines Elementary" },
                    { new Guid("35adad97-f3df-4dbc-a604-fbaf09be4474"), "Hubbard Elementary School" },
                    { new Guid("301df10a-7c6b-4104-8189-f27b3927ee47"), "Hubbard High School" },
                    { new Guid("0dbabc13-53ef-4349-abcb-0657369e97ac"), "Hubbard Middle School" },
                    { new Guid("40384e94-a708-4241-9835-4776b6264b90"), "Mesopatamia Elementary" },
                    { new Guid("6f98b180-0218-4b4d-9f17-cf0f7ecb83b6"), "Howland Middle School" },
                    { new Guid("037b6812-11aa-490a-83ac-1f043fcbd12f"), "Liberty High School" },
                    { new Guid("f45d5ed0-b819-41ef-b303-252a37f47e1b"), "North Road Intermediate" },
                    { new Guid("ff6dc408-00cf-4cbc-89f6-cd11536ce027"), "Prospect Elementary" },
                    { new Guid("97640604-7108-40d1-af9a-c05549aa4825"), "Springs Primary School" },
                    { new Guid("0b883b24-c5a7-468d-830e-4a3cbef92a3e"), "Girard Intermediate" },
                    { new Guid("f480910f-02ca-4241-83b2-4bafd483a159"), "Howland High School" },
                    { new Guid("b2d980e2-e69b-4ae0-a962-6ecf32b69997"), "Girard High School" },
                    { new Guid("18beccb7-012d-4481-9817-e24fb365e8e9"), "Brookfield Elementary School" },
                    { new Guid("f06b89a7-635c-4b9e-9327-a0580b499be4"), "Champion High School" },
                    { new Guid("abadb6f3-e4d2-4755-b532-2fd730b97a3e"), "Champion Middle School" },
                    { new Guid("87425cc5-8777-4a0a-ae7e-9ab561cd40bd"), "Badger Elementary School" },
                    { new Guid("7f7c9866-6c68-49b4-bedc-6b0365b26114"), "Badger Middle School" },
                    { new Guid("c15a250e-0294-47f1-aaba-942f5a78cd61"), "Badger High School" },
                    { new Guid("efe44639-f0b8-4307-9727-dd68e8048f59"), "Bloomfield Middle/High School" },
                    { new Guid("1710c47f-6f5f-4373-84e4-2b9135be3d17"), "Bristol Elementary" },
                    { new Guid("cceaa442-1505-49f8-8782-d1c9f6d6db1e"), "Austintown Fitch High School" },
                    { new Guid("f99441d4-6978-48e0-b1e8-662398744b1f"), "Brookfield Middle School" },
                    { new Guid("dac29a49-37b6-4dc1-bdeb-4e1b8ab5c91b"), "Brookfield High School" },
                    { new Guid("0950b493-0e12-4d28-9763-977f74a287c9"), "Canfield High School" },
                    { new Guid("85309c50-f49a-4114-8b16-aa6a7456bf33"), "Central Elementary" },
                    { new Guid("fb5ee15b-c8b4-4b3c-89db-f36496498129"), "Bristol Middle & High School" }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "student",
                columns: new[] { "id", "birth_date", "first_name", "last_name", "middle_name" },
                values: new object[,]
                {
                    { new Guid("80ae933b-bb55-4c44-be9e-603e001ce35b"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lovely", "Beefton", "Ionez" },
                    { new Guid("5a8a1ebf-f6b1-4508-98b4-9a90f5c772c6"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Janet", "Flores", "Philomena" },
                    { new Guid("b660dc1a-789a-44d7-9d9d-ec1d9d7a54c8"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daffy", "Duck", "Junior" },
                    { new Guid("d2ded293-4e3e-406f-bcb1-ab88e45cbb69"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Smart", "Daryl" },
                    { new Guid("61ec22bf-1c2b-4294-82bd-f1c6ad77a474"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe", "Donuts", "Bagga" },
                    { new Guid("fe832246-dfb0-4395-81b9-7a98af816946"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bernie", "Kosar", "QB" },
                    { new Guid("e89a18b0-1e38-4a70-957f-4e37c6849b8c"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rictor", "Scale", "The" },
                    { new Guid("3d671297-72e5-4a60-b614-b7284aab9fef"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brian", "Man", "Donald" },
                    { new Guid("3656494f-b07e-44d3-b5c4-ed550dae257f"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilomena", "Rogers", "Darla" },
                    { new Guid("68332405-b6f8-43a0-85ad-4e5fb9c2cd12"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riahna", "Fabian", "Darla" },
                    { new Guid("894c0e1d-0f33-4b0d-87c0-1dd9bca4c91c"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roger", "Doger", "The" },
                    { new Guid("907bcb4b-a996-4b3d-abfe-3c17dc3849fa"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Clinton", "Jefferson" },
                    { new Guid("935b4cc8-2522-412f-836c-97da7bc2f699"), new DateTime(2006, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Timkin", "Dudley" },
                    { new Guid("ebc8e233-094c-485b-8702-2034c99826d1"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donald", "Trump", "John" },
                    { new Guid("be3c6e97-ccc7-44ef-939c-0e2fe59e6e7c"), new DateTime(2009, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Kirk", "Theodore" },
                    { new Guid("50a45463-b054-4e3a-b48a-f72af750ff4c"), new DateTime(2008, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronald", "McDonald", "Burger" },
                    { new Guid("b8149607-3ecf-4b90-80df-9641f11148c5"), new DateTime(2008, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abby", "Smart", "Darla" },
                    { new Guid("b128e1f2-ce49-4c43-80c3-ecfeab8c4f0f"), new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Carter", "Lynn" },
                    { new Guid("07884332-2c12-4655-9945-b462930dfa86"), new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Kriter", "Anthony" },
                    { new Guid("f2a900bb-cd3f-42c5-9988-3df540a2fb4c"), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann", "Smith", "Grace" },
                    { new Guid("e50fe569-8af6-4941-aa5e-4f6cae8e111d"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Abott", "Alfred" },
                    { new Guid("befcc0a1-dab6-43b0-b672-65f29aeccef0"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Doe", "Alla" },
                    { new Guid("f1070c79-4669-4622-a68c-8a4cc1daafd4"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barack", "Obama", "Hussein" },
                    { new Guid("1ba2f52e-ed52-4e89-9ba3-70935255f60d"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Harrison", "Henry" }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "role",
                columns: new[] { "id", "date_created", "description", "is_active", "name" },
                values: new object[] { new Guid("049bd083-9586-4811-a138-cfce21f743c1"), new DateTime(2019, 3, 7, 3, 29, 27, 907, DateTimeKind.Utc).AddTicks(719), "Total access to all other roles", true, "System Administrator" });

            migrationBuilder.InsertData(
                schema: "security",
                table: "user",
                columns: new[] { "id", "date_created", "email_address", "first_name", "is_active", "last_name", "middle_name", "password_hash", "password_salt", "user_name" },
                values: new object[] { new Guid("b95399a4-1d49-4962-b9d8-59179cae7c05"), new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(7663), "auser1@email.com", "A", true, "User1", "A", null, null, "auser1" });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "district_school",
                columns: new[] { "id", "date_created", "district_id", "end_date", "school_id", "start_date" },
                values: new object[,]
                {
                    { new Guid("911ea4de-e156-4135-ba02-d8880f936047"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5b3626ac-3c35-4f96-8359-54d63575b85b"), null, new Guid("cceaa442-1505-49f8-8782-d1c9f6d6db1e"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(7975) },
                    { new Guid("1d6e2561-7a9b-406c-b82f-abd7b7220fe4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1da01bd-2b5a-41b3-bf90-9a7f1942d1ba"), null, new Guid("ff6dc408-00cf-4cbc-89f6-cd11536ce027"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9207) },
                    { new Guid("96b951c7-95de-4b9e-9b3e-7f2eac26d486"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d52a80de-32dc-45e6-bfab-17d8a728aa3e"), null, new Guid("40384e94-a708-4241-9835-4776b6264b90"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9098) },
                    { new Guid("21fcd2a9-710a-4d4d-81cc-7c2e03d270d7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1da01bd-2b5a-41b3-bf90-9a7f1942d1ba"), null, new Guid("039a995a-53bd-47b3-87de-89e5f0381f7b"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9199) },
                    { new Guid("aebca9a0-74d9-4c0f-9866-cd269caa5667"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1da01bd-2b5a-41b3-bf90-9a7f1942d1ba"), null, new Guid("0b883b24-c5a7-468d-830e-4a3cbef92a3e"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9191) },
                    { new Guid("133653b0-00c7-44f8-b34e-d7117d78e055"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5a9eddc-a8b1-4026-afa8-f0fa7d44a718"), null, new Guid("abadb6f3-e4d2-4755-b532-2fd730b97a3e"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9175) },
                    { new Guid("bc45812e-2218-4323-9c06-3f49df28523e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5a9eddc-a8b1-4026-afa8-f0fa7d44a718"), null, new Guid("f06b89a7-635c-4b9e-9327-a0580b499be4"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9167) },
                    { new Guid("3c1c11f7-f65c-4c9a-969e-4f4da8de897e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1da01bd-2b5a-41b3-bf90-9a7f1942d1ba"), null, new Guid("b2d980e2-e69b-4ae0-a962-6ecf32b69997"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9183) },
                    { new Guid("178a9666-e801-4390-bc39-8ec58109b148"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44f4cc1a-ed6c-41f9-b039-dce3caebf79d"), null, new Guid("dac29a49-37b6-4dc1-bdeb-4e1b8ab5c91b"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9143) },
                    { new Guid("cef4ecec-2afc-46fd-bf92-66b3df621b3a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44f4cc1a-ed6c-41f9-b039-dce3caebf79d"), null, new Guid("f99441d4-6978-48e0-b1e8-662398744b1f"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9134) },
                    { new Guid("9f1abd8a-b8e3-4181-8fb2-22f6507eaccc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("44f4cc1a-ed6c-41f9-b039-dce3caebf79d"), null, new Guid("18beccb7-012d-4481-9817-e24fb365e8e9"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9126) },
                    { new Guid("393a4741-c9ce-48d7-bce5-87f23d22663f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f2040b11-abec-4213-92a4-fc99e0661d5a"), null, new Guid("fb5ee15b-c8b4-4b3c-89db-f36496498129"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9116) },
                    { new Guid("6bcb1893-0633-4322-924a-501db42013c0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f2040b11-abec-4213-92a4-fc99e0661d5a"), null, new Guid("1710c47f-6f5f-4373-84e4-2b9135be3d17"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9107) },
                    { new Guid("1797038e-b1c9-45c2-ae40-14b5af07854f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d52a80de-32dc-45e6-bfab-17d8a728aa3e"), null, new Guid("efe44639-f0b8-4307-9727-dd68e8048f59"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9084) },
                    { new Guid("988fcc7f-93cc-4a41-a90d-41f763a3eda8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5a9eddc-a8b1-4026-afa8-f0fa7d44a718"), null, new Guid("85309c50-f49a-4114-8b16-aa6a7456bf33"), new DateTime(2019, 3, 7, 3, 29, 27, 908, DateTimeKind.Utc).AddTicks(9154) }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "school_student",
                columns: new[] { "id", "date_created", "grade_level", "registration_date", "school_id", "student_id" },
                values: new object[,]
                {
                    { new Guid("fa77f251-ad2e-414e-922e-f3b35dcb249f"), new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5176), "9", new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5177), new Guid("b2d980e2-e69b-4ae0-a962-6ecf32b69997"), new Guid("b8149607-3ecf-4b90-80df-9641f11148c5") },
                    { new Guid("f22e8906-2dde-4f87-957e-b64483b42171"), new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(1208), "9", new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(3024), new Guid("cceaa442-1505-49f8-8782-d1c9f6d6db1e"), new Guid("e50fe569-8af6-4941-aa5e-4f6cae8e111d") },
                    { new Guid("ade9cc84-1a6d-4228-9bac-3fbf68f03e19"), new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5106), "9", new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5123), new Guid("efe44639-f0b8-4307-9727-dd68e8048f59"), new Guid("f2a900bb-cd3f-42c5-9988-3df540a2fb4c") },
                    { new Guid("a690b303-0f93-42ca-95e3-0e90d5e71543"), new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5150), "9", new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5156), new Guid("efe44639-f0b8-4307-9727-dd68e8048f59"), new Guid("07884332-2c12-4655-9945-b462930dfa86") },
                    { new Guid("14e5857f-83ee-42aa-9ebc-4d7cc36fa548"), new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5161), "9", new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5163), new Guid("b2d980e2-e69b-4ae0-a962-6ecf32b69997"), new Guid("b128e1f2-ce49-4c43-80c3-ecfeab8c4f0f") },
                    { new Guid("57c606a0-6021-4249-8df3-a8d6e7f49df9"), new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5169), "9", new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5170), new Guid("b2d980e2-e69b-4ae0-a962-6ecf32b69997"), new Guid("935b4cc8-2522-412f-836c-97da7bc2f699") },
                    { new Guid("08b94496-14b6-4b28-9702-9945015fe936"), new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5182), "9", new DateTime(2019, 3, 7, 3, 29, 27, 910, DateTimeKind.Utc).AddTicks(5183), new Guid("b2d980e2-e69b-4ae0-a962-6ecf32b69997"), new Guid("50a45463-b054-4e3a-b48a-f72af750ff4c") }
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
