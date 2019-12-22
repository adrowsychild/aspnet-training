using System;
using System.Collections.Generic;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public interface IRepository
    {
        void AddAccount(DalAccount account);

        void RemoveAccount(DalAccount account);

        void UpdateAccount(DalAccount account);

        DalAccount GetAccount(int id);

        List<DalAccount> GetAllAccounts();
    }
}
