using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {

        }

        public DbSet<Companhia> Companhias { get; set; }
        public DbSet<Depoimento> Depoimentos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Passagem> Passagens { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
    }
}
