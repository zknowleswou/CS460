using GymAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymAppCore.Services
{
    public interface IDesignWorkoutService
    {
        Day CreateDay(Day day);
        Exercise CreateExercise(Exercise exercise);
        Set CreateSet(Set set);
        Day UpdateDay(Day day, Guid userId);
        Workout CreateNewWorkout(Workout workout, Guid userId);
        Exercise UpdateExercise(Exercise exercise, Guid guid);
        Set UpdateSet(Set set, Guid guid);
        Day DeleteDay(Day day, Guid userId);
        Exercise DeleteExercise(Exercise exerciseId, Guid userId);
        Set DeleteSet(Set setId, Guid userId);
        Workout UpdateWorkout(Workout workout);
    }
}
