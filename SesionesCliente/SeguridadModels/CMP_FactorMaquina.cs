using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SesionesCliente.SeguridadModels;
public partial class CMP_FactorMaquina {
    [Key]
    public string CodMaquina { get; set; }
    public decimal FactorMultiplicador { get; set; }
}
