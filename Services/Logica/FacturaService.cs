using Repository.Context;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services.Logica
{

    public class FacturaService
    {
        private readonly FacturaRepository _facturaRepository;

        public FacturaService(Repository.Context.ContextoAplicacionDB context)
        {
            _facturaRepository = new FacturaRepository(context);
        }
        public async Task<IEnumerable<FacturaModel>> ListarAsync()
        {
            try
            {
                return await _facturaRepository.ListarAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AgregarAsync(FacturaModel modelo)
        {
            if (ValidacionFactura(modelo))
            {
                return await _facturaRepository.AgregarAsync(modelo);
            }
            else
            {
                return false;
            }
        }
        
        public async Task<bool> ModificarAsync(FacturaModel modelo)
        {
            if (ValidacionFactura(modelo))
            {
                return await _facturaRepository.ModificarAsync(modelo);
            }
            else
            {
                return false;
            }
        }
        
        public async Task<bool> EliminarAsync(int id)
        {
            return await _facturaRepository.EliminarAsync(id);
        }

        public async Task<FacturaModel> ConsultarAsync(int id)
        {
            try
            {
                return await _facturaRepository.ConsultarAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la factura.", ex);
            }
        }

        private bool ValidacionFactura(FacturaModel factura)
        {
            if (factura == null || string.IsNullOrEmpty(factura.nro_factura))
            {
                return false;
            }
            return true;
        }
        /*
        private void CalcularTotales(FacturaModel factura)
        {
            factura.total_iva = factura.total_iva5 + factura.total_iva10;
            factura.total = (int)((factura.total_iva5 / 0.05m) + (factura.total_iva10 / 0.1m)) + factura.total_iva; // Utiliza tipos decimales para los cálculos
        }*/
    }
}
