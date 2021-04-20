using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.DataBase
{ 
    class TransactionsHandler
    {
        protected List<DBTransaction> records = new List<DBTransaction>();
        string filename = "";

        public string Filename { get => filename; set => filename = value; }

        public async Task write(DBTransaction t)
        {
            var res = await GetAllAsync();
            res.Add(t);
            string stringObj = JsonConvert.SerializeObject(res);
            using (StreamWriter sw = new StreamWriter(filename))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public async Task<List<DBTransaction>> GetAllAsync()
        {
            var res = new List<DBTransaction>();
            string t = "";
            using (StreamReader streamReader = new StreamReader(filename))
            {
                t = await streamReader.ReadToEndAsync();
            }

            res = JsonConvert.DeserializeObject<List<DBTransaction>>(t);

            return res;
        }

        public async Task<List<DBTransaction>> Find(Guid key, bool byTrKey = false)
        {
            var res = new List<DBTransaction>();
            string t = "";
            using (StreamReader streamReader = new StreamReader(filename))
            {
                t = await streamReader.ReadToEndAsync();
            }


            res = JsonConvert.DeserializeObject<List<DBTransaction>>(t);

            if (byTrKey)
            {
                fByTr(res,key);
            }
            else
            {
                fByWallet(res, key);
            }
           
            return records;
        }

        private void fByWallet(List<DBTransaction> res, Guid key)
        {
            //int i = 0;
            foreach (var u in res
               .Where(obj => obj.WalletGuid == key))
            {
               
                
                //MessageBox.Show((string)u["FirstName"]);
                records.Add(u);
            }
        }
        private void fByTr(List<DBTransaction> res, Guid key)
        {
            //int i = 0;
            foreach (var u in res
               .Where(obj => obj.TransactionGuid == key))
            {
                              
                //MessageBox.Show((string)u["FirstName"]);
                records.Add(u);
            }
        }

        public async Task Remove(Guid tr)
        {

            var toRemove = await Find(tr,true);
            var all = await GetAllAsync();


            var res = new List<DBTransaction>();

            foreach (var db in all)
            {
                if(toRemove[0] == null)
                    MessageBox.Show("Something went wrong. Please, try again");
                else
                    if (toRemove[0].TransactionGuid == db.TransactionGuid)
                        continue;
                res.Add(db);               

            }

            string stringObj = JsonConvert.SerializeObject(res);
            using (StreamWriter sw = new StreamWriter(filename))
            {
                await sw.WriteAsync(stringObj);
            }


        }

        public async Task Change(lab.Transaction n)
        {
            await Remove(n.Guid);
            var transaction = new DBTransaction(CurrentInfo.Wallet.Guid, n.Description, 
                n.Sum, n.Date, n.Currency, n.File);
            await write(transaction);

        }
    }
}
