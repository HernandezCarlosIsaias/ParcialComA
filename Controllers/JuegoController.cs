using Microsoft.AspNetCore.Mvc;
using Parcial.Entities;

namespace Parcial.Controllers;

[ApiController]
[Route("[controller]")]
public class JuegoController : ControllerBase
{
    private static readonly List<Juego> Juegos = new List<Juego>
    {
        new Juego { Id = 1, Nombre = "Juego 1", Genero = "Accion", Descripcion = "Descripcion 1" },
        new Juego { Id = 2, Nombre = "Juego 2", Genero = "Aventura", Descripcion = "Descripcion 2" },
        new Juego { Id = 3, Nombre = "Juego 3", Genero = "Estrategia", Descripcion = "Descripcion 3" }
    };

    private readonly ILogger<JuegoController> _logger;

    public JuegoController(ILogger<JuegoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task <IActionResult> GetById(int id)
    {
        try
        {
            
            var juego = Juegos.FirstOrDefault(j => j.Id == id);
            if (juego == null)
            {
                return NotFound();
            }
            return Ok(juego);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el juego por ID");
            return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(Juego juego)
    {
        try
        {
            if (juego.Nombre == null || juego.Genero == null || juego.Descripcion == null)
            {
                return BadRequest("Todos los campos son obligatorios.");
            }
            Juegos.Add(juego);
            return Ok("Juego creado con exito.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear el juego");
            return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest("El ID del juego debe ser mayor que cero.");
            }
            var juego = Juegos.FirstOrDefault(j => j.Id == id);
            if (juego == null)
            {
                return NotFound();
            }
            Juegos.Remove(juego);
            return Ok("Juego eliminado con exito.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar el juego");
            return StatusCode(500, "Ocurrió un error al procesar la solicitud.");
        }
    }
}
