using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Publisher
    {
        public Publisher()
        {
            IsActive = true;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Address")]
        public int ? AddressId { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}