using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("USUARIO")]
public partial class Usuario
{
    [Key]
    [Column("IDUSUARIO")]
    public int Idusuario { get; set; }

    [Column("IDPERSONA")]
    public int Idpersona { get; set; }

    [Column("NOMBREUSER")]
    [StringLength(50)]
    public string Nombreuser { get; set; } = null!;

    [Column("CONTRASEÑA")]
    [StringLength(50)]
    public string Contraseña { get; set; } = null!;

    [Column("FECHAREG", TypeName = "datetime")]
    public DateTime Fechareg { get; set; }

    [ForeignKey("Idpersona")]
    [InverseProperty("Usuarios")]
    public virtual Persona IdpersonaNavigation { get; set; } = null!;

    [InverseProperty("IdusuarioNavigation")]
    public virtual ICollection<Usuariorol> Usuariorols { get; set; } = new List<Usuariorol>();

    [InverseProperty("IdvendedorNavigation")]
    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
