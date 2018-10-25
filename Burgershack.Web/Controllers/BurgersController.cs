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
    public class BurgersController : Controller
    {
        private readonly BurgersService _bs;

        public BurgersController(BurgersService bs)
        {
            _bs = bs;
        }

        // GET: Burgers
        public IActionResult Index()
        {
            return View(_bs.GetAll());
        }

        // GET: Burgers/Details/5
        public IActionResult Details(int id)
        {
            var burger = _bs.GetById(id);
            if (burger == null)
            {
                return NotFound();
            }

            return View(burger);
        }

        // GET: Burgers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Burgers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Burger burger)
        {
            if (ModelState.IsValid)
            {
                Burger b = _bs.Create(burger);
                return RedirectToAction(nameof(Index));
            }
            return View(burger);
        }

        //// GET: Burgers/Edit/5
        public IActionResult Edit(int id)
        {
            var burger = _bs.GetById(id);
            if (burger == null)
            {
                return NotFound();
            }
            return View(burger);
        }

        //// POST: Burgers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] Burger burger)
        {
            _bs.UpdateBurger(burger);
            return View(burger);
        }

        //// GET: Burgers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var burger = await _context.Burger
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (burger == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(burger);
        //}

        //// POST: Burgers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var burger = await _context.Burger.FindAsync(id);
        //    _context.Burger.Remove(burger);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BurgerExists(int id)
        //{
        //    return _context.Burger.Any(e => e.Id == id);
        //}
    }
}
