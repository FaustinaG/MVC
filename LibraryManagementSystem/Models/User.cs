using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class User
    {
        public User()
        {
            IsActive = true;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }
        [DisplayName("Address")]
        public int ? AddressId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [DisplayName("Login Name")]
        [Required]
        public int LoginDetailId { get; set; }

        public virtual Address Address { get; set; }
        public virtual LoginDetail LoginDetail { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}