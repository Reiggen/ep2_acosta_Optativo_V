using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    public class FacturaRepository : IFactura
    {
        private readonly DbContext _context;

        public FacturaRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FacturaModel>> ListarAsync()
        {
            try
            {
                return await _context.Set<FacturaModel>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<FacturaModel> ConsultarAsync(int id)
        {
            try
            {
                return await _context.Set<FacturaModel>().FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*
        public async Task<bool> AgregarAsync(FacturaModel factura)
        {
            try
            {
                if (ValidarNumeroFactura(factura.nro_factura))
                {
                    await _context.Set<FacturaModel>().AgregarAsync(factura);
                    int resultado = await _context.SaveChangesAsync();
                    return resultado > 0;
                }
                else
                {
                    throw new ArgumentException("El número de factura no cumple con el patrón especificado.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }*/
        public async Task<bool> AgregarAsync(FacturaModel factura)
        {
            try
            {
                await _context.AddAsync(factura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> ModificarAsync(FacturaModel factura)
        {
            try
            {
                _context.Update(factura);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*public async Task<bool> ModificarAsync(FacturaModel factura)
        {
            try
            {
                if (ValidarNumeroFactura(factura.nro_factura))
                {
                    _context.Set<FacturaModel>().Update(factura);
                    int resultado = await _context.SaveChangesAsync();
                    return resultado > 0;
                }
                else
                {
                    throw new ArgumentException("El número de factura no cumple con el patrón especificado.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }*/

        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                var factura = await _context.Set<FacturaModel>().FindAsync(id);
                if (factura != null)
                {
                    _context.Set<FacturaModel>().Remove(factura);
                    int resultado = await _context.SaveChangesAsync();
                    return resultado > 0;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool ValidarNumeroFactura(string numeroFactura)
        {
            string patron = @"^\d{3}-\d{3}-\d{6}$";
            return Regex.IsMatch(numeroFactura, patron);
        }
    }
}
