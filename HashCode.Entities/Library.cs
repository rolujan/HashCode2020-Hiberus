using System.Collections.Generic;

namespace HashCode.Entities
{
    public class Library
    {
        public LinkedList<Book> Books { get; set; }

        public int Days { get; set; }

        public int NumberOfBooksCanScanPerDay { get; set; }

        public int Time { get; set; }
    }
}
