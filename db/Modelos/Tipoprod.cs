using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("TIPOPROD")]
public partial class Tipoprod
{
    [Key]
    [Column("IDTIPOPROD")]
    public int Idtipoprod { get; set; }

    [Column("NOMBRE")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdtipoprodNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
