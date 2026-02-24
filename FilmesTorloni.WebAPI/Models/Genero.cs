using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FilmesTorloni.WebAPI.Models;

[Table("Genero")]
public partial class Genero
{
    [Key]
    [StringLength(40)]
    [Unicode(false)]
    public string IdGenero { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [InverseProperty("IdGeneroNavigation")]
    public virtual ICollection<Filme> Filmes { get; set; } = new List<Filme>();
}
