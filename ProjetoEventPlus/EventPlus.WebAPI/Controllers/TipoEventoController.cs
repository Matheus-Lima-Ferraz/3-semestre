using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoEventoController : ControllerBase
{
    private ITipoEventoRepository _tipoEventoRepository;

    public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
    {
        _tipoEventoRepository = tipoEventoRepository;
    }

    /// <summary>
    /// Endpoint da API quefaz chamada para o método de listar os tipos de evento
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos de eventos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoEventoRepository.Listar());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para um método de busca de um tipo de evento específico
    /// </summary>
    /// <param name="id">Id do tipo de evento buscado</param>
    /// <returns>Status code 200 e tipo de evento buscado</returns>

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoEventoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para o método para cadastrar um tipo de evento
    /// </summary>
    /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>
    /// <returns>Status code 202 e o tipo de evento cadastrado</returns>

    [HttpPost]
    public IActionResult Cadastrar(TipoEventoDTO tipoEvento)
    {
        try
        {
            var novoTipoEvento = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.Cadastrar(novoTipoEvento);
            return StatusCode(201, novoTipoEvento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        };
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de atualizar um tipo de evento específico
    /// </summary>
    /// <param name="id">Id do tipo de evento a ser atualizado</param>
    /// <param name="tipoEvento">Tipo de evento com os dados atualiados</param>
    /// <returns>Status code 204 e o tipo de evento atualizado</returns>

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoEventoDTO tipoEvento)
    {
        try
        {
            var tipoEventoAtulizado = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.Atualizar(id, tipoEventoAtulizado);
            return StatusCode(204, tipoEventoAtulizado);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de deletar um tipo de evento específico
    /// </summary>
    /// <param name="id">Id do tipo do evento a ser excluido</param>
    /// <returns>Status code 204</returns>

    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _tipoEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

}
