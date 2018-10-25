using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Burgershack.Entities;
using Burgershack.Web.Models;
using Burgershack.Business;

namespace Burgershack.Web.Controllers
{
    public class DrinksController : Controller
    { 
        private readonly DrinksService _ds;

        public DrinksController(DrinksService ds)
        {
            _ds = ds;
        }

        // GET: Drinks
        public IActionResult Index()
        {
            return View(_ds.GetAll());
        }

        // GET: Drinks/Details/5
        public IActionResult Details(int id)
        {


            var drink = _ds.GetById(id);
            if (drink == null)
            {
                return NotFound();
            }

            return View(drink);
        }

        // GET: Drinks/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Drinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Drink drink)
        {
            if (ModelState.IsValid)
            {
                Drink d = _ds.Create(drink);
                
                return RedirectToAction(nameof(Index));
            }
            return View(drink);
        }

        // GET: Drinks/Edit/5
        public IActionResult Edit(int id)
        {

            var drink = _ds.GetById(id);
            if (drink == null)
            {
                return NotFound();
            }
            return View(drink);
        }

        // POST: Drinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Drink drink)
        {
            _ds.Update(drink);
            return View(drink);
        }

        //// GET: Drinks/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var drink = await _context.Drink
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (drink == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(drink);
        //}

        //// POST: Drinks/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var drink = await _context.Drink.FindAsync(id);
        //    _context.Drink.Remove(drink);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool DrinkExists(int id)
        //{
        //    return _context.Drink.Any(e => e.Id == id);
        //}
    }
}
