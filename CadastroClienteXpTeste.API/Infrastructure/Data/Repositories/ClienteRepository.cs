using System.Runtime.CompilerServices;
using CadastroClienteXpTeste.API.Core.Entities;
using CadastroClienteXpTeste.API.Core.Interfaces;
using CadastroClienteXpTeste.API.Core.Interfaces.Repositories;
using CadastroClienteXpTeste.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CadastroClienteXpTeste.API.Infrastructure.Data.Repositories
{

    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Cliente>> GetClientesAsync()
        {

            return await _context.Clientes
                .Include(c => c.Telefones)
                .Include(c => c.Emails)
                .Include(c => c.Enderecos)
                .AsNoTracking()
                .ToListAsync();

        }


        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes
                .Include(c => c.Telefones)
                .Include(c => c.Emails)
                .Include(c => c.Enderecos)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente));
            }

            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id) ?? throw new Exception("Cliente not found");
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<ClienteResumidoDTO> GetClienteResumidoById(int id)
        {
            return await _context.Clientes
                    .Where(c => c.Id == id)
                    .Select(c => new ClienteResumidoDTO
                    {
                        Cliente = c,
                        TelefoneMaisRecente = c.Telefones.OrderByDescending(t => t.DataDeModificacao ?? t.DataDeCriacao).FirstOrDefault(),
                        EmailMaisRecente = c.Emails.OrderByDescending(e => e.DataDeModificacao ?? e.DataDeCriacao).FirstOrDefault(),
                        EnderecoMaisRecente = c.Enderecos.OrderByDescending(end => end.DataDeModificacao ?? end.DataDeCriacao).FirstOrDefault()
                    })
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }

        // private TEntity GetLatest<TEntity>(IQueryable<TEntity> entities) where TEntity : class, IDataEntity
        // {
        //     return entities.OrderByDescending(e => e.DataDeModificacao ?? e.DataDeCriacao).FirstOrDefault();
        // }
    }
}
