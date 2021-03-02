﻿// <auto-generated />
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20210302082156_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Hospital.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EMPLOYEE_ID");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("FIRST_NAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("LAST_NAME");

                    b.Property<int>("SVNR")
                        .HasColumnType("INT")
                        .HasColumnName("SVNR");

                    b.Property<int>("Salary")
                        .HasColumnType("INT")
                        .HasColumnName("SALARY");

                    b.HasKey("Id");

                    b.HasIndex("SVNR")
                        .IsUnique();

                    b.ToTable("EMPLOYEES");
                });
#pragma warning restore 612, 618
        }
    }
}