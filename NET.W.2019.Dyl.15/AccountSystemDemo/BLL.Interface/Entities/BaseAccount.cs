using System;

namespace BLL.Interface.Entities
{
    public class BaseAccount : Account
    {
        public BaseAccount(int _id, string _name, string _lastName, decimal _sum = 0, int _bonus = 0)
            : base(_id, _name, _lastName, _sum, _bonus)
        {
        }
    }
}
