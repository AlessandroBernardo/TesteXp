using Moq;
using Xunit;
using System.Threading.Tasks;
using CadastroClienteXpTeste.API.Core.Interfaces.Repositories;
using CadastroClienteXpTeste.API.Services;
using AutoMapper;
using System;
using CadastroClienteXpTeste.Tests;
using CadastroClienteXpTeste.API.Core.Entities;

public class ClienteServiceTests
{
    private readonly ClienteService _service;
    private readonly Mock<IClienteRepository> _clienteRepoMock;
    private readonly Mock<IMapper> _mapperMock;

    public ClienteServiceTests()
    {
        _clienteRepoMock = new Mock<IClienteRepository>();
        _mapperMock = new Mock<IMapper>();

        // Configuração padrão dos mocks. Ajuste conforme necessário.
        _clienteRepoMock.Setup(repo => repo.AddClienteAsync(It.IsAny<Cliente>())).Returns(Task.CompletedTask);

        _service = new ClienteService(_clienteRepoMock.Object, _mapperMock.Object);
    }    
    
    [Fact]
    public async Task AddCliente_ValidEmail_AddsSuccessfully()
    {
        var cliente = ObjetosMock.ClienteValido();
       
        await _service.AddClienteAsync(cliente);
        _clienteRepoMock.Verify(repo => repo.AddClienteAsync(It.IsAny<Cliente>()), Times.Once);
    }

    [Fact]
    public async Task AddCliente_InvalidEmail_ThrowsException()
    {
        var cliente = ObjetosMock.ClienteTelValidoEmailInvalido();
        await Assert.ThrowsAsync<ArgumentException>(() => _service.AddClienteAsync(cliente));
    }

    [Fact]
    public async Task AddCliente_ValidTel_AddsSuccessfully()
    {
        var cliente = ObjetosMock.ClienteValido();
       
        await _service.AddClienteAsync(cliente);
        _clienteRepoMock.Verify(repo => repo.AddClienteAsync(It.IsAny<Cliente>()), Times.Once);
    }

    [Fact]
    public async Task AddCliente_InvalidTel_ThrowsException()
    {
        var cliente = ObjetosMock.ClienteEmailValidoTelInvalido();
        await Assert.ThrowsAsync<ArgumentException>(() => _service.AddClienteAsync(cliente));
    }
}
