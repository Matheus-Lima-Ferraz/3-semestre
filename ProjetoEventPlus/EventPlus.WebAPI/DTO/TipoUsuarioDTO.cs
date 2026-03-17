using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class TipoUsuarioDTO
    {
        [Required(ErrorMessage = "O título do tipo de usuario é obrigatório!")]
        public string? Titulo { get; set; }
    }
}
