using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GymAppData.Models
{
    public class WorkoutDb : DbContext
    {
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Set> Sets { get; set; }
        public virtual DbSet<Workout> Workouts { get; set; }
        public virtual DbSet<SetRecord> SetRecords { get; set; }
        public virtual DbSet<WorkoutSession> WorkoutSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .Property(b => b.Created)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Workout>()
                .Property(b => b.WorkoutId)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Exercise>()
                .Property(b => b.Created)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Exercise>()
                .Property(b => b.ExerciseId)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Day>()
                .Property(b => b.Created)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Day>()
                .Property(b => b.DayId)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Set>()
                .Property(b => b.Created)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Set>()
                .Property(b => b.SetId)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<SetRecord>()
                .Property(b => b.Created)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<SetRecord>()
                .Property(b => b.SetRecordId)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<SetRecord>()
                .HasOne(x => x.WorkoutSession)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutSession>()
                .Property(b => b.Created)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<WorkoutSession>()
                .Property(b => b.WorkoutSessionId)
                .UseSqlServerIdentityColumn();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:gymappdb.database.windows.net,1433;Initial Catalog=GymAppDb;Persist Security Info=False;User ID=zknowles;Password=Fearisthemindkiller1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .HasData(
                new Workout
                {
                    WorkoutId = 0,
                    Name = "Zach's Test Workout",
                    Days = new List<Day>
                    {
                        new Day
                        {
                            Name = "Day A",
                            Order = 1,
                            WorkoutId = 0,
                            Exercises = new List<Exercise>
                            {
                                new Exercise
                                {
                                    Name = "Bench Press",
                                    Order = 1,
                                    DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            ExerciseId = 0,
                                            Name = "Set 1",
                                            Repititions = 12,
                                            Weight = 20m
                                        },
                                        new Set
                                        {
                                            ExerciseId = 0,
                                            Name = "Set 2",
                                            Repititions = 12,
                                            Weight = 20m
                                        },
                                        new Set
                                        {
                                            ExerciseId = 0,
                                            Name = "Set 3",
                                            Repititions = 12,
                                            Weight = 20m
                                        },
                                    }
                                }
                            }
                        }
                    }
                });
        }
    }
}
