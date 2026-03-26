using ConnectPlus.BdContEvent;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;

namespace ConnectPlus.Repository;

public class ContatoRepository : IContatoRepository
{
    private readonly EventContext _context;
    public ContatoRepository(EventContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid id, Contato contato)
    {
        var ContatoExistente = _context.Contatos.Find(id);
        if (contato != null && contato != null)
        {
            contato.IdContato = id;
        }
    }

    public Contato BuscarPorId(Guid id)
    {
        return _context.Contatos.Find(id)!;
    }

    public void Cadastrar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var contatoList = _context.Contatos.Find(id);
        if (contatoList != null)
        {
            _context.Contatos.Remove(contatoList);
            _context.SaveChanges();
        }
    }

    public List<Contato> Listar()
    {
        return _context.Contatos.ToList();
    }
}
