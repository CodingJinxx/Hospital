﻿// <auto-generated />
using System;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.Migrations
{
    [DbContext(typeof(HospitalContext))]
    [Migration("20210309075458_FixedFacilityID")]
    partial class FixedFacilityID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Hospital.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
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

                    b.HasKey("EmployeeId");

                    b.HasIndex("SVNR")
                        .IsUnique();

                    b.ToTable("EMPLOYEES");
                });

            modelBuilder.Entity("Hospital.Models.HospitalFacility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("FACILITY_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("NAME");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("PHONE_NR");

                    b.HasKey("FacilityId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("HOSPITAL_FACILITIES");
                });

            modelBuilder.Entity("Hospital.Models.PhysicianWard", b =>
                {
                    b.Property<int>("PhysicianId")
                        .HasColumnType("INT")
                        .HasColumnName("PHYSICIAN_ID");

                    b.Property<int>("WardId")
                        .HasColumnType("INT")
                        .HasColumnName("WARD_ID");

                    b.Property<int>("WorkingHours")
                        .HasColumnType("INT")
                        .HasColumnName("WORKING_HOURS");

                    b.HasKey("PhysicianId", "WardId");

                    b.HasIndex("WardId");

                    b.ToTable("PHYSICIAN_STATION_JT");
                });

            modelBuilder.Entity("Hospital.Models.Ward", b =>
                {
                    b.Property<int>("WardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("WARD_ID");

                    b.Property<int>("CarryingCapacity")
                        .HasColumnType("INT")
                        .HasColumnName("CARRYING_CAPACITY");

                    b.Property<int>("HOSPITAL_FACILITY_ID")
                        .HasColumnType("INT");

                    b.Property<int?>("LeadPhysicianId")
                        .HasColumnType("INT")
                        .HasColumnName("FACILITY_ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("NAME");

                    b.HasKey("WardId");

                    b.HasIndex("HOSPITAL_FACILITY_ID");

                    b.HasIndex("LeadPhysicianId")
                        .IsUnique();

                    b.ToTable("WARDS");
                });

            modelBuilder.Entity("Hospital.Models.CareTaker", b =>
                {
                    b.HasBaseType("Hospital.Models.Employee");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("INT")
                        .HasColumnName("SUPERVISOR_ID");

                    b.HasIndex("SupervisorId");

                    b.ToTable("CARE_TAKERS");
                });

            modelBuilder.Entity("Hospital.Models.Physician", b =>
                {
                    b.HasBaseType("Hospital.Models.Employee");

                    b.Property<string>("JobSpecialisation")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("JOB_SPECIALISATION");

                    b.ToTable("PHYSICIANS");
                });

            modelBuilder.Entity("Hospital.Models.PhysicianWard", b =>
                {
                    b.HasOne("Hospital.Models.Physician", "Physician")
                        .WithMany()
                        .HasForeignKey("PhysicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.Ward", "Ward")
                        .WithMany()
                        .HasForeignKey("WardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Physician");

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("Hospital.Models.Ward", b =>
                {
                    b.HasOne("Hospital.Models.HospitalFacility", "HospitalFacility")
                        .WithMany()
                        .HasForeignKey("HOSPITAL_FACILITY_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.Physician", "LeadPhysician")
                        .WithOne()
                        .HasForeignKey("Hospital.Models.Ward", "LeadPhysicianId");

                    b.Navigation("HospitalFacility");

                    b.Navigation("LeadPhysician");
                });

            modelBuilder.Entity("Hospital.Models.CareTaker", b =>
                {
                    b.HasOne("Hospital.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("Hospital.Models.CareTaker", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hospital.Models.CareTaker", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("Hospital.Models.Physician", b =>
                {
                    b.HasOne("Hospital.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("Hospital.Models.Physician", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
