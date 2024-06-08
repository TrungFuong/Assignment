﻿// <auto-generated />
using System;
using LibraryASM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryASM.Migrations
{
    [DbContext(typeof(LibraryASMDBContext))]
    partial class LibraryASMDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookQuantity")
                        .HasColumnType("int");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = new Guid("2024a4ad-2a91-46af-b718-efb96cbb521b"),
                            BookAuthor = "Tao",
                            BookDescription = "lorem ipsum",
                            BookQuantity = 3,
                            BookTitle = "Book 1",
                            CategoryId = 1
                        },
                        new
                        {
                            BookId = new Guid("be18f8e3-555f-47f4-81fd-4649bfdcb459"),
                            BookAuthor = "Josh",
                            BookDescription = "irem lopsum",
                            BookQuantity = 2,
                            BookTitle = "Book 2",
                            CategoryId = 2
                        },
                        new
                        {
                            BookId = new Guid("99521204-7f4b-41e0-adfe-95ec32ed5cb5"),
                            BookAuthor = "Josh",
                            BookDescription = "irem lopsum",
                            BookQuantity = 5,
                            BookTitle = "Book 3",
                            CategoryId = 43
                        },
                        new
                        {
                            BookId = new Guid("9e0a589d-9011-485e-8ce7-47ea37d63cad"),
                            BookAuthor = "Josh",
                            BookDescription = "irem lopsum",
                            BookQuantity = 8,
                            BookTitle = "Book 4",
                            CategoryId = 24
                        },
                        new
                        {
                            BookId = new Guid("285baf57-3905-4da8-a709-2ff5e0db950c"),
                            BookAuthor = "Josh",
                            BookDescription = "irem lopsum",
                            BookQuantity = 7,
                            BookTitle = "Book 5",
                            CategoryId = 39
                        },
                        new
                        {
                            BookId = new Guid("3d2a6fc8-ca32-42f6-9c08-48828dd2604a"),
                            BookAuthor = "Josh",
                            BookDescription = "irem lopsum",
                            BookQuantity = 5,
                            BookTitle = "Book 6",
                            CategoryId = 12
                        },
                        new
                        {
                            BookId = new Guid("54614055-b280-445c-a68a-52c471580bdc"),
                            BookAuthor = "Josh",
                            BookDescription = "irem lopsum",
                            BookQuantity = 4,
                            BookTitle = "Book 7",
                            CategoryId = 4
                        });
                });

            modelBuilder.Entity("Library.Models.BookBorrowingRequest", b =>
                {
                    b.Property<Guid>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<int>("PageNumber")
                        .HasColumnType("int");

                    b.Property<int>("PageSize")
                        .HasColumnType("int");

                    b.Property<int>("RequestStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("BookBorrowingRequests");

                    b.HasData(
                        new
                        {
                            RequestId = new Guid("d48eabbc-0ea8-49f4-b8ca-6815a7caa172"),
                            DateRequested = new DateTime(2024, 6, 7, 11, 29, 21, 748, DateTimeKind.Local).AddTicks(6019),
                            PageNumber = 1,
                            PageSize = 20,
                            RequestStatus = 0,
                            UserId = new Guid("18574f89-3fa6-4f1e-8c4c-1e4d060822d7")
                        },
                        new
                        {
                            RequestId = new Guid("5981ee3f-b7e2-411d-be49-1c3ed02f5881"),
                            DateRequested = new DateTime(2024, 6, 7, 11, 29, 21, 748, DateTimeKind.Local).AddTicks(6038),
                            PageNumber = 1,
                            PageSize = 20,
                            RequestStatus = 1,
                            UserId = new Guid("531850a0-06d8-4188-a5d7-ac258e05ca05")
                        });
                });

            modelBuilder.Entity("Library.Models.BookBorrowingRequestDetail", b =>
                {
                    b.Property<Guid>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PageNumber")
                        .HasColumnType("int");

                    b.Property<int>("PageSize")
                        .HasColumnType("int");

                    b.HasKey("RequestId", "BookId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("BookBorrowingRequestDetails");

                    b.HasData(
                        new
                        {
                            RequestId = new Guid("d48eabbc-0ea8-49f4-b8ca-6815a7caa172"),
                            BookId = new Guid("2024a4ad-2a91-46af-b718-efb96cbb521b"),
                            PageNumber = 1,
                            PageSize = 20
                        },
                        new
                        {
                            RequestId = new Guid("5981ee3f-b7e2-411d-be49-1c3ed02f5881"),
                            BookId = new Guid("be18f8e3-555f-47f4-81fd-4649bfdcb459"),
                            PageNumber = 1,
                            PageSize = 20
                        });
                });

            modelBuilder.Entity("Library.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Romance"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Fiction"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Mystery"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Thriller"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Science Fiction"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Fantasy"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Horror"
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryName = "Adventure"
                        },
                        new
                        {
                            CategoryId = 9,
                            CategoryName = "Historical Fiction"
                        },
                        new
                        {
                            CategoryId = 10,
                            CategoryName = "Biography"
                        },
                        new
                        {
                            CategoryId = 11,
                            CategoryName = "Self-Help"
                        },
                        new
                        {
                            CategoryId = 12,
                            CategoryName = "Business"
                        },
                        new
                        {
                            CategoryId = 13,
                            CategoryName = "Cooking"
                        },
                        new
                        {
                            CategoryId = 14,
                            CategoryName = "Travel"
                        },
                        new
                        {
                            CategoryId = 15,
                            CategoryName = "Art"
                        },
                        new
                        {
                            CategoryId = 16,
                            CategoryName = "Music"
                        },
                        new
                        {
                            CategoryId = 17,
                            CategoryName = "Sports"
                        },
                        new
                        {
                            CategoryId = 18,
                            CategoryName = "History"
                        },
                        new
                        {
                            CategoryId = 19,
                            CategoryName = "Religion"
                        },
                        new
                        {
                            CategoryId = 20,
                            CategoryName = "Philosophy"
                        },
                        new
                        {
                            CategoryId = 21,
                            CategoryName = "Psychology"
                        },
                        new
                        {
                            CategoryId = 22,
                            CategoryName = "Science"
                        },
                        new
                        {
                            CategoryId = 23,
                            CategoryName = "Technology"
                        },
                        new
                        {
                            CategoryId = 24,
                            CategoryName = "Education"
                        },
                        new
                        {
                            CategoryId = 25,
                            CategoryName = "Politics"
                        },
                        new
                        {
                            CategoryId = 26,
                            CategoryName = "Law"
                        },
                        new
                        {
                            CategoryId = 27,
                            CategoryName = "Medicine"
                        },
                        new
                        {
                            CategoryId = 28,
                            CategoryName = "Fashion"
                        },
                        new
                        {
                            CategoryId = 29,
                            CategoryName = "Design"
                        },
                        new
                        {
                            CategoryId = 30,
                            CategoryName = "Gardening"
                        },
                        new
                        {
                            CategoryId = 31,
                            CategoryName = "Parenting"
                        },
                        new
                        {
                            CategoryId = 32,
                            CategoryName = "Psychology"
                        },
                        new
                        {
                            CategoryId = 33,
                            CategoryName = "Science"
                        },
                        new
                        {
                            CategoryId = 34,
                            CategoryName = "Technology"
                        },
                        new
                        {
                            CategoryId = 35,
                            CategoryName = "Education"
                        },
                        new
                        {
                            CategoryId = 36,
                            CategoryName = "Politics"
                        },
                        new
                        {
                            CategoryId = 37,
                            CategoryName = "Law"
                        },
                        new
                        {
                            CategoryId = 38,
                            CategoryName = "Medicine"
                        },
                        new
                        {
                            CategoryId = 39,
                            CategoryName = "Fashion"
                        },
                        new
                        {
                            CategoryId = 40,
                            CategoryName = "Design"
                        },
                        new
                        {
                            CategoryId = 41,
                            CategoryName = "Gardening"
                        },
                        new
                        {
                            CategoryId = 42,
                            CategoryName = "Parenting"
                        },
                        new
                        {
                            CategoryId = 43,
                            CategoryName = "Psychology"
                        },
                        new
                        {
                            CategoryId = 44,
                            CategoryName = "Science"
                        },
                        new
                        {
                            CategoryId = 45,
                            CategoryName = "Technology"
                        },
                        new
                        {
                            CategoryId = 46,
                            CategoryName = "Education"
                        },
                        new
                        {
                            CategoryId = 47,
                            CategoryName = "Politics"
                        },
                        new
                        {
                            CategoryId = 48,
                            CategoryName = "Law"
                        },
                        new
                        {
                            CategoryId = 49,
                            CategoryName = "Medicine"
                        },
                        new
                        {
                            CategoryId = 50,
                            CategoryName = "Fashion"
                        },
                        new
                        {
                            CategoryId = 51,
                            CategoryName = "Design"
                        },
                        new
                        {
                            CategoryId = 52,
                            CategoryName = "Gardening"
                        },
                        new
                        {
                            CategoryId = 53,
                            CategoryName = "Parenting"
                        });
                });

            modelBuilder.Entity("Library.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PageNumber")
                        .HasColumnType("int");

                    b.Property<int>("PageSize")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("a9743a8a-b7ca-438a-8a5a-90c2333b3f5d"),
                            PageNumber = 1,
                            PageSize = 20,
                            Password = "1",
                            Role = 1,
                            RoleId = 0,
                            UserEmail = "john@gmail.com",
                            UserName = "John Doe",
                            UserPhone = "0912345678"
                        },
                        new
                        {
                            UserId = new Guid("18574f89-3fa6-4f1e-8c4c-1e4d060822d7"),
                            PageNumber = 1,
                            PageSize = 20,
                            Password = "2",
                            Role = 0,
                            RoleId = 0,
                            UserEmail = "jane@gmail.com",
                            UserName = "Jane Smith",
                            UserPhone = "135098123"
                        },
                        new
                        {
                            UserId = new Guid("531850a0-06d8-4188-a5d7-ac258e05ca05"),
                            PageNumber = 1,
                            PageSize = 20,
                            Password = "3",
                            Role = 0,
                            RoleId = 0,
                            UserEmail = "jake@gmail.com",
                            UserName = "Jake Brown",
                            UserPhone = "135123534"
                        });
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Library.Models.BookBorrowingRequest", b =>
                {
                    b.HasOne("Library.Models.User", "User")
                        .WithMany("BookBorrowingRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Library.Models.BookBorrowingRequestDetail", b =>
                {
                    b.HasOne("Library.Models.Book", "Book")
                        .WithOne("BookBorrowingRequestDetail")
                        .HasForeignKey("Library.Models.BookBorrowingRequestDetail", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.BookBorrowingRequest", "BookBorrowingRequest")
                        .WithMany("BorrowingRequestDetails")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookBorrowingRequest");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Navigation("BookBorrowingRequestDetail")
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.BookBorrowingRequest", b =>
                {
                    b.Navigation("BorrowingRequestDetails");
                });

            modelBuilder.Entity("Library.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.Models.User", b =>
                {
                    b.Navigation("BookBorrowingRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
