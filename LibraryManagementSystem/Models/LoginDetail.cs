using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class LoginDetail
    {
        public LoginDetail()
        {
            IsActive = true;
        }
        public enum UserTypes
        {
            Admin,
            LibraryMember
        }
        public int Id { get; set; }
        [Required]
        [DisplayName("Login Name")]
        [StringLength(30)]
        public string LoginName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        [DisplayName("Active")]
        public bool IsActive { get; set; }
        [Required]
        [DisplayName("User Type")]
        public UserTypes TypeofUser { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}