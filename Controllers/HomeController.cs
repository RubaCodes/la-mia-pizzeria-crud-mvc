using la_mia_pizzeria_static.Contexts;
using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class HomeController : Controller
    {
        PizzaContext _context;
        public HomeController() {
            _context = new PizzaContext();
        }
        public IActionResult Index()
        {
            List<Pizza> pizze = _context.Pizzas.Include("Ingredients").Include("Category").ToList();
            return View(pizze);
        }
        public IActionResult Show(int id)
        {
            Pizza pizza = _context.Pizzas.Where(x => x.PizzaId == id).Include("Category").Include("Ingredients").FirstOrDefault();
            return View(pizza);
        }
    }
}
