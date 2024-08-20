using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class LibraryManagemet
    {
        static void Main(string[] args)
        {
            ILibrary library = new Library();
            while (true)
            {
                //Menu for user.

                Console.WriteLine("------------- COllEGE LIBRARY MANAGEMENT SYSTEM-------------");
                Console.WriteLine("1.List of all the books");
                Console.WriteLine("2.Add Books");
                Console.WriteLine("3.Edit Books");
                Console.WriteLine("4.Remove Books");
                Console.WriteLine("5.Search By Author");
                Console.WriteLine("6.Search By Title");
                Console.WriteLine("7.Exit");
                Console.WriteLine("Select your choice: ");

                //choice must be in between 1 an 4.

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 7)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }
                //Menu driven execution using switch
                switch (choice)
                {
                    case 1:
                        //Showing the list of books
                        library.ListAllBooks();
                        break;
                    case 2:
                        //adding books
                        library.AddBook();
                        break;
                    case 3:
                        //Editing details
                        Console.Write("Enter ISBN of the book to edit: ");
                        string editIsbn = Console.ReadLine();
                        library.EditBook(editIsbn);
                        break;
                    case 4:
                        //for removing details
                        Console.Write("Enter ISBN of the book to delete: ");
                        string deleteIsbn = Console.ReadLine();
                        library.RemoveBook(deleteIsbn);
                        break;

                    case 5:
                        //searching the books based on author name

                        Console.Write("Enter the author name to search: ");
                        string authorName = Console.ReadLine();
                        library.SearchByAuthor(authorName);
                        break;
                    case 6:
                        //searching book based on book title
                        Console.Write("Enter the title to search: ");
                        string bookTitle = Console.ReadLine();
                        library.SearchByTitle(bookTitle);
                        break;
                    case 7:
                        return;
                        break;



                }

            }
            Console.ReadKey();
        }
    }
}

