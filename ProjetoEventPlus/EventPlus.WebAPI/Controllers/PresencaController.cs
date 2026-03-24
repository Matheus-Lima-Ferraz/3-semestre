using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private readonly IPresencaRepository _presencaRepository;

    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }
    /// <summary>
    /// Endpoint da API que retorna a presença por id 
    /// </summary>
    /// <param name="id">id da presença buscada</param>
    /// <returns>Status code 200 e presença buscada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_presencaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que retorna a lista de presenças filtrada por usuário
    /// </summary>
    /// <param name="idUsuario">id do usuário para filtragem</param>
    /// <returns>uma lista de presenças filtrad pelo usuário </returns>
    [HttpGet("ListaMinhas/{idUsuario}")]
    public IActionResult BuscarPorUsario(Guid idUsuario)
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(idUsuario));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que retorna a lista de presença
    /// </summary>
    /// <param name="inscricao"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Inscrever(Presenca inscricao)
    {
        try
        {
            _presencaRepository.Inscrever(inscricao);
            return StatusCode(201);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que Atualiza a presença por id da presença
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut]
    public IActionResult Atualizar(Guid id, Presenca presenca)
    {
        try
        {
            _presencaRepository.Atualizar(id, presenca);
            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
    /// <summary>
    /// Endpoint da API que deleta a presença por id da presença
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _presencaRepository.Deletar(id);
            return StatusCode(204);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
