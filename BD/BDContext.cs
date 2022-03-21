using System;
using DesafioBCP.Model;
using Microsoft.EntityFrameworkCore;

namespace DesafioBCP.BD
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options) { }

        public DbSet<EquivMonedaEntity> EquivMonedaEnt { get; set; }
    }
}
