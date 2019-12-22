using System;
using System.Collections.Generic;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        Account OpenAccount(string owner, AccountType accountType, IAccountNumberCreateService creator);
        
        void DepositAccount(Account account, decimal sum);

        void DepositAccount(int id, decimal sum);
        
        void WithdrawAccount(Account account, decimal sum);

        void WithdrawAccount(int id, decimal sum);
        
        void CloseAccount(Account account);

        void CloseAccount(int id);
        
        Account GetAccount(int id);

        List<Account> GetAllAccounts();
    }
}
