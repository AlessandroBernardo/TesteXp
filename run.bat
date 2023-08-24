@echo off

:: Salva o diretório atual em uma variável
set CURRENT_DIR=%CD%

:: Mostra uma mensagem no terminal
echo Rodando os testes do CadastroClienteXp...

:: Restaura os pacotes NuGet para o projeto de teste
echo Restaurando pacotes do projeto de teste...
dotnet restore ".\CadastroClienteXpTeste.Tests\CadastroClienteXpTeste.Tests.csproj"

:: Compila o projeto de teste
echo Compilando o projeto de teste...
dotnet build ".\CadastroClienteXpTeste.Tests\CadastroClienteXpTeste.Tests.csproj"

:: Roda os testes usando caminho relativo
dotnet test ".\CadastroClienteXpTeste.Tests\CadastroClienteXpTeste.Tests.csproj"

:: Verifica se os testes passaram. Se falharam, o script para aqui.
IF ERRORLEVEL 1 (
    echo Testes falharam. A aplicação não será executada.
    pause
    exit /b
)

:: Mostra uma mensagem no terminal
echo Testes passaram! Restaurando os pacotes...

:: Restaura os pacotes NuGet
dotnet restore "CadastroClienteXpTeste.API\CadastroClienteXpTeste.API.csproj"

:: Mostra uma mensagem no terminal
echo Compilando o projeto...

:: Compila o projeto
dotnet build "CadastroClienteXpTeste.API\CadastroClienteXpTeste.API.csproj"

:: Mostra uma mensagem no terminal
echo Preparando o ambiente com Docker...

:: Verifica se o container do SQL Server já está rodando
docker ps | findstr "sqlXP_container" > nul
IF ERRORLEVEL 1 (
    echo "Container não encontrado. Iniciando..."
    :: Se o container "sqlXP_container" não estiver rodando, construa e inicie os serviços
    :: Navega até o diretório onde o docker-compose.yml está localizado
    cd CadastroClienteXpTeste.API
    docker-compose build
    docker-compose up -d
    :: Retorna para o diretório original
    cd %CURRENT_DIR%
    :: Entra no loop de espera para garantir que o container "sqlXP_container" esteja em execução
    :loop
    docker ps | findstr "sqlXP_container" > nul
    IF ERRORLEVEL 1 (
        echo Aguarde... subindo banco no Docker.
        timeout /t 10 /NOBREAK >nul
        goto :loop
    ) ELSE (
        echo "Container sqlXP_container em execução!"
    )
) ELSE (
    echo "Container sqlXP_container já está em execução!"
)

:: Mostra uma mensagem no terminal
echo Docker ok... Atualizando o banco de dados...

:: Roda as migrações do EF Core
dotnet ef database update --project "CadastroClienteXpTeste.API\CadastroClienteXpTeste.API.csproj"

:: Mostra uma mensagem no terminal
echo Ambiente pronto! Executando a API...

:: Roda a aplicação usando caminho relativo
dotnet run --project "CadastroClienteXpTeste.API\CadastroClienteXpTeste.API.csproj"

:: Abre o Visual Studio Code na pasta raiz do projeto
start code .

:: Abre a URL do Swagger no navegador padrão
start http://localhost:5228/swagger
