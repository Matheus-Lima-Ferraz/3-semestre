using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class TipoEventoRepository : ITipoEventoRepository
{

    private readonly EventContext _context;

    // Injeção de dependência: Recebe o contexto do banco de dados através do construtor

    public TipoEventoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um tipo de evento usando o rastreamento automático
    /// </summary>
    /// <param name="id">id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">Novos dados do tipo evento</param>
    

    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if (tipoEventoBuscado != null)
        {
            tipoEventoBuscado.Titulo = tipoEvento.Titulo;

            //O SaveChanges() detecta a mudança na propriedade "Titulo" automaticamente
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Busca um tipo de evento por id
    /// </summary>
    /// <param name="id">id do tipo evento a ser buscado</param>
    /// <returns>Objeto do tipoEvento com as informações do tipo de evento buscado</returns>

    public TipoEvento BuscarPorId(Guid id)
    {
        return _context.TipoEventos.Find(id)!;
    }


    /// <summary>
    /// Cadastra um novo tipo de evento no banco de dados
    /// </summary>
    /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>

    public void Cadastrar(TipoEvento tipoEvento)
    {
        _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }



    /// <summary>
    /// Deleta um tipo de evento
    /// </summary>
    /// <param name="id">id do tipo evento a ser deletado</param>

    public void Deletar(Guid id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if (tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }


    /// <summary>
    /// Busca a lista de tipo de eventos cadstarado
    /// </summary>
    /// <returns>Uma lista de instituições</returns>

    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos.OrderBy(tipoEvento => tipoEvento.Titulo).ToList();
    }
}
