﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bugtracker.Data;

namespace bugtracker.Migrations
{
    [DbContext(typeof(BugtrackerContext))]
    [Migration("20210329012030_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("bugtracker.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("bugtracker.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DueOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FinishedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("bugtracker.Models.TicketHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("NewValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("OldValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("PropertyFeild")
                        .HasColumnType("TEXT");

                    b.Property<int>("TicketID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TicketID")
                        .IsUnique();

                    b.ToTable("TicketHistory");
                });

            modelBuilder.Entity("bugtracker.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("bugtracker.Models.Ticket", b =>
                {
                    b.HasOne("bugtracker.Models.Project", "Project")
                        .WithMany("Tickets")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("bugtracker.Models.TicketHistory", b =>
                {
                    b.HasOne("bugtracker.Models.Ticket", "Ticket")
                        .WithOne("TicketHistory")
                        .HasForeignKey("bugtracker.Models.TicketHistory", "TicketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("bugtracker.Models.User", b =>
                {
                    b.HasOne("bugtracker.Models.Project", null)
                        .WithMany("Users")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("bugtracker.Models.Project", b =>
                {
                    b.Navigation("Tickets");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("bugtracker.Models.Ticket", b =>
                {
                    b.Navigation("TicketHistory");
                });
#pragma warning restore 612, 618
        }
    }
}