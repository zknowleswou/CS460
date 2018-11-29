using GymAppData.Models;
using System;

namespace GymAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Saving workout to DB.");
            var db = new WorkoutDb();
            var alexWorkout = new AlexsWorkout().DefineWorkout();
            var zachWorkout = new ZachsWorkout().DefineWorkout();

            db.Workouts.Add(alexWorkout);
            db.Workouts.Add(zachWorkout);
            db.SaveChanges();
            Console.WriteLine("Workout saved.");

            Console.ReadKey();
        }

    }
}
