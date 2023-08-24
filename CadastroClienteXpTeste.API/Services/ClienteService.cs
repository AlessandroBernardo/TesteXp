using AutoMapper;
using CadastroClienteXpTeste.API.DTOs;
using CadastroClienteXpTeste.API.Core.Entities;
using CadastroClienteXpTeste.API.Core.Interfaces.Repositories;
using CadastroClienteXpTeste.API.Core.Interfaces.Services;
using System.Text.RegularExpressions;


namespace CadastroClienteXpTeste.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ClienteDTO>> GetClientesAsync()
        {
            var clientes = await _clienteRepository.GetClientesAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
        }

        public async Task<ClienteDTO> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteByIdAsync(id);
            return _mapper.Map<ClienteDTO>(cliente);
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            ValidateCliente(cliente);
            await _clienteRepository.AddClienteAsync(cliente);
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            ValidateCliente(cliente);
            await _clienteRepository.UpdateClienteAsync(cliente);

        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteRepository.DeleteClienteAsync(id);
        }

        public async Task<ClienteResumidoDTO> GetClienteResumidoById(int id)
        {
            return await _clienteRepository.GetClienteResumidoById(id);
        }


        private void ValidateCliente(Cliente cliente)
        {
            // Validando os e-mails
            if (cliente.Emails != null && cliente.Emails.Any())
            {
                foreach (var email in cliente.Emails)
                {
                    if (!Regex.IsMatch(email.EnderecoEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) // Regex básico para e-mail
                    {
                        throw new ArgumentException($"E-mail inválido: {email.EnderecoEmail}");
                    }
                }
            }

            // Validando o telefone
            if (cliente.Telefones != null && cliente.Telefones.Any())
            {
                foreach (var telefone in cliente.Telefones)
                {
                    //Aqui válida se tem no minimo 8 digitos numéricos e no maximo 12
                    if (!Regex.IsMatch(telefone.Numero, @"^\d{8,12}$"))
                    {
                        throw new ArgumentException($"Telefone inválido: {telefone.Numero}");
                    }
                }
            }
        }
    }

}