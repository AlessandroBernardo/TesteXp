using AutoMapper;
using CadastroClienteXpTeste.API.DTOs;
using CadastroClienteXpTeste.API.Core.Entities;
using CadastroClienteXpTeste.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteXpTeste.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // POST: api/AddCliente
        [HttpPost("Cliente")]
        public async Task<ActionResult<ClienteDTO>> AddCliente([FromBody] ClienteDTO clienteCreateDTO)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteCreateDTO);
                await _clienteService.AddClienteAsync(cliente);

                var ClienteCreatedDTO = _mapper.Map<ClienteDTO>(cliente);
                return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, ClienteCreatedDTO);
            }
            catch (Exception ex)
            {
                return ex;
            }


        }


        // GET: api/Clientes
        [HttpGet("Clientes")]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
        {

            try
            {
                var clientes = await _clienteService.GetClientesAsync();
                var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
                return Ok(clientesDTO);
            }
            catch (Exception ex)
            {
                return ex;
            }


        }

        // GET: api/Clientes/5
        [HttpGet("Cliente/{id}")]
        public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
        {

            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                var clienteDTO = _mapper.Map<ClienteDTO>(cliente);
                return clienteDTO;
            }
            catch (Exception ex)
            {
                return ex;
            }


        }

        // PUT: api/Clientes/5
        [HttpPut("Cliente/{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDTO);
                await _clienteService.UpdateClienteAsync(cliente);

                return NoContent();

            }
            catch (Exception ex)
            {
                return ex;
            }


        }

        // DELETE: api/Clientes/5
        [HttpDelete("Cliente/{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {

            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                await _clienteService.DeleteClienteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return ex;
            }


        }

        [HttpGet("GetClienteResumidoById/{id}")]
        public async Task<ActionResult<ClienteResumidoDTO>> GetClienteResumidoById(int id)
        {

            try
            {
                var cliente = await _clienteService.GetClienteResumidoById(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return cliente;
            }
            catch (Exception ex)
            {
                return ex;
            }


        }
    }

}