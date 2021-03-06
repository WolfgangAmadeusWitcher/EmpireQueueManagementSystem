﻿// <auto-generated />
using System;
using EmpireQms.TerminalService.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpireQms.TerminalService.Api.Migrations
{
    [DbContext(typeof(TerminalContext))]
    [Migration("20200920085156_RemovedOpenBreakIdColumn")]
    partial class RemovedOpenBreakIdColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpireQms.TerminalService.Api.Domain.Models.BreakLogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasIndex("TerminalId");

                    b.ToTable("BreakLogEntries");
                });

            modelBuilder.Entity("EmpireQms.TerminalService.Api.Domain.Models.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("EmpireQms.TerminalService.Api.Domain.Models.TerminalCategory", b =>
                {
                    b.Property<int>("TerminalId")
                        .HasColumnType("int");

                    b.Property<int>("TicketCategoryId")
                        .HasColumnType("int");

                    b.HasKey("TerminalId", "TicketCategoryId");

                    b.ToTable("TerminalCategories");
                });

            modelBuilder.Entity("EmpireQms.TerminalService.Api.Domain.Models.TicketCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriorityCoefficient")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TicketCategories");
                });

            modelBuilder.Entity("EmpireQms.TerminalService.Api.Domain.Models.BreakLogEntry", b =>
                {
                    b.HasOne("EmpireQms.TerminalService.Api.Domain.Models.Terminal", null)
                        .WithMany("BreakLogEntries")
                        .HasForeignKey("TerminalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
