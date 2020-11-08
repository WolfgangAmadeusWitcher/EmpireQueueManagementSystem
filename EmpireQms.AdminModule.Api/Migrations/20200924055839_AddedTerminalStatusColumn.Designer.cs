﻿// <auto-generated />
using EmpireQms.AdminModule.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpireQms.AdminModule.Api.Migrations
{
    [DbContext(typeof(SettingsContext))]
    [Migration("20200924055839_AddedTerminalStatusColumn")]
    partial class AddedTerminalStatusColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpireQms.AdminModule.Api.Domain.Models.Signage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Signages");
                });

            modelBuilder.Entity("EmpireQms.AdminModule.Api.Domain.Models.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("EmpireQms.AdminModule.Api.Domain.Models.TerminalCategory", b =>
                {
                    b.Property<int>("TerminalId")
                        .HasColumnType("int");

                    b.Property<int>("TicketCategoryId")
                        .HasColumnType("int");

                    b.HasKey("TerminalId", "TicketCategoryId");

                    b.HasIndex("TicketCategoryId");

                    b.ToTable("TerminalCategories");
                });

            modelBuilder.Entity("EmpireQms.AdminModule.Api.Domain.Models.TerminalSignage", b =>
                {
                    b.Property<int>("TerminalId")
                        .HasColumnType("int");

                    b.Property<int>("SignageId")
                        .HasColumnType("int");

                    b.HasKey("TerminalId", "SignageId");

                    b.HasIndex("SignageId");

                    b.ToTable("TerminalSignages");
                });

            modelBuilder.Entity("EmpireQms.AdminModule.Api.Domain.Models.TicketCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirstTicketNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LastTicketNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriorityCoefficient")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("TicketCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Gişe işlemleri yapmak",
                            FirstTicketNumber = 100,
                            IsDeleted = false,
                            LastTicketNumber = 200,
                            Name = "Gişe İşlemleri",
                            PriorityCoefficient = 1.0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Bireysel Bankacılık hizmetlerimizden faydalanmak",
                            FirstTicketNumber = 300,
                            IsDeleted = false,
                            LastTicketNumber = 450,
                            Name = "Bireysel Hizmetler",
                            PriorityCoefficient = 3.0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Kurumsal Bankacılık hizmetlerimizden faydalanmak",
                            FirstTicketNumber = 450,
                            IsDeleted = false,
                            LastTicketNumber = 750,
                            Name = "Ticari İşlemler",
                            PriorityCoefficient = 5.0
                        });
                });

            modelBuilder.Entity("EmpireQms.AdminModule.Api.Domain.Models.TerminalCategory", b =>
                {
                    b.HasOne("EmpireQms.AdminModule.Api.Domain.Models.Terminal", "Terminal")
                        .WithMany("TerminalCategories")
                        .HasForeignKey("TerminalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpireQms.AdminModule.Api.Domain.Models.TicketCategory", "TicketCategory")
                        .WithMany("TerminalCategories")
                        .HasForeignKey("TicketCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmpireQms.AdminModule.Api.Domain.Models.TerminalSignage", b =>
                {
                    b.HasOne("EmpireQms.AdminModule.Api.Domain.Models.Signage", "Signage")
                        .WithMany("TerminalSignages")
                        .HasForeignKey("SignageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpireQms.AdminModule.Api.Domain.Models.Terminal", "Terminal")
                        .WithMany("TerminalSignages")
                        .HasForeignKey("TerminalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}