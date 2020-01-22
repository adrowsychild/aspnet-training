using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace DAL.Repositories
{
    public class AccountDatabaseRepository : IRepository
    {
        public void AddAccount(DalAccount account)
        {
            using (AccountContext db = new AccountContext())
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }

        public DalAccount GetAccount(int id)
        {
            using (AccountContext db = new AccountContext())
            {
                DalAccount account = db.Accounts.Find(id);
                return account;
            }
        }

        public List<DalAccount> GetAllAccounts()
        {
            using (AccountContext db = new AccountContext())
            {
                List<DalAccount> accounts = db.Accounts.ToList<DalAccount>();
                return accounts;
            }
        }

        public void RemoveAccount(DalAccount account)
        {
            using (AccountContext db = new AccountContext())
            {
                db.Accounts.Remove(account);
                db.SaveChanges();
            }
        }

        public void UpdateAccount(DalAccount account)
        {
            using (AccountContext db = new AccountContext())
            {
                DalAccount dbAccount = db.Accounts.Find(account.Id);

                foreach (var prop in account.GetType().GetProperties())
                {
                    prop.SetValue(dbAccount, (prop.GetValue(account)));
                }

                db.SaveChanges();
            }
        }
    }
}
