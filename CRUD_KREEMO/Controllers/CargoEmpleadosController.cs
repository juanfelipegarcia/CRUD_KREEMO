using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_KREEMO.Models.DAL;
using CRUD_KREEMO.Models.Entities;

namespace CRUD_KREEMO.Controllers
{
    public class CargoEmpleadosController : Controller
    {
        private readonly DbContextPrueba _context;

        public CargoEmpleadosController(DbContextPrueba context)
        {
            _context = context;
        }

        // GET: CargoEmpleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.CargoEmpleados.ToListAsync());
        }

        // GET: CargoEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoEmpleado = await _context.CargoEmpleados
                .FirstOrDefaultAsync(m => m.IdCargo == id);
            if (cargoEmpleado == null)
            {
                return NotFound();
            }

            return View(cargoEmpleado);
        }

        // GET: CargoEmpleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CargoEmpleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCargo,Cargo")] CargoEmpleado cargoEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cargoEmpleado);
        }

        // GET: CargoEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoEmpleado = await _context.CargoEmpleados.FindAsync(id);
            if (cargoEmpleado == null)
            {
                return NotFound();
            }
            return View(cargoEmpleado);
        }

        // POST: CargoEmpleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCargo,Cargo")] CargoEmpleado cargoEmpleado)
        {
            if (id != cargoEmpleado.IdCargo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoEmpleadoExists(cargoEmpleado.IdCargo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cargoEmpleado);
        }

        // GET: CargoEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoEmpleado = await _context.CargoEmpleados
                .FirstOrDefaultAsync(m => m.IdCargo == id);
            if (cargoEmpleado == null)
            {
                return NotFound();
            }

            return View(cargoEmpleado);
        }

        // POST: CargoEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargoEmpleado = await _context.CargoEmpleados.FindAsync(id);
            _context.CargoEmpleados.Remove(cargoEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoEmpleadoExists(int id)
        {
            return _context.CargoEmpleados.Any(e => e.IdCargo == id);
        }
    }
}
