using FilmesTorloni.WebAPI.BdContextFilme;
using FilmesTorloni.WebAPI.Interfaces;
using FilmesTorloni.WebAPI.Models;

namespace FilmesTorloni.WebAPI.Repositories;

public class GeneroRepository : IGeneroRepository
{
    private readonly FilmeContext _context;

    public GeneroRepository(FilmeContext context)
    {
        _context = context; 
    }

    public void AtualizarIdCorpo(Genero generoAtualizado)
    {
        throw new NotImplementedException();
    }

    public void AtualizarIdUrl(Guid id, Genero generoAtualizado)
    {
        throw new NotImplementedException();
    }

    public Genero BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Cadastrar(Genero novoGenero)
    {
        try
        {
            novoGenero.IdGenero = Guid.NewGuid().ToString();

            _context.Generos.Add(novoGenero);

            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Deletar(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Genero> Listar()
    {
        try
        {
            List<Genero> listaGeneros = _context.Generos.ToList();
            return listaGeneros;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
