using System;
using System.Collections.Generic;
using System.Linq;
using GymAppData.Models;
using Microsoft.EntityFrameworkCore;

namespace GymAppData.Repositories
{
    public interface IDesignWorkoutRepository
    {
        Workout CreateWorkout(Workout workout);
        List<Workout> GetWorkouts(Guid userId);
        Workout GetWorkout(int workoutId);
        Day CreateNewDay(Day day);
        void UpdateDay(Day day);
        Exercise CreateExercise(Exercise exercise);
        Set CreateSet(Set set);
        void UpdateExercise(Exercise exercise);
        void UpdateSet(Set set);
        Guid GetOwnerIdForDay(int dayId);
        Guid GetOwnerIdForExercise(int exerciseId);
        Guid GetOwnerIdForSet(int setId);
        void DeleteDay(int dayId);
        void DeleteExercise(int exerciseId);
        void DeleteSet(int setId);
    }

    public class DesignWorkoutRepository : IDesignWorkoutRepository
    {
        public Workout CreateWorkout(Workout workout)
        {
            using (var context = new WorkoutDb())
            {
                context.Workouts.Add(workout);
                context.SaveChanges();
                return workout;
            }
        }

        public List<Workout> GetWorkouts(Guid userId)
        {
            using (var context = new WorkoutDb())
            {
                var workouts = context.Workouts.Include(x=> x.Days).Where(x => x.OwnerId == userId.ToString()).ToList();
                workouts.ForEach(x=> x.Days = x.Days.Where(y=> y.IsDeleted == false).ToList());
                return workouts;
            }
        }

        public Workout GetWorkout(int workoutId)
        {
            using (var context = new WorkoutDb())
            {
                var workout = context.Workouts.Include(x => x.Days.Select(y => y.Exercises.Select(z => z.Sets))).Single(x => x.WorkoutId == workoutId);

                workout.Days = workout.Days.Where(x => x.IsDeleted == false).ToList();

                foreach (var day in workout.Days)
                {
                    day.Exercises = day.Exercises.Where(x => x.IsDeleted == false).ToList();
                    foreach (var exercise in day.Exercises)
                    {
                        exercise.Sets = exercise.Sets.Where(x => x.IsDeleted == false).ToList();
                    }
                }

                return workout;
            }
        }

        public Day CreateNewDay(Day day)
        {
            using (var context = new WorkoutDb())
            {
                context.Days.Add(day);
                context.SaveChanges();
                return day;
            }
        }

        public void UpdateDay(Day day)
        {
            using (var context = new WorkoutDb())
            {
                context.Days.Attach(day);
                context.Entry(day).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UpdateExercise(Exercise exercise)
        {
            using (var context = new WorkoutDb())
            {
                context.Exercises.Attach(exercise);
                context.Entry(exercise).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void UpdateSet(Set set)
        {
            using (var context = new WorkoutDb())
            {
                context.Sets.Attach(set);
                context.Entry(set).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Guid GetOwnerIdForDay(int dayId)
        {
            using (var context = new WorkoutDb())
            {
                return new Guid(context.Days.Single(x => x.DayId == dayId).Workout.OwnerId);
            }
        }

        public Guid GetOwnerIdForExercise(int exerciseId)
        {
            using (var context = new WorkoutDb())
            {
                return new Guid(context.Exercises.Single(x => x.ExerciseId == exerciseId).Day.Workout.OwnerId);
            }
        }

        public Guid GetOwnerIdForSet(int setId)
        {
            using (var context = new WorkoutDb())
            {
                return new Guid(context.Sets.Single(x => x.SetId == setId).Exercise.Day.Workout.OwnerId);
            }
        }

        public void DeleteDay(int dayId)
        {
            using (var context = new WorkoutDb())
            {
                var day = context.Days.Single(x=> x.DayId == dayId);
                day.IsDeleted = true;

                foreach (var exercise in day.Exercises)
                {
                    exercise.IsDeleted = true;
                    foreach (var set in exercise.Sets)
                    {
                        set.IsDeleted = true;
                    }
                }

                context.SaveChanges();
            }
        }

        public void DeleteExercise(int exerciseId)
        {
            using (var context = new WorkoutDb())
            {
                var exercise = context.Exercises.Single(x => x.ExerciseId == exerciseId);
                exercise.IsDeleted = true;

                foreach (var set in exercise.Sets)
                {
                    set.IsDeleted = true;
                }
                context.SaveChanges();
            }
        }

        public void DeleteSet(int setId)
        {
            using (var context = new WorkoutDb())
            {
                context.Sets.Single(x => x.SetId == setId).IsDeleted = true;
                context.SaveChanges();
            }
        }

        public Exercise CreateExercise(Exercise exercise)
        {
            using (var context = new WorkoutDb())
            {
                context.Exercises.Add(exercise);
                context.SaveChanges();
                return exercise;
            }
        }

        public Set CreateSet(Set set)
        {
            using (var context = new WorkoutDb())
            {
                context.Sets.Add(set);
                context.SaveChanges();

                return set;
            }
        }
    }
}