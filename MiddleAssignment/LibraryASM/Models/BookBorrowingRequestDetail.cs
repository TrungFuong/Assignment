using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class BookBorrowingRequestDetail
    {
        [ForeignKey("BookId")]
        [Required]
        public Guid BookId { get; set; }
        [Required]
        [ForeignKey("RequestId")]
        public Guid RequestId { get; set;}
        public BookBorrowingRequest BookBorrowingRequest { get; set; }
        public Book Book { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
