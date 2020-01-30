using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public Book()
        {
            IsActive = true;
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Author")]
        public int ? AuthorId { get; set; }
        [DisplayName("Publisher")]
        public int ? PublisherId { get; set; }
        [DisplayName("Total Count")]
        public int TotalCount { get; set; }
        [DisplayName("Available Count")]
        public int AvailableCount { get; set; }
        [DisplayName("Borrowed Count")]
        public int BorrowedCount { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<BorrowedBy> BorrowedBies { get; set; }
    }
}