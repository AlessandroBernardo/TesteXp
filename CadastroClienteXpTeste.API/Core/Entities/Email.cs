using System.Text.Json.Serialization;

namespace CadastroClienteXpTeste.API.Core.Entities
{
    public class Email : EntityBase
    {
        public string EnderecoEmail { get; set; }
        
        [JsonIgnore]
        public int ClienteId { get; set; }

        
        public Cliente Cliente { get; set; }
    }

}