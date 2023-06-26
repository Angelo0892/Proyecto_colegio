using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Usuario_control.Models;

namespace Usuario_control.Controllers
{
    public class HorarioController : Controller
    {
        private readonly ColegioPruebaContext _context;

        public HorarioController(ColegioPruebaContext context)
        {
            _context = context;
        }

        // GET: Horario
        public async Task<IActionResult> Index()
        {
            var colegioPruebaContext = _context.Horarios.Include(h => h.CodigoAsignaturaNavigation);
            return View(await colegioPruebaContext.ToListAsync());
        }

        // GET: Horario/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .Include(h => h.CodigoAsignaturaNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horario/Create
        public IActionResult Create()
        {
            ViewData["CodigoAsignatura"] = new SelectList(_context.Asignaturas, "Codigo", "Codigo");
            return View();
        }

        // POST: Horario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,HoraIngreso,HoraSalida,Dia,CodigoAsignatura")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoAsignatura"] = new SelectList(_context.Asignaturas, "Codigo", "Codigo", horario.CodigoAsignatura);
            return View(horario);
        }

        // GET: Horario/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["CodigoAsignatura"] = new SelectList(_context.Asignaturas, "Codigo", "Codigo", horario.CodigoAsignatura);
            return View(horario);
        }

        // POST: Horario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Codigo,HoraIngreso,HoraSalida,Dia,CodigoAsignatura")] Horario horario)
        {
            if (id != horario.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.Codigo))
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
            ViewData["CodigoAsignatura"] = new SelectList(_context.Asignaturas, "Codigo", "Codigo", horario.CodigoAsignatura);
            return View(horario);
        }

        // GET: Horario/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .Include(h => h.CodigoAsignaturaNavigation)
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Horarios == null)
            {
                return Problem("Entity set 'ColegioPruebaContext.Horarios'  is null.");
            }
            var horario = await _context.Horarios.FindAsync(id);
            if (horario != null)
            {
                _context.Horarios.Remove(horario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(string id)
        {
          return (_context.Horarios?.Any(e => e.Codigo == id)).GetValueOrDefault();
        }
    }
}
