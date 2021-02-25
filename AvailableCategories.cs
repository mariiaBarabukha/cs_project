using System.Collections.Generic;

namespace lab{
    public class AvailableCategories{
        static Dictionary<string,Category> categories = new Dictionary<string,Category>();

        static AvailableCategories availableCategories;
        
        private AvailableCategories(){
            categories.Add("c1", new Category("c1", "ddddd", "red", "icon"));
            categories.Add("c2", new Category("c2", "ddddd", "blue", "icon"));
        }

        public static AvailableCategories GetAvailableCategories(){
            if(availableCategories == null){
                availableCategories = new AvailableCategories();
            }
            return availableCategories;
        }

        public static Category GetCategory(string name){
            GetAvailableCategories();
            return categories[name];
        }

    }
}