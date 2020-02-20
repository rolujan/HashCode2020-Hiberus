using System.Collections.Generic;

namespace HashCode.Entities
{
    public class Library
    {
        public int Id { get; set; }
        public LinkedList<Book> Books { get; set; }
        public int TimeToSignup { get; set; }
        public int NumberOfBooksCanScanPerDay { get; set; }
    }
}