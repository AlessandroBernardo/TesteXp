
namespace CadastroClienteXpTeste.API.DTOs
{
    public class ClienteDTO : EntityBaseDTO
    {
        public string Nome { get; set; }        
        public ICollection<EmailDTO> Emails { get; set; }
        public ICollection<TelefoneDTO> Telefones { get; set; }
        public ICollection<EnderecoDTO> Enderecos { get; set; }
    }
}