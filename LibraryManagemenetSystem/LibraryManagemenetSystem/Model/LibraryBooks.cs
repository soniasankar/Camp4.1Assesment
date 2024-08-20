using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class LibraryBooks
    {
        //instanace fields
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author
        { get; set; }

        public DateTime PublishedDate { get; set; }
        //Default Constructor
        public LibraryBooks()
        {
        }

        // Parameterized constructor
        public LibraryBooks(string isbn, string title, string author, DateTime publishedDate)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            PublishedDate = publishedDate;
        }
    }
}



