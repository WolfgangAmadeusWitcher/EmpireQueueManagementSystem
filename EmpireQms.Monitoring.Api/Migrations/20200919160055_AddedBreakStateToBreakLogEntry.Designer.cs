﻿// <auto-generated />
using System;
using EmpireQms.Monitoring.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpireQms.Monitoring.Api.Migrations
{
    [DbContext(typeof(MonitoringContext))]
    [Migration("20200919160055_AddedBreakStateToBreakLogEntry")]
    partial class AddedBreakStateToBreakLogEntry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpireQms.Monitoring.Api.Domain.Models.BreakLogEntry", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("BreakEndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("BreakReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BreakStartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("BreakState")
                        .HasColumnType("int");

                    b.Property<int>("TerminalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BreakLogEntries");
                });

            modelBuilder.Entity("EmpireQms.Monitoring.Api.Domain.Models.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OpenBreakId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Terminals");
                });
#pragma warning restore 612, 618
        }
    }
}
