using CadastroClienteXpTeste.API.DTOs;
using CadastroClienteXpTeste.API.Core.Entities;

namespace CadastroClienteXpTeste.API.Core.Interfaces.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetClientesAsync();
        Task<ClienteDTO> GetClienteByIdAsync(int id);
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
        Task <ClienteResumidoDTO>GetClienteResumidoById(int id);
    }
}