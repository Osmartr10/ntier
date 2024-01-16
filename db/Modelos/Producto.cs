using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("PRODUCTO")]
public partial class Producto
{
    [Key]
    [Column("IDPRODUCTO")]
    public int Idproducto { get; set; }

    [Column("IDTIPOPROD")]
    public int Idtipoprod { get; set; }

    [Column("IDMARCA")]
    public int Idmarca { get; set; }

    [Column("NOMBRE")]
    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [Column("CODIGOBARRA")]
    [StringLength(20)]
    public string Codigobarra { get; set; } = null!;

    [Column("UNIDAD")]
    public int Unidad { get; set; }

    [Column("DESCRIPCION")]
    [StringLength(100)]
    public string Descripcion { get; set; } = null!;

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdproductoNavigation")]
    public virtual ICollection<Detalleing> Detalleings { get; set; } = new List<Detalleing>();

    [InverseProperty("IdproductoNavigation")]
    public virtual ICollection<Detalleventum> Detalleventa { get; set; } = new List<Detalleventum>();

    [ForeignKey("Idmarca")]
    [InverseProperty("Productos")]
    public virtual Marca IdmarcaNavigation { get; set; } = null!;

    [ForeignKey("Idtipoprod")]
    [InverseProperty("Productos")]
    public virtual Tipoprod IdtipoprodNavigation { get; set; } = null!;

    [InverseProperty("IdproductoNavigation")]
    public virtual ICollection<Provee> Provees { get; set; } = new List<Provee>();
}
