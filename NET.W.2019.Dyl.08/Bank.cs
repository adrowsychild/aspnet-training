using System;
using System.Collections.Generic;
using System.IO;

namespace Bank
{
    public abstract class Account
    {
        private static List<Account> accounts;

        protected static int idCounter;

        protected bool isOpened = false;

        protected int Id { get; set; }

        protected string Name { get; private set; }

        protected string LastName { get; private set; }

        protected decimal Sum { get; private set; }

        protected int Bonus { get; private set; }

        protected static int PutCost;

        protected static int WithdrawCost;

        public static int? PutBonus = null;

        public static int? WithdrawBonus = null;

        protected Account() 
        {
            accounts = new List<Account>();
        }

        protected Account(string _name, string _lastName)
        {
            this.Name = _name;
            this.LastName = _lastName;
            this.Id = idCounter;
            this.Sum = 0;
            accounts[idCounter] = this;
            idCounter++;
        }

        public override string ToString()
        {
            string str = "";
            str += "Id: " + this.Id + " Name: " + this.Name + " Last Name: " + this.LastName
                + " Sum: " + this.Sum + " Bonus" + this.Bonus;
            return str;
        }

        public void Open()
        {
            if (this.isOpened)
            {
                Console.WriteLine("The Account has already been opened!");
                return;
            }
            else
            {
                if ((PutBonus == null) && (WithdrawBonus == null))
                {
                    Console.WriteLine("Please, set the PutBonus and WithdrawBonus at first.");
                    return;
                }
            }

            this.Id = idCounter.GetHashCode();
            idCounter++;

            Console.WriteLine("Congradulation!");
            Console.WriteLine("Your Bank Account was created!");
            Console.WriteLine("Your Id is: " + this.Id);

            this.isOpened = true;
            accounts.Add(this);
        }

        public decimal Close()
        {
            if (!this.isOpened)
            {
                Console.WriteLine("Account hasn't been opened!");
                Console.WriteLine("There is nothing to close!");
                return 0;
            }

            decimal moneyLeft = this.Sum;

            if (moneyLeft > 0)
            {
                Console.WriteLine("Please, take your money left: " + moneyLeft + " $.");
            }
            else
            {
                Console.WriteLine("You have no money to take back.");
            }

            Console.WriteLine("Dear " + this.Name + ",");
            Console.WriteLine("Your account has been closed! Come here again :)");
            accounts.Remove(this);
            this.isOpened = false;

            return moneyLeft;
        }

        public void Put(decimal money)
        {
            if (!this.isOpened)
            {
                Console.WriteLine("There is nowhere to put your money to!");
                Console.WriteLine("Please, create your account first.");
                return;
            }

            if (money < PutCost)
            {
                Console.WriteLine("You don't have enough money to carry out the operation.");
                return;
            }

            Sum += money;
            Console.WriteLine(money + "$ have been successfully put on your account!");
            int bonusBuff = BonusLogic(money, true);
            Console.WriteLine(bonusBuff+" bonuses were added to your account.");
            Sum -= (decimal)PutCost;
        }

        public decimal Withdraw(decimal money)
        {
            if (!this.isOpened)
            {
                Console.WriteLine("There is nowhere to withdraw your money from!");
                Console.WriteLine("Please, create your account first.");
                return 0;
            }

            if (money > Sum)
            {
                Console.WriteLine("You have less money than you want to withdraw!");
                return 0;
            }

            if (money < PutCost)
            {
                Console.WriteLine("You don't have enough money to carry out the operation.");
                return 0;
            }

            Sum -= money;
            Console.WriteLine(this.Sum + "$ have been successfully withdrawned!");
            int bonusBuff = BonusLogic(money, false);
            Console.WriteLine(bonusBuff + " bonuses were added to your account.");
            Sum -= WithdrawCost;
            return Sum;
        }

        protected virtual int BonusLogic(decimal money, bool operation)
        {
            int bonusBuff = 0;
            for (int i = 0; i < money; i++)
            {
                if (operation)
                {
                    bonusBuff += (int)PutBonus;
                }
                else
                {
                    bonusBuff += (int)WithdrawBonus;
                }
            }
            Bonus += bonusBuff;
            return bonusBuff;
        }

        public virtual void BonusInfo()
        {
            Console.WriteLine("There are " + Bonus + " bonuses on your account.");
        }

        public virtual void CheckBalance() 
        {
            Console.WriteLine("You have " + Sum + "$ on your account.");
            Console.WriteLine("You also have " + Bonus + " bonuses left.");
        }

        public static void DoingStorage()
        {
            Console.WriteLine("Enter the path to store information at: ");
            string path = Console.ReadLine();

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Account b in accounts)
                {
                    writer.Write(b.ToString());
                }
            }
        }

    }

    public class BaseAccount : Account
    {
        public BaseAccount(string _name, string _lastName)
        {

        }
    }

    public class GoldAccount : Account
    {
        public GoldAccount(string _name, string _lastName)
        {

        }
    }

    public class PlatinumAccount : Account
    {
        public PlatinumAccount(string _name, string _lastName)
        {

        }
    }

    class Bank
    {
        static void Main(string[] args)
        {
            var baseAccount1 = new BaseAccount("John", "Smith");
            Account.PutBonus = 5;
            Account.WithdrawBonus = 3;
            baseAccount1.Open();
            baseAccount1.Put(10);
            baseAccount1.Withdraw(20);
            baseAccount1.Withdraw(5);
            baseAccount1.CheckBalance();
            baseAccount1.BonusInfo();
            baseAccount1.Open();
            var platinumAccount = new PlatinumAccount("Harry", "Potter");
            platinumAccount.Open();
            platinumAccount.Withdraw(2);
            platinumAccount.Put(5);
            platinumAccount.Put(10);
            Account.DoingStorage();
            Console.ReadKey();
        }
    }
}
