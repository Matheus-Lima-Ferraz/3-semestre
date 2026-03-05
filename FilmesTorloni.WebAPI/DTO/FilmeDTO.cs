namespace FilmesTorloni.WebAPI.DTO;

public class FilmeDTO
{

    public string? Nome { get; set; }
    public Guid? IdGenero { get; set; }
    public IFormFile? Imagem { get; set; }
}
