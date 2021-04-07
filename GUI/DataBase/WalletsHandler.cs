using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DataBase
{
    class WalletsHandler
    {
        
        List<string> records;
        string _email;
        string text = "";

        public WalletsHandler(string email)
        {
            records = new List<string>();
            _email = email;
            findRecords();
        }

        public List<string> Records { get => records; }

        private void findRecords()
        {
            StreamReader sr = new StreamReader(@"..\..\..\DataBase\Wallets.txt");
            string line;
            
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Split(' ')[0] == _email)
                {
                   
                    records.Add(line);
                }
                text += (line + '\n');
            }
            sr.Close();
        }

        public void AddRecord(lab.Wallet wallet)
        {
            
            StreamWriter sw = new StreamWriter(@"..\..\..\DataBase\Wallets.txt");
            string line = $"{_email} {wallet.Name} {wallet.Balance}, {wallet.Description}, {wallet.BasicCurrency}";
            sw.WriteLine(line);
            sw.Close();
        }

        public void Remove(lab.Wallet wallet)
        {

            string toRemove = $"{_email} {wallet.Name} {wallet.Balance}, {wallet.Description}, {wallet.BasicCurrency}";
            StreamWriter sw = new StreamWriter(@"..\..\..\DataBase\Wallets.txt");
            string[] lines = text.Split('\n');
            foreach (string l in lines)
            {
                if (l == toRemove)
                {
                    continue;
                }
                sw.WriteLine(l);
            }

            
            sw.Close();
        }
    }
}
