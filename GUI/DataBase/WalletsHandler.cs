﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            //findRecords();
        }

        public List<string> Records { get => records; }

        public void findRecords()
        {
            StreamReader sr = new StreamReader(@"..\..\..\DataBase\Wallets.txt");
            string line;
            //MessageBox.Show(_email);
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Split(' ')[0] == _email.Trim())
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
            string line = $"{_email.Trim()} {wallet.Name} {wallet.Balance} {wallet.Description} {wallet.BasicCurrency}";
            text = text.Trim();
            sw.Write(text += ('\n' + line));
            sw.Close();

        }

        public void Remove(string name)
        {
            
            MessageBox.Show($"{CurrentInfo.Wallets.Count}");
            lab.Wallet wallet = CurrentInfo.Customer.GetWalletByName(name);
            if (wallet!=null) {
                removePart(wallet);
                CurrentInfo.Customer.RemoveWallet(name);

                //sw.Close();
            }
        }

        public void RemoveUseless(string o, string n, double bo, double bn)
        {
            //MessageBox.Show($"{CurrentInfo.Wallets.Count}");
            lab.Wallet wallet = CurrentInfo.Customer.GetWalletByName(n);
            wallet.Name = o;
            wallet.Balance = bo;
            if (wallet != null)
            {
                removePart(wallet);
                //CurrentInfo.Customer.RemoveWallet(o);

                //sw.Close();
            }
            wallet.Name = n;
            wallet.Balance = bn;
        }

        private void removePart(lab.Wallet wallet)
        {
            string temp = "";
            string toRemove = $"{_email.Trim()} {wallet.Name} {wallet.Balance} {wallet.Description} {wallet.BasicCurrency}";
            StreamWriter sw = new StreamWriter(@"..\..\..\DataBase\Wallets.txt");
            string[] lines = text.Split('\n');
            foreach (string l in lines)
            {
                if (l == toRemove)
                {
                    continue;
                }
                temp += (l+'\n');
            }
            text = temp;
            //CurrentInfo.Customer.RemoveWallet(name);
            sw.WriteLine(temp);
            sw.Close();
        }
    }
}
