using System;

namespace FCManagement.Models
{
    public class MembershipDTO
    {
        public Guid MembershipId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int MembershipPeriod { get; set; }//max 178 - half a year
    }
}
