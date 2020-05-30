﻿// <auto-generated />
using System;
using ConferenceApp.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200530124003_Seeders")]
    partial class Seeders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConferenceApp.Backend.Data.Attendee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Attendees");
                });

            modelBuilder.Entity("ConferenceApp.Backend.Data.Session", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Title = "Keynote"
                        });
                });

            modelBuilder.Entity("ConferenceApp.Backend.Data.SessionAttendee", b =>
                {
                    b.Property<int>("AttendeeId")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("AttendeeId", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionAttendee");
                });

            modelBuilder.Entity("ConferenceApp.Backend.Data.SessionSpeaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("SpeakerId", "SessionId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionSpeaker");

                    b.HasData(
                        new
                        {
                            SpeakerId = 1,
                            SessionId = 1
                        });
                });

            modelBuilder.Entity("ConferenceApp.Backend.Data.Speaker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("ID");

                    b.ToTable("Speakers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Bio = "Awesome Scott",
                            Name = "Scott hanselman",
                            Website = "hanselman.com"
                        });
                });

            modelBuilder.Entity("ConferenceApp.Backend.Data.SessionAttendee", b =>
                {
                    b.HasOne("ConferenceApp.Backend.Data.Attendee", "Attendee")
                        .WithMany("Sessions")
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConferenceApp.Backend.Data.Session", "Session")
                        .WithMany("Attendees")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConferenceApp.Backend.Data.SessionSpeaker", b =>
                {
                    b.HasOne("ConferenceApp.Backend.Data.Session", "Session")
                        .WithMany("Speakers")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConferenceApp.Backend.Data.Speaker", "Speaker")
                        .WithMany("Sessions")
                        .HasForeignKey("SpeakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}