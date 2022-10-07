using la_mia_pizzeria_static.Contexts;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        PizzaContext _pc;
        public PizzaController() {
            _pc = new PizzaContext();
        }
        public IActionResult Index()
        {
            List<Pizza> menu = _pc.Pizzas.Include("Category").ToList();
            return View(menu);
        }

        public IActionResult Show(int id)
        {
            Pizza pizza = _pc.Pizzas.Where(x => x.PizzaId == id).Include("Category").FirstOrDefault();
            return View(pizza);
        }
        /*
         * CREATE
         */
        [HttpGet]
        public IActionResult Create() {
            categoryPizzas categoryPizzas = new();
            categoryPizzas.Categories = _pc.Categories.ToList();
            return View(categoryPizzas);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(categoryPizzas data) {
            /*
             * validazione
             */
            if (!ModelState.IsValid)
            {
                data.Categories = _pc.Categories.ToList();
                return View("Create", data);
            }

            _pc.Pizzas.Add(data.Pizza);
            _pc.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Pizza pizza = _pc.Pizzas.Where(x => x.PizzaId == id).First();
                if (pizza == null)
                {
                    return NotFound("La pizza che stai cercando di modificare non esiste");
                }
            categoryPizzas ctp = new categoryPizzas();
            ctp.Categories = _pc.Categories.ToList();
            ctp.Pizza = pizza;
            return View(ctp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update( int id,  categoryPizzas model) {
            if (!ModelState.IsValid)
            {
                model.Categories = _pc.Categories.ToList();
                return View(model);
            }
            Pizza pizza = _pc.Pizzas.Where(x => x.PizzaId == id).First();
            if (pizza == null)
            {
                return NotFound("La pizza che stai cercando di modificare non esiste");
            }
            pizza.Name = model.Pizza.Name;
            pizza.Description = model.Pizza.Description;
            pizza.Price = model.Pizza.Price;
            pizza.ImgPath = model.Pizza.ImgPath;
            pizza.CategoryId = model.Pizza.CategoryId;
            _pc.SaveChanges();
            return RedirectToAction("Index");
            }

        //delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id){
            Pizza pizza = _pc.Pizzas.Find(id);
            if (pizza == null) {
                return NotFound("La pizza che stai eliminando non esiste");
            }
            _pc.Pizzas.Remove(pizza);
            _pc.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}