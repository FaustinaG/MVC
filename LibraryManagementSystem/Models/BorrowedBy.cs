using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class BorrowedBy
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Issue Date")]
        public DateTime IssueDate { get; set; }
        [Required]
        [DisplayName("Return Date")]
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        [DisplayName("Member")]
        [Required]
        public int MemberId { get; set; }
        [DisplayName("Book")]
        [Required]
        public int BookId { get; set; }

        public virtual Member Member { get; set; }
        public virtual Book Book { get; set; }
    }
}