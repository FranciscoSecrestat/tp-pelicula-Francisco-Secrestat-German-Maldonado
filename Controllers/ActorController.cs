using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tp_pelicula_Francisco_Secrestat.Models;

namespace tp_pelicula_Francisco_Secrestat.Controllers
{
    public class ActorController : Controller
    {
        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _env;
        public ActorController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.actor.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.generos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaNacimiento,Foto")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                var archivos = HttpContext.Request.Form.Files;
                if (archivos != null && archivos.Count > 0)
                {
                    var archivoFoto = archivos[0];
                    if (archivoFoto.Length > 0)
                    {
                        var pathDestino = Path.Combine(_env.WebRootPath, "images\\fotos");

                        var archivoDestino = Guid.NewGuid().ToString().Replace("-", "");
                        var extension = Path.GetExtension(archivoFoto.FileName);
                        archivoDestino += extension;

                        using (var filestream = new FileStream(Path.Combine(pathDestino, archivoDestino), FileMode.Create))
                        {
                            archivoFoto.CopyTo(filestream);
                            actor.Foto = archivoDestino;
                        }

                    }
                }
                _context.Add(actor);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "Estudiante registrado correctamente";

                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }
        public async Task<IActionResult> editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.actor.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        public async Task<IActionResult> editar(int id, [Bind("Id,Nombre,FechaNacimiento,Foto")] Actor actor)
        {
            if (id != actor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var archivos = HttpContext.Request.Form.Files;
                if (archivos != null && archivos.Count > 0)
                {
                    var archivoFoto = archivos[0];
                    if (archivoFoto.Length > 0)
                    {
                        var pathDestino = Path.Combine(_env.WebRootPath, "images\\fotos");

                        var archivoDestino = Guid.NewGuid().ToString().Replace("-", "");
                        var extension = Path.GetExtension(archivoFoto.FileName);
                        archivoDestino += extension;

                        using (var filestream = new FileStream(Path.Combine(pathDestino, archivoDestino), FileMode.Create))
                        {
                            archivoFoto.CopyTo(filestream);
                            if (actor.Foto != null)
                            {
                                var archivoViejo = Path.Combine(pathDestino, actor.Foto!);
                                if (System.IO.File.Exists(archivoViejo))
                                {
                                    System.IO.File.Delete(archivoViejo);
                                }
                            }
                            actor.Foto = archivoDestino;
                        }
                        try
                        {
                            _context.Update(actor);
                            await _context.SaveChangesAsync();
                            TempData["Mensaje"] = "actor editado correctamente";
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!ActorExists(actor.Id))
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
                    
                }
                

            }
            return View(actor);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            var actor = await _context.actor.FirstAsync(e => e.Id == id);
            _context.actor.Remove(actor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {

            return _context.actor.Any(e => e.Id == id);
        }
    }



}
    

