using HashCode.Bussiness;
using HashCode.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashCode
{
    class Program
    {
        private static Input _input;

        static void Main(string[] args)
        {
            // General

            Initialize();

            /*************************
            *    Leemos el fichero   *
            *************************/

            string path = @"D:\proyectos\.NET\HashCode2020-Hiberus\HashCode\Files\a_example.txt";

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.ASCII);

            // Leemos la línea 1

            LoadInformationFromLine1(sr);

            // Leemos la línea 2

            LoadBookScoreFromLine2(sr);

            // Leemos el resto de líneas con librerías

            LoadLibrariesFromOtherLines(sr);

            /*************************
            * Aplicamos el algoritmo *
            *************************/

            Algorithm.Apply(_input);

            /*************************
            *  Preparamos la salida  *
            *************************/

            // Para evitar cerrar la consola
            Console.ReadLine();
        }

        private static void Initialize()
        {
            _input = new Input();
            _input.Books = new LinkedList<Book>();
        }

        private static void LoadInformationFromLine1(StreamReader sr)
        {
            string informativeLine = sr.ReadLine();

            List<string> informativeLineList = informativeLine.Split(' ').ToList();

            _input.NumberOfDaysToScan = int.Parse(informativeLineList[2]);
        }

        private static void LoadBookScoreFromLine2(StreamReader sr)
        {
            string booksScoreLine = sr.ReadLine();

            List<string> scoreList = booksScoreLine.Split(' ').ToList();

            for (int index = 0; index < scoreList.Count; index++)
            {
                Book book = new Book {
                    Id = index,
                    Score = int.Parse(scoreList[index])
                };

                _input.Books.AddLast(book);
            }
        }

        private static void LoadLibrariesFromOtherLines(StreamReader sr)
        {
            LinkedList<Library> libraryList = new LinkedList<Library>();

            string otherLine = String.Empty;

            while ((otherLine = sr.ReadLine()) != null)
            {
                List<string> libraryLine1 = otherLine.Split(' ').ToList();

                Library library = new Library {
                    Books = new LinkedList<Book>(),
                    TimeToSignup = int.Parse(libraryLine1[1]),
                    NumberOfBooksCanScanPerDay = int.Parse(libraryLine1[2])
                };

                string libraryLine2 = sr.ReadLine();

                string[] bookListInLibrary = libraryLine2.Split(' ');

                foreach (string bookInLibrary in bookListInLibrary)
                {
                    int index = int.Parse(bookInLibrary);
                    Book book = GetBook(index);
                    library.Books.AddLast(book);
                }

                libraryList.AddLast(library);
            }

            _input.Libraries = libraryList;
        }

        private static Book GetBook(int index)
        {
            return _input.Books
                .Where(book => book.Id.Equals(index))
                .First();
        }
    }
}