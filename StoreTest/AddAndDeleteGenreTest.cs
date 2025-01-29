using BookStore;
using BookStore.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace StoreTest
{
    [TestClass]
    public class GenresPageTest
    {
        private BookStoreEntities _context;
        private GenresPage _genresPage;
        private AddGenrePage _addGenrePage;

        [TestInitialize]
        public void Setup()
        {
            _context = new BookStoreEntities();
            _genresPage = new GenresPage();
            _addGenrePage = new AddGenrePage();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Dispose();
        }

        [TestMethod]
        public void AddGenre_Test()
        {
            string testGenreName = "Test Genre1";

            _addGenrePage.AddGenre(testGenreName);

            var addedGenre = _context.Genres.FirstOrDefault(g => g.GenreName == testGenreName);
            Assert.IsNotNull(addedGenre);
        }

        [TestMethod]
        public void DeleteGenre_Test()
        {
            string testGenreName = "Test Genre2";
            var genre = new Genres { GenreName = testGenreName };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            _genresPage.DeleteGenre(genre.GenreID);

            var deletedGenre = _context.Genres.FirstOrDefault(g => g.GenreName == testGenreName);
            Assert.IsNull(deletedGenre);
        }
    }
}