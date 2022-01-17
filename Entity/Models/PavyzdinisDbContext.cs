using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class PavyzdinisDbContext : DbContext
    {
        public  PavyzdinisDbContext(DbContextOptions<PavyzdinisDbContext> options) : base(options){ }

        public DbSet<Savininkas> Savininkai { get; set; }

        public DbSet<Daiktas> Daiktai { get; set; }

        public DbSet<Automobilis> Automobiliai { get; set; }

        public DbSet<Mopedas> Mopedai { get; set; }


    }
}
