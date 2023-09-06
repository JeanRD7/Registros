using Microsoft.EntityFrameworkCore;
using Registros.Models;

namespace Registros.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> Opcions) : base(Opcions) { }
        public DbSet<Clientes> Clientes { get; set; }
    }
}
