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


        [Required, Column(TypeName = "date")]
        public DateTime WorkoutDate { get; set; }


        [Required]
        public TimeSpan WorkoutTime { get; set; }


        public Guid InstructorId { get; set; }
        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; }

        public Guid MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }

        public Guid WorkoutId { get; set; }
        [ForeignKey(nameof(WorkoutId))]
        public Workout Workout { get; set; }
    }
}
