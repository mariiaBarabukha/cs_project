using GUI.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUI.DataBase
{
    public static class CurrentInfo
    {
        private static lab.Customer _customer;
       // private static List<lab.Wallet> _wallets;


        public static lab.Customer Customer { get => _customer; set => _customer = value; }
        public static List<lab.Wallet> Wallets 
        {
            get
            {
                return _customer.GetWallets();
            }
        }
    }
}
