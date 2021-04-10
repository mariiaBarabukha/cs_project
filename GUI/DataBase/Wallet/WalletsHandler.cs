
using GUI.WalletDB;
using lab;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;


namespace GUI.DataBase
{
    class WalletsHandler
    {
        protected List<DBWallet> records = new List<DBWallet>();
        string filename = "";

        public string Filename { get => filename; set => filename = value; }

        public async Task write(DBWallet t)
        {
            var res = await GetAllAsync();
            res.Add(t);
            string stringObj = JsonSerializer.Serialize(res);
            using (StreamWriter sw = new StreamWriter(filename))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public async Task<List<DBWallet>> GetAllAsync()
        {
            var res = new List<DBWallet>();
            string t = "";
            using (StreamReader streamReader = new StreamReader(filename))
            {
                t = await streamReader.ReadToEndAsync();
            }

            res = JsonSerializer.Deserialize<List<DBWallet>>(t);

            return res;
        }
       

        // public WalletsHandler(string filename) => this.filename = filename;

        public async Task<List<DBWallet>> Find(string key, string key2 = "")
        {
            var res = new List<DBWallet>();
            string t = "";
            using (StreamReader streamReader = new StreamReader(filename))
            {
                t = await streamReader.ReadToEndAsync();
            }

            res = JsonSerializer.Deserialize<List<DBWallet>>(t);
            if (key2=="")
            {
                foreach (DBWallet dB in res
                .Where(obj => obj.OwnerEmail == key))
                {
                    records.Add(dB);
                }
            }
            else
            {
                foreach (DBWallet dB in res
               .Where(obj => obj.OwnerEmail == key  && obj.Name == key2))
                {
                    records.Add(dB);
                }
            }
            
           
            return records;
        }

        public async Task Remove(string key, string key2)
        {
            
            var toRemove = await Find(key,key2);
            var all = await GetAllAsync();

            
            var res = new List<DBWallet>();

            foreach (DBWallet r in toRemove)
            {
                foreach(DBWallet db in all)
                    
                {
                    if (db.OwnerEmail == r.OwnerEmail&&db.Name == r.Name)
                    {
                        continue;
                    }

                    res.Add(db);
                }

            }
            
            string stringObj = JsonSerializer.Serialize(res);
            using (StreamWriter sw = new StreamWriter(filename))
            {
                await sw.WriteAsync(stringObj);
            }


        }

        public async Task Change(Wallet n, string prev_n)
        {
            await Remove(CurrentInfo.Customer.Email, prev_n);

            await write(new DBWallet(CurrentInfo.Customer.Email, n.Name,n.StartBalance, 
                n.Description, n.BasicCurrency));
           
        }

    }
}
