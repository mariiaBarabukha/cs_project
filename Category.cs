namespace lab{
    public class Category{
        public string _name;
        string _description;
        string _color;
        string _icon;

        public Category(string name, string description, string color, string icon){
            _name = name;
            _description = description;
            _color = color;
            _icon = icon;
        }

        public Category CopyCategory(){
            return new Category(_name, _description, _color, _icon);
        }
    }
}