namespace Library.DTOs
{
    public class ResponseCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class RequestCategoryDTO
    {
        public string CategoryName { get; set; }
    }
}
