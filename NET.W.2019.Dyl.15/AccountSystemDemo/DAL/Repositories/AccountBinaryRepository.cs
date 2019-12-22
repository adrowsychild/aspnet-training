using System;
using System.IO;
using System.Collections.Generic;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class AccountBinaryRepository : IRepository
    {
        private readonly string path;

        public AccountBinaryRepository(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new NullReferenceException("Invalid path.");
            }

            this.path = path;

            File.Create(path).Close();
        }

        public void AddAccount(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException();
            }

            List<DalAccount> accounts = new List<DalAccount>(LoadFromStorage());
            if (accounts.Contains(account))
            {
                throw new ArgumentException("Bank account already exists in the storage");
            }

            accounts.Add(account);
            SaveToStorage(accounts);
        }

        public void RemoveAccount(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            List<DalAccount> accounts = LoadFromStorage();

            if (accounts.Contains(account))
            {
                accounts.Remove(account);
                SaveToStorage(accounts);
            }
            else
            {
                throw new ArgumentException("There is no such account in the storage.");
            }
        }

        public void UpdateAccount(DalAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            List<DalAccount> accounts = LoadFromStorage();

            DalAccount foundAcc = accounts.Find(acc => acc.Id == account.Id);
            if (foundAcc == null)
            {
                throw new ArgumentException("There is no such account in the storage.");
            }

            accounts.Remove(foundAcc);
            accounts.Add(account);
            SaveToStorage(accounts);
        }

        public DalAccount GetAccount(int id)
        {
            List <DalAccount> accounts = LoadFromStorage();
            DalAccount foundAcc = accounts.Find(acc => acc.Id == id);
            return foundAcc;
        }

        public List<DalAccount> GetAllAccounts()
        {
            return LoadFromStorage();
        }

        private List<DalAccount> LoadFromStorage()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(this.path, FileMode.OpenOrCreate)))
            {
                List<DalAccount> accounts = new List<DalAccount>();
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    var id = reader.ReadInt32();
                    var firstName = reader.ReadString();
                    var lastName = reader.ReadString();
                    var sum = reader.ReadDecimal();
                    var bonus = reader.ReadInt32();
                    var type = reader.ReadString();

                    accounts.Add(new DalAccount
                    {
                        Id = id,
                        FirstName = firstName,
                        LastName = lastName,
                        Sum = sum,
                        Bonus = bonus,
                        AccountType = type,
                    });
                }

                return accounts;
            }
        }

        private void SaveToStorage(List<DalAccount> accounts)
        {
            if (accounts == null)
            {
                throw new ArgumentNullException();
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(this.path, FileMode.Create)))
            {
                foreach (var account in accounts)
                {
                    writer.Write(account.Id);
                    writer.Write(account.FirstName);
                    writer.Write(account.LastName);
                    writer.Write(account.Sum);
                    writer.Write(account.Bonus);
                    writer.Write(account.AccountType);
                }
            }
        }

    }
}
