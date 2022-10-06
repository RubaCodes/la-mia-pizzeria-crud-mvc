using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria_static.Models;
namespace la_mia_pizzeria_static.Contexts
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilding)
        {
            optionsBuilding.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizzeria;Integrated Security=True");
        }
    }
}
