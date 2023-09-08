using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Registros.DAL;
using Registros.Models;

namespace Registros.BLL
{
    public class ClientesBLL
    {
        private Context _context;

        public ClientesBLL(Context context)
        {
            _context = context;
        }

        public bool Existe(int ClienteId)
        {
            return _context.Clientes.Any(op => op.ClientesId == ClienteId);
        }

        private bool Insertar(Clientes Clientes)
        {
            _context.Clientes.Add(Clientes);
            return _context.SaveChanges() > 0;
        }

        private bool Modificar(Clientes Clientes)
        {
            var existe = _context.Clientes.Find(Clientes.ClientesId);
            if (existe != null)
            {
                _context.Entry(existe).CurrentValues.SetValues(Clientes);
                return _context.SaveChanges() > 0;
            }

            return false;
        }

        public bool Guardar(Clientes Clientes)
        {
            if (!Existe(Clientes.ClientesId))
                return this.Insertar(Clientes);
            else
                return this.Modificar(Clientes);
        }

        public bool Eliminar(int ClientesId)
        {
            var eliminado = _context.Clientes.Where(op => op.ClientesId == ClientesId).SingleOrDefault();

            if (eliminado != null)
            {
                _context.Entry(eliminado).State = EntityState.Deleted;
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public Clientes? Buscar(int ClienteId)
        {
            return _context.Clientes.Where(op => op.ClientesId == ClienteId)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            return _context.Clientes
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }

        public bool VerificarExistencia(Clientes Cliente)
        {
            var clienteIgual = _context.Clientes.Any(op => op.Nombre == Cliente.Nombre || op.Rnc == Cliente.Rnc);

            if (clienteIgual)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
