using System;

namespace FCManagement.Models
{
    public class WorkoutDTO
    {
        public Guid WorkoutId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
