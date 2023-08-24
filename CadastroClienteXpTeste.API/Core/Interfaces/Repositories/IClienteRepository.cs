using CadastroClienteXpTeste.API.DTOs;
using CadastroClienteXpTeste.API.Core.Entities;

namespace CadastroClienteXpTeste.API.Core.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
        Task <ClienteResumidoDTO>GetClienteResumidoById(int id);
    }
} 