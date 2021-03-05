using System.Collections.Generic;

namespace lab{

    class Costumer{      
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

        public bool ShareWallet(Costumer costumer, Wallet wallet){
            if(costumer.GetWallets().Contains(wallet)){
                return false;
            }
            costumer.AddWallet(wallet);
            return true;
        }

            
    }
}