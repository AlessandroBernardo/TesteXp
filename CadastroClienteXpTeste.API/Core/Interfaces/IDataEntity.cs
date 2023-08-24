namespace CadastroClienteXpTeste.API.Core.Interfaces
{
    public interface IDataEntity
    {
        DateTime? DataDeCriacao { get; set; }
        DateTime? DataDeModificacao { get; set; }
    }
}