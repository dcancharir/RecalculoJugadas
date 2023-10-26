using System.ComponentModel.DataAnnotations;

namespace SesionesCliente.SeguridadModels;
public partial class CMP_SorteoSala {
    [Key]
    public int SorteoId { get; set; }

    public int? CodSala { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? UsuarioCreacion { get; set; }

    public int? Estado { get; set; }

    public decimal? CondicionWin { get; set; }

    public decimal? CondicionBet { get; set; }

    public int? EstadoCondicionBet { get; set; }

    public int? TopeCuponesxJugada { get; set; }
}
