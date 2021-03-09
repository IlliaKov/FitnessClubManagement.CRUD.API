using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FCManagement.Entities
{
    public class WorkoutPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid WorkoutPlanId { get; set; }
        public DateTime WorkoutDate { get; set; }
        public int WorkoutTime { get; set; }

        public int InstructorId { get; set; }
        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; }

        public int MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }

        public int WorkoutId { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public Member Workout { get; set; }
    }
}
