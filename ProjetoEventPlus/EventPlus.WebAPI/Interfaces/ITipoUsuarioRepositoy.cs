using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface ITipoUsuarioRepositoy
{
        List<TipoUsuario> Listar();
        void Cadastrar(TipoUsuario tipoUsuario);
        void Atualizar(Guid id, TipoUsuario tipoUsuario);
        void Deletar(Guid id);
        TipoUsuario BuscarPorId(Guid id);
    void Cadastrar(TipoEvento tipoEvento);
    void Atualizar(Guid id, TipoEvento tipoEvento);
}
