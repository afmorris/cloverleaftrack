﻿// <auto-generated />
using System;
using CloverleafTrack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CloverleafTrack.Migrations
{
    [DbContext(typeof(CloverleafTrackDataContext))]
    [Migration("20210107134945_MakePerformanceDataNullable")]
    partial class MakePerformanceDataNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CloverleafTrack.Models.Athlete", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<int>("GraduationYear")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Athletes");
                });

            modelBuilder.Entity("CloverleafTrack.Models.Meet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("Meets");
                });

            modelBuilder.Entity("CloverleafTrack.Models.MeetResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CloverleafPlace")
                        .HasColumnType("int");

                    b.Property<Guid>("MeetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MeetId")
                        .IsUnique();

                    b.ToTable("MeetResult");
                });

            modelBuilder.Entity("CloverleafTrack.Models.Performance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AthleteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Feet")
                        .HasColumnType("int");

                    b.Property<int?>("FrationalInches")
                        .HasColumnType("int");

                    b.Property<int?>("Inches")
                        .HasColumnType("int");

                    b.Property<Guid>("MeetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Milliseconds")
                        .HasColumnType("int");

                    b.Property<int?>("Minutes")
                        .HasColumnType("int");

                    b.Property<int?>("Seconds")
                        .HasColumnType("int");

                    b.Property<Guid>("TrackEventId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AthleteId");

                    b.HasIndex("MeetId");

                    b.HasIndex("TrackEventId");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("CloverleafTrack.Models.School", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("CloverleafTrack.Models.Season", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("CloverleafTrack.Models.TrackEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RelayEvent")
                        .HasColumnType("bit");

                    b.Property<bool>("RunningEvent")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TrackEvents");
                });

            modelBuilder.Entity("MeetSchool", b =>
                {
                    b.Property<Guid>("MeetsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SchoolsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MeetsId", "SchoolsId");

                    b.HasIndex("SchoolsId");

                    b.ToTable("MeetSchool");
                });

            modelBuilder.Entity("CloverleafTrack.Models.Meet", b =>
                {
                    b.HasOne("CloverleafTrack.Models.Season", "Season")
                        .WithMany("Meets")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("CloverleafTrack.Models.MeetResult", b =>
                {
                    b.HasOne("CloverleafTrack.Models.Meet", "Meet")
                        .WithOne("MeetResult")
                        .HasForeignKey("CloverleafTrack.Models.MeetResult", "MeetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meet");
                });

            modelBuilder.Entity("CloverleafTrack.Models.Performance", b =>
                {
                    b.HasOne("CloverleafTrack.Models.Athlete", "Athlete")
                        .WithMany("Performances")
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloverleafTrack.Models.Meet", "Meet")
                        .WithMany("Performances")
                        .HasForeignKey("MeetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloverleafTrack.Models.TrackEvent", "TrackEvent")
                        .WithMany("Performances")
                        .HasForeignKey("TrackEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Athlete");

                    b.Navigation("Meet");

                    b.Navigation("TrackEvent");
                });

            modelBuilder.Entity("MeetSchool", b =>
                {
                    b.HasOne("CloverleafTrack.Models.Meet", null)
                        .WithMany()
                        .HasForeignKey("MeetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CloverleafTrack.Models.School", null)
                        .WithMany()
                        .HasForeignKey("SchoolsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CloverleafTrack.Models.Athlete", b =>
                {
                    b.Navigation("Performances");
                });

            modelBuilder.Entity("CloverleafTrack.Models.Meet", b =>
                {
                    b.Navigation("MeetResult");

                    b.Navigation("Performances");
                });

            modelBuilder.Entity("CloverleafTrack.Models.Season", b =>
                {
                    b.Navigation("Meets");
                });

            modelBuilder.Entity("CloverleafTrack.Models.TrackEvent", b =>
                {
                    b.Navigation("Performances");
                });
#pragma warning restore 612, 618
        }
    }
}
