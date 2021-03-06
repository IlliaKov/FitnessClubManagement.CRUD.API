using System;

namespace FCManagement.Models
{
    public class InstructorDTO
    {
        public Guid InstructorId { get; set; }
        public string FullName { get; set; }
        public char Gender { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
    }
}
