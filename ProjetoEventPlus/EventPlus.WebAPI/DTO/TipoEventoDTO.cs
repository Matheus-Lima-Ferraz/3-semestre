using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class TipoEventoDTO
{
    [Required(ErrorMessage = "O título do tipo de evento é obrigatório!")]
    public string? Titulo { get; set; }
}
