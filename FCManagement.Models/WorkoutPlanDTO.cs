using System;

namespace FCManagement.Models
{
    public class WorkoutPlanDTO
    {
        public Guid WorkoutPlanId { get; set; }
        public DateTime WorkoutDate { get; set; }
        public int WorkoutTime { get; set; }
    }
}
