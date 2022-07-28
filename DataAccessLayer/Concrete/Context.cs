using EntityLayer.ModelBuilders;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1JGN6SC;Database=EfCodeFirstDb;integrated security=true");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Active> Activies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserModelBuilder).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActiveModelBuilder).Assembly);
        }
    }
}
