using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace la_mia_pizzeria_static.Models
{
    public class categoryPizzas
    {
        public Pizza Pizza { get; set; }
        public List<Category> Categories { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<int> SelectedIngredients { get; set; }
        
        public categoryPizzas() {
            Pizza = new Pizza();
            Categories = new List<Category>();
            Ingredients = new List<Ingredient>();
            SelectedIngredients = new List<int>();

        }
    }

}
