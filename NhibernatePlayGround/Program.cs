using HibernatingRhinos.Profiler.Appender.NHibernate;
using NhibernatePlayGround;
using System;

namespace NhibernatePlayGround
{
    class Program
    {

        /// <summary>
        /// Dears,
        /// This is a playgroud for FluentNHibernate
        /// Base idea is: understand the ORM metodology and behaviors Nhibernate
        /// Example domain is Library Management System. library, books etc.
        /// 
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();

            //NHibernateProfiler.Initialize();

            Configuration.SetupSchemaByConfigure();
            //CreateBook();
            //CreateLibraryWithBooks();
            //GetLibraryAndClearBookList();
            //ThrowExceptionAndRollback();
            CreateBorrowing();

            Console.WriteLine("Finished! Enter to exit");
            Console.ReadLine();
        }

        private static void CreateBorrowing()
        {
            Configuration.WorkWithTransaction(session =>
            {
                Library lib = new Library("New Lib");
                Book book = new Book("book for borrow", DateTime.Now);
                lib.Books.Add(book);
                session.Save(lib);

                Student student = new Student("Jeff", 1212);
                session.Save(student);

                Borrowing borrowing = new Borrowing(book, student, DateTime.Now, DateTime.Now.AddMonths(1));
                session.Save(borrowing);
                

            });
        }

        static void CreateLibrary()
        {
            Configuration.WorkWithTransaction(session =>
            {

                Library a = new Library("ITU Central Library");

                session.Save(a);
            });
        }
        static void CreateLibraryWithBooks()
        {
            Configuration.WorkWithTransaction(session =>
            {
                Library library = new Library("ITU Central Library");

                Book b1 = new Book("Alice in a Wonderland", new DateTime(2001, 12, 16));
                Book b2 = new Book("NUTUK", new DateTime(1927, 6, 3));


                library.Books.Add(b1);
                library.Books.Add(b2);

                session.Save(library);

            });
        }
        static void GetLibraryAndClearBookList()
        {
            Configuration.WorkWithTransaction(session =>
            {

                var modelB = session.QueryOver<Library>().OrderBy(x => x.Id).Desc.Take(1).SingleOrDefault();

                modelB.Books.Clear();

                session.Save(modelB);
            });
        }
        static void ThrowExceptionAndRollback()
        {

            Configuration.WorkWithTransaction(session =>
            {

                var book = new Book("Some Stupid Book", DateTime.Now);
                session.Save(book);

                var bookSearchResult = session.QueryOver<Book>()
                        .Where(x => x.Name.Equals("There is no book like that"))
                        .SingleOrDefault();

                bookSearchResult.IncreaseReadCount();

                session.Save(bookSearchResult);
            });
        }
    }
}


