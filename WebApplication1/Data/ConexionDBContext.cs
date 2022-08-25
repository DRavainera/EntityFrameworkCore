using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ConexionDBContext : DbContext
    {
        protected readonly IConfiguration Configuracion;
        public ConexionDBContext(IConfiguration configuracion)
        {
            Configuracion = configuracion;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuracion.GetConnectionString("MiConexion"));
        }
        public DbSet<Producto> Producto
        {
            get;
            set;
        }
    }
}
