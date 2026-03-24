using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Repositories;

public class ComentarioEventoRepository : IComentarioEventoRepository
{
    private readonly EventContext _context;

    public ComentarioEventoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Método para buscar um comentário específico
    /// </summary>
    /// <param name="idUsuario">idUsuario</param>
    /// <param name="IdEvento">idEvento</param>
    /// <returns>Comentário Buscado</returns>
    public ComentarioEvento BuscarPorIdUsuario(Guid idUsuario, Guid IdEvento)
    {
        try
        {
            // Usamos Include para trazer os dados relacionados sem precisar "mapear na mão"
            return _context.ComentarioEventos
                .Include(c => c.IdUsuarioNavigation)
                .Include(c => c.IdEventoNavigation)
                .FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdEvento == IdEvento)!;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Método para cadastrar um comentário
    /// </summary>
    /// <param name="comentarioEvento">Comentário a ser cadastrado</param>
    public void Cadastrar(ComentarioEvento comentarioEvento)
    {
        _context.ComentarioEventos.Add(comentarioEvento);
        _context.SaveChanges();
    }

    /// <summary>
    /// Método para deletar um comentário
    /// </summary>
    /// <param name="IdComentarioEvento">Id do comentário a ser excluído</param>
    public void Deletar(Guid IdComentarioEvento)
    {
        var comentarioBuscado = _context.ComentarioEventos.Find(IdComentarioEvento);

        if (comentarioBuscado != null)
        {
            _context.ComentarioEventos.Remove(comentarioBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Método para listar os comentários
    /// </summary>
    /// <returns>Lista dos comentários</returns>
    /// <param name="IdEvento">Id do evento a ter os comentários buscados</param>
    public List<ComentarioEvento> Listar(Guid IdEvento)
    {
        return _context.ComentarioEventos
        .Include(c => c.IdUsuarioNavigation)
        .Include(c => c.IdEventoNavigation)
        .Where(c => c.IdEvento == IdEvento)
        .ToList();
    }

    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        return _context.ComentarioEventos
            .Include(c => c.IdUsuarioNavigation)
            .Include(c => c.IdEventoNavigation)
            .Where(c => c.Exibe == true && c.IdEvento == IdEvento)
            .ToList();
    }

}