using Library.Models;

namespace LibraryASM.DTOs
{
    public class BookBorrowingResponseDTO
    {
        public Guid RequestId { get; set; }
        public DateTime DateRequested { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public Guid UserId { get; set; }
        public ICollection<BookBorrowingRequestDetailDTO> BorrowingRequestDetails { get; set; }
    }
    public class BookBorrowingResquestDTO
    {
        public RequestStatus RequestStatus { get; set; }
        public Guid UserId { get; set; }
        public ICollection<BookBorrowingRequestDetailDTO> BorrowingRequestDetails { get; set; }
    }
}