﻿// <auto-generated />
using System;
using EmpireQms.QueueService.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpireQms.QueueService.Api.Migrations
{
    [DbContext(typeof(QueueContext))]
    partial class QueueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpireQms.QueueService.Api.Domain.Models.EmpireQueue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActiveWaitersCount")
                        .HasColumnType("int");

                    b.Property<int?>("MaxAllowedCustomers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("QueueWeight")
                        .HasColumnType("float");

                    b.Property<int>("TicketCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EmpireQueues");
                });

            modelBuilder.Entity("EmpireQms.QueueService.Api.Domain.Models.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("EmpireQms.QueueService.Api.Domain.Models.TerminalCategory", b =>
                {
                    b.Property<int>("TerminalId")
                        .HasColumnType("int");

                    b.Property<int>("TicketCategoryId")
                        .HasColumnType("int");

                    b.HasKey("TerminalId", "TicketCategoryId");

                    b.ToTable("TerminalCategories");
                });

            modelBuilder.Entity("EmpireQms.QueueService.Api.Domain.Models.TerminalTicket", b =>
                {
                    b.Property<int>("TerminalId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("TerminalId", "TicketId");

                    b.ToTable("TerminalTickets");
                });

            modelBuilder.Entity("EmpireQms.QueueService.Api.Domain.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("QueueId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ServiceCompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TicketStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("EmpireQms.QueueService.Api.Domain.Models.TicketCategory", b =>
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
#pragma warning restore 612, 618
        }
    }
}
