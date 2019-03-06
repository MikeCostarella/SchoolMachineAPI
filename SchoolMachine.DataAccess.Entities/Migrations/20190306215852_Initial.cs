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

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "district",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("af19034a-9b05-40cd-b669-1e3a20700a7e"), "Austintown Local School District" },
                    { new Guid("d55d6520-f910-4062-87ca-e74eee9689a8"), "Mathews Local School District" },
                    { new Guid("88835e1e-51a0-473f-b860-c3b550fc5be8"), "McDonald Local School District" },
                    { new Guid("0d484526-9b1b-4cf1-b46f-8eebe5991d7e"), "Newton Falls Exempted Village School District" },
                    { new Guid("829dbcd7-9c24-49db-b976-05951cc9599b"), "Niles City School District" },
                    { new Guid("58f02df8-aca2-429e-ba40-58a33fc384af"), "Sebring Local School District" },
                    { new Guid("2473faa7-036c-491b-80d3-d96a13ec7ae4"), "Southington Local School District" },
                    { new Guid("f21437d5-2001-432d-b78b-498f83f7ae66"), "South Range Local School District" },
                    { new Guid("a8c69e3c-7c46-47d0-9116-1ee6e74e7119"), "Springfield Local School District" },
                    { new Guid("e9aed448-91bf-499a-97ea-619e8a1a73bf"), "Struthers City School District" },
                    { new Guid("b89ac4fa-156a-44b0-bc77-867f0adc866f"), "Trumbull Career & Technical Center" },
                    { new Guid("be91dc50-b90b-4ece-9b9f-e4ae71ace0c3"), "Trumbull County Educational Service Center" },
                    { new Guid("e43a4044-9a5d-4780-a857-57a804d661c8"), "Warren City School District" },
                    { new Guid("09a4f24d-2b9f-437a-8148-b7180d350254"), "Weathersfield Local School District" },
                    { new Guid("41495d82-ba39-44df-b360-279d1bc4b2f6"), "Western Reserve Local School District" },
                    { new Guid("cd381eb2-ca3b-476c-a76f-b7ed71739278"), "Youngstown City School District" },
                    { new Guid("37606e42-c5e6-4dcd-bedd-c47510a30b3f"), "Maplewood Local School District" },
                    { new Guid("f44f30f6-0c7e-41ba-acc4-10b5324b093a"), "Lowellville Local School District" },
                    { new Guid("cc32fcc9-78b6-4398-96e3-bdc3f1448704"), "West Branch Local School District" },
                    { new Guid("5079bbd1-ddee-4db8-b442-74932ad3899c"), "Liberty Local School District" },
                    { new Guid("7dc25aba-4996-4903-9103-c8ccad9ec7eb"), "Bloomfield-Mespo Local School District" },
                    { new Guid("2333535d-1a2b-49f2-a524-b42a339360e6"), "Boardman Local School District" },
                    { new Guid("4f2ca199-aba5-41c8-9b17-1f998b74ef9b"), "Bristol Local School District" },
                    { new Guid("80a3a720-15ad-40ac-a99b-b8fc3c25e0ad"), "Brookfield Local School District" },
                    { new Guid("7e112678-f650-4579-8e09-cf499c694ddc"), "Canfield Local School District" },
                    { new Guid("c2bbbc3d-054b-47e5-b5f3-53810bb1621b"), "Lordstown Local School District" },
                    { new Guid("5462e10a-d37d-460b-b397-44efb6e8ed97"), "Girard City School District" },
                    { new Guid("da0c5498-16c3-4e0c-82bd-5ffc72499116"), "Champion Local School District" },
                    { new Guid("a85c7946-feea-4bbb-b9eb-55638af824a7"), "Hubbard Exempted Village School District" },
                    { new Guid("8d53de90-4bc2-4834-af8b-2d1613ab8b4d"), "Howland Local School District" },
                    { new Guid("17710eba-149b-47b2-ab53-280296f8fa93"), "Hubbard Exempted Village School District" },
                    { new Guid("e298ba9f-09b1-453d-9437-b0fcf05de2a6"), "Jackson-Milton Local School District" },
                    { new Guid("ba0197d4-49dd-4e17-8d0e-f2c714f07b48"), "Joseph Badger Local School District" },
                    { new Guid("17deafb6-0c14-4ba9-8229-6d9e0b6431f5"), "LaBrae Local School District" },
                    { new Guid("175a7430-8fe5-460d-803b-5ee5cab7bbb2"), "Lakeview Local School District" },
                    { new Guid("a2adc3f9-8e43-4245-b39f-17ec9b885b89"), "Howland Local School District" }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "school",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("08ce76cf-1d7b-4f51-9f04-557506c16c4f"), "Girard Junior High School" },
                    { new Guid("c924a9d2-244a-4886-bc7b-8c7e2d26ffe8"), "Glen Primary School" },
                    { new Guid("a7782fc8-1996-4793-8202-22bc4da62b19"), "H.C. Mines Elementary" },
                    { new Guid("69485dff-e8a3-4289-bb6e-0e49c3adf80b"), "Howland High School" },
                    { new Guid("66a84276-387a-48d4-a9da-e5c85acb19f4"), "Springs Primary School" },
                    { new Guid("8d13f86c-2ad1-4388-9549-47095efa80e2"), "Liberty High School" },
                    { new Guid("30aa33a9-454b-45ef-a33a-13c149aaf909"), "Mesopatamia Elementary" },
                    { new Guid("172d5551-2338-4782-ac1a-bb6fd4d3740a"), "North Road Intermediate" },
                    { new Guid("837c19e9-70cc-4c49-b55c-41f659d518c8"), "Prospect Elementary" },
                    { new Guid("e5cfc991-c7f2-49b1-b01c-cd0278b712bd"), "Girard Intermediate" },
                    { new Guid("d95323a9-5afb-405f-877d-ef3a729876ef"), "Howland Middle School" },
                    { new Guid("dc8c4a32-c1b1-4f05-b7fc-b39e3d90cb34"), "Girard High School" },
                    { new Guid("ea306521-8580-481f-8465-1975e4edc967"), "Brookfield Elementary School" },
                    { new Guid("cebf61e5-b9bd-4425-8569-25624346559b"), "Champion High School" },
                    { new Guid("441f7072-921c-4ae7-83dc-9829e9249fdd"), "Champion Middle School" },
                    { new Guid("fbbed763-515c-48d9-9c8e-98ae6b64b2ce"), "Bloomfield Middle/High School" },
                    { new Guid("5044182c-8159-494a-917c-61e7ea88da67"), "Bristol Elementary" },
                    { new Guid("19ff2588-3584-4451-b149-728b403bcd77"), "Bristol Middle & High School" },
                    { new Guid("5196a610-8b03-42b1-a808-65d54d5314d5"), "Austintown Fitch High School" },
                    { new Guid("a0f3d3be-fad9-4271-b985-7053b711ddd0"), "Brookfield High School" },
                    { new Guid("816bb6cb-6521-4a5c-a2d8-861c15ae1f23"), "Canfield High School" },
                    { new Guid("d7622023-d0f7-46dc-91b2-2115dd85bf59"), "Central Elementary" },
                    { new Guid("72c09015-3818-4dde-ad25-9d1f74666cca"), "Brookfield Middle School" }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "student",
                columns: new[] { "id", "birth_date", "first_name", "last_name", "middle_name" },
                values: new object[,]
                {
                    { new Guid("a22a800c-35bc-4b03-9727-50faba4a03b5"), new DateTime(2006, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Timkin", "Dudley" },
                    { new Guid("64c3e34d-d1a1-4c3f-9c8f-1a5df56e76d3"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Abott", "Alfred" },
                    { new Guid("298e516a-83ce-4892-9aca-de0146a130ca"), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann", "Smith", "Grace" },
                    { new Guid("49644507-908c-42ca-b7a4-4a787e7ba1d5"), new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Kriter", "Anthony" },
                    { new Guid("dc799f62-5825-417d-97d6-23b95d0c0e7a"), new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Carter", "Lynn" },
                    { new Guid("cdbdfd16-39cd-4ba4-a852-6bcd3b85603a"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abby", "Smart", "Darla" }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "role",
                columns: new[] { "id", "date_created", "description", "is_active", "name" },
                values: new object[] { new Guid("c30fcad3-1662-4f7b-abbf-440b5dc77443"), new DateTime(2019, 3, 6, 21, 58, 52, 307, DateTimeKind.Utc).AddTicks(7144), "Total access to all other roles", true, "System Administrator" });

            migrationBuilder.InsertData(
                schema: "security",
                table: "user",
                columns: new[] { "id", "date_created", "email_address", "first_name", "is_active", "last_name", "middle_name", "password_hash", "password_salt", "user_name" },
                values: new object[] { new Guid("40a63361-6277-479c-84fc-6183a8d2a949"), new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(5121), "auser1@email.com", "A", true, "User1", "A", null, null, "auser1" });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "district_school",
                columns: new[] { "id", "date_created", "district_id", "end_date", "school_id", "start_date" },
                values: new object[,]
                {
                    { new Guid("247d8161-1415-47cb-aca3-284e300916a8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("af19034a-9b05-40cd-b669-1e3a20700a7e"), null, new Guid("5196a610-8b03-42b1-a808-65d54d5314d5"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(2426) },
                    { new Guid("603ca2a5-7f32-4a40-89ac-86a1769f61fc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5462e10a-d37d-460b-b397-44efb6e8ed97"), null, new Guid("837c19e9-70cc-4c49-b55c-41f659d518c8"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3100) },
                    { new Guid("9d071f7a-1464-4e37-abe9-a6a8c9070df9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7dc25aba-4996-4903-9103-c8ccad9ec7eb"), null, new Guid("30aa33a9-454b-45ef-a33a-13c149aaf909"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(2992) },
                    { new Guid("87dfebe7-e94e-4185-9c45-3e8aa3bce2e3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5462e10a-d37d-460b-b397-44efb6e8ed97"), null, new Guid("08ce76cf-1d7b-4f51-9f04-557506c16c4f"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3092) },
                    { new Guid("c170809d-c8a4-487e-a110-e0382127be3a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5462e10a-d37d-460b-b397-44efb6e8ed97"), null, new Guid("e5cfc991-c7f2-49b1-b01c-cd0278b712bd"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3084) },
                    { new Guid("5c74e792-347a-417d-9931-393123741ab1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("da0c5498-16c3-4e0c-82bd-5ffc72499116"), null, new Guid("441f7072-921c-4ae7-83dc-9829e9249fdd"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3066) },
                    { new Guid("40b70eb0-c1fb-4f22-81ba-216b61b9f619"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("da0c5498-16c3-4e0c-82bd-5ffc72499116"), null, new Guid("cebf61e5-b9bd-4425-8569-25624346559b"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3058) },
                    { new Guid("6ea6883b-4660-4bf3-8d94-2f15e2dcc659"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5462e10a-d37d-460b-b397-44efb6e8ed97"), null, new Guid("dc8c4a32-c1b1-4f05-b7fc-b39e3d90cb34"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3077) },
                    { new Guid("b34ccb5f-40bc-4748-87a1-cac0a7f6c2ea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80a3a720-15ad-40ac-a99b-b8fc3c25e0ad"), null, new Guid("a0f3d3be-fad9-4271-b985-7053b711ddd0"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3040) },
                    { new Guid("954b859c-c18b-418b-a908-ed2979b692fd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80a3a720-15ad-40ac-a99b-b8fc3c25e0ad"), null, new Guid("72c09015-3818-4dde-ad25-9d1f74666cca"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3032) },
                    { new Guid("b029c316-1117-44c3-9fec-2961d39e8fb0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("80a3a720-15ad-40ac-a99b-b8fc3c25e0ad"), null, new Guid("ea306521-8580-481f-8465-1975e4edc967"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3024) },
                    { new Guid("97e786f8-9085-402a-80a3-4c0b894a5d2e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4f2ca199-aba5-41c8-9b17-1f998b74ef9b"), null, new Guid("19ff2588-3584-4451-b149-728b403bcd77"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3014) },
                    { new Guid("801f5d98-bc67-483f-90aa-0011910e97ae"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4f2ca199-aba5-41c8-9b17-1f998b74ef9b"), null, new Guid("5044182c-8159-494a-917c-61e7ea88da67"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3005) },
                    { new Guid("bcf7996b-6eed-494a-98a9-7605a0a61df4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7dc25aba-4996-4903-9103-c8ccad9ec7eb"), null, new Guid("fbbed763-515c-48d9-9c8e-98ae6b64b2ce"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(2980) },
                    { new Guid("b19a8487-7379-4d35-bed5-26cba9eadf62"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("da0c5498-16c3-4e0c-82bd-5ffc72499116"), null, new Guid("d7622023-d0f7-46dc-91b2-2115dd85bf59"), new DateTime(2019, 3, 6, 21, 58, 52, 309, DateTimeKind.Utc).AddTicks(3049) }
                });

            migrationBuilder.InsertData(
                schema: "schooldata",
                table: "school_student",
                columns: new[] { "id", "date_created", "grade_level", "registration_date", "school_id", "student_id" },
                values: new object[,]
                {
                    { new Guid("ccd5bc5a-cc82-4135-b2eb-d65f841671e5"), new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(3480), "9", new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(3481), new Guid("dc8c4a32-c1b1-4f05-b7fc-b39e3d90cb34"), new Guid("a22a800c-35bc-4b03-9727-50faba4a03b5") },
                    { new Guid("fd705a62-0488-4b98-b1b7-5f911879b8b8"), new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(48), "9", new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(1498), new Guid("5196a610-8b03-42b1-a808-65d54d5314d5"), new Guid("64c3e34d-d1a1-4c3f-9c8f-1a5df56e76d3") },
                    { new Guid("c6dffc63-0a0f-4c64-9aea-8d19bab70c52"), new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(3430), "9", new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(3445), new Guid("fbbed763-515c-48d9-9c8e-98ae6b64b2ce"), new Guid("298e516a-83ce-4892-9aca-de0146a130ca") },
                    { new Guid("a719f43c-0083-4343-b8fb-690949dd90c9"), new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(3468), "9", new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(3470), new Guid("fbbed763-515c-48d9-9c8e-98ae6b64b2ce"), new Guid("49644507-908c-42ca-b7a4-4a787e7ba1d5") },
                    { new Guid("917a14b0-b0d0-4598-b215-2e231cb55d5b"), new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(3475), "9", new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(3476), new Guid("dc8c4a32-c1b1-4f05-b7fc-b39e3d90cb34"), new Guid("dc799f62-5825-417d-97d6-23b95d0c0e7a") },
                    { new Guid("77b30c82-8e53-45df-ab7b-ed79280b54af"), new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(3487), "9", new DateTime(2019, 3, 6, 21, 58, 52, 310, DateTimeKind.Utc).AddTicks(3488), new Guid("dc8c4a32-c1b1-4f05-b7fc-b39e3d90cb34"), new Guid("cdbdfd16-39cd-4ba4-a852-6bcd3b85603a") }
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

            migrationBuilder.DropTable(
                name: "district",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "school",
                schema: "schooldata");

            migrationBuilder.DropTable(
                name: "student",
                schema: "schooldata");
        }
    }
}
