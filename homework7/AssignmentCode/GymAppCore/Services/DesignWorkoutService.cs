using System;
using System.Collections.Generic;
using System.Linq;
using GymAppData.Models;
using Microsoft.EntityFrameworkCore;

namespace GymAppCore.Services
{
    public class DesignWorkoutService : IDesignWorkoutService
    {
        private const string _deleteKeyWord = "delete";
        public Day CreateDay(Day day)
        {
            using (var db = new WorkoutDb())
            {
                var order = db.Days.Count(x => x.WorkoutId == day.WorkoutId && !x.IsDeleted) + 1;
                day.Order = order;
                db.Days.Add(day);
                db.SaveChanges();
                day.Exercises = new List<Exercise>();
                return day;
            }
        }

        public Exercise CreateExercise(Exercise exercise)
        {
            using (var db = new WorkoutDb())
            {
                var order = db.Exercises.Count(x => x.DayId == exercise.DayId && !x.IsDeleted) + 1;
                exercise.Order = order;
                db.Exercises.Add(exercise);
                db.SaveChanges();
                exercise.Sets = new List<Set>();
                return exercise;
            }
        }

        public Workout CreateNewWorkout(Workout workout, Guid userId)
        {
            using (var db = new WorkoutDb())
            {
                workout.OwnerId = userId.ToString();

                db.Workouts.Add(workout);
                db.SaveChanges();
                workout.Days = new List<Day>();
                return workout;
            }
        }

        public Set CreateSet(Set set)
        {
            using (var db = new WorkoutDb())
            {
                var order = db.Sets.Count(x => x.ExerciseId == set.ExerciseId && !x.IsDeleted) + 1;
                set.Order = order;
                db.Sets.Add(set);
                db.SaveChanges();
                return set;
            }
        }

        public Day DeleteDay(Day day, Guid userId)
        {
            using (var db = new WorkoutDb())
            {
                if(day.Workout == null)
                {
                    day.Workout = db.Workouts.Find(day.WorkoutId);
                }
                if (day.Workout.OwnerId == userId.ToString())
                {
                    day.IsDeleted = true;
                    db.Days.Find(day.DayId).IsDeleted = true;
                    db.SaveChanges();
                    return day;
                }
                return day;
            }
        }

        public Exercise DeleteExercise(Exercise exercise, Guid userId)
        {
            using (var db = new WorkoutDb())
            {
                if (exercise.Day == null)
                {
                    exercise.Day = db.Days.Find(exercise.DayId);
                }

                if (exercise.Day.Workout == null)
                {
                    exercise.Day.Workout = db.Workouts.Find(exercise.Day.WorkoutId);
                }

                
                if (exercise.Day.Workout.OwnerId == userId.ToString())
                {
                    exercise.IsDeleted = true;
                    db.Exercises.Find(exercise.ExerciseId).IsDeleted = true;
                    db.SaveChanges();
                    return exercise;
                }

                return exercise;
            }
        }

        public Set DeleteSet(Set set, Guid userId)
        {
            using (var db = new WorkoutDb())
            {
                if (set.Exercise == null)
                {
                    set.Exercise = db.Exercises.Find(set.ExerciseId);
                }
                if (set.Exercise.Day == null)
                {
                    set.Exercise.Day = db.Days.Find(set.Exercise.DayId);
                }

                if (set.Exercise.Day.Workout == null)
                {
                    set.Exercise.Day.Workout = db.Workouts.Find(set.Exercise.Day.WorkoutId);
                }


                if (set.Exercise.Day.Workout.OwnerId == userId.ToString())
                {
                    set.IsDeleted = true;
                    db.Sets.Find(set.SetId).IsDeleted = true;
                    db.SaveChanges();
                    return set;
                }

                return set;
            }
        }

        public Day UpdateDay(Day day, Guid userId)
        {
            if(string.Equals(day.Name, _deleteKeyWord, StringComparison.InvariantCultureIgnoreCase))
            {
                return DeleteDay(day, userId);
            }
            using (var db = new WorkoutDb())
            {
                var previousDay = db.Days.Find(day.DayId);
                if (previousDay.Order != day.Order)
                {
                    if (previousDay.Order - day.Order + 1 > 0)
                    {
                        var orderUpdates = db.Days.Where(x => x.Order >= day.Order && x.Order < previousDay.Order && x.DayId != day.DayId && x.WorkoutId == day.WorkoutId).ToList();
                        orderUpdates.ForEach(x => x.Order++);
                    }
                    else
                    {
                        var orderUpdates = db.Days.Where(x => x.Order > previousDay.Order && x.Order <= day.Order + 1 && x.DayId != day.DayId && x.WorkoutId == day.WorkoutId).ToList();
                        orderUpdates.ForEach(x => x.Order--);
                    }
                    db.SaveChanges();
                }

                db.Entry(previousDay).State = EntityState.Detached;

                db.Update(day);
                db.SaveChanges();
                return day;
            }
        }

        public Exercise UpdateExercise(Exercise exercise, Guid userId)
        {
            if (string.Equals(exercise.Name, _deleteKeyWord, StringComparison.InvariantCultureIgnoreCase))
            {
                return DeleteExercise(exercise, userId);
            }
            using (var db = new WorkoutDb())
            {
                var previousExercise = db.Exercises.Find(exercise.ExerciseId);
                if (previousExercise.Order != exercise.Order)
                {
                    if (previousExercise.Order - exercise.Order + 1 > 0)
                    {
                        var orderUpdates = db.Exercises.Where(x => x.Order >= exercise.Order && x.Order < previousExercise.Order && x.ExerciseId != exercise.ExerciseId && x.DayId == exercise.DayId).ToList();
                        orderUpdates.ForEach(x => x.Order++);
                    }
                    else
                    {
                        var orderUpdates = db.Exercises.Where(x => x.Order > previousExercise.Order && x.Order <= exercise.Order + 1 && x.ExerciseId != exercise.ExerciseId && x.DayId == exercise.DayId).ToList();
                        orderUpdates.ForEach(x => x.Order--);
                    }
                    db.SaveChanges();
                }

                db.Entry(previousExercise).State = EntityState.Detached;

                db.Update(exercise);
                db.SaveChanges();
                return exercise;
            }
        }

        public Set UpdateSet(Set set, Guid userId)
        {
            if (string.Equals(set.Name, _deleteKeyWord, StringComparison.InvariantCultureIgnoreCase))
            {
                return DeleteSet(set, userId);
            }
            using (var db = new WorkoutDb())
            {
                var previousSet = db.Sets.Find(set.SetId);
                if (previousSet.Order != set.Order)
                {
                    if (previousSet.Order - set.Order + 1 > 0)
                    {
                        var orderUpdates = db.Sets.Where(x => x.Order >= set.Order && x.Order < previousSet.Order && x.SetId != set.SetId && x.ExerciseId == set.ExerciseId).ToList();
                        orderUpdates.ForEach(x => x.Order++);
                    }
                    else
                    {
                        var orderUpdates = db.Sets.Where(x => x.Order > previousSet.Order && x.Order <= set.Order + 1 && x.SetId != set.SetId && x.ExerciseId == set.ExerciseId).ToList();
                        orderUpdates.ForEach(x => x.Order--);
                    }
                    db.SaveChanges();
                }

                db.Entry(previousSet).State = EntityState.Detached;

                db.Update(set);
                db.SaveChanges();
                return set;
            }
        }

        public Workout UpdateWorkout(Workout workout)
        {
            using(var db = new WorkoutDb())
            {
                db.Update(workout);
                db.SaveChanges();
                return workout;
            }
        }
    }
}
