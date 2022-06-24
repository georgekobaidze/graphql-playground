﻿// <auto-generated />
using GraphQLPlayground.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQLPlayground.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220624082118_AddCommandsTable")]
    partial class AddCommandsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GraphQLPlayground.Models.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("CommandLine")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("command-line");

                    b.Property<string>("HowTo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("how-to");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int")
                        .HasColumnName("platform-id");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("command");
                });

            modelBuilder.Entity("GraphQLPlayground.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("LicenseKey")
                        .HasColumnType("longtext")
                        .HasColumnName("license-key");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("platforms");
                });

            modelBuilder.Entity("GraphQLPlayground.Models.Command", b =>
                {
                    b.HasOne("GraphQLPlayground.Models.Platform", "Platform")
                        .WithMany("Commands")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("GraphQLPlayground.Models.Platform", b =>
                {
                    b.Navigation("Commands");
                });
#pragma warning restore 612, 618
        }
    }
}