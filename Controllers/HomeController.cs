using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using reporte.Services;

namespace reporte.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{

    private readonly ILogger<HomeController> _logger;

    private readonly IReporteService _reporteService;

    public HomeController(ILogger<HomeController> logger, IReporteService reporteService)
    {
        _logger = logger;
        _reporteService = reporteService;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }

    [HttpGet("generate")]
    public IActionResult Generate(string textoNumero = "E06000012828368")
    {
        var pdf = _reporteService.Generate(textoNumero);
        return File(pdf, MediaTypeNames.Application.Pdf, "prueba.pdf");
    }

}
