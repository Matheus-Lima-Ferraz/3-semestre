using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class TipoUsuarioRepository : ITipoUsuarioRepositoy
{

    private readonly EventContext _context;

    public TipoUsuarioRepository(EventContext context)
    {
        _context = context;
    }


    /// <summary>
    /// Atualiza o tipo de usuário por rastreamento automatico
    /// </summary>
    /// <param name="id">id do tipo usuário a ser atualizado</param>
    /// <param name="tipoUsuario">Novos dados do tipo usuario</param>

    public void Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);

        if (tipoUsuarioBuscado != null)
        {
            tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;
            _context.SaveChanges();
        }
    }

    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        throw new NotImplementedException();
    }


    /// <summary>
    /// Busca um tipo de usuário por id
    /// </summary>
    /// <param name="id">id do tipo usuario a ser buscado</param>
    /// <returns>Objeto do tipoEvento com as informações do tipo de evento buscado</returns>

    public TipoUsuario BuscarPorId(Guid id)
    {
        return _context.TipoUsuarios.Find(id)!;
    }

    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _context.TipoUsuarios.Add(tipoUsuario);
        _context.SaveChanges();
    }

    public void Cadastrar(TipoEvento tipoEvento)
    {
        throw new NotImplementedException();
    }

    public void Deletar(Guid id)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(id);

        if (tipoUsuarioBuscado != null)
        {
            _context.TipoUsuarios.Remove(tipoUsuarioBuscado);
            _context.SaveChanges();
        }
    }

    public List<TipoUsuario> Listar()
    {
        return _context.TipoUsuarios.OrderBy(tipoUsuario => tipoUsuario.Titulo).ToList();
    }
}
