using System.Collections.Generic;

namespace HashCode.Entities
{
    public class LibraryOutput
    {
        public int Id { get; set; }
        public LinkedList<Book> BooksToScan { get; set; }
    }
}