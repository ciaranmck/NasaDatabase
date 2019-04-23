using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NasaDatabase.Models;

namespace NasaDatabase.Data
{
    public class NasaDbContext : DbContext
    {
        public NasaDbContext() :
            base("NasaDbConnection")
        {
        }

        public static NasaDbContext Create()
        {
            return new NasaDbContext();
        }

        public DbSet<Fireball> Fireballs { get; set; }
    }
}