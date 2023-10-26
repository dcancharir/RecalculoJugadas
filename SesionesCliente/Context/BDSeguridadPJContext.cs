using Microsoft.EntityFrameworkCore;
using SesionesCliente.SeguridadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SesionesCliente.Context;
public partial class BDSeguridadPJContext : DbContext
{
    public BDSeguridadPJContext()
    {
    }
    public BDSeguridadPJContext(DbContextOptions<BDSeguridadPJContext> options) : base(options)
    {
    }
    public virtual DbSet<CMP_SorteoSala> CMP_SorteoSala { get; set; }
    public virtual DbSet<CMP_FactorMaquina> CMP_FactorMaquina{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(local);Database=BD_SEGURIDAD_PJ_SALA;Trusted_Connection=true;TrustServerCertificate=true");
}
