using la_mia_pizzeria_static.Contexts;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<Pizza> menu = new List<Pizza>();
            using (PizzaContext db = new PizzaContext())
            {
                menu = (from e in db.Pizzas select e).ToList();
            }
            return View(menu);
        }

        public IActionResult Show(int id)
        {
            Pizza pizza = new Pizza();
            using (PizzaContext db = new PizzaContext())
            {
                pizza = db.Pizzas.Where(x => x.PizzaId == id).FirstOrDefault();
            }
            return View(pizza);
        }


        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza data) {
            /*
             * validazione
             */
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }
            using (PizzaContext db = new PizzaContext()) {
                db.Pizzas.Add(data);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzaContext pc = new PizzaContext()) { 
            Pizza pizza = pc.Pizzas.Where(x => x.PizzaId == id).First();
                if (pizza == null)
                {
                    return NotFound("La pizza che stai cercando di modificare non esiste");
                }
                return View(pizza);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza model) {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (PizzaContext pc = new PizzaContext())
            {
                Pizza pizza = pc.Pizzas.Where(x => x.PizzaId == id).First();
                if (pizza == null)
                {
                    return NotFound("La pizza che stai cercando di modificare non esiste");
                }
                pizza.Name = model.Name;
                pizza.Description = model.Description;
                pizza.Price = model.Price;
                pizza.ImgPath = model.ImgPath;
                pc.SaveChanges();
                //oppure con update
                //pc.Pizzas.Update(model);
                return RedirectToAction("Index");
            }

        }

        //delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id){

            using (PizzaContext pc = new PizzaContext()) {
                //Pizza pizza = pc.Pizzas.Find(x => x.PizzaId == id);
                Pizza pizza = pc.Pizzas.Where(x => x.PizzaId == id).First();
                if (pizza == null) {
                    return NotFound("La pizza che stai eliminando non esiste");
                }
                pc.Pizzas.Remove(pizza);
                pc.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}