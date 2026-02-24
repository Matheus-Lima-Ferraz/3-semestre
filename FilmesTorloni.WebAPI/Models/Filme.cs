using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FilmesTorloni.WebAPI.Models;

[Table("Filme")]
public partial class Filme
{
    [Key]
    [StringLength(40)]
    [Unicode(false)]
    public string IdFilme { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string? Imagem { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [StringLength(40)]
    [Unicode(false)]
    public string? IdGenero { get; set; }

    [ForeignKey("IdGenero")]
    [InverseProperty("Filmes")]
    public virtual Genero? IdGeneroNavigation { get; set; }
}
