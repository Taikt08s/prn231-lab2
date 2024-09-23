using ODataBookStore.Model;

namespace ODataBookStore
{
    public static class DataSource
    {
        private static IList<Book> listBooks { get; set; }
        public static IList<Book> GetBooks()
        {
            if (listBooks != null)
            {
                return listBooks;
            }
            listBooks = new List<Book>();
            Book book = new Book
            {
                Id = 1,
                ISBN = "978-0-321-87758-1",
                Title = "Essential C# 5.0",
                Author = "Mark Michaelis",
                Price = 59.99M,
                Location = new Address
                {
                    City = "HCM City",
                    Street = "D2, Thu Duc District"
                },
                Press = new Press
                {
                    Id = 1,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            book = new Book
            {
                Id = 2,
                ISBN = "978-0-596-00673-0",
                Title = "Programming C# 8.0",
                Author = "Ian Griffiths",
                Price = 45.00M,
                Location = new Address
                {
                    City = "New York",
                    Street = "5th Avenue"
                },
                Press = new Press
                {
                    Id = 2,
                    Name = "O'Reilly Media",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            book = new Book
            {
                Id = 3,
                ISBN = "978-1-491-92437-0",
                Title = "Pro ASP.NET Core 6",
                Author = "Adam Freeman",
                Price = 55.99M,
                Location = new Address
                {
                    City = "San Francisco",
                    Street = "Market Street"
                },
                Press = new Press
                {
                    Id = 3,
                    Name = "Apress",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            // Additional Books
            book = new Book
            {
                Id = 4,
                ISBN = "978-1-118-96369-5",
                Title = "C# 7.0 in a Nutshell",
                Author = "Joseph Albahari",
                Price = 49.99M,
                Location = new Address
                {
                    City = "Chicago",
                    Street = "Michigan Avenue"
                },
                Press = new Press
                {
                    Id = 4,
                    Name = "O'Reilly Media",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            book = new Book
            {
                Id = 5,
                ISBN = "978-1-491-92472-1",
                Title = "Entity Framework Core in Action",
                Author = "Jon P Smith",
                Price = 39.99M,
                Location = new Address
                {
                    City = "Seattle",
                    Street = "Pike Street"
                },
                Press = new Press
                {
                    Id = 5,
                    Name = "Manning Publications",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            book = new Book
            {
                Id = 6,
                ISBN = "978-1-59327-950-9",
                Title = "The Art of Unit Testing",
                Author = "Roy Osherove",
                Price = 54.99M,
                Location = new Address
                {
                    City = "London",
                    Street = "King's Road"
                },
                Press = new Press
                {
                    Id = 6,
                    Name = "Manning Publications",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            book = new Book
            {
                Id = 7,
                ISBN = "978-1-4842-5308-3",
                Title = "Design Patterns in C#",
                Author = "Vaskaran Sarcar",
                Price = 44.99M,
                Location = new Address
                {
                    City = "Boston",
                    Street = "Boylston Street"
                },
                Press = new Press
                {
                    Id = 7,
                    Name = "Apress",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            book = new Book
            {
                Id = 8,
                ISBN = "978-0-7356-6745-7",
                Title = "Programming Microsoft Azure Service Fabric",
                Author = "Haishi Bai",
                Price = 64.99M,
                Location = new Address
                {
                    City = "Redmond",
                    Street = "Microsoft Way"
                },
                Press = new Press
                {
                    Id = 8,
                    Name = "Microsoft Press",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            book = new Book
            {
                Id = 9,
                ISBN = "978-0-13-485833-3",
                Title = "Refactoring: Improving the Design of Existing Code",
                Author = "Martin Fowler",
                Price = 59.99M,
                Location = new Address
                {
                    City = "San Francisco",
                    Street = "Market Street"
                },
                Press = new Press
                {
                    Id = 9,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            book = new Book
            {
                Id = 10,
                ISBN = "978-1-68050-239-8",
                Title = "Domain-Driven Design",
                Author = "Eric Evans",
                Price = 70.00M,
                Location = new Address
                {
                    City = "Berlin",
                    Street = "Friedrichstrasse"
                },
                Press = new Press
                {
                    Id = 10,
                    Name = "Addison-Wesley",
                    Category = Category.Book
                }
            };
            listBooks.Add(book);

            return listBooks;
        }
    }
}