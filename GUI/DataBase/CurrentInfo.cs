using GUI.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace GUI.DataBase
{
    public static class CurrentInfo
    {

        private static lab.Customer _customer;
        private static List<lab.Wallet> _wallets = new List<lab.Wallet>();


        public static lab.Customer Customer { get => _customer; set => _customer = value; }
       // private static List<lab.Wallet> _wallets = getWalletsFromDB();
        public static List<lab.Wallet> Wallets 
        {
            get
            {                
                return _wallets;
            }
           
            
        }

        static WalletsHandler walletsHandler;
        public static void getWalletsFromDB()
        {

            walletsHandler = new WalletsHandler(_customer.Email);
           // MessageBox.Show(walletsHandler.Records[0]);
            foreach (string line in walletsHandler.Records)
            {
                string[] w = line.Split(' ');
                MessageBox.Show(w[0]);
                
                lab.Wallet wal = new lab.Wallet(_customer, w[1], Convert.ToDouble(w[2]), w[3], w[4]);
                _wallets.Add(wal);
            }
            //return _customer.GetWallets();
        }

        public static void AddRecord(lab.Wallet w)
        {
            walletsHandler.AddRecord(w);
        }

        public static void Remove(lab.Wallet wallet)
        {
            walletsHandler.Remove(wallet);
        }
    }
}
