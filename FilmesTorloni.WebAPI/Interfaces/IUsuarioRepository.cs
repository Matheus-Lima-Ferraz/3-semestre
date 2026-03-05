using FilmesTorloni.WebAPI.Models;

namespace FilmesTorloni.WebAPI.Interfaces;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario novoUsuario);
    Usuario BuscarPorId(Guid id);
    Usuario BuscarPorEmailESenha(string email, string senha);
}
