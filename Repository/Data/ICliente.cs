using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
   public interface ICliente
   {
        Task<bool> AgregarAsync(ClienteModel cliente);
        Task<bool> ModificarAsync(ClienteModel cliente);
        Task<bool> EliminarAsync(int id);
        Task<ClienteModel> ConsultarAsync(int id);
        Task<IEnumerable<ClienteModel>> ListarAsync();
    }
}
