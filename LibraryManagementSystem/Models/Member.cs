using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        public enum MemberShipTypes
        {
            Permanent,
            Temporary
        }
        [Required]
        public int Id { get; set; }
        [DisplayName("MemberShip Type")]
        public MemberShipTypes TypeOfMembership { get; set; }
        [DisplayName("Student")]
        public bool IsStudent { get; set; }
        [Required]
        [DisplayName("Expiry Date")]
        public DateTime ExpiryDate { get; set; }
        [DisplayName("User")]
        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<BorrowedBy> BorrowedBies { get; set; } 
    }
}