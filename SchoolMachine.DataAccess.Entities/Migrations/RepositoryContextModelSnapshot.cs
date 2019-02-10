﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolMachine.DataAccess.Entities;

namespace SchoolMachine.DataAccess.Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.Models.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SchoolId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Schools","SchoolData");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2edfe2bb-2148-43f8-a441-fe2fc348f830"),
                            Name = "Girard High School"
                        },
                        new
                        {
                            Id = new Guid("43a8c018-d859-450c-a336-522b6984d11d"),
                            Name = "Liberty High School"
                        });
                });

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.Models.SchoolStudent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SchoolStudentId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("GradeLevel")
                        .IsRequired();

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("SchoolId");

                    b.Property<Guid>("StudentId");

                    b.HasKey("Id");

                    b.ToTable("SchoolStudents","SchoolData");
                });

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StudentId");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Students","SchoolData");
                });
#pragma warning restore 612, 618
        }
    }
}
