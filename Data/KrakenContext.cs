using System;
using System.Collections.Generic;
using System.Text;
using KrakenEfCOre.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KrakenEfCOre.Data
{
    class KrakenContext : DbContext
    {
        public DbSet<Target>  Target { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Kraken;Integrated Security=True");

        }
    }
}
