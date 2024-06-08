using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class BookBorrowingRequest
    {
        [Key]
        [Required]
        public Guid RequestId{ get; set; }
        [Required]
        public DateTime DateRequested { get; set; }
        public RequestStatus RequestStatus { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<BookBorrowingRequestDetail> BorrowingRequestDetails { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
