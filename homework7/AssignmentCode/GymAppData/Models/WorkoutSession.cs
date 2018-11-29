using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppData.Models
{
    public class WorkoutSession
    {
        public int WorkoutSessionId { get; set; }
        public int DayId { get; set; }
        public Guid UserId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Ended { get; set; }
        public virtual Day Day { get; set; }
    }
}
