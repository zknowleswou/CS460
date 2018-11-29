﻿// <auto-generated />
using System;
using GymAppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GymAppData.Migrations
{
    [DbContext(typeof(WorkoutDb))]
    [Migration("20180915232827_AddWorkoutSessionTable")]
    partial class AddWorkoutSessionTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GymAppData.Models.Day", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsRestDay");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("Order");

                    b.Property<DateTime?>("Updated");

                    b.Property<int>("WorkoutId");

                    b.HasKey("DayId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("GymAppData.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("DayId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("Order");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("ExerciseId");

                    b.HasIndex("DayId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GymAppData.Models.Set", b =>
                {
                    b.Property<int>("SetId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("ExerciseId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("Order");

                    b.Property<int>("Repititions");

                    b.Property<DateTime?>("Updated");

                    b.Property<decimal>("Weight");

                    b.HasKey("SetId");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("GymAppData.Models.SetRecord", b =>
                {
                    b.Property<int>("SetRecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompletedRepititions");

                    b.Property<decimal>("CompletedWeight");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("GoalRepititions");

                    b.Property<decimal>("GoalWeight");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("Order");

                    b.Property<int>("SetId");

                    b.Property<DateTime?>("Updated");

                    b.Property<int>("WorkoutSessionId");

                    b.HasKey("SetRecordId");

                    b.HasIndex("SetId");

                    b.HasIndex("WorkoutSessionId");

                    b.ToTable("SetRecords");
                });

            modelBuilder.Entity("GymAppData.Models.Workout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("OwnerId");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("WorkoutId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("GymAppData.Models.WorkoutSession", b =>
                {
                    b.Property<int>("WorkoutSessionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("DayId");

                    b.Property<DateTime?>("Ended");

                    b.Property<bool>("IsCompleted");

                    b.Property<Guid>("UserId");

                    b.HasKey("WorkoutSessionId");

                    b.HasIndex("DayId");

                    b.ToTable("WorkoutSessions");
                });

            modelBuilder.Entity("GymAppData.Models.Day", b =>
                {
                    b.HasOne("GymAppData.Models.Workout", "Program")
                        .WithMany("Days")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GymAppData.Models.Exercise", b =>
                {
                    b.HasOne("GymAppData.Models.Day", "Day")
                        .WithMany("Exercises")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GymAppData.Models.Set", b =>
                {
                    b.HasOne("GymAppData.Models.Exercise", "Exercise")
                        .WithMany("Sets")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GymAppData.Models.SetRecord", b =>
                {
                    b.HasOne("GymAppData.Models.Set", "Set")
                        .WithMany()
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GymAppData.Models.WorkoutSession", "WorkoutSession")
                        .WithMany()
                        .HasForeignKey("WorkoutSessionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GymAppData.Models.WorkoutSession", b =>
                {
                    b.HasOne("GymAppData.Models.Day", "Day")
                        .WithMany()
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}