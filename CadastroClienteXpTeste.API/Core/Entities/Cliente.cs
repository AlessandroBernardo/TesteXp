
namespace CadastroClienteXpTeste.API.Core.Entities
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }         
        public ICollection<Email> Emails { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}