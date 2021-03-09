using System;

namespace FCManagement.Models
{
    public class MemberDTO
    {
        public Guid MemberId { get; set; }
        public string FullName { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime EndOfMembership { get; set; }
    }
}
