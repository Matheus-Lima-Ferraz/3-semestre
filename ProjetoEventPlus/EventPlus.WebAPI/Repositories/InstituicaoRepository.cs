using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class InstituicaoRepository : IInstituicaoRepository
{

    private readonly EventContext _context;

    public InstituicaoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza a instituição usando o rastreamento automático
    /// </summary>
    /// <param name="id">id do tipo instituicao a ser atualizado</param>
    /// <param name="instituicao">Novos dados do tipo Instituicao</param>

    public void Atualizar(Guid id, Instituicao instituicao)
    {
        var instituicaoBuscada = _context.Instituicaos.Find(id);

        if (instituicaoBuscada != null)
        {
            instituicaoBuscada.NomeFantasia = String.IsNullOrWhiteSpace(instituicao.NomeFantasia) ? instituicaoBuscada.NomeFantasia : instituicao.NomeFantasia;
            instituicaoBuscada.Cnpj = String.IsNullOrWhiteSpace(instituicao.Cnpj) ? instituicaoBuscada.Cnpj : instituicao.Cnpj;
            instituicaoBuscada.Endereco = String.IsNullOrWhiteSpace(instituicao.Endereco) ? instituicaoBuscada.Endereco : instituicao.Endereco;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca uma instituição por id
    /// </summary>
    /// <param name="id">id da instituição a ser buscado</param>
    /// <returns>Objeto da instituição com as informações da instituição buscado</returns>

    public Instituicao BuscarPorId(Guid id)
    {
        return _context.Instituicaos.Find(id)!;
    }


    /// <summary>
    /// Cadastra uma nova instituição no banco de dados
    /// </summary>
    /// <param name="instituicao">Instituição a ser cadastrada<</param>

    public void Cadastrar(Instituicao instituicao)
    {
        _context.Instituicaos.Add(instituicao);
        _context.SaveChanges();
    }


    /// <summary>
    /// Deleta uma instituição
    /// </summary>
    /// <param name="id">id da instituição a ser deletada</param>

    public void Deletar(Guid id)
    {
        var instituicaoBuscada = _context.Instituicaos.Find(id);

        if (instituicaoBuscada != null)
        {
            _context.Instituicaos.Remove(instituicaoBuscada);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de instituições
    /// </summary>
    /// <returns></returns>

    public List<Instituicao> Listar()
    {
        return _context.Instituicaos.OrderBy(Instituicao => Instituicao.NomeFantasia).ToList();
    }
}
