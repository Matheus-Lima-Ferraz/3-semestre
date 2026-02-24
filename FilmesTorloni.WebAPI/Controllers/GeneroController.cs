using FilmesTorloni.WebAPI.Interfaces;
using FilmesTorloni.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesTorloni.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GeneroController : ControllerBase
{
    private readonly IGeneroRepository _generoRepository;

    public GeneroController(IGeneroRepository generoRepository)
    {
        _generoRepository = generoRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
           try
        {
            return Ok(_generoRepository.Listar());
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult Post(Genero novoGenero)
    {
        try
        {
            _generoRepository.Cadastrar(novoGenero);
            return StatusCode(201);
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message);
        }
    }
}
