using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SesionesCliente.TestSorteoSalaModels;
public partial class TEST_Jugada {
    [Key]
    public long JugadaId { get; set; }

    public long? Cod_Cont_OL { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? Hora { get; set; }

    public string? CodMaq { get; set; }

    public double? CoinOut { get; set; }

    public double? CurrentCredits { get; set; }

    public decimal? Monto { get; set; }

    public decimal? Token { get; set; }

    public double? CoinOutAnterior { get; set; }

    public int? Estado_Oln { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public double? HandPay { get; set; }

    public double? JackPot { get; set; }

    public double? HandPayAnterior { get; set; }

    public double? JackPotAnterior { get; set; }

    public decimal? CoinIn { get; set; }

    public decimal? CoinInAnterior { get; set; }

    public long? Cod_Cont_OLAnterior { get; set; }
}
