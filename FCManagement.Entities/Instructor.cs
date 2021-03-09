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
        public string FullName { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }
        public string HomeAdress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
