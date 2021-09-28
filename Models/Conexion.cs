using Microsoft.EntityFrameworkCore;
namespace Api_Catalogos.Models
{
    class Conexion : DbContext{
        public Conexion(DbContextOptions<Conexion> options):base(options){}

        public DbSet<Clientes> Clientes {get;set;}
    }
    class Conectar{

        private const string cadenaConexion = "server=localhost; port=3308; userid=root; password=maxima0606; database=ctacteproveedores;";
        //private const string cadena="server=localhost;port=3308;database=ctacteproveedores;userid=root;pwd=maxima0606;";

        public static Conexion Create(){
            var constructor = new DbContextOptionsBuilder<Conexion>();
            constructor.UseMySQL(cadenaConexion);
            var cn = new Conexion(constructor.Options);
            return cn;
        }

    }
}