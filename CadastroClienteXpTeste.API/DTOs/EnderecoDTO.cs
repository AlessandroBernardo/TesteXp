using System.Text.Json.Serialization;

namespace CadastroClienteXpTeste.API.DTOs
{
    public class EnderecoDTO : EntityBaseDTO
    {
        public string Rua { get; set; }
        public string Cidade { get; set; }        
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        
        [JsonIgnore]
        public int ClienteId { get; set; }
       
    }

}