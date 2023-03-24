using Microsoft.EntityFrameworkCore;

namespace Shopping.Data.Entities
{
    //Esta clase debe heredar de otra clase
    public class DataContext: DbContext
    {
        //Para la conexion a la base de datos se debe generar un contructor
        public DataContext(DbContextOptions<DataContext>options): base(options)//pasa una clase generica 
        {
            
        }
        //Se debe mapear
        public DbSet<Country> Countries { get; set; }
        //Se deben validar que no existan registros repetidos en la BD

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();//Lo que quiere decir que es un indice unico sobre el campo name
            //se guardan los cambios en la consola (add-migration AddIndexToCountry)
        }

    }
}
