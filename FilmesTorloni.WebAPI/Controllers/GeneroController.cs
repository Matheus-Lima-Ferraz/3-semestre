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
    private Genero generoAtualizado;

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

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            return Ok(_generoRepository.BuscarPorId(id));
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

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, Genero generoAtualizado)
    {
        try
        {   
            _generoRepository.AtualizarIdUrl(id, generoAtualizado);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult PutBody(Genero generoAtualizado)
    {
        try
        {
            _generoRepository.AtualizarIdCorpo(generoAtualizado);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _generoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
