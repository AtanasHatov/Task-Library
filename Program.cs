using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectLibrary
{
    internal class Program
    {
        static List<Book> books = new List<Book>();
        static List<Reader> reader = new List<Reader>();
        static List<Borrowing> borrowings = new List<Borrowing>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - Изход");
                Console.WriteLine("2 - Въведи книга");
                Console.WriteLine("3 - Въведи читател");
                Console.WriteLine("4 - Вземане на книга");
                Console.WriteLine("5 - Всички книги в библиотеката.");
                Console.WriteLine("6 - Всички читатели.");
                Console.WriteLine("7 - Книги, заети от даден читател.");
                Console.WriteLine("8 - Читатели с активни заеми.");
                Console.WriteLine("9 - Всички налични книги");
                Console.WriteLine("10 - Закъснели връщания");
                Console.WriteLine("11 - Най-заеманите книги.");

                int num = int.Parse(Console.ReadLine());
                if (num == 1)
                {
                    break;
                }

                switch (num) 
                {
                    case 1: Console.WriteLine();
                        break;
                    case 2: AddBook();
                        break;
                    case 3: AddReader();
                        break;
                    case 4: Console.WriteLine("Въведи имe на книга");
                        string titleizbrano = Console.ReadLine();
                        Book bookIzbrana=books.FirstOrDefault(b=>b.Title==titleizbrano);
                        Console.WriteLine("Въведи id на читателя");
                        int idIzbrano=int.Parse(Console.ReadLine());
                        Reader readerIzbrana=reader.FirstOrDefault(r=>r.Id==idIzbrano);
                        BorrowingBook(bookIzbrana,readerIzbrana);
                        break;
                    case 5:
                        AllBookInLibrary();
                        break;
                        case 6:
                            AllReaders();
                        break;
                    case 7:
                        Console.WriteLine("Въведи id на читателя");
                        int idIzbrano2 = int.Parse(Console.ReadLine());
                        Reader readerIzbrana2 = reader.FirstOrDefault(r => r.Id == idIzbrano2);
                        BookBorringByReared(readerIzbrana2);
                        break;
                        case 8:
                        ReaderWithActivBorrow();
                        break;
                    case 9:
                        AllAvaibleBooks();
                        break;
                    case 10:
                        LateReturns();
                        break;
                    case 11:
                        TheMostBorrowedBooks();
                        break;
                    default:
                        Console.WriteLine("Няма такава опция в менюто!!!!!");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.WriteLine("Въведи заглавие на книгата");
            string title = Console.ReadLine();

            Console.WriteLine("Въведи автор на книгата");
            string author = Console.ReadLine();

            Console.WriteLine("Въведи жанр на книгата");
            string genre = Console.ReadLine();

            Console.WriteLine("Брой налични копия от книгата");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Брой общо заемани пъти");
            int a = int.Parse(Console.ReadLine());

            Book book = new Book(title, author, genre, n, a);
            books.Add(book);
        }

        static void AddReader()
        {
            Console.WriteLine("Въведи име на читател");
            string name = Console.ReadLine();

            Console.WriteLine("Въведи Идентификационен номер на читателя");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Въведи възраст на читателя");
            int age = int.Parse(Console.ReadLine());

            List<Book> zaemanibook = new List<Book>();
            Reader reader1 = new Reader(name, id, age, zaemanibook);
            reader.Add(reader1);
        }

        static void BorrowingBook(Book book,Reader reader)
        {
            if (book.BrAvaibelCopys > 0)
            {
                DateTime borrowingdateTime = DateTime.Now;
                DateTime returnTime = borrowingdateTime.AddDays(30);
                Borrowing borrowing = new Borrowing(reader, book, borrowingdateTime, returnTime);
                reader.ZaemaniBook.Add(book);
                book.BrTimesVzemana++;
                book.BrAvaibelCopys--;
                borrowings.Add(borrowing);
            }
            else
            {
                Console.WriteLine("No copy!!!");
            }
        }

        static void AllBookInLibrary()
        {
            foreach (Book book in books)
            {
                Console.WriteLine(book.Title);
            }
        }

        static void AllReaders()
        {
            foreach(Reader reade in reader)
            {
                Console.WriteLine(reade.Name);
            }
        }

        static void BookBorringByReared(Reader reader)
        {
            foreach (Book item in reader.ZaemaniBook)
            {
                Console.WriteLine(item.Title);
            }
        }

        static void ReaderWithActivBorrow()
        {
            foreach (var item in borrowings)
            {
                if(item.Reader.ZaemaniBook != null)
                {
                    Console.WriteLine(item.Reader.Name);
                }
            }
        }

        static void AllAvaibleBooks()
        {
            foreach (var item in books)
            {
                if(item.BrAvaibelCopys > 0)
                {
                    Console.WriteLine(item.Title);
                }
            }
        }

        static void LateReturns()
        {
            DateTime maxDay = DateTime.Now.AddDays(-30);
            foreach (var borrowing in borrowings)
            {
                if (maxDay > borrowing.BorrowingDate && borrowing.ReturnDate == null)
                {
                    Console.WriteLine(borrowing.Book.Title, borrowing.Reader.Name, borrowing.ReturnDate);
                }
            }
        }

        static void TheMostBorrowedBooks()
        {
            foreach (var borrowing in borrowings.OrderByDescending(b => b.Book.BrTimesVzemana).Take(3))
            {
                Console.WriteLine(borrowing.Book.Title);
            }
        }
    }
}
