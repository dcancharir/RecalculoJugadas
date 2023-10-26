using Microsoft.EntityFrameworkCore;
namespace SesionesCliente.TestSorteoSalaModels;
[PrimaryKey(nameof(SesionId), nameof(SorteoId),nameof(JugadaId))]
public partial class TEST_SesionSorteoSala {
    public long SesionId { get; set; }
    public long SorteoId { get; set; }
    public long JugadaId { get; set; }

    public int? CantidadCupones { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? SerieIni { get; set; }

    public string? SerieFin { get; set; }

    public string? NombreSorteo { get; set; }

    public decimal? CondicionWin { get; set; }

    public decimal? WinCalculado { get; set; }

    public decimal? CondicionBet { get; set; }

    public decimal? BetCalculado { get; set; }

    public int? TopeCuponesxJugada { get; set; }

    public string? ParametrosImpresion { get; set; }

    public decimal? Factor { get; set; }

    public decimal? DescartePorFactor { get; set; }
}
