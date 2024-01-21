using Microsoft.EntityFrameworkCore;
using Store.Persistance.Configurations;
using Store.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistance.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Package> Package { get; set; }
        
        public DbSet<Project> Project { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<PackageDocument> PackageDocument { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const string schema = "dbo";
            modelBuilder.ApplyConfiguration(new CategoryConfiguration(schema));
            modelBuilder.ApplyConfiguration(new MovieConfiguration(schema));
            modelBuilder.ApplyConfiguration(new UserConfiguration(schema));
            modelBuilder.ApplyConfiguration(new ProjectConfiguration(schema));
            modelBuilder.ApplyConfiguration(new PackageConfiguration(schema));
            modelBuilder.ApplyConfiguration(new DocumentConfiguration(schema));
            modelBuilder.ApplyConfiguration(new PackageDocumentConfiguration(schema));
        }
    }
}
