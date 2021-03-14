using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCManagement.Entities
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MemberId { get; set; }

        [Required, MaxLength(35), MinLength(5, ErrorMessage ="Member's full name must be at least 5 characters or more")]
        public string FullName { get; set; }

        [Column(TypeName = "char")]
        public char Gender { get; set; }

        [Required, MaxLength(2), MinLength(1)]
        public int Age { get; set; }


        [Required, Column(TypeName="date")]
        public DateTime Birthday { get; set; }


        [Required, MaxLength(35), MinLength(10)]
        public string Email { get; set; }


        [MaxLength(25), MinLength(5)]
        public string HomeAddress { get; set; }


        [Required, MaxLength(15), MinLength(5)]
        public string PhoneNumber { get; set; }


        [Column(TypeName="date"), Required] 
        public DateTime JoiningDate { get; set; }


        [Column(TypeName = "date"), Required]
        public DateTime EndOfMembership { get; set; }
    }
}
