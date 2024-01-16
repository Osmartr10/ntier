using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("USUARIOROL")]
public partial class Usuariorol
{
    [Key]
    [Column("IDUSUARIOROL")]
    public int Idusuariorol { get; set; }

    [Column("IDUSUARIO")]
    public int Idusuario { get; set; }

    [Column("IDROL")]
    public int Idrol { get; set; }

    [Column("FECHAASIGNA", TypeName = "datetime")]
    public DateTime Fechaasigna { get; set; }

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [ForeignKey("Idrol")]
    [InverseProperty("Usuariorols")]
    public virtual Rol IdrolNavigation { get; set; } = null!;

    [ForeignKey("Idusuario")]
    [InverseProperty("Usuariorols")]
    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
