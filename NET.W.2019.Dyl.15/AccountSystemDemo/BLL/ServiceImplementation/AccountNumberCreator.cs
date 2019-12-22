using System;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        private int idCounter;

        public int GenerateId()
        {
            return ++idCounter;
        }
    }
}
