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

        [Required, MaxLength(15), MinLength(5)]
        public string Name { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public int MembershipPeriod { get; set; }//max 178 - half a year

        public Guid MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }
    }
}
