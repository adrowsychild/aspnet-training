using System;
using NUnit.Framework;
using Books;

namespace BooksTests
{
    [TestFixture]
    public class BooksTests
    {
        #region Properties
        [Test]
        [TestCase("123-4-56-78910-1")]
        [TestCase("987-6-54-32109-8")]
        [TestCase("000-1-23-45678-0")]
        [Category("BooksTests")]
        public void InitBook_ISBNProperty_Successfully(string testISBN)
        {
            Assert.DoesNotThrow(() =>
            {
                Book testBook = new Book(testISBN, "John", "Thoughts", "Unfamous publisher", 2019, 404, 20);
            });
        }

        [Test]
        [TestCase("12345")]
        [TestCase("-1")]
        [TestCase(null)]
        public void InitBook_ISBNProperty_ThowsArgumentException(string testISBN)
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Book testBook = new Book(testISBN, "John", "Thoughts", "Unfamous publisher", 2019, 404, 20);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void InitBook_AuthorProperty_ThowsArgumentException(string testAuthor)
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Book testBook = new Book("123-4-56-78910-1", testAuthor, "Thoughts", "Unfamous publisher", 2019, 404, 20);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void InitBook_TitleProperty_ThowsArgumentException(string testTitle)
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Book testBook = new Book("123-4-56-78910-1", "John", testTitle, "Unfamous publisher", 2019, 404, 20);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void InitBook_PublisherProperty_ThowsArgumentException(string testPublisher)
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Book testBook = new Book("123-4-56-78910-1", "John", "Thoughts", testPublisher, 2019, 404, 20);
            });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(5019)]
        [TestCase(-5019)]
        public void InitBook_YearProperty_ThowsArgumentException(int testYear)
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Book testBook = new Book("123-4-56-78910-1", "John", "Thoughts", "Unfamous publisher", testYear, 404, 20);
            });
        }

        [Test]
        [TestCase(-1)]
        public void InitBook_NumOfPagesProperty_ThowsArgumentException(int testNumOfPages)
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Book testBook = new Book("123-4-56-78910-1", "John", "Thoughts", "Unfamous publisher", 2019, testNumOfPages, 20);
            });
        }

        [Test]
        [TestCase(-1.5)]
        public void InitPrice_YearProperty_ThowsArgumentException(decimal testPrice)
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Book testBook = new Book("123-4-56-78910-1", "John", "Thoughts", "Unfamous publisher", 2019, 404, testPrice);
            });
        }

        #endregion

        #region Format
        
        [Test]
        [TestCase("A", "Jeffrey Richter")]
        [TestCase("AT", "Jeffrey Richter, \"CLR via C#\"")]
        [TestCase("IAT", "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, \"CLR via C#\"")]
        [TestCase("ATRY", "Jeffrey Richter, \"CLR via C#\", Microsoft Press, 2012")]
        public void Formating_ReturnsFormatedString(string format, string expectedResult)
        {
            Book testBook = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 29.99m);
            
            BookFormat bookFormat = new BookFormat();

            string result = bookFormat.Format(format, testBook, null);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("A", "Markus Zusak")]
        [TestCase("AT", "Markus Zusak, \"The Book Thief\"")]
        [TestCase("ATRY", "Markus Zusak, \"The Book Thief\", EKSMO, 2018")]
        [TestCase("ITRNP", "ISBN 13: 978-5-699-96201-3, \"The Book Thief\", EKSMO, P. 512, 6$")]
        
        public void ToString_ReturnsFormatedString(string format, string expectedResult)
        {
            Book testBook = new Book("978-5-699-96201-3", "Markus Zusak", "The Book Thief", "EKSMO", 2018, 512, 6m);
            string result = testBook.ToString(format, null);
            Assert.AreEqual(expectedResult, result);
        }
        
        #endregion
    }


}