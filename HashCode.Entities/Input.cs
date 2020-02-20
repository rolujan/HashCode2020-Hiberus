using System.Collections.Generic;

namespace HashCode.Entities
{
    public class Input
    {
        public int NumberOfBooks {
            get { return Books.Count; }
        }

        public int NumberOfLibraries {
            get { return Libraries.Count; }
        }

        public int NumberOfDaysToScan { get; set; }

        public LinkedList<Book> Books { get; set; }
        public LinkedList<Library> Libraries { get; set; }
    }
}
