using System;

namespace DAL.Interface.Interfaces
{
    public class DalAccount
    {
        public string AccountType { get; set; }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Sum { get; set; }

        public int Bonus { get; set; }
    }
}
