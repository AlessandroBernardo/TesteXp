using System.Text.Json.Serialization;

namespace CadastroClienteXpTeste.API.DTOs
{
    public class EmailDTO : EntityBaseDTO
    {
        public string EnderecoEmail { get; set; }
        
        [JsonIgnore]
        public int ClienteId { get; set; }
        
    }

}