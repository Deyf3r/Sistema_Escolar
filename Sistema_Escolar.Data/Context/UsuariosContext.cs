

using Microsoft.EntityFrameworkCore;
using Sistema_Escolar.Data.Entities;

namespace Sistema_Escolar.Data.Context
{
    public class UsuariosContext : DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("EscuelaDB");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Usuarios> Usuarios { get; set; }    
        
    }
}
