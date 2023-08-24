using System.Text.Json.Serialization;

namespace CadastroClienteXpTeste.API.DTOs
{
    public class TelefoneDTO : EntityBaseDTO
    {
        public string Numero { get; set; }

        [JsonIgnore]
        public int ClienteId { get; set; }
        
    }

}