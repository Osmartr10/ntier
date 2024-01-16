using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("PERSONA")]
public partial class Persona
{
    [Key]
    [Column("IDPERSONA")]
    public int Idpersona { get; set; }

    [Column("NOMBRE")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Column("APELLIDO")]
    [StringLength(50)]
    public string Apellido { get; set; } = null!;

    [Column("TELEFONO")]
    [StringLength(50)]
    public string? Telefono { get; set; }

    [Column("CI")]
    [StringLength(10)]
    public string Ci { get; set; } = null!;

    [Column("CORREO")]
    [StringLength(20)]
    public string? Correo { get; set; }

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdpersonaNavigation")]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    [InverseProperty("IdpersonaNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
