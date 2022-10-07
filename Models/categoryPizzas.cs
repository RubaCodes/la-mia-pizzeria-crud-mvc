namespace la_mia_pizzeria_static.Models
{
    public class categoryPizzas
    {
        public Pizza Pizza { get; set; }
        public List<Category> Categories { get; set; }
        
        public categoryPizzas() {
            Pizza = new Pizza();
        }
    }

}
