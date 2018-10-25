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
    public class SidesController : Controller
    {
        private readonly SidesService _service;

        public SidesController(SidesService service)
        {
            _service = service;
        }

        // GET: Sides
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: Sides/Details/5
        public IActionResult Details(int id)
        {

            var side = _service.GetById(id);
            if (side == null)
            {
                return NotFound();
            }

            return View(side);
        }

        // GET: Sides/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Side side)
        {
            if (ModelState.IsValid)
            {

                _service.Create(side);
                return RedirectToAction(nameof(Index));
            }
            return View(side);
        }

        // GET: Sides/Edit/5
        public IActionResult Edit(int id)
        {
            var side = _service.GetById(id);
            if (side == null)
            {
                return NotFound();
            }
            return View(side);
        }

        // POST: Sides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Side side)
        {
            _service.Update(side);
            return View(side);
        }

        //// GET: Sides/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var side = await _context.Side
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (side == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(side);
        //}

        //// POST: Sides/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var side = await _context.Side.FindAsync(id);
        //    _context.Side.Remove(side);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SideExists(int id)
        //{
        //    return _context.Side.Any(e => e.Id == id);
        //}
    }
}
