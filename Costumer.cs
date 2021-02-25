using System.Collections.Generic;

namespace lab{

    class Costumer{
        //should be deleted
        string _test;


        string _firstName;
        string _lastName;
        string _email;

        List<Wallet> wallets = new List<Wallet>();
        List<Category> categories = new List<Category>();

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }

        public Costumer(string fN, string lN, string email){
            _firstName = fN;
            _lastName = lN;
            _email = email;
        }

// провірити на коректність ім'я та прізвище
       

        public void AddCategory(string name){
            var check = true;
            foreach(Category c in categories){
                if(c._name == name){
                    check = false;
                    break;
                }
            }
            if(check)
             categories.Add(AvailableCategories.GetCategory(name));
        }

        public List<Category> GetCategories(){
            return categories;
        }

        public void AddWallet(string name, double sB, string description, string bC){
            wallets.Add(new Wallet(this, name, sB,description, bC));
        }

        public void AddWallet(Wallet wallet){
            wallets.Add(wallet);
            wallet.AddOwner(this);
        }
        public List<Wallet> GetWallets(){
            return wallets;
        }   

        public void ShareWallet(Costumer costumer, Wallet wallet){
            costumer.AddWallet(wallet);
        }

            
    }
}