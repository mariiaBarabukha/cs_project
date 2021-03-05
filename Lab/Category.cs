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

            while (name == "")
            {
                    Console.WriteLine("Enter a valid name for the category.");
                    name = Console.ReadLine();
            }
                
            if (color == "")
            {
                color = "black";
            }

            if (icon == "")
            {
                icon = "default";
            }

            Description = description;
            _name = name;
            Color = color;
            Icon = icon;

        }

        public string Description { get => _description; set => _description = value; }
        public string Color { get => _color; set => _color = value; }
        public string Icon { get => _icon; set => _icon = value; }

        public Category CopyCategory(){
            return new Category(_name, Description, Color, Icon);
        }
    }
}