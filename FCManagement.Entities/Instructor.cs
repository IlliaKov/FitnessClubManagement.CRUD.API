using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FCManagement.Entities
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InstructorId { get; set; }


        [Required, MaxLength(35), MinLength(5, ErrorMessage = "Instructor's full name must be at least 5 characters or more")]
        public string FullName { get; set; }


        [Column(TypeName = "char")]
        public char Gender { get; set; }

        [Required, MaxLength(35), MinLength(5)]
        public string Email { get; set; }



        [MaxLength(15), MinLength(5)]
        public string HomeAddress { get; set; }
        [Required, MaxLength(15), MinLength(5)]
        public string PhoneNumber { get; set; }
    }
}
