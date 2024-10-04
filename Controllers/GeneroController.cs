using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tp_pelicula_Francisco_Secrestat.Models;

namespace tp_pelicula_Francisco_Secrestat.Controllers
{
    public class GeneroController : Controller
    {
        private readonly AppDbContext _context;

        public GeneroController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.generos.ToListAsync());  
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.generos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id,Descripcion")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genero);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.generos.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] Genero genero)
        {
            if (id != genero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneroExist(genero.Id))
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
            return View(genero);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int? id)
        {
            var producto = await _context.generos.FirstAsync(e => e.Id == id);
            _context.generos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





        private bool GeneroExist(int id)
        {
            return _context.generos.Any(e => e.Id == id);
        }
    }
}
