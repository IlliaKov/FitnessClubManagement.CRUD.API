using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FCManagement.Entities
{
    public class Membership
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MembershipId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int MembershipPeriod { get; set; }//max 178 - half a year

        public Guid MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }
    }
}
