using BookStore;
using BookStore.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace StoreTest
{
    [TestClass]
    public class AddAndDeleteBook
    {
        private BookStoreEntities _context;
        private BooksPage _booksPage;
        private AddBookPage _addBookPage;

        [TestInitialize]
        public void Setup()
        {
            _context = new BookStoreEntities();
            _booksPage = new BooksPage();
            _addBookPage = new AddBookPage();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public void AddBook_Test()
        {
            string title = "Test Book";
            int authorId = _context.Authors.First().AuthorID;
            int genreId = _context.Genres.First().GenreID;
            decimal price = 9.99m;
            int stock = 10;

            _addBookPage.AddBook(title, authorId, genreId, price, stock);

            var addedBook = _context.Books.FirstOrDefault(b => b.Title == title);
            Assert.IsNotNull(addedBook);
        }

        [TestMethod]
        public void DeleteBook_Test()
        {
            string title = "Test Book2";
            var book = new Books { Title = title, AuthorID = _context.Authors.First().AuthorID, GenreID = _context.Genres.First().GenreID, Price = 9.99m, Stock = 10 };
            _context.Books.Add(book);
            _context.SaveChanges();

            _booksPage.DeleteBook(book.BookID);

            var deletedBook = _context.Books.FirstOrDefault(b => b.Title == title);
            Assert.IsNull(deletedBook);
        }
    }
}