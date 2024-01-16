using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("INGRESO")]
public partial class Ingreso
{
    [Key]
    [Column("IDINGRESO")]
    public int Idingreso { get; set; }

    [Column("IDPROVEEDOR")]
    public int Idproveedor { get; set; }

    [Column("FECHAINGRESO", TypeName = "datetime")]
    public DateTime Fechaingreso { get; set; }

    [Column("TOTAL", TypeName = "money")]
    public decimal Total { get; set; }

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdingresoNavigation")]
    public virtual ICollection<Detalleing> Detalleings { get; set; } = new List<Detalleing>();

    [ForeignKey("Idproveedor")]
    [InverseProperty("Ingresos")]
    public virtual Proveedor IdproveedorNavigation { get; set; } = null!;
}
