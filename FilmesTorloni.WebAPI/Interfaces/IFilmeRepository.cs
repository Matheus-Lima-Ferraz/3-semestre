using FilmesTorloni.WebAPI.Models;

namespace FilmesTorloni.WebAPI.Interfaces;

public interface IFilmeRepository
{
    void Cadastrar(Filme novoFilme);
    void AtualizarIdCorpo(Filme filmeAtualizado);
    void AtualizarIdUrl(Guid id, Filme filmeAtualizado);
    List<Filme> Listar();
    void Deletar(Guid id);
    Filme BuscarPorId(Guid id);
}
