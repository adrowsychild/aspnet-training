using System;
using BLL.Interface.Entities;
using DAL.Interface.Interfaces;

namespace BLL.Mappers
{
    public static class Mapper
    {
        public static Account ToAccount(this DalAccount dalAccount)
        {
            return (Account)Activator.CreateInstance(
                GetAccountType(dalAccount.AccountType),
                dalAccount.Id,
                dalAccount.FirstName, 
                dalAccount.LastName, 
                dalAccount.Sum, 
                dalAccount.Bonus);
        }

        public static DalAccount ToDalAccount(this Account account)
        {
            return new DalAccount
            {
                AccountType = account.GetType().Name,
                Id = account.Id,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Sum = account.Sum,
                Bonus = account.Bonus,
            };
        }

        private static Type GetAccountType(string type)
        {
            if (type.Contains("Base"))
            {
                return typeof(BaseAccount);
            }

            if (type.Contains("Silver"))
            {
                return typeof(BaseAccount);
            }

            if (type.Contains("Gold"))
            {
                return typeof(GoldAccount);
            }

            if (type.Contains("Platinum"))
            {
                return typeof(PlatinumAccount);
            }

            return typeof(BaseAccount);
        }
    }
}
