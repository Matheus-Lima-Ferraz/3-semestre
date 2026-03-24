using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly EventContext _context;
    public EventoRepository(EventContext context)
    {
        _context = context; 
    }

    /// <summary>
    /// Atualiza um evento usando o rastreamento automático
    /// </summary>
    /// <param name="id">id do evento a ser atualizado</param>
    /// <param name="tipoEvento">Novos dados do evento</param>
    public void Atualizar(Guid id, Evento evento)
    {
        var EventoBuscado = _context.Eventos.Find(id);

        if (EventoBuscado != null)
        {
            EventoBuscado.Nome = evento.Nome;
            EventoBuscado.Descricao = evento.Descricao;
            EventoBuscado.DataEvento = evento.DataEvento;
            EventoBuscado.IdTipoEvento = evento.IdTipoEvento;
            EventoBuscado.Idinstituicao = evento.Idinstituicao;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca um evento por id
    /// </summary>
    /// <param name="id">id do evento a ser buscado</param>
    /// <returns>Objeto do Evento com as informações do evento buscado</returns>

    public TipoEvento BuscarPorId(Guid id)
    {
        return _context.TipoEventos.Find(id)!;
    }


    /// <summary>
    /// Cadastra um novo evento no banco de dados
    /// </summary>
    /// <param name="tipoEvento">Evento a ser cadastrado</param>

    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }


    /// <summary>
    /// Deleta um evento
    /// </summary>
    /// <param name="id">id do evento a ser deletado</param>

    public void Deletar(Guid id)
    {
        var EventoBuscado = _context.Eventos.Find(id);

        if (EventoBuscado != null)
        {
            _context.Eventos.Remove(EventoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de tipo de eventos cadstarado
    /// </summary>
    /// <returns>Uma lista de instituições</returns>

    public List<Evento> Listar()
    {
        return _context.Eventos.OrderBy(evento => evento.Nome).ToList();
    }


    /// <summary>
    /// Método que busca eventos no qual um usuário confirmo presença
    /// </summary>
    /// <param name="id">Id do usuário a ser buscado</param>
    /// <returns>Uma lista de eventos</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdinstituicaoNavigation)
            .Where(e => e.Presencas.Any(p => p.IdUsuario == IdUsuario && p.Situacao == true)) 
            .ToList(); 
    }

    /// <summary>
    /// Método que traz a lista de próximos eventos
    /// </summary>
    /// <returns>Uma lista de eventos</returns>
    public List<Evento> ProximosEventos()
    {
        return _context .Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdinstituicaoNavigation)
            .Where(e => e.DataEvento >= DateTime.Now)
            .OrderBy(e => e.DataEvento)
            .ToList();
    }

    Evento IEventoRepository.BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }
}
