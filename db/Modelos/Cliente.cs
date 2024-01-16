using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("CLIENTE")]
public partial class Cliente
{
    [Key]
    [Column("IDCLIENTE")]
    public int Idcliente { get; set; }

    [Column("IDPERSONA")]
    public int Idpersona { get; set; }

    [Column("TIPOCLIENTE")]
    [StringLength(20)]
    public string Tipocliente { get; set; } = null!;

    [Column("CODIGOCLIENTE")]
    [StringLength(20)]
    public string Codigocliente { get; set; } = null!;

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [ForeignKey("Idpersona")]
    [InverseProperty("Clientes")]
    public virtual Persona IdpersonaNavigation { get; set; } = null!;

    [InverseProperty("IdclienteNavigation")]
    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
