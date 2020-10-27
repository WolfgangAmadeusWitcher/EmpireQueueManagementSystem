﻿// <auto-generated />
using EmpireQms.SignageService.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpireQms.SignageService.Api.Migrations
{
    [DbContext(typeof(SignageContext))]
    [Migration("20200930142314_AddedConnectionIdFieldToSignage")]
    partial class AddedConnectionIdFieldToSignage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpireQms.SignageService.Api.Domain.Models.Signage", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConnectionIds")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Signages");
                });

            modelBuilder.Entity("EmpireQms.SignageService.Api.Domain.Models.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("EmpireQms.SignageService.Api.Domain.Models.TerminalSignage", b =>
                {
                    b.Property<int>("TerminalId")
                        .HasColumnType("int");

                    b.Property<int>("SignageId")
                        .HasColumnType("int");

                    b.HasKey("TerminalId", "SignageId");

                    b.HasIndex("SignageId");

                    b.ToTable("TerminalSignages");
                });

            modelBuilder.Entity("EmpireQms.SignageService.Api.Domain.Models.TerminalSignage", b =>
                {
                    b.HasOne("EmpireQms.SignageService.Api.Domain.Models.Signage", "Signage")
                        .WithMany("TerminalSignages")
                        .HasForeignKey("SignageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmpireQms.SignageService.Api.Domain.Models.Terminal", "Terminal")
                        .WithMany("TerminalSignages")
                        .HasForeignKey("TerminalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
