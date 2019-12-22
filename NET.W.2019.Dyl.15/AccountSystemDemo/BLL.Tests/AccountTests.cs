using System;
using BLL.Interface.Entities;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class AccountTests
    {
        [Test]
        [TestCase(-1)]
        public void InitAccount_IdProperty_ThrowsArgumentException(int id)
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Account account = new BaseAccount(id, "John", "Smith");
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("    ")]
        public void InitAccount_FirstNameProperty_ThrowsArgumentNullException(string firstName)
        {
            var ex = Assert.Catch<ArgumentNullException>(() =>
            {
                Account account = new BaseAccount(1, firstName, "Smith");
            });
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("    ")]
        public void InitAccount_LastNameProperty_ThrowsArgumentNullException(string lastName)
        {
            var ex = Assert.Catch<ArgumentNullException>(() =>
            {
                Account account = new BaseAccount(1, "John", lastName);
            });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-100)]
        public void InitAccount_SumProperty_ThrowsArgumentException(decimal sum)
        {
            var ex = Assert.Catch<ArgumentException>(() =>
            {
                Account account = new BaseAccount(1, "John", "Smith", sum);
            });
        }
    }
}
