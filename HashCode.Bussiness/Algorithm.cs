using HashCode.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HashCode.Bussiness
{
    public class Algorithm
    {
        public static Output Apply(Input container)
        {
            Output output = new Output();
            output.Libraries = new LinkedList<LibraryOutput>();

            return output;
        }

        public static State FindSolution(List<Library> libraries, int dias)
        {
            Queue<State> states = new Queue<State>();
            State state = null;
            List<State> solution = new List<State>();

            state = new State();
            state.ClosedLibraries = libraries;
            while ((state = states.Peek()) != null)
            {
                foreach (var library in state.ClosedLibraries)
                {
                    State state2 = new State();
                    Library library2 = new Library();
                    library2.Id = library.Id;
                    int nDiasRestantes = dias - state2.ExpendedTime;
                    //library2.
                    //states.Append(state2);
                    state2.OpenLibraries.AddRange(state.OpenLibraries);
                    state2.ClosedLibraries.AddRange(state.ClosedLibraries);
                    state2.ClosedLibraries.Remove(library);
                    state2.OpenLibraries.Append(library2);
                }
            }
            //while () { }

            return state;
        }
    }

    public class State
    {
        public HashSet<Book> Sent { get; set; }
        public List<Library> OpenLibraries { get; set; }
        public List<Library> ClosedLibraries { get; set; }
        public State()
        {
            Sent = new HashSet<Book>();
            ExpendedTime = 0;
            OpenLibraries = new List<Library>();
            ClosedLibraries = new List<Library>();
        }
        public int ExpendedTime { get; set; }
    }
}