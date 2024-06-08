using Library.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DTOs
{
    public class RequestBookDTO
    {
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string BookAuthor { get; set; }
        public int BookQuantity { get; set; }
        public int CategoryId { get; set; }
    } 
    public class ResponseBookDTO
    {
        public Guid BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public string BookAuthor { get; set; }
        public int BookQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
