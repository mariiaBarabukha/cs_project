using System;
using System.Collections.Generic;
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
            _wallets = new List<lab.Wallet>();
            MessageBox.Show(_customer.Email);
            walletsHandler = new WalletsHandler(_customer.Email);
            walletsHandler.findRecords();
           // MessageBox.Show(walletsHandler.Records[0]);
            foreach (string line in walletsHandler.Records)
            {
                string[] w = line.Split(' ');
                //MessageBox.Show($"{w[0]}, {w[1]}, {Convert.ToDouble(w[2])}, {w[3]}");
                lab.Wallet wal = new lab.Wallet(_customer, w[1], Convert.ToDouble(w[2]), w[3], w[4]);
                _customer.AddWallet(wal);
                _wallets.Add(wal);

            }
            //return _customer.GetWallets();
        }

        public static void AddRecord(lab.Wallet w)
        {
            walletsHandler.AddRecord(w);
            _customer.AddWallet(w);
            _wallets.Add(w);
        }

        public static void Remove(string name)
        {
            walletsHandler.Remove(name);
        }

        public static void Change(string name_old,string name_new, double bal_old, double bal_new)
        {
            //MessageBox.Show($"{name_new}");   
            lab.Wallet w = _customer.GetWalletByName(name_new);
            walletsHandler.RemoveUseless(name_old,name_new,bal_old,bal_new);
            w.Name = name_new;
            walletsHandler.AddRecord(w);
        }
    }
}
