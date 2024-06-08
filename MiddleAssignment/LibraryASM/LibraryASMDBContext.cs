using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryASM
{
    public class LibraryASMDBContext : DbContext
    {
        public LibraryASMDBContext(DbContextOptions<LibraryASMDBContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }
        public DbSet<BookBorrowingRequestDetail> BookBorrowingRequestDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.BookBorrowingRequests)
                .WithOne(bbr => bbr.User)
                .HasForeignKey(bbr => bbr.UserId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<BookBorrowingRequest>()
                .HasOne(bbr => bbr.User)
                .WithMany(u => u.BookBorrowingRequests)
                .HasForeignKey(bbr => bbr.UserId);

            modelBuilder.Entity<BookBorrowingRequest>()
                .HasMany(bbr => bbr.BorrowingRequestDetails)
                .WithOne(bbrd => bbrd.BookBorrowingRequest)
                .HasForeignKey(bbrd => bbrd.RequestId);

            modelBuilder.Entity<BookBorrowingRequestDetail>()
                .HasKey(bbrd => new { bbrd.RequestId, bbrd.BookId });

            // Seed data
            var johnId = Guid.NewGuid();
            var janeId = Guid.NewGuid();
            var jakeId = Guid.NewGuid();
            var book1Id = Guid.NewGuid();
            var book2Id = Guid.NewGuid();
            var request1 = Guid.NewGuid();
            var request2 = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User { UserId = johnId, UserName = "John Doe", Password = "1", UserEmail = "john@gmail.com", UserPhone = "0912345678", Role = Role.SuperUser },
                new User { UserId = janeId, UserName = "Jane Smith", Password = "2", UserEmail = "jane@gmail.com", UserPhone = "135098123", Role = Role.NormalUser },
                new User { UserId = jakeId, UserName = "Jake Brown", Password = "3", UserEmail = "jake@gmail.com", UserPhone = "135123534", Role = Role.NormalUser }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Romance" },
                new Category { CategoryId = 2, CategoryName = "Fiction" },
                new Category { CategoryId = 3, CategoryName = "Mystery" },
                new Category { CategoryId = 4, CategoryName = "Thriller" },
                new Category { CategoryId = 5, CategoryName = "Science Fiction" },
                new Category { CategoryId = 6, CategoryName = "Fantasy" },
                new Category { CategoryId = 7, CategoryName = "Horror" },
                new Category { CategoryId = 8, CategoryName = "Adventure" },
                new Category { CategoryId = 9, CategoryName = "Historical Fiction" },
                new Category { CategoryId = 10, CategoryName = "Biography" },
                new Category { CategoryId = 11, CategoryName = "Self-Help" },
                new Category { CategoryId = 12, CategoryName = "Business" },
                new Category { CategoryId = 13, CategoryName = "Cooking" },
                new Category { CategoryId = 14, CategoryName = "Travel" },
                new Category { CategoryId = 15, CategoryName = "Art" },
                new Category { CategoryId = 16, CategoryName = "Music" },
                new Category { CategoryId = 17, CategoryName = "Sports" },
                new Category { CategoryId = 18, CategoryName = "History" },
                new Category { CategoryId = 19, CategoryName = "Religion" },
                new Category { CategoryId = 20, CategoryName = "Philosophy" },
                new Category { CategoryId = 21, CategoryName = "Psychology" },
                new Category { CategoryId = 22, CategoryName = "Science" },
                new Category { CategoryId = 23, CategoryName = "Technology" },
                new Category { CategoryId = 24, CategoryName = "Education" },
                new Category { CategoryId = 25, CategoryName = "Politics" },
                new Category { CategoryId = 26, CategoryName = "Law" },
                new Category { CategoryId = 27, CategoryName = "Medicine" },
                new Category { CategoryId = 28, CategoryName = "Fashion" },
                new Category { CategoryId = 29, CategoryName = "Design" },
                new Category { CategoryId = 30, CategoryName = "Gardening" },
                new Category { CategoryId = 31, CategoryName = "Parenting" },
                new Category { CategoryId = 32, CategoryName = "Psychology" },
                new Category { CategoryId = 33, CategoryName = "Science" },
                new Category { CategoryId = 34, CategoryName = "Technology" },
                new Category { CategoryId = 35, CategoryName = "Education" },
                new Category { CategoryId = 36, CategoryName = "Politics" },
                new Category { CategoryId = 37, CategoryName = "Law" },
                new Category { CategoryId = 38, CategoryName = "Medicine" },
                new Category { CategoryId = 39, CategoryName = "Fashion" },
                new Category { CategoryId = 40, CategoryName = "Design" },
                new Category { CategoryId = 41, CategoryName = "Gardening" },
                new Category { CategoryId = 42, CategoryName = "Parenting" },
                new Category { CategoryId = 43, CategoryName = "Psychology" },
                new Category { CategoryId = 44, CategoryName = "Science" },
                new Category { CategoryId = 45, CategoryName = "Technology" },
                new Category { CategoryId = 46, CategoryName = "Education" },
                new Category { CategoryId = 47, CategoryName = "Politics" },
                new Category { CategoryId = 48, CategoryName = "Law" },
                new Category { CategoryId = 49, CategoryName = "Medicine" },
                new Category { CategoryId = 50, CategoryName = "Fashion" },
                new Category { CategoryId = 51, CategoryName = "Design" },
                new Category { CategoryId = 52, CategoryName = "Gardening" },
                new Category { CategoryId = 53, CategoryName = "Parenting" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = book1Id, BookTitle = "Book 1", BookAuthor = "Tao", CategoryId = 1, BookQuantity = 3, BookDescription = "lorem ipsum" },
                new Book { BookId = book2Id, BookTitle = "Book 2", BookAuthor = "Josh", CategoryId = 2, BookQuantity = 2, BookDescription = "irem lopsum" },
                new Book { BookId = Guid.NewGuid(), BookTitle = "Book 3", BookAuthor = "Josh", CategoryId = 43, BookQuantity = 5, BookDescription = "irem lopsum" },
                new Book { BookId = Guid.NewGuid(), BookTitle = "Book 4", BookAuthor = "Josh", CategoryId = 24, BookQuantity = 8, BookDescription = "irem lopsum" },
                new Book { BookId = Guid.NewGuid(), BookTitle = "Book 5", BookAuthor = "Josh", CategoryId = 39, BookQuantity = 7, BookDescription = "irem lopsum" },
                new Book { BookId = Guid.NewGuid(), BookTitle = "Book 6", BookAuthor = "Josh", CategoryId = 12, BookQuantity = 5, BookDescription = "irem lopsum" },
                new Book { BookId = Guid.NewGuid(), BookTitle = "Book 7", BookAuthor = "Josh", CategoryId = 4, BookQuantity = 4, BookDescription = "irem lopsum" }
            );

            modelBuilder.Entity<BookBorrowingRequest>().HasData(
                new BookBorrowingRequest { RequestId = request1, UserId = janeId, DateRequested = DateTime.Now, RequestStatus = RequestStatus.Waiting },
                new BookBorrowingRequest { RequestId = request2, UserId = jakeId, DateRequested = DateTime.Now, RequestStatus = RequestStatus.Approved }
            );

            modelBuilder.Entity<BookBorrowingRequestDetail>().HasData(
                new BookBorrowingRequestDetail { RequestId = request1, BookId = book1Id },
                new BookBorrowingRequestDetail { RequestId = request2, BookId = book2Id }
            );
        }
    
    }
}