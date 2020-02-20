using System.Collections.Generic;

namespace HashCode.Entities
{
    public class Output
    {
        public int NumberOfLibraries {
            get { return Libraries.Count; }
        }

        public LinkedList<LibraryOutput> Libraries { get; set; }
    }
}
