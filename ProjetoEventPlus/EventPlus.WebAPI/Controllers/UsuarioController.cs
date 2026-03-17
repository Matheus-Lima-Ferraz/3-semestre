using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _UsuarioRepository;
    public UsuarioController(IUsuarioRepository UsuarioRepository)
    {
        _UsuarioRepository = UsuarioRepository;
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de Buscar um usuário por id
    /// </summary>
    /// <param name="id">id do usuário a ser buscado</param>
    /// <returns>Status code 200 e o usuário buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_UsuarioRepository.BuscarPorId(id));
        }
        catch (Exception erro) 
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de Buscar um usuário por id
    /// </summary>
    /// <param name="usuario">id do usuário a ser buscado</param>
    /// <returns>Status code 200 e o usuário buscado</returns>
    [HttpPost]
    public IActionResult Cadastrar(Usuario usuario)
    {
        try
        {
            _UsuarioRepository.Cadastrar(usuario);

            return StatusCode(201, usuario);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}    

