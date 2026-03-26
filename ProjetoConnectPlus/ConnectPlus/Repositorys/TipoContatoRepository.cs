using ConnectPlus.BdContEvent;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;

namespace ConnectPlus.Repository;

public class TipoContatoRepository : ITipoContatoRepository
{
    private readonly EventContext _context;
    public TipoContatoRepository(EventContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid id, TipoContato tipoContato)
    {
        var tipoContatoList = _context.TipoContatos.Find(id);
        if (tipoContatoList == null)
        {
            tipoContatoList.Titulo = tipoContato.Titulo;

            _context.SaveChanges();
        }
    }

    public TipoContato BuscarPorId(Guid id)
    {
        return _context.TipoContatos.Find(id)!;
    }

    public void Cadastrar(TipoContato tipoContato)
    {
        _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var tipoContatoList = _context.TipoContatos.Find(id);
        if (tipoContatoList != null)
        {
            _context.TipoContatos.Remove(tipoContatoList);
            _context.SaveChanges();
        }
    }

    public List<TipoContato> Listar()
    {
        return _context.TipoContatos.OrderBy(TipoContatos => TipoContatos.Titulo).ToList();
    }
}
