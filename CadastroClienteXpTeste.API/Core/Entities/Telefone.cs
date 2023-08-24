using System.Text.Json.Serialization;

namespace CadastroClienteXpTeste.API.Core.Entities
{
    public class Telefone : EntityBase
    {
        public string Numero { get; set; }
        
        [JsonIgnore]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }

}