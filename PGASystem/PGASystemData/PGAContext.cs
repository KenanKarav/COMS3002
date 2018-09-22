using System;
using Microsoft.EntityFrameworkCore;
using PGASystemData.Models;

namespace PGASystemData
{
    public class PGAContext : DbContext
    {
        public PGAContext(DbContextOptions options) : base(options) { }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationFiles> ApplicationFile { get; set; }

    }
}
