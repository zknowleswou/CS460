using System;
using System.Linq;
using GymAppData.Models;
using Microsoft.EntityFrameworkCore;

namespace GymAppData.Repositories
{
    public interface IRecordWorkoutRepository
    {
        Day GetDay(int dayId);
        void RecordSet(Set set);
    }

    public class RecordWorkoutRepository : IRecordWorkoutRepository
    {
        public Day GetDay(int dayId)
        {
            using (var context = new WorkoutDb())
            {
                return context.Days.Include(x => x.Workout)
                                   .Include(x => x.Exercises.Select(y => y.Sets)).First(x => x.DayId == dayId);
            }
        }

        public void RecordSet(Set set)
        {
            throw new NotImplementedException();
        }
    }
}