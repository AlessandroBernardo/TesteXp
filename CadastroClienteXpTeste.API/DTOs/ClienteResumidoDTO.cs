using CadastroClienteXpTeste.API.Core.Entities;

namespace CadastroClienteXpTeste.API.DTOs
{
    public class ClienteResumidoDTO
    {
        public Cliente Cliente { get; set; }
        public Telefone TelefoneMaisRecente { get; set; }
        public Email EmailMaisRecente { get; set; }
        public Endereco EnderecoMaisRecente { get; set; }
    }
}