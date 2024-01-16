using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("DETALLEING")]
public partial class Detalleing
{
    [Key]
    [Column("IDDETALLEING")]
    public int Iddetalleing { get; set; }

    [Column("IDINGRESO")]
    public int Idingreso { get; set; }

    [Column("IDPRODUCTO")]
    public int Idproducto { get; set; }

    [Column("FECHAVENC", TypeName = "datetime")]
    public DateTime Fechavenc { get; set; }

    [Column("CANTIDAD")]
    public int Cantidad { get; set; }

    [Column("PRECIOCOSTO", TypeName = "money")]
    public decimal Preciocosto { get; set; }

    [Column("PRECIOVENTA", TypeName = "money")]
    public decimal Precioventa { get; set; }

    [Column("SUBTOTAL", TypeName = "money")]
    public decimal Subtotal { get; set; }

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [ForeignKey("Idingreso")]
    [InverseProperty("Detalleings")]
    public virtual Ingreso IdingresoNavigation { get; set; } = null!;

    [ForeignKey("Idproducto")]
    [InverseProperty("Detalleings")]
    public virtual Producto IdproductoNavigation { get; set; } = null!;
}
