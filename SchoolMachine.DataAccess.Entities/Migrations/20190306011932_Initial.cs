using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMachine.DataAccess.Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "school_data");

            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "school_district_schools",
                schema: "school_data",
                columns: table => new
                {
                    school_district_school_id = table.Column<Guid>(nullable: false),
                    school_district_id = table.Column<Guid>(nullable: false),
                    school_id = table.Column<Guid>(nullable: false),
                    start_date = table.Column<DateTime>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: true),
                    date_created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school_district_schools", x => x.school_district_school_id);
                });

            migrationBuilder.CreateTable(
                name: "school_districts",
                schema: "school_data",
                columns: table => new
                {
                    school_district_id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school_districts", x => x.school_district_id);
                });

            migrationBuilder.CreateTable(
                name: "school_students",
                schema: "school_data",
                columns: table => new
                {
                    school_student_id = table.Column<Guid>(nullable: false),
                    school_id = table.Column<Guid>(nullable: false),
                    student_id = table.Column<Guid>(nullable: false),
                    grade_level = table.Column<string>(nullable: false),
                    registration_date = table.Column<DateTime>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school_students", x => x.school_student_id);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                schema: "school_data",
                columns: table => new
                {
                    school_id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schools", x => x.school_id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                schema: "school_data",
                columns: table => new
                {
                    student_id = table.Column<Guid>(nullable: false),
                    first_name = table.Column<string>(maxLength: 60, nullable: false),
                    last_name = table.Column<string>(maxLength: 60, nullable: false),
                    middle_name = table.Column<string>(maxLength: 60, nullable: false),
                    birth_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                schema: "security",
                columns: table => new
                {
                    role_id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "team_roles",
                schema: "security",
                columns: table => new
                {
                    team_role_id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false),
                    team_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_roles", x => x.team_role_id);
                });

            migrationBuilder.CreateTable(
                name: "team_users",
                schema: "security",
                columns: table => new
                {
                    team_user_id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    team_id = table.Column<Guid>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_users", x => x.team_user_id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                schema: "security",
                columns: table => new
                {
                    team_id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    date_modified = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    description = table.Column<string>(maxLength: 1000, nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.team_id);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                schema: "security",
                columns: table => new
                {
                    user_role_id = table.Column<Guid>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    role_id = table.Column<Guid>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_roles", x => x.user_role_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "security",
                columns: table => new
                {
                    user_id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.InsertData(
                schema: "school_data",
                table: "school_district_schools",
                columns: new[] { "school_district_school_id", "date_created", "end_date", "school_district_id", "school_id", "start_date" },
                values: new object[,]
                {
                    { new Guid("e3c8ebbf-2914-41ab-9000-45a1fea66b6e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("09a703c1-11ca-4605-a13f-bc4ad63849e6"), new Guid("caf6455d-dc20-48a5-9411-f3cf08ccadcb"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7210) },
                    { new Guid("2d2addbe-bdc4-44a3-8846-6eb3c02a63a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c30ffa47-a9d2-4309-a278-81740776632d"), new Guid("f705d344-40f6-4c4e-8fde-53a43219d429"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(6531) },
                    { new Guid("4176a7b6-c7c5-44a9-8d2e-2735cf1d0fcc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("075c477b-9071-40c5-88e3-a2ee9b089357"), new Guid("0af946d3-8434-47f7-8cc4-3aa95559cb95"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7119) },
                    { new Guid("db59b01a-fd3b-44d4-922f-0ffc4c96b4cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("075c477b-9071-40c5-88e3-a2ee9b089357"), new Guid("9675f5e0-5c83-453d-a7f8-b7378ce487f9"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7132) },
                    { new Guid("258d2c65-e074-4a57-a715-a99e904d1e26"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c6c93c34-44cf-4928-9626-b94ff0f9c858"), new Guid("31d66451-004d-4040-a204-1441e75bd390"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7140) },
                    { new Guid("d001a13b-a41b-46eb-abcc-3f41c2a7b1c0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("c6c93c34-44cf-4928-9626-b94ff0f9c858"), new Guid("a2fc0644-985b-4e22-a490-3b454ba60aae"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7148) },
                    { new Guid("ce611e15-1162-49c3-8722-1d39b9c24abb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b5b74604-3695-4040-9a51-001af3e9b4d0"), new Guid("5ef2545c-80f3-4b2f-a45a-e8991935c8a7"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7171) },
                    { new Guid("5b30d296-9917-4684-97cd-c6b9865acecf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b5b74604-3695-4040-9a51-001af3e9b4d0"), new Guid("52635373-9af5-455d-853e-699c9d82191f"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7157) },
                    { new Guid("dfc0404c-f277-4d47-ad52-87ffc79fb868"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("85acc9e8-f67e-4057-928e-afec9c657af0"), new Guid("d0a837e5-38e4-4ef4-a1d9-8b441c7b682f"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7186) },
                    { new Guid("56d62e64-500a-4d0d-8de7-4cf7d98a1e82"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("85acc9e8-f67e-4057-928e-afec9c657af0"), new Guid("448930db-3d06-4f19-84a3-faf16d35c2ca"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7195) },
                    { new Guid("d26a1149-115f-4a74-a34d-39bf8191319c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("85acc9e8-f67e-4057-928e-afec9c657af0"), new Guid("2dc2e2c1-c080-42a8-ba82-cbcff2b6b194"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7202) },
                    { new Guid("37039a01-f4bc-47ae-a5d8-7a6b6aaac755"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("09a703c1-11ca-4605-a13f-bc4ad63849e6"), new Guid("8feadc58-cf0c-412c-8526-9eccf8589b09"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7217) },
                    { new Guid("89769907-4b32-4867-8788-198908d19e87"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("09a703c1-11ca-4605-a13f-bc4ad63849e6"), new Guid("d9b8023f-cd9b-4291-a5a7-02b7e263ddef"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7225) },
                    { new Guid("23983a3d-897f-4eb4-a812-5bca21d869ee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("09a703c1-11ca-4605-a13f-bc4ad63849e6"), new Guid("ae266327-36a8-4b5f-a8fa-5bc83c68597a"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7235) },
                    { new Guid("8ce47e07-7da3-4cfb-8b72-97e271968fa5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("b5b74604-3695-4040-9a51-001af3e9b4d0"), new Guid("512c4c18-e28a-4c39-858b-797a1afd2bad"), new DateTime(2019, 3, 6, 1, 19, 32, 106, DateTimeKind.Utc).AddTicks(7178) }
                });

            migrationBuilder.InsertData(
                schema: "school_data",
                table: "school_districts",
                columns: new[] { "school_district_id", "name" },
                values: new object[,]
                {
                    { new Guid("765d2f12-ef69-47f4-89a9-0940929e911a"), "Trumbull County Educational Service Center" },
                    { new Guid("ef1e35eb-5911-4951-a37a-3a1a6aaf3ccb"), "Weathersfield Local School District" },
                    { new Guid("ea581fef-8be0-47f3-9231-f26992fda16a"), "Warren City School District" },
                    { new Guid("363af5e2-f4ba-4153-8ac3-9e5a7119689f"), "Trumbull Career & Technical Center" },
                    { new Guid("c30ffa47-a9d2-4309-a278-81740776632d"), "Austintown Local School District" },
                    { new Guid("e944f4dd-2d76-4c6f-8fe0-bfe414f99f80"), "Niles City School District" },
                    { new Guid("075c477b-9071-40c5-88e3-a2ee9b089357"), "Bloomfield-Mespo Local School District" },
                    { new Guid("c6c93c34-44cf-4928-9626-b94ff0f9c858"), "Bristol Local School District" },
                    { new Guid("b5b74604-3695-4040-9a51-001af3e9b4d0"), "Brookfield Local School District" },
                    { new Guid("98df3102-afa5-426c-9236-23243e1f1c35"), "Southington Local School District" },
                    { new Guid("85acc9e8-f67e-4057-928e-afec9c657af0"), "Champion Local School District" },
                    { new Guid("09a703c1-11ca-4605-a13f-bc4ad63849e6"), "Girard City School District" },
                    { new Guid("1e596a59-0f18-45a2-887e-6fcb5b289f81"), "Howland Local School District" },
                    { new Guid("27e3ca27-1844-4fdf-a37b-2e3d290ff100"), "Hubbard Exempted Village School District" },
                    { new Guid("0bf90c6b-8bdb-4dfc-b21b-6ead84b02ca8"), "Joseph Badger Local School District" },
                    { new Guid("6ed0793b-9315-4845-87f2-9fd68a748b0c"), "LaBrae Local School District" },
                    { new Guid("1da88b73-a3cf-4804-878b-ebe6571c2279"), "Lakeview Local School District" },
                    { new Guid("b9be5a3b-0603-4bb1-877f-99681042b8d0"), "Liberty Local School District" },
                    { new Guid("8768a050-d704-4714-93b1-e0f2b11bc3ca"), "Lordstown Local School District" },
                    { new Guid("6ddb33b6-578b-41cc-abf6-b5da2474a733"), "Maplewood Local School District" },
                    { new Guid("ad8d6d36-dab5-4aec-a9f6-d72f53f775be"), "Mathews Local School District" },
                    { new Guid("ee46a916-64d3-4a10-9806-e9a7f8c2f379"), "McDonald Local School District" },
                    { new Guid("ebaf3241-a843-49bf-b9a5-5cd269fa305d"), "Newton Falls Exempted Village School District" }
                });

            migrationBuilder.InsertData(
                schema: "school_data",
                table: "school_students",
                columns: new[] { "school_student_id", "date_created", "grade_level", "registration_date", "school_id", "student_id" },
                values: new object[,]
                {
                    { new Guid("af64558e-8e54-40ea-aaea-b2a5df8b9efe"), new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(3731), "9", new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(5107), new Guid("f705d344-40f6-4c4e-8fde-53a43219d429"), new Guid("2ad7fafa-2bfe-4af7-9b93-e6a5a22c6737") },
                    { new Guid("c2a8e642-c91a-4599-8220-4effda85eff8"), new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(6964), "9", new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(6984), new Guid("0af946d3-8434-47f7-8cc4-3aa95559cb95"), new Guid("59bceede-01b9-4019-bcb0-7592b8d62b16") },
                    { new Guid("f0991723-2a81-4643-aa92-af41d6644b09"), new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(7025), "9", new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(7026), new Guid("caf6455d-dc20-48a5-9411-f3cf08ccadcb"), new Guid("c142ce23-a170-4a82-ac7a-457c37383219") },
                    { new Guid("e5f4ecef-a151-4da9-8ee2-731f0defc78d"), new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(7013), "9", new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(7014), new Guid("caf6455d-dc20-48a5-9411-f3cf08ccadcb"), new Guid("9fda4546-3010-4513-98cc-6fcd3fee8142") },
                    { new Guid("35d2cc38-0328-4b39-b39c-0c495c077a30"), new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(7018), "9", new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(7019), new Guid("caf6455d-dc20-48a5-9411-f3cf08ccadcb"), new Guid("e0ad44ee-5e68-46e7-b896-4fd576ab0eb0") },
                    { new Guid("12bd5771-e4b9-49fd-93ba-fc39fdb55d93"), new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(7007), "9", new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(7008), new Guid("0af946d3-8434-47f7-8cc4-3aa95559cb95"), new Guid("ad80e71d-32e9-4813-bee1-54cb663e3fba") }
                });

            migrationBuilder.InsertData(
                schema: "school_data",
                table: "schools",
                columns: new[] { "school_id", "name" },
                values: new object[,]
                {
                    { new Guid("ae266327-36a8-4b5f-a8fa-5bc83c68597a"), "Prospect Elementary" },
                    { new Guid("8feadc58-cf0c-412c-8526-9eccf8589b09"), "Girard Intermediate" },
                    { new Guid("9675f5e0-5c83-453d-a7f8-b7378ce487f9"), "Mesopatamia Elementary" },
                    { new Guid("25b17c15-33d6-4dbc-bd53-00af1148028a"), "Liberty High School" },
                    { new Guid("d9b8023f-cd9b-4291-a5a7-02b7e263ddef"), "Girard Junior High School" },
                    { new Guid("caf6455d-dc20-48a5-9411-f3cf08ccadcb"), "Girard High School" },
                    { new Guid("52635373-9af5-455d-853e-699c9d82191f"), "Brookfield Elementary School" },
                    { new Guid("448930db-3d06-4f19-84a3-faf16d35c2ca"), "Champion High School" },
                    { new Guid("2dc2e2c1-c080-42a8-ba82-cbcff2b6b194"), "Champion Middle School" },
                    { new Guid("0af946d3-8434-47f7-8cc4-3aa95559cb95"), "Bloomfield Middle/High School" },
                    { new Guid("31d66451-004d-4040-a204-1441e75bd390"), "Bristol Elementary" },
                    { new Guid("a2fc0644-985b-4e22-a490-3b454ba60aae"), "Bristol Middle & High School" },
                    { new Guid("f705d344-40f6-4c4e-8fde-53a43219d429"), "Austintown Fitch High School" },
                    { new Guid("512c4c18-e28a-4c39-858b-797a1afd2bad"), "Brookfield High School" },
                    { new Guid("e0358b6b-0c6d-410e-93a7-089c58a60c28"), "Canfield High School" },
                    { new Guid("d0a837e5-38e4-4ef4-a1d9-8b441c7b682f"), "Central Elementary" },
                    { new Guid("5ef2545c-80f3-4b2f-a45a-e8991935c8a7"), "Brookfield Middle School" }
                });

            migrationBuilder.InsertData(
                schema: "school_data",
                table: "students",
                columns: new[] { "student_id", "birth_date", "first_name", "last_name", "middle_name" },
                values: new object[,]
                {
                    { new Guid("e0ad44ee-5e68-46e7-b896-4fd576ab0eb0"), new DateTime(2006, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Timkin", "Dudley" },
                    { new Guid("2ad7fafa-2bfe-4af7-9b93-e6a5a22c6737"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Abott", "Alfred" },
                    { new Guid("59bceede-01b9-4019-bcb0-7592b8d62b16"), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann", "Smith", "Grace" },
                    { new Guid("ad80e71d-32e9-4813-bee1-54cb663e3fba"), new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Kriter", "Anthony" },
                    { new Guid("9fda4546-3010-4513-98cc-6fcd3fee8142"), new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Carter", "Lynn" },
                    { new Guid("c142ce23-a170-4a82-ac7a-457c37383219"), new DateTime(2006, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abby", "Smart", "Darla" }
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "roles",
                columns: new[] { "role_id", "date_created", "description", "is_active", "name" },
                values: new object[] { new Guid("2bda5d47-a248-4b2c-9ae7-c751377da806"), new DateTime(2019, 3, 6, 1, 19, 32, 105, DateTimeKind.Utc).AddTicks(1490), "Total access to all other roles", true, "System Administrator" });

            migrationBuilder.InsertData(
                schema: "security",
                table: "users",
                columns: new[] { "user_id", "date_created", "email_address", "first_name", "is_active", "last_name", "middle_name", "password_hash", "password_salt", "user_name" },
                values: new object[] { new Guid("a494b37d-2b84-4a70-b5f8-cf9217e475a4"), new DateTime(2019, 3, 6, 1, 19, 32, 107, DateTimeKind.Utc).AddTicks(8234), "auser1@email.com", "A", true, "User1", "A", null, null, "auser1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "school_district_schools",
                schema: "school_data");

            migrationBuilder.DropTable(
                name: "school_districts",
                schema: "school_data");

            migrationBuilder.DropTable(
                name: "school_students",
                schema: "school_data");

            migrationBuilder.DropTable(
                name: "schools",
                schema: "school_data");

            migrationBuilder.DropTable(
                name: "students",
                schema: "school_data");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "team_roles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "team_users",
                schema: "security");

            migrationBuilder.DropTable(
                name: "teams",
                schema: "security");

            migrationBuilder.DropTable(
                name: "user_roles",
                schema: "security");

            migrationBuilder.DropTable(
                name: "users",
                schema: "security");
        }
    }
}
