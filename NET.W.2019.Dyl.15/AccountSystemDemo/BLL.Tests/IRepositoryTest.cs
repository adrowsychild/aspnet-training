using System;
using System.Collections.Generic;
using BLL.Interface.Entities;
using DAL.Repositories;
using BLL.Mappers;
using Moq;

namespace BLL.Tests
{
    public class IRepositoryTest
    {
        public void InitRepo()
        {
            var mock = new Mock<IRepository>();
            Account defaultAcc = new BaseAccount(1, "John", "Smith");
            mock.Setup(repo => repo.AddAccount(defaultAcc.ToDalAccount()));
        }
    }
}
