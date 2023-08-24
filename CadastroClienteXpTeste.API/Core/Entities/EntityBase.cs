using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteXpTeste.API.Core.Entities
{
    public abstract class EntityBase
    {    
        // [JsonIgnore]
        public int Id { get; set; }        
        
        [JsonIgnore]
        public DateTime DataDeCriacao { get; set; } = DateTime.UtcNow;        
        
        [JsonIgnore]
        public DateTime? DataDeModificacao { get; set; }
    }

}