using Microsoft.EntityFrameworkCore;
using SesionesCliente.TestSorteoSalaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SesionesCliente.Context;
public partial class BDTestSorteoSalaContext:DbContext
{
    public BDTestSorteoSalaContext() {

    }
    public BDTestSorteoSalaContext(DbContextOptions<DbContext> options) : base(options) { }
    public virtual DbSet<TEST_Sesion> TEST_Sesion { get; set; }
    public virtual DbSet<TEST_SesionSorteoSala> TEST_SesionSorteoSala { get; set; }
    public virtual DbSet<TEST_Jugada> TEST_Jugada { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=(local);Database=TestSorteos;Trusted_Connection=true;TrustServerCertificate=true");
}
