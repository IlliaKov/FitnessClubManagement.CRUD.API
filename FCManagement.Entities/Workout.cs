using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FCManagement.Entities
{
    public class Workout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid WorkoutId { get; set; }


        [Required, MaxLength(15), MinLength(5)]
        public string Name { get; set; }


        [MaxLength(77), MinLength(0)]
        public string Description { get; set; }
    }
}
