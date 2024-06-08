using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
        //public int PageNumber { get; set; } = 1;
        //public int PageSize { get; set; } = 20;
    }
}
