using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventPlusTorloni.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private IInstituicaoRepository _instituicaoRepository;

    public InstituicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }

    ///<summary>
    /// Endpoint da API que faz chamada para o metodo de listar a instituicao
    /// </summary>
    /// <returns>Status code 200 e a lista a instituicao</returns>

    [HttpGet]
    public ActionResult Listar()
    {
        try
        {
            return Ok(_instituicaoRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {
            return Ok(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Cadastrar(InstituicaoDTO instituicao)
    {
        try
        {
            var novaInstituicao = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia!,
                Cnpj = instituicao.Cnpj!,
                Endereco = instituicao.Endereco!
            };

            _instituicaoRepository.Cadastrar(novaInstituicao);

            return StatusCode(201, novaInstituicao);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{id}")]
    public IActionResult Atualizar(Guid id, InstituicaoDTO instituicao)
    {
        try
        {
            var instituicaoAtualizada = new Instituicao()
            {
                NomeFantasia = instituicao.NomeFantasia!,
                Cnpj = instituicao.Cnpj!,
                Endereco = instituicao.Endereco!
            };

            _instituicaoRepository.Atualizar(id, instituicaoAtualizada);
            return StatusCode(204, instituicaoAtualizada);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _instituicaoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}