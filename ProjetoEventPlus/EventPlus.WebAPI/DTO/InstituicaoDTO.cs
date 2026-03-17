using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O Titulo do tipo de instituicao é obrigatório!")]
    public string? Cnpj { get; set; }
    public string? NomeFantasia { get; set; }
    public string? Endereco { get; set; }
}
