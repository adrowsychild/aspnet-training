using System;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Repositories;
using Moq;

namespace BLL.Tests
{
    public class IAccountServiceTest
    {
        public void InitAccountTest_ReturnsAccount()
        {
            var mock = new Mock<IAccountService>();
            string owner = "John Smith";
            AccountType type = AccountType.Base;
            AccountNumberCreator creator = new AccountNumberCreator();
            Account defaultAcc = new BaseAccount(1, "John", "Smith");
            Account depositedAcc = new BaseAccount(1, "John", "Smith", 20);
            mock.Setup(accService => accService.OpenAccount(owner, type, creator)).Returns(defaultAcc);
        }

        public void InitAccountTest_ThrowsArgumentException()
        {
            var mock = new Mock<IAccountService>();
            mock.Setup(accService => accService.OpenAccount("", AccountType.Base, null)).Throws<ArgumentNullException>();
        }

    }
}
