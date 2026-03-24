
using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class PresencaRepository : IPresencaRepository
{
    private readonly EventContext _eventContext;
    public PresencaRepository(EventContext eventcontext)
    {
        _eventContext = eventcontext;
    }

    public void Atualizar(Guid id, Presenca presenca)
    {
        var presencaBuscada = _eventContext.Presencas.Find(id);
        if (presencaBuscada != null && presencaBuscada != null)
        {
            presencaBuscada.IdPresenca = presencaBuscada.IdPresenca;
            //presencaBuscada.IdUsaurio = presencaBuscada.IdUsaurio;
            presencaBuscada.IdEvento = presencaBuscada.IdEvento;


            _eventContext.SaveChanges();
        }
    }

    public void Atualizar(Guid idPresencaEvento)
    {
        var presencaBuscada = _eventContext.Presencas.Find(idPresencaEvento);

        if(presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _eventContext.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a presença por id da
    /// </summary>
    /// <param name="id">id da presença a ser buscada</param>
    /// <returns>presença buscada</returns>
    public Presenca BuscarPorId(Guid id)
    {
        return _eventContext.Presencas.Include(p => p.IdEventoNavigation).ThenInclude(e => e!.IdinstituicaoNavigation).FirstOrDefault(p => p.IdPresenca == id)!;
    }

    public void Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deleta a presença por id da presença
    /// </summary>
    /// <param name="id"></param>
    public void Deleter(Guid id)
    {
        var presencaBuscada = _eventContext.Presencas.Find(id);
        if (presencaBuscada != null)
        {
            _eventContext.Presencas.Remove(presencaBuscada);
            _eventContext.SaveChanges();
        }
    }
    /// <summary>
    /// Inscreve um usuário em um evento
    /// </summary>
    /// <param name="inscricao"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void Inscrever(Presenca inscricao)
    {
        var presencaBuscada = _eventContext.Presencas.FirstOrDefault(p => p.IdUsuario == inscricao.IdUsuario && p.IdEvento == inscricao.IdEvento);
        if (presencaBuscada != null)
        {
            throw new InvalidOperationException("Usuário já inscrito neste evento.");
        }
    }
    /// <summary>
    /// Lista todas as presenças cadastradas
    /// </summary>
    /// <returns></returns>
    public List<Presenca> Listar()
    {
        return _eventContext.Presencas.Include(p => p.IdEventoNavigation).ThenInclude(e => e!.IdinstituicaoNavigation).ToList();
    }
    /// <summary>
    /// Lista as presenças de um usuário especifico
    /// </summary>
    /// <param name="idUsuario">id do usuario para filtragem</param>
    /// <returns>uma lista de presença de presencas de um usuario especifico</returns>
    public List<Presenca> ListarMinhas(Guid idUsuario)
    {
        return _eventContext.Presencas.Include(p => p.IdEventoNavigation).ThenInclude(e => e!.IdinstituicaoNavigation).Where(p => p.IdUsuario == idUsuario).ToList();
    }
}
