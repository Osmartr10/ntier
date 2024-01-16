using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db.Modelos;

[Table("auditoriaProducto")]
public partial class AuditoriaProducto
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("idproducto")]
    public int Idproducto { get; set; }

    [Column("precioCostoAntiguo", TypeName = "money")]
    public decimal? PrecioCostoAntiguo { get; set; }

    [Column("precioCostoNuevo", TypeName = "money")]
    public decimal? PrecioCostoNuevo { get; set; }

    [Column("fecha", TypeName = "datetime")]
    public DateTime? Fecha { get; set; }
}
