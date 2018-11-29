using System;
using System.Collections.Generic;
using System.Linq;
using GymAppData.Models;
using Microsoft.EntityFrameworkCore;

namespace GymAppCore.Services
{
    public class WorkoutInformationService : IWorkoutInformationService
    {

        public Day GetDay(int dayId)
        {
            using (var db = new WorkoutDb())
            {
                var day = db.Days
                    .Include(x => x.Exercises)
                    .ThenInclude(x => x.Sets)
                    .First(x => x.DayId == dayId);

                foreach (var exercise in day.Exercises)
                {
                    exercise.Sets = exercise.Sets.OrderBy(x => x.Order).ToList();
                }
                day.Exercises = day.Exercises.OrderBy(x => x.Order).ToList();
                return day;
            }
        }

        public Workout GetWorkoutForSession(int workoutId, Guid userId)
        {
            using (var db = new WorkoutDb())
            {
                var workout = db.Workouts
                    .Include(x => x.Days)
                    .ThenInclude(x => x.Exercises)
                    .ThenInclude(x => x.Sets)
                    .First(x => x.WorkoutId == workoutId);

                workout.Days.RemoveAll(x=> x.IsDeleted);
                workout.Days.ForEach(x => x.Exercises.RemoveAll(y=> y.IsDeleted));

                return OrderWorkout(workout);
            }
        }

        public Workout GetWorkout(int workoutId)
        {
            using (var db = new WorkoutDb())
            {
                var workout = db.Workouts
                    .Include(x => x.Days)
                    .ThenInclude(x => x.Exercises)
                    .ThenInclude(x => x.Sets)
                    .First(x => x.WorkoutId == workoutId);

                //Occasionally the order gets totally out of whack and needs to be repaired.
                //var saveFixedOrdering = CheckOrderIntegrity(workout);

                //if (saveFixedOrdering)
                //    db.SaveChanges();

                
                return OrderWorkout(workout);
            }
        }

        private Workout OrderWorkout(Workout workout)
        {
            workout.Days = workout.Days.OrderBy(x => x.Order).ToList();
            foreach (var day in workout.Days)
            {
                day.Exercises = day.Exercises.OrderBy(x => x.Order).ToList();
                day.Exercises.Where(x=> x.Sets.Any()).ToList().ForEach(x=> x.Sets = x.Sets.OrderBy(y=> y.Order).ToList() );
            }

            return workout;
        }

        private bool CheckOrderIntegrity(Workout workout)
        {
            var orderingNeedsSaving = false;
            if(workout.Days.Any(x=> workout.Days.Any(y=> y.Order == x.Order && y.DayId != x.DayId))
                || workout.Days.Any(x=> x.Order == 0 || x.Order > workout.Days.Count))
            {
                orderingNeedsSaving = true;
                var order = 1;
                foreach(var day in workout.Days.OrderBy(x=> x.DayId))
                {
                    day.Order = order;
                    order++;
                }
            }

            foreach (var day in workout.Days)
            {
                var orderFixed = CheckDayForOrderIntegrity(day);
                if (orderFixed)
                    orderingNeedsSaving = true;
            }

            return orderingNeedsSaving;
        }

        private bool CheckDayForOrderIntegrity(Day day)
        {
            var orderingNeedsSaving = false;
            if (day.Exercises.Any(x => day.Exercises.Any(y => y.Order == x.Order && y.ExerciseId != x.ExerciseId))
                || day.Exercises.Any(x => x.Order == 0 || x.Order > day.Exercises.Count))
            {
                orderingNeedsSaving = true;
                var order = 1;
                foreach (var Exercise in day.Exercises.OrderBy(x => x.ExerciseId))
                {
                orderingNeedsSaving = true;
                    Exercise.Order = order;
                    order++;
                }
            }

            foreach (var exercise in day.Exercises)
            {
                var orderFixed = CheckExerciseOrderIntegrity(exercise);
                if (orderFixed)
                    orderingNeedsSaving = true;
            }

            return orderingNeedsSaving;
        }

        private bool CheckExerciseOrderIntegrity(Exercise exercise)
        {
            var orderingNeedsSaving = false;
            if (exercise.Sets.Any(x => exercise.Sets.Any(y => y.Order == x.Order && y.SetId != x.SetId))
                || exercise.Sets.Any(x => x.Order == 0 || x.Order > exercise.Sets.Count))
            {
                orderingNeedsSaving = true;
                var order = 1;
                foreach (var Set in exercise.Sets.OrderBy(x => x.SetId))
                {
                    orderingNeedsSaving = true;
                    Set.Order = order;
                    order++;
                }
            }

            return orderingNeedsSaving;
        }

        public List<Workout> GetWorkouts(Guid userId)
        {
            using (var db = new WorkoutDb())
            {
                var workouts = db.Workouts
                    .Where(x => x.OwnerId == userId.ToString())
                    .Include(x => x.Days)
                    .ToList();
                return workouts;
            }
        }
    }
}
