using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }
        [Required]
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string BookAuthor { get; set; }
        public int BookQuantity { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public BookBorrowingRequestDetail BookBorrowingRequestDetail { get; set; }
        //public int PageNumber { get; set; } = 1;
        //public int PageSize { get; set; } = 20;
    }
}
