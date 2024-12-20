﻿using Microsoft.EntityFrameworkCore;

namespace MiApiProyecto.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
    }
}

