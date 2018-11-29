using GymAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymAppCore.Services
{
    public interface IWorkoutInformationService
    {
        Workout GetWorkout(int workoutId);
        List<Workout> GetWorkouts(Guid userId);
        Day GetDay(int dayId);
        Workout GetWorkoutForSession(int workoutId, Guid userId);
    }
}
