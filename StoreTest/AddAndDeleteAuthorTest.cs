using BookStore;
using BookStore.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace StoreTest
{
    [TestClass]
    public class AddAndDeleteAuthorTest
    {
        private BookStoreEntities _context;
        private AuthorsPage _authorsPage;
        private AddAuthorPage _addAuthorPage;

        [TestInitialize]
        public void Setup()
        {
            _context = new BookStoreEntities();
            _authorsPage = new AuthorsPage();
            _addAuthorPage = new AddAuthorPage();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public void AddAuthor_Test()
        {
            string firstName = "Test";
            string lastName = "Author";
            string patronymic = "Testovich";
            string bio = "Test biography";

            _addAuthorPage.AddAuthor(firstName, lastName, patronymic, bio);

            var addedAuthor = _context.Authors.FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);
            Assert.IsNotNull(addedAuthor);
        }

        [TestMethod]
        public void DeleteAuthor_Test()
        {
            string firstName = "Test1";
            string lastName = "Author1";
            var author = new Authors { FirstName = firstName, LastName = lastName, Patronymic = "Testovich", Bio = "Test biography" };
            _context.Authors.Add(author);
            _context.SaveChanges();

            _authorsPage.DeleteAuthor(author.AuthorID);

            var deletedAuthor = _context.Authors.FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);
            Assert.IsNull(deletedAuthor, "Author should be deleted from the database.");
        }
    }
}