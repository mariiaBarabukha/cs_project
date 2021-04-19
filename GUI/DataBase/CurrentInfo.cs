using lab;
using System;
using System.Collections.Generic;
using System.Windows;
using GUI.Transactions;
using GUI.Wallets;

namespace GUI.DataBase
{
    public static class CurrentInfo
    {
        
        public static Customer Customer { get; set; }
        public static WalletInfo WalletInfo { get; set; }
        public static TransactionInfo TransactionInfo { get; set; }
    }
}
