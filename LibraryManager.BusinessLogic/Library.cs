using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.BusinessLogic
{
    public class Library
        


    {

        public Library()
        {
            Books[0].TryRent(Users[0], DateTime.Now);
            Books[0].Return(DateTime.Now);
            Books[1].TryRent(Users[1], DateTime.Now);
            Books[5].TryRent(Users[1], DateTime.Now);
        }


        //CRUD - create, read, update, delete
        public List<Book> Books { get; } = new List<Book>
        {
            new Book("Adam Mickiewicz", "Pan Tadeusz"),
            new Book("Adam Mickiewicz", "Pan Tadeusz"),
            new Book("Adam Mickiewicz", "Pan Tadeusz"),
            new Book("Adam Mickiewicz", "Pan Tadeusz"),
            new Book("Adam Mickiewicz", "Pan Tadeusz"),
            new Book("Terry Pratchett", "Para w Ruch"),

        };
        public List<User> Users { get; } = new List<User>
        { 
        new User ("Mietek Sz"),
        new User ("Mietek A"),
        new User ("Mietek B"),
        new User ("Mietek C"),
        new User ("Mietek D"),
        new User ("Mieczyslaw"),
        
        
        };
    }
}
