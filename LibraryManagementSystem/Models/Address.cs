using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Address
    {
        public Address()
        {
            IsActive = true;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Address Line1")]
        public string AddressLine1 { get; set; }
        [DisplayName("Address Line2")]
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Pincode { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Publisher> Publishers { get; set; }
    }
}