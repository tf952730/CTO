﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace D01.Migrations
{
    [DbContext(typeof(D01DbContext))]
    partial class D01DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContosoUniversity.A01.Entities.Person", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .HasMaxLength(1000);

                    b.Property<string>("Mobile")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("SortCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("person");
                });

            modelBuilder.Entity("D01.A01.Entities.Department", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<bool>("IsActiveDepartment");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<Guid?>("ParentDepartmentID");

                    b.Property<string>("SortCode")
                        .HasMaxLength(150);

                    b.HasKey("ID");

                    b.HasIndex("ParentDepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("D01.A01.Entities.Employee", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDay");

                    b.Property<Guid?>("DepartmentID");

                    b.Property<string>("Description")
                        .HasMaxLength(2000);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("Mobile")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .HasMaxLength(10);

                    b.Property<bool>("Sex");

                    b.Property<string>("SortCode")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("D01.A01.Entities.Department", b =>
                {
                    b.HasOne("D01.A01.Entities.Department", "ParentDepartment")
                        .WithMany()
                        .HasForeignKey("ParentDepartmentID");
                });

            modelBuilder.Entity("D01.A01.Entities.Employee", b =>
                {
                    b.HasOne("D01.A01.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID");
                });
#pragma warning restore 612, 618
        }
    }
}