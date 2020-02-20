using HashCode.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode
{
    class State
    {
        public HashSet<Book> Sent { get; set; }
        public List<Library> OpenLibraries{ get; set; }
        public List<Library> ClosedLibraries { get; set; }
        public State()
        {
            Sent = new HashSet<Book>();
            ExpendedTime = 0;
            OpenLibraries = new List<Library>();
            ClosedLibraries = new List<Library>();
        }
        int ExpendedTime { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\proyectos\.NET\HashCode2020-Hiberus\HashCode\Files\a_example.txt";

            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs, Encoding.ASCII);

            // General

            LinkedList<Book> bookList = new LinkedList<Book>();
            LinkedList<Library> libraryList = new LinkedList<Library>();

            // Leemos la línea 1

            string line1 = sr.ReadLine();
            List<string> line1Array = line1.Split(' ').ToList();

            string numBooks = line1Array[0];
            string numLibraries = line1Array[1];
            string timeToScan = line1Array[2];

            // Leemos la línea 2

            string line2 = sr.ReadLine();
            List<string> scoreList = line2.Split(' ').ToList();

            for (int index = 0; index < scoreList.Count; index++)
            {
                Book book = new Book {
                    Id = index,
                    Score = int.Parse(scoreList[index])
                };

                bookList.AddLast(book);
            }


            // Leemos el resto de líneas con librerías

            string otherLine = String.Empty;

            while ((otherLine = sr.ReadLine()) != null)
            {
                LinkedList<Book> libraryBooks = new LinkedList<Book>();

                List<string> libraryLine1 = otherLine.Split(' ').ToList();

                string libraryLine2 = sr.ReadLine();
                string[] bookListInLibrary = libraryLine2.Split(' ');

                foreach (string bookInLibrary in bookListInLibrary)
                {
                    int index = int.Parse(bookInLibrary);
                    Book book = GetBook(bookList, index);
                    libraryBooks.AddLast(book);
                }

                Library library = new Library {
                    Books = libraryBooks,
                    Time = int.Parse(libraryLine1[1]),
                    NumberOfBooksCanScanPerDay = int.Parse(libraryLine1[2])
                };

                libraryList.AddLast(library);
            }

            // Para evitar cerrar la consola
            Console.ReadLine();
        }

        public static Book GetBook(LinkedList<Book> bookList, int index)
        {
            return bookList
                .Where(book => book.Id.Equals(index))
                .First();
        }
        public static void EscribeSalida(List<Library> librerias, FileStream salida)
        {
            using (StreamWriter writer = new StreamWriter(salida))
            {

                foreach (var liberia in librerias)
                {
                    if (liberia.Books.Count == 0)
                    {
                        writer.WriteLine(liberia.Id);
                    }
                    else
                    {
                        writer.WriteLine($"{liberia.Id} {liberia.Books.Count}");
                        string linea = "";
                        foreach (var libro in liberia.Books)
                        {
                            linea += " " + libro.Id;
                        }
                        writer.WriteLine(linea.Substring(1));
                    }
                }
            }

        }

        public static State FindSolution(List<Library> libraries,int dias)
        {
            Queue<State> states = new Queue<State>();
            State state = null;
            List<State> solution = new List<State();

            state = new State();
            state.ClosedLibraries = libraries;
            while ((state = states.Peek())!=null){
                foreach(var library in state.ClosedLibraries)
                {
                    State state2 = new State();
                    Library library2 = new Library();
                    library2.Id = library.Id;
                    int nDiasRestantes = dias - state2.
                    library2.
                    states.Append(state2);
                    state2.OpenLibraries.AddRange(state.OpenLibraries);
                    state2.ClosedLibraries.AddRange(state.ClosedLibraries);
                    state2.ClosedLibraries.Remove(library);
                    state2.OpenLibraries.Append(library2);

                }
            }
            while () { }

            return state;

        }

    }