using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class EventoDTO
{
    public string? Nome { get; set; }
    public DateTime DataEvento { get; set; }
    public string? Descricao {  get; set; }
    public Guid? IdTipoEvento { get; set; }
    public Guid? IdInstituicao { get; set; }
}