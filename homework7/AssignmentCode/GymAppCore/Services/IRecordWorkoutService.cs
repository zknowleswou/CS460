using GymAppData.Models;
using System;
using System.Collections.Generic;

namespace GymAppCore.Services
{
    public interface IRecordWorkoutService
    {
        WorkoutSession CreateWorkoutSession(int dayId, Guid userId);
        WorkoutSession UpdateWorkoutSession(WorkoutSession workoutSession);
        SetRecord CreateOrUpdateSetRecord(SetRecord setRecord);
        List<WorkoutSession> GetIncompleteSessions(Guid userId);
        List<SetRecord> GetWorkoutSession(int workoutSessionId, Guid userId);
    }
}
