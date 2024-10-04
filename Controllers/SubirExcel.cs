using Microsoft.AspNetCore.Mvc;
using tp_pelicula_Francisco_Secrestat.Models;
using ClosedXML.Excel;

namespace tp_pelicula_Francisco_Secrestat.Controllers
{
    public class SubirExcel : Controller
    {
        
        
            private readonly AppDbContext _context;
            public SubirExcel(AppDbContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                return View();
            }

            public IActionResult SubirExcel1(IFormFile excel)
            {
                try
                {
                    var workbook = new XLWorkbook(excel.OpenReadStream());
                    var hoja = workbook.Worksheet(1);
                    var primeraFila = hoja.FirstRowUsed().RangeAddress.FirstAddress.RowNumber;
                    var ultimaFila = hoja.LastRowUsed().RangeAddress.LastAddress.RowNumber;

                    List<Genero> generos = new List<Genero>();
                    for (int i = primeraFila + 1; i <= ultimaFila; i++)
                    {
                        var fila = hoja.Row(i);
                        Genero genero = new Genero();
                        genero.Descripcion = fila.Cell(1).GetString();
                        generos.Add(genero);
                    }
                    _context.generos.AddRange(generos);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return RedirectToAction("Index", "generos");
            }
    }
}

