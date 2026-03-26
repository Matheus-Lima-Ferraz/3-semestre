using ConnectPlus.Models;

namespace ConnectPlus.Interfaces;

public interface IContatoRepository
{
    List<Contato> Listar();
    void Cadastrar(Contato contato);
    void Atualizar(Guid id, Contato contato);
    void Deletar(Guid id);
    Contato BuscarPorId(Guid id);
}
