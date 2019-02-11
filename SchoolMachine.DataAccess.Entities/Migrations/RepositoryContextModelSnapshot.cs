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

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.Models.Security.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoleId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DateCreated");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(1000);

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Roles","Security");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5771357e-8085-4dfb-a8ca-b9e8b4468f54"),
                            DateCreated = new DateTime(2019, 2, 11, 17, 28, 32, 454, DateTimeKind.Utc).AddTicks(1619),
                            Description = "Total access to all other roles",
                            IsActive = true,
                            Name = "System Administrator"
                        });
                });

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.Models.Security.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TeamId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DateCreated");

                    b.Property<DateTime>("DateModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("DateModified");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasMaxLength(1000);

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Teams","Security");
                });

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.Models.Security.TeamRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TeamRoleId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("DateCreated");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("TeamId");

                    b.HasKey("Id");

                    b.ToTable("TeamRoles","Security");
                });

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.Models.Security.TeamUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TeamUserId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("DateCreated");

                    b.Property<Guid>("TeamId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("TeamUsers","Security");
                });

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.Models.Security.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DateCreated");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnName("EmailAddress")
                        .HasMaxLength(150);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnName("MiddleName")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("UserName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users","Security");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4b53cd37-935b-492d-a16f-175cb51ef2ad"),
                            DateCreated = new DateTime(2019, 2, 11, 17, 28, 32, 455, DateTimeKind.Utc).AddTicks(2514),
                            EmailAddress = "auser1@email.com",
                            FirstName = "A",
                            IsActive = true,
                            LastName = "User1",
                            MiddleName = "A",
                            UserName = "auser1"
                        });
                });

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.Models.Security.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserRoleId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("DateCreated");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserRoles","Security");
                });

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.SchoolData.Models.School", b =>
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
                            Id = new Guid("eb9cd9f6-b98f-4ca0-a895-50c5270b2847"),
                            Name = "Girard High School"
                        },
                        new
                        {
                            Id = new Guid("21042f07-0295-4be3-8a42-b268a85c824c"),
                            Name = "Liberty High School"
                        });
                });

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.SchoolData.Models.SchoolStudent", b =>
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

            modelBuilder.Entity("SchoolMachine.DataAccess.Entities.SchoolData.Models.Student", b =>
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("026e3e0d-b851-45cd-abc6-f8e31c5849e0"),
                            BirthDate = new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Abott",
                            MiddleName = "Alfred"
                        },
                        new
                        {
                            Id = new Guid("6f08ff4c-f9c3-485a-bb9c-2063b70cb6b6"),
                            BirthDate = new DateTime(2005, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Ann",
                            LastName = "Smith",
                            MiddleName = "Grace"
                        },
                        new
                        {
                            Id = new Guid("600f8d50-765b-4d9f-ac4e-41636cf92fa9"),
                            BirthDate = new DateTime(2004, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bill",
                            LastName = "Kriter",
                            MiddleName = "Anthony"
                        },
                        new
                        {
                            Id = new Guid("249743a4-208e-41fe-8d95-18eab906fb41"),
                            BirthDate = new DateTime(2005, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sara",
                            LastName = "Carter",
                            MiddleName = "Lynn"
                        },
                        new
                        {
                            Id = new Guid("602d3eb8-2d1a-4849-abab-7b8a4c5581b2"),
                            BirthDate = new DateTime(2006, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Timkin",
                            MiddleName = "Dudley"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
