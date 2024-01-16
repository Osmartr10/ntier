using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("PROVEEDOR")]
public partial class Proveedor
{
    [Key]
    [Column("IDPROVEEDOR")]
    public int Idproveedor { get; set; }

    [Column("NOMBRE")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Column("TELEFONO")]
    [StringLength(50)]
    public string Telefono { get; set; } = null!;

    [Column("DIRECCION")]
    [StringLength(50)]
    public string Direccion { get; set; } = null!;

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdproveedorNavigation")]
    public virtual ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();

    [InverseProperty("IdproveedorNavigation")]
    public virtual ICollection<Provee> Provees { get; set; } = new List<Provee>();
}
