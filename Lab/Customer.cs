using System.Collections.Generic;
using System;
using Lab;

namespace lab{

   public class Customer{      
        string _firstName;
        string _lastName;
        string _email;

        List<Wallet> wallets = new List<Wallet>();
        List<Category> categories = new List<Category>();

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }

        public Customer(string fN, string lN, string email){

            while ((Validity.checkValidity(fN) && Validity.checkValidity(lN) && Validity.checkValidityEmail(email)) == false)
            {
                if (Validity.checkValidity(fN) == false)
                {
                    Console.WriteLine("Enter a valid first name:");
                    fN = Console.ReadLine();
                }

                if (Validity.checkValidity(lN) == false)
                {
                    Console.WriteLine("Enter a valid last name:");
                    lN = Console.ReadLine();
                }

                if (Validity.checkValidityEmail(email) == false)
                {
                    Console.WriteLine("Enter a valid email:");
                    email = Console.ReadLine();
                }
            }

            _firstName = fN;
            _lastName = lN;
            _email = email;
        }

       

// провірити на коректність ім'я та прізвище
       

        public bool AddCategory(string name, string description, string color, string icon){
            var check = true;
            foreach(Category c in categories){
                if(c._name == name){
                    check = false;
                    break;
                }
            }
            if(check){
                categories.Add(new Category(name,description,color,icon));                
            }

            return check;
             
        }

        public bool AddCategory(Category category)
        {
            var check = true;
            if (categories.Contains(category))
            {
                check = false;
            }
            if (check)
            {
                categories.Add(category);
            }

            return check;

        }
        public List<Category> GetCategories(){
            return categories;
        }

        public bool AddWallet(string name, double sB, string description, string bC){
            var check = true;
            foreach(Wallet c in wallets){
                if(c.Name == name){
                    check = false;
                    break;
                }
            }
            if(check)
                wallets.Add(new Wallet(this, name, sB,description, bC));
            return check;
        }

        public bool AddWallet(Wallet wallet){
            if(wallets.Contains(wallet)){
                return false;
            }
            wallets.Add(wallet);
            wallet.AddOwner(this);
            return true;
        }
        public List<Wallet> GetWallets(){
            return wallets;
        }   

        public bool ShareWallet(Customer costumer, Wallet wallet){
            if (costumer.GetWallets().Contains(wallet))
            {
                return false;
            }
            else
            {
                costumer.AddWallet(wallet);
                return true;
            }
            
        }

            
    }
}