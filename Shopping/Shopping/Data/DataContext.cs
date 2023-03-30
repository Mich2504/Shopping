using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shooping.Data.Entities;
using Shopping.Data.Entities;

namespace Shooping.Data
{
    //Esta clase debe heredar de otra clase
    public class DataContext : IdentityDbContext<User>
    {
        //Para la conexion a la base de datos se debe generar un contructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)//pasa una clase generica 
        {

        }
        //Se debe mapear
        public DbSet<Category> Categories { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        //public DbSet<Sale> Sales { get; set; }

        //public DbSet<SaleDetail> SaleDetails { get; set; }

        public DbSet<State> States { get; set; }

        //public DbSet<TemporalSale> TemporalSales { get; set; }

        //Se deben validar que no existan registros repetidos en la BD

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Creacion del indice
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();//Lo que quiere decir que es un indice unico sobre el campo name
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();//Creacion de indice compuesto
            modelBuilder.Entity<Product>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<ProductCategory>().HasIndex("ProductId", "CategoryId").IsUnique();
            //se guardan los cambios en la consola (add-migration AddIndexToCountry)
            //No olvides agregar la migracion
        }

    }
}
