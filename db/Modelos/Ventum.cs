using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("VENTA")]
public partial class Ventum
{
    [Key]
    [Column("IDVENTA")]
    public int Idventa { get; set; }

    [Column("IDCLIENTE")]
    public int Idcliente { get; set; }

    [Column("IDVENDEDOR")]
    public int? Idvendedor { get; set; }

    [Column("FECHA", TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column("TOTAL", TypeName = "money")]
    public decimal Total { get; set; }

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdventaNavigation")]
    public virtual ICollection<Detalleventum> Detalleventa { get; set; } = new List<Detalleventum>();

    [ForeignKey("Idcliente")]
    [InverseProperty("Venta")]
    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    [ForeignKey("Idvendedor")]
    [InverseProperty("Venta")]
    public virtual Usuario? IdvendedorNavigation { get; set; }
}
