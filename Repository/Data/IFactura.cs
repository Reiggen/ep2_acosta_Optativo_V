using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public interface IFactura
    {
        Task<bool> AgregarAsync(FacturaModel factura);
        Task<bool> ModificarAsync(FacturaModel factura);
        Task<bool> EliminarAsync(int id);
        Task<FacturaModel> ConsultarAsync(int id);
        Task<IEnumerable<FacturaModel>> ListarAsync();
    }
}
