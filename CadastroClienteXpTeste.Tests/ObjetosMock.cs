
using CadastroClienteXpTeste.API.Core.Entities;

namespace CadastroClienteXpTeste.Tests;

public class ObjetosMock
{
    public static Cliente ClienteInvalido()
    {
        return new Cliente
        {            
            Nome = "Alessandro Cliente Nok",
            Emails = new List<Email>
            {
            new Email
                {            
                    EnderecoEmail = "emailinvalido"
                }
            },
            Telefones = new List<Telefone>
            {
            new Telefone
                {            
                    Numero = "1234567" 
                }
            },
                Enderecos = new List<Endereco>
            {
            new Endereco
                {           
                    Rua = "Avenida Brasil",
                    Cidade = "São Paulo",
                    Numero = 123,
                    Complemento = "Apartamento 1",
                    CEP = "12345-678"
                }
            }
        };
    }

    public static Cliente ClienteEmailValidoTelInvalido()
    {
        return new Cliente
        {            
            Nome = "Alessandro Email ok Tel Nok",
            Emails = new List<Email>
            {
            new Email
                {            
                    EnderecoEmail = "emailvalido@emailvalido.com"
                }
            },
            Telefones = new List<Telefone>
            {
            new Telefone
                {            
                    Numero = "011988761673444" 
                }
            },
                Enderecos = new List<Endereco>
            {
            new Endereco
                {           
                    Rua = "Avenida Brasil",
                    Cidade = "São Paulo",
                    Numero = 123,
                    Complemento = "Apartamento 1",
                    CEP = "12345-678"
                }
            }
        };
    }
    public static Cliente ClienteTelValidoEmailInvalido()
    {
        return new Cliente
        {            
            Nome = "Alessandro Tel Ok Email Nok",
            Emails = new List<Email>
            {
            new Email
                {            
                    EnderecoEmail = "emailvalidoINVALIDOemailvalido.com"
                }
            },
            Telefones = new List<Telefone>
            {
            new Telefone
                {            
                    Numero = "011988761678" 
                }
            },
                Enderecos = new List<Endereco>
            {
            new Endereco
                {           
                    Rua = "Avenida Brasil",
                    Cidade = "São Paulo",
                    Numero = 123,
                    Complemento = "Apartamento 1",
                    CEP = "12345-678"
                }
            }
        };
    }

    public static Cliente ClienteValido()
    {
        return new Cliente
        {            
            Nome = "Alessandro Valido",
            Emails = new List<Email>
            {
            new Email
                {            
                    EnderecoEmail = "emailvalido@emailvalido.com"
                }
            },
            Telefones = new List<Telefone>
            {
            new Telefone
                {            
                    Numero = "011988761678" 
                }
            },
                Enderecos = new List<Endereco>
            {
            new Endereco
                {           
                    Rua = "Avenida Brasil",
                    Cidade = "São Paulo",
                    Numero = 123,
                    Complemento = "Apartamento 1",
                    CEP = "12345-678"
                }
            }
        };
    }
}