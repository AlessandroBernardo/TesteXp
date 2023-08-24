using System.Data;
using System.Text.Json.Serialization;

namespace CadastroClienteXpTeste.API.DTOs
{
    public abstract class EntityBaseDTO
    {   
        // [JsonIgnore]
        public int Id { get; set; }
        
        [JsonIgnore]
        public DateTime DataDeCriacao { get; set; } = DateTime.UtcNow;
        
        [JsonIgnore]
        public DateTime? DataDeModificacao { get; set; }
    }

}

