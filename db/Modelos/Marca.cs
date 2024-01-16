using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("MARCA")]
public partial class Marca
{
    [Key]
    [Column("IDMARCA")]
    public int Idmarca { get; set; }

    [Column("NOMBRE")]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [Column("ESTADO")]
    [StringLength(20)]
    public string Estado { get; set; } = null!;

    [InverseProperty("IdmarcaNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
