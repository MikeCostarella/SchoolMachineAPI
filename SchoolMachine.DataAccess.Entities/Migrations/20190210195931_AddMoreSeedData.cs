using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMachine.DataAccess.Entities.Migrations
{
    public partial class AddMoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "SchoolData",
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: new Guid("2edfe2bb-2148-43f8-a441-fe2fc348f830"));

            migrationBuilder.DeleteData(
                schema: "SchoolData",
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: new Guid("43a8c018-d859-450c-a336-522b6984d11d"));

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "Schools",
                columns: new[] { "SchoolId", "Name" },
                values: new object[,]
                {
                    { new Guid("3b95457d-c125-408d-a825-52da69528bb1"), "Girard High School" },
                    { new Guid("08879ae6-0c9f-4523-b509-04900adce695"), "Liberty High School" }
                });

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "Students",
                columns: new[] { "StudentId", "BirthDate", "FirstName", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("e5350749-45da-459b-8916-31107261fedf"), new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Abott", "Alfred" },
                    { new Guid("03dde39f-ef5b-4e13-826e-9d12b9a8da4e"), new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ann", "Smith", "Grace" },
                    { new Guid("57858b78-39fb-4881-a40c-6c76d9d62502"), new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "Kriter", "Anthony" },
                    { new Guid("12939e7c-9aeb-476c-8281-efc8a2b15e1c"), new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Carter", "Lynn" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "SchoolData",
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: new Guid("08879ae6-0c9f-4523-b509-04900adce695"));

            migrationBuilder.DeleteData(
                schema: "SchoolData",
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: new Guid("3b95457d-c125-408d-a825-52da69528bb1"));

            migrationBuilder.DeleteData(
                schema: "SchoolData",
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("03dde39f-ef5b-4e13-826e-9d12b9a8da4e"));

            migrationBuilder.DeleteData(
                schema: "SchoolData",
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("12939e7c-9aeb-476c-8281-efc8a2b15e1c"));

            migrationBuilder.DeleteData(
                schema: "SchoolData",
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("57858b78-39fb-4881-a40c-6c76d9d62502"));

            migrationBuilder.DeleteData(
                schema: "SchoolData",
                table: "Students",
                keyColumn: "StudentId",
                keyValue: new Guid("e5350749-45da-459b-8916-31107261fedf"));

            migrationBuilder.InsertData(
                schema: "SchoolData",
                table: "Schools",
                columns: new[] { "SchoolId", "Name" },
                values: new object[,]
                {
                    { new Guid("2edfe2bb-2148-43f8-a441-fe2fc348f830"), "Girard High School" },
                    { new Guid("43a8c018-d859-450c-a336-522b6984d11d"), "Liberty High School" }
                });
        }
    }
}
