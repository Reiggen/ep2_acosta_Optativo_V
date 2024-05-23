using Dapper;
using Repository.Data;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Data
{

    public class ClienteRepository : ICliente
    {
        private readonly ContextoAplicacionDB _context;

        public ClienteRepository(ContextoAplicacionDB context)
        {
            _context = context;
        }

        public async Task<bool> AgregarAsync(ClienteModel cliente)
        {
            try
            {
                await _context.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ModificarAsync(ClienteModel cliente)
        {
            try
            {
                _context.Set<ClienteModel>().Update(cliente);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> EliminarAsync(ClienteModel cliente)
        {
            try
            {
                _context.Remove(cliente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ClienteModel> ConsultarAsync(int id)
        {
            try
            {
                return await _context.Set<ClienteModel>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ClienteModel>> ListarAsync()
        {
            try
            {
                return await _context.Set<ClienteModel>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}