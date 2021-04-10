using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.WalletDB
{
    class DBWallet
    {
        public DBWallet()
        {

        }

        public DBWallet(string ownerEmail, string name,double balance,
            string description, string basicCurrency,
            Guid[] coownerGuids = null)
        {
            WalletGuid = Guid.NewGuid();
            OwnerEmail = ownerEmail;
            Name = name;
            Balance = balance;
            Description = description;
            BasicCurrency = basicCurrency;
            CoownerGuids = coownerGuids;
        }

        public Guid WalletGuid { get; set; }
        public string OwnerEmail { get;set; }
        public string Name { get;  set; }
        public double Balance { get; set; }
        public string Description { get; set; }
        public string BasicCurrency { get; set; }
        public Guid[] CoownerGuids { get; set; }

    }
}
