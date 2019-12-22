using System;
using System.Collections.Generic;
using BLL.Mappers;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Repositories;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {   
        private const int BaseAccountBonus = 1;
        private const int SilverAccountBonus = 15;
        private const int GoldAccountBonus = 25;
        private const int PlatinumAccountBonus = 50;

        private readonly IRepository repository;

        public AccountService(IRepository repository)
        {
            this.repository = repository;
        }

        public Account OpenAccount(string owner, AccountType accountType, IAccountNumberCreateService creator)
        {
            Account account;
            string[] fullName = owner.Split();
            switch (accountType)
            {
                case AccountType.Base:
                    account = new BaseAccount(creator.GenerateId(), fullName[0], fullName[1]);
                    break;
                case AccountType.Silver:
                    account = new SilverAccount(creator.GenerateId(), fullName[0], fullName[1]);
                    break;
                case AccountType.Gold:
                    account = new GoldAccount(creator.GenerateId(), fullName[0], fullName[1]);
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount(creator.GenerateId(), fullName[0], fullName[1]);
                    break;
                default:
                    account = new BaseAccount(creator.GenerateId(), fullName[0], fullName[1]);
                    break;
            }

            this.repository.AddAccount(account.ToDalAccount());
            return account;
        }

        public void DepositAccount(Account account, decimal sum)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (sum < 0)
            {
                throw new ArgumentException("Deposit value can't be less than 0.");
            }

            switch (account.GetType().ToString())
            {
                case "BaseAccount":
                    account.Put(sum, BaseAccountBonus);
                    break;
                case "SilverAccount":
                    account.Put(sum, SilverAccountBonus);
                    break;
                case "GoldAccount":
                    account.Put(sum, GoldAccountBonus);
                    break;
                case "PlatinumAccount":
                    account.Put(sum, PlatinumAccountBonus);
                    break;
                default:
                    account.Put(sum, BaseAccountBonus);
                    break;
            }

            this.repository.UpdateAccount(account.ToDalAccount());
        }

        public void DepositAccount(int id, decimal sum)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("Id mustn't be less than 1.");
            }

            if (sum < 0)
            {
                throw new ArgumentException("Deposit value can't be less than 0.");
            }

            Account account = repository.GetAccount(id).ToAccount();
            switch (account.GetType().ToString())
            {
                case "BaseAccount":
                    account.Put(sum, BaseAccountBonus);
                    break;
                case "SilverAccount":
                    account.Put(sum, SilverAccountBonus);
                    break;
                case "GoldAccount":
                    account.Put(sum, GoldAccountBonus);
                    break;
                case "PlatinumAccount":
                    account.Put(sum, PlatinumAccountBonus);
                    break;
                default:
                    account.Put(sum, BaseAccountBonus);
                    break;
            }
            this.repository.UpdateAccount(account.ToDalAccount());
        }

        public void WithdrawAccount(Account account, decimal sum)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (sum < 0)
            {
                throw new ArgumentException("Withdraw value can't be less than 0!");
            }

            switch (account.GetType().ToString())
            {
                case "BaseAccount":
                    account.Withdraw(sum, BaseAccountBonus);
                    break;
                case "SilverAccount":
                    account.Withdraw(sum, SilverAccountBonus);
                    break;
                case "GoldAccount":
                    account.Withdraw(sum, GoldAccountBonus);
                    break;
                case "PlatinumAccount":
                    account.Withdraw(sum, PlatinumAccountBonus);
                    break;
                default:
                    account.Withdraw(sum, BaseAccountBonus);
                    break;
            }
            
            this.repository.UpdateAccount(account.ToDalAccount());
        }

        public void WithdrawAccount(int id, decimal sum)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("Id mustn't be less than 1.");
            }

            if (sum < 0)
            {
                throw new ArgumentException("Withdraw value can't be less than 0!");
            }

            Account account = repository.GetAccount(id).ToAccount();

            switch (account.GetType().ToString())
            {
                case "BaseAccount":
                    account.Withdraw(sum, BaseAccountBonus);
                    break;
                case "SilverAccount":
                    account.Withdraw(sum, SilverAccountBonus);
                    break;
                case "GoldAccount":
                    account.Withdraw(sum, GoldAccountBonus);
                    break;
                case "PlatinumAccount":
                    account.Withdraw(sum, PlatinumAccountBonus);
                    break;
                default:
                    account.Withdraw(sum, BaseAccountBonus);
                    break;
            }

            this.repository.UpdateAccount(account.ToDalAccount());
        }

        public void CloseAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            this.repository.RemoveAccount(account.ToDalAccount());
        }

        public void CloseAccount(int id)
        {
            if (id < 1)
            {
                throw new ArgumentNullException("Id mustn't be less than 1.");
            }

            Account account = repository.GetAccount(id).ToAccount();
            this.repository.RemoveAccount(account.ToDalAccount());
        }

        public Account GetAccount(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("Id mustn't be less than 1.");
            }

            return repository.GetAccount(id).ToAccount();
        }

        public List<Account> GetAllAccounts()
        {
            List<DalAccount> dalAccounts = repository.GetAllAccounts();
            List<Account> accounts = new List<Account>();
            foreach (var dalAcc in dalAccounts)
            {
                accounts.Add(dalAcc.ToAccount());
            }

            return accounts;
        }
    }
}
