using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("ROL")]
public partial class Rol
{
    [Key]
    [Column("IDROL")]
    public int Idrol { get; set; }

    [Column("NOMBRE")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdrolNavigation")]
    public virtual ICollection<Usuariorol> Usuariorols { get; set; } = new List<Usuariorol>();
}
