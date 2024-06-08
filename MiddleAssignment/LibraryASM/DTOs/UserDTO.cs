using Library.Models;

namespace Library.DTOs
{
    public class ResponseUserDTO
    {
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public Role UserRole { get; set; }
    }
    public class RequestUserDTO
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public Role UserRole { get; set; }
    }
}