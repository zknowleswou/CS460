using System;
using System.Collections.Generic;
using System.Linq;
using GymAppData.Models;

namespace GymAppCore.Services
{
    public class RecordWorkoutService : IRecordWorkoutService
    {
        public SetRecord CreateOrUpdateSetRecord(SetRecord setRecord)
        {
            using (var db = new WorkoutDb())
            {
                if (db.SetRecords.Any(x => x.SetRecordId == setRecord.SetRecordId))
                {
                    db.Update(setRecord);
                }
                else
                {
                    db.Add(setRecord);
                }

                db.SaveChanges();

                return setRecord;
            }
        }

        public List<WorkoutSession> GetIncompleteSessions(Guid userId)
        {
            using (var db = new WorkoutDb())
            {
                var incompleteSessions =
                    db.WorkoutSessions.Where(x => x.UserId == userId && !x.IsCompleted).ToList();
                return incompleteSessions;
            }
        }

        public List<SetRecord> GetWorkoutSession(int workoutSessionId, Guid userId)
        {
            using (var db = new WorkoutDb())
            {
                var records = db.SetRecords.Where(x =>
                    x.WorkoutSessionId == workoutSessionId && x.WorkoutSession.UserId == userId).ToList();
                return records;
            }
        }

        public WorkoutSession CreateWorkoutSession(int dayId, Guid userId)
        {
            using (var db = new WorkoutDb())
            {
                var session = new WorkoutSession
                {
                    DayId = dayId,
                    UserId = userId,
                    IsCompleted = false
                };

                db.WorkoutSessions.Add(session);
                db.SaveChanges();

                return session;
            }
        }

        public WorkoutSession UpdateWorkoutSession(WorkoutSession workoutSession)
        {
            using (var db = new WorkoutDb())
            {
                workoutSession.Ended = DateTime.Now;
                db.Update(workoutSession);
                db.SaveChanges();
                return workoutSession;
            }
        }
    }
}
