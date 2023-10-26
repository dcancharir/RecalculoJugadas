using Microsoft.EntityFrameworkCore;
using SesionesCliente.OnlineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SesionesCliente.Context;
public partial class BDOnlineContext : DbContext
{
    public BDOnlineContext()
    {

    }
    public BDOnlineContext(DbContextOptions<BDOnlineContext> options) : base(options)
    {

    }
    public virtual DbSet<CMP_Sesion> CMP_Sesion { get; set; }
    public virtual DbSet<CMP_SesionSorteoSala> CMP_SesionSorteoSala { get; set; }
    public virtual DbSet<CMP_Jugada> CMP_Jugada { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(local);Database=BD_ONLINE;Trusted_Connection=true;TrustServerCertificate=true");
}
