namespace EventPlus.WebAPI.DTO;

public class ComentarioEventoDTO
{
    public string Descricao { get; set; }
    public Guid IdEvento { get; set; }
    public Guid IdUsuario { get; set; }
}
