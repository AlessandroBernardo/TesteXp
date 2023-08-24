using System.Text.Json.Serialization;

namespace CadastroClienteXpTeste.API.Core.Entities
{
    public class Endereco : EntityBase
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }        
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        
        [JsonIgnore]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }

}