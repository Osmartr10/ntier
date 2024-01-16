using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("DETALLEVENTA")]
public partial class Detalleventum
{
    [Key]
    [Column("IDDETALLEVENTA")]
    public int Iddetalleventa { get; set; }

    [Column("IDVENTA")]
    public int Idventa { get; set; }

    [Column("IDPRODUCTO")]
    public int Idproducto { get; set; }

    [Column("CANTIDAD")]
    public int Cantidad { get; set; }

    [Column("PRECIOVENTA", TypeName = "money")]
    public decimal Precioventa { get; set; }

    [Column("SUBTOTAL", TypeName = "money")]
    public decimal Subtotal { get; set; }

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [ForeignKey("Idproducto")]
    [InverseProperty("Detalleventa")]
    public virtual Producto IdproductoNavigation { get; set; } = null!;

    [ForeignKey("Idventa")]
    [InverseProperty("Detalleventa")]
    public virtual Ventum IdventaNavigation { get; set; } = null!;
}
