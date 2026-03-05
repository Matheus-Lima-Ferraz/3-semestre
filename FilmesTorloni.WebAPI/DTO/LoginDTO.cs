using System.ComponentModel.DataAnnotations;

namespace FilmesTorloni.WebAPI.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O Email do usuario é obrigatório!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A Senha do usuario é obrigatório!")]
    public string? Senha { get; set; }
}
