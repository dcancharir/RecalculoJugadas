using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SesionesCliente.TecnologiasModels;

namespace SesionesCliente.Context;

public partial class BDTecnologiasContext : DbContext
{
    public BDTecnologiasContext()
    {
    }

    public BDTecnologiasContext(DbContextOptions<BDTecnologiasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contadores_Online> Contadores_OnLine { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(local);Database=BD_TECNOLOGIAS;Trusted_Connection=true;TrustServerCertificate=true");
}
