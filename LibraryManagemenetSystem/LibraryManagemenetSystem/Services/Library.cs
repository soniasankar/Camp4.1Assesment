using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using LibraryManagementSystem.Model;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Services
{
    public class Library : ILibrary
    {//the dictionary to storing the data
        public static Dictionary<string, LibraryBooks> librarydata = new Dictionary<string, LibraryBooks>();
        //auto generated id start with 1000
        private static int ISBNGenerator = 1000;

        //generate a new ISBN
        private static string GenerateISBN()
        {
            return (ISBNGenerator++).ToString();
        }

        // Adding a book
        #region AddBook
        public void AddBook()
        {
            //Exception handling
            try
            {
                Console.WriteLine("Enter the book details.");

                // Generate a new ISBN
                string isbn = GenerateISBN();
                Console.WriteLine($"Generated ISBN: {isbn}");
                //validation for adding a title
                string title;
                while (true)
                {
                    Console.Write("Title: ");
                    title = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(title))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for title.");
                    }
                }
                //validation for name
                string name;
                while (true)
                {
                    Console.Write("Author Name: ");
                    name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name) && !System.Text.RegularExpressions.Regex.IsMatch(name, @"\d"))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Author name. Ensure it is not empty and does not contain numbers.");
                    }
                }
                //validation for published date
                DateTime publishedDate;
                while (true)
                {
                    Console.Write("Published Date (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out publishedDate) && publishedDate <= DateTime.Now)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Published Date. Must be today or a previous date. Please try again.");
                    }
                }
                //adding the data into dictionary

                librarydata.Add(isbn, new LibraryBooks
                {
                    ISBN = isbn,
                    Title = title,
                    Author = name,
                    PublishedDate = publishedDate
                });

                Console.WriteLine("Book added successfully.");
                //showing number of books
                Console.WriteLine($"Number of books: {librarydata.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        #endregion
        //editing the given book details
        public void EditBook(string isbn)
        {
            try
            {//checking the book with given ISBN exist or not
                if (!librarydata.ContainsKey(isbn))
                {
                    Console.WriteLine("Book not found.");
                    return;
                }

                var books = librarydata[isbn];

                // Edit Title
                Console.WriteLine($"Current Title: {books.Title}");
                string newTitle;
                while (true)
                {
                    //giving new title
                    Console.Write("New Title: ");
                    newTitle = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newTitle))
                    {
                        books.Title = newTitle;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for title.");
                    }
                }

                // Edit Author Name
                //current author name
                Console.WriteLine($"Current Author Name: {books.Author}");
                string newAuthor;
                while (true)
                {
                    //giving new author aame
                    Console.Write("New Author Name: ");
                    newAuthor = Console.ReadLine();
                    //validation for name
                    if (!string.IsNullOrWhiteSpace(newAuthor) && !System.Text.RegularExpressions.Regex.IsMatch(newAuthor, @"\d"))
                    {
                        books.Author = newAuthor;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Author name. Ensure it is not empty and does not contain numbers.");
                    }
                }

                // Edit Published Date
                Console.WriteLine($"Current Published Date: {books.PublishedDate}");
                DateTime newPublishedDate;
                while (true)
                {
                    //new date
                    Console.Write("New Published Date (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out newPublishedDate) && newPublishedDate <= DateTime.Now)
                    {
                        books.PublishedDate = newPublishedDate;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for Published Date. Must be today or a previous date. Please try again.");
                    }
                }

                Console.WriteLine("Book updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        //show all the list of books
        /*
        public void ListAllBooks()
        {
            try
            {
                // If no data present, show no books found
                if (libraryData.Count == 0)
                {
                    Console.WriteLine("No books found.");
                    return;
                }

                // Define column widths
                int isbnWidth = 15;
                int titleWidth = 30;
                int authorWidth = 25;
                int publishedDateWidth = 20;

                // Display header
                Console.WriteLine($"{"ISBN".PadRight(isbnWidth)}{"Title".PadRight(titleWidth)}{"Author".PadRight(authorWidth)}{"Published Date".PadRight(publishedDateWidth)}");
                Console.WriteLine(new string('-', isbnWidth + titleWidth + authorWidth + publishedDateWidth));

                // Display each book's details in a tabular format
                foreach (var book in libraryData.Values)
                {
                    Console.WriteLine($"{book.ISBN.PadRight(isbnWidth)}{book.Title.PadRight(titleWidth)}{book.Author.PadRight(authorWidth)}{book.PublishedDate.ToString("yyyy-MM-dd").PadRight(publishedDateWidth)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        */
        public void ListAllBooks()
        {
            try
            {
                // If no data present, show no books found
                if (librarydata.Count == 0)
                {
                    Console.WriteLine("No books found.");
                    return;
                }

                // Define column widths
                int isbnWidth = 15;
                int titleWidth = 30;
                int authorWidth = 25;
                int publishedDateWidth = 20;

                // Display header
                Console.WriteLine($"{"ISBN".PadRight(isbnWidth)}{"Title".PadRight(titleWidth)}{"Author".PadRight(authorWidth)}{"Published Date".PadRight(publishedDateWidth)}");
                Console.WriteLine(new string('-', isbnWidth + titleWidth + authorWidth + publishedDateWidth));

                // Display each book's details in a tabular format
                foreach (var book in librarydata.Values)
                {
                    Console.WriteLine($"{book.ISBN.PadRight(isbnWidth)}{book.Title.PadRight(titleWidth)}{book.Author.PadRight(authorWidth)}{book.PublishedDate.ToString("yyyy-MM-dd").PadRight(publishedDateWidth)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        //removing a book details form dictionary
        public void RemoveBook(string isbn)
        {
            if (librarydata.Remove(isbn))
            {
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        //Search book details based on author name
        public void SearchByAuthor(string author)
        {
            try
            {
                var foundBooks = librarydata.Values.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
                if (foundBooks.Count == 0)
                {
                    Console.WriteLine("No books found by this author.");
                    return;
                }

                foreach (var book in foundBooks)
                {
                    Console.WriteLine($"ISBN: {book.ISBN}");
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"Published Date: {book.PublishedDate}");
                    Console.WriteLine(); // Add a blank line for better readability
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        //search book name based on title of the book
        public void SearchByTitle(string title)
        {
            try
            {
                var foundBooks = librarydata.Values.Where(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();
                if (foundBooks.Count == 0)
                {
                    Console.WriteLine("No books found with this title.");
                    return;
                }

                foreach (var book in foundBooks)
                {
                    Console.WriteLine($"ISBN: {book.ISBN}");
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"Published Date: {book.PublishedDate}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
