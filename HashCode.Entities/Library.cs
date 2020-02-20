using System.Collections.Generic;

namespace HashCode.Entities
{
    public class Library
    {
        public IList<Book> Books { get; set; }

        public int Days { get; set; }

        public int NumberOfBooks { get; set; }

        public int Time { get; set; }
    }
}
