using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("PROVEE")]
public partial class Provee
{
    [Key]
    [Column("IDPROVEE")]
    public int Idprovee { get; set; }

    [Column("IDPRODUCTO")]
    public int Idproducto { get; set; }

    [Column("IDPROVEEDOR")]
    public int Idproveedor { get; set; }

    [Column("FECHA", TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column("PRECIO", TypeName = "money")]
    public decimal Precio { get; set; }

    [ForeignKey("Idproducto")]
    [InverseProperty("Provees")]
    public virtual Producto IdproductoNavigation { get; set; } = null!;

    [ForeignKey("Idproveedor")]
    [InverseProperty("Provees")]
    public virtual Proveedor IdproveedorNavigation { get; set; } = null!;
}
