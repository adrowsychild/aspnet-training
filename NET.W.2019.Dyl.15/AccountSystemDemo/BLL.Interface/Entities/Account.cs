using System;

namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        #region fields

        protected int id;
        protected string firstName;
        protected string lastName;
        protected decimal sum;
        protected int bonus;

        #endregion

        #region constructor
        protected Account(int _id, string _name, string _lastName, decimal _sum = 0, int _bonus = 0)
        {
            this.Id = _id;
            this.FirstName = _name;
            this.LastName = _lastName;
            this.Sum = _sum;
            this.Bonus = _bonus;
        }

        #endregion

        #region properties

        public int Id
        {
            get => id;

            set
            {
                if (id < 0)
                {
                    throw new ArgumentException();
                }
                id = value;
            }
        }

        public string FirstName
        {
            get => firstName;

            set
            {
                if (string.IsNullOrEmpty(value))
                { 
                    throw new ArgumentNullException();
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                lastName = value;
            }
        }

        public decimal Sum
        {
            get => sum;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                sum = value;
            }
        }

        public int Bonus
        {
            get => bonus;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
            }
        }

        #endregion

        #region tostring
        public override string ToString()
        {
            return $"{this.Id}. {this.FirstName} {this.LastName}, sum: {this.Sum}, bonuses: {this.Bonus} ";
        }

        #endregion

        #region bonus logic

        protected virtual int PutBonusLogic(decimal putSum, int putBonus)
        {
            return (int)putSum / 100 * putBonus;
        }

        protected virtual int WithdrawBonusLogic(decimal withdrawSum, int withdrawBonus)
        {
            return (int)withdrawSum / 100 * withdrawBonus;
        }

        #endregion

        #region put/withdraw

        public void Put(decimal sum, int putBonus)
        {
            Sum += sum;
            Bonus += PutBonusLogic(sum, putBonus);
        }

        public void Withdraw(decimal sum, int withdrawBonus)
        {
            Sum -= sum;
            Bonus -= WithdrawBonusLogic(sum, withdrawBonus);
        }

        #endregion
    }
}
