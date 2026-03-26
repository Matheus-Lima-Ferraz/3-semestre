using ConnectPlus.Models;

namespace ConnectPlus.Interfaces;

public interface ITipoContatoRepository
{
    List<TipoContato> Listar();
    void Cadastrar(TipoContato tipoContato);
    void Atualizar(Guid id, TipoContato tipoContato);
    void Deletar(Guid id);
    TipoContato BuscarPorId(Guid id);
}
