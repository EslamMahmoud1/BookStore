using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookStoreContext>>()))
            {
                if (context.Books.Any())
                {
                    return;   // DB has been seeded
                }

                context.Books.AddRange(
                    new Book
                    {
                        Title = "To Kill a Mockingbird",
                        Author = "Harper Lee",
                        Genre = "Fiction",
                        Description = "A powerful story of racial injustice and moral growth.",
                        Price = 12.99m,
                        ISBN = "9780061120084",
                        Rating = "PG",
                    },

                    new Book
                    {
                        Title = "1984",
                        Author = "George Orwell",
                        Genre = "Dystopian Fiction",
                        Description = "A dystopian novel set in a totalitarian regime, where independent thought is outlawed.",
                        Price = 10.99m,
                        ISBN = "9780451524935",
                        Rating = "PG",
                    },

                    new Book
                    {
                        Title = "The Great Gatsby",
                        Author = "F. Scott Fitzgerald",
                        Genre = "Classic",
                        Description = "A novel set in the Jazz Age, capturing the essence of the American Dream.",
                        Price = 9.99m,
                        ISBN = "9780743273565",
                        Rating = "PG",
                    },

                    new Book
                    {
                        Title = "Pride and Prejudice",
                        Author = "Jane Austen",
                        Genre = "Romance",
                        Description = "A timeless love story set in the early 19th century English society.",
                        Price = 8.99m,
                        ISBN = "9780141439518",
                        Rating = "PG",
                    },
                    new Book
                    {
                        Title = "Harry Potter and the Philosopher's Stone",
                        Author = "J.K. Rowling",
                        Genre = "Fantasy",
                        Description = "The first book in the Harry Potter series, introducing the magical world of Hogwarts.",
                        Price = 14.99m,
                        ISBN = "9781408855652",
                        Rating = "PG",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
