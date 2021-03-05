using System;
namespace lab{
    public class Category{
        public string _name;
        string _description;
        string _color;
        string _icon;

        public Category()
        {

        }

        //if name is null, need to ask to recreate
        public Category(string name, string description, string color, string icon){
            if(name == "")
            {
                Console.WriteLine("Entered name is invalid, try using another name:");
                name = Console.ReadLine();

            }
            _name = name;

            _description = description;

            if(color == "")
            {
                color = "black";
            }
            _color = color;

            if(icon == "")
            {
                icon = "default";
            }
            _icon = icon;
        }

        public Category CopyCategory(){
            return new Category(_name, _description, _color, _icon);
        }
    }
}