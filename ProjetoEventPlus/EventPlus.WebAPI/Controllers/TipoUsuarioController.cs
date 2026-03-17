using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private ITipoUsuarioRepositoy _tipoUsuarioRepository;

    public TipoUsuarioController(ITipoUsuarioRepositoy tipoUsuarioRepositoy)
    {
        _tipoUsuarioRepository = tipoUsuarioRepositoy;
    }

    /// <summary>
    /// Endpoint da API quefaz chamada para o método de listar os tipos de usuario
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos de usuario</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para um método de busca de um tipo de usuario específico
    /// </summary>
    /// <param name="id">Id do tipo de usuario buscado</param>
    /// <returns>Status code 200 e tipo de usuario buscado</returns>

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para o método para cadastrar um tipo de usuario
    /// </summary>
    /// <param name="tipoUsuario">Tipo de usuario a ser cadastrado</param>
    /// <returns>Status code 202 e o tipo de usuario cadastrado</returns>

    [HttpPost]
    public IActionResult Cadastrar(TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var novoTipoUsuario = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
            return StatusCode(201, novoTipoUsuario);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
        ;
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de atualizar um tipo de usuario específico
    /// </summary>
    /// <param name="id">Id do tipo de usuario a ser atualizado</param>
    /// <param name="tipoUsuario">Tipo de usuario com os dados atualiados</param>
    /// <returns>Status code 204 e o tipo de usuario atualizado</returns>

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var tipoUsuarioAtulizado = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtulizado);
            return StatusCode(204, tipoUsuarioAtulizado);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de deletar um tipo de usuario específico
    /// </summary>
    /// <param name="id">Id do tipo do usuario a ser excluido</param>
    /// <returns>Status code 204</returns>

    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _tipoUsuarioRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

}
