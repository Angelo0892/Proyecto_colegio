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
    public class AlumnoController : Controller
    {
        private readonly ColegioPruebaContext _context;

        public AlumnoController(ColegioPruebaContext context)
        {
            _context = context;
        }

        // GET: Alumno
        public async Task<IActionResult> Index()
        {
            var colegioPruebaContext = _context.Alumnos.Include(a => a.CiTutorNavigation);
            return View(await colegioPruebaContext.ToListAsync());
        }

        // GET: Alumno/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .Include(a => a.CiTutorNavigation)
                .FirstOrDefaultAsync(m => m.Ci == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // GET: Alumno/Create
        public IActionResult Create()
        {
            ViewData["CiTutor"] = new SelectList(_context.Tutors, "Ci", "Ci");
            return View();
        }

        // POST: Alumno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ci,Nombres,ApellidoP,ApellidoM,FechaNac,Genero,AnoIngreso,Observaciones,CiTutor")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiTutor"] = new SelectList(_context.Tutors, "Ci", "Ci", alumno.CiTutor);
            return View(alumno);
        }

        // GET: Alumno/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            ViewData["CiTutor"] = new SelectList(_context.Tutors, "Ci", "Ci", alumno.CiTutor);
            return View(alumno);
        }

        // POST: Alumno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Ci,Nombres,ApellidoP,ApellidoM,FechaNac,Genero,AnoIngreso,Observaciones,CiTutor")] Alumno alumno)
        {
            if (id != alumno.Ci)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.Ci))
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
            ViewData["CiTutor"] = new SelectList(_context.Tutors, "Ci", "Ci", alumno.CiTutor);
            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .Include(a => a.CiTutorNavigation)
                .FirstOrDefaultAsync(m => m.Ci == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Alumnos == null)
            {
                return Problem("Entity set 'ColegioPruebaContext.Alumnos'  is null.");
            }
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(string id)
        {
          return (_context.Alumnos?.Any(e => e.Ci == id)).GetValueOrDefault();
        }
    }
}
