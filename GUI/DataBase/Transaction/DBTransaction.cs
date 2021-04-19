using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DataBase
{
    class DBTransaction
    {

        public DBTransaction(Guid w_guid, string description, double sum, DateTime dateTime,
           string currency, string file)
        {
            TransactionGuid = Guid.NewGuid();
            WalletGuid = w_guid;
            Description = description;
            Sum = sum;
            Date = dateTime;
            Currency = currency;
            File = file;
        }

        public Guid TransactionGuid { get; set; }
        public Guid WalletGuid { get; set; }
        public string Description { get; set ; }        
        public double Sum { get; set; }
        public DateTime Date { get; set; }
        public string Currency { get; set; }
        public string File { get; set; }

       
    }
}
