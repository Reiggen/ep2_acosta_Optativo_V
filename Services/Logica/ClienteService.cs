using Repository.Context;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(Repository.Context.ContextoAplicacionDB context)
        {
            _clienteRepository = new ClienteRepository(context);
        }

        public async Task<bool> AgregarAsync(ClienteModel modelo)
        {
            if (ValidacionCliente(modelo))
            {
                return await _clienteRepository.AgregarAsync(modelo);
            }
            else
            {
                return false;
            }
        }


        public async Task<ClienteModel> ConsultarAsync(int id)
        {
            return await _clienteRepository.ConsultarAsync(id);
        }

        public async Task<bool> ModificarAsync(ClienteModel modelo)
        {
            if (ValidacionCliente(modelo))
            {
                return await _clienteRepository.ModificarAsync(modelo);
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> EliminarAsync(ClienteModel modelo)
        {
            if (modelo != null)
            {
                return await _clienteRepository.EliminarAsync(modelo);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<ClienteModel>> ListarAsync()
        {
            try
            {
                return await _clienteRepository.ListarAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidacionCliente(ClienteModel cliente)
        {
            if (cliente == null || string.IsNullOrEmpty(cliente.nombre))
            {
                return false;
            }
            return true;
        }
    }
}