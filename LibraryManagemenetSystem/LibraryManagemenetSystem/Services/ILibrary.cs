using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public interface ILibrary
    {
        //all the crud operations without implemetation
        void ListAllBooks();
        void AddBook();
        void EditBook(string isbn);
        void RemoveBook(string isbn);
        void SearchByAuthor(string author);
        void SearchByTitle(string title);

    }
}

