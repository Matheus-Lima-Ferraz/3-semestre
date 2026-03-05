using FilmesTorloni.WebAPI.Interfaces;
using FilmesTorloni.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesTorloni.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _IUsuarioRepository;

    public UsuarioController(IUsuarioRepository iUsuarioRepository)
    {
        _IUsuarioRepository = iUsuarioRepository;
    }

    [HttpPost]
    public IActionResult Post(Usuario novoUsuario)
    {
        try
        {
            _IUsuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201, novoUsuario);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
