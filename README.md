# Descrição do Projeto

Este projeto foi desenvolvido com uma simplificação da **Arquitetura Limpa**, utilizando:
- .NET 7
- AutoMapper
- Migrations (Code First)

Alguns dos padrões de design aplicados incluem:
- Repositório
- Injeção de Dependência

O projeto também conta com testes unitários, focados na validação (ainda que simplificada) de e-mail e telefone.

Adicionalmente, o projeto contém o arquivo `docker-compose`, que está configurado para subir um container no Docker com um banco SQL, servindo assim a aplicação.

## Pré-requisitos para execução após ter clonado o repositório locamente:

1. Ter o Docker instalado com WSL 2. Siga os passos deste [tutorial](https://learn.microsoft.com/pt-br/windows/wsl/install-manual#step-4---download-the-linux-kernel-update-package).
2. Verifique se tem a ferramenta `dotnet-ef` instalada. Caso contrário, instale-a usando o comando:
    ```
    dotnet tool install --global dotnet-ef
    ```
3. Na raiz do projeto existe o arquivo **run.bat**, ele automatiza as etapas envolvidas para execução do projeto, testes e subida do container sql no docker, além da criação do banco.
4. Esteja ciente de possíveis problemas de segurança ao executar o `run.bat`, como bloqueios por antivírus ou falta do **WSL 2** e `dotnet-ef`. Se necessário, execute as etapas manualmente.

## Executando manualmente:

1. **Preparação**:
   - Clone o repositório localmente.
   - Certifique-se de ter o Docker instalado com WSL 2.

2. **Subindo o SQL no Docker**:
   - Utilize o comando abaixo de acordo com o terminal de sua escolha:

      - Terminal Linux:
        ```
        sudo docker-compose up -d
        ```

      - PowerShell ou CMD:
        ```
        docker-compose up -d
        ```

   > [Nota]: Consulte o [tutorial mencionado anteriormente](https://learn.microsoft.com/pt-br/windows/wsl/install-manual#step-4---download-the-linux-kernel-update-package) para mais detalhes.

   - Para verificar se o container foi iniciado, use:
     ```
     docker ps
     ```

3. **Configurando a API e Testes**:
   - Na raiz do projeto `CadastroClienteXpTeste.API`, abra o terminal de sua escolha e execute:
     ```
     dotnet restore
     dotnet build
     ```

   - Faça o mesmo para o projeto de testes `CadastroClienteXpTeste.Tests`.
   - Ainda na raiz do projeto de Tests, execute:
     ```
     dotnet test
     ```

4. **Rodando a API**:
   - Na raiz da API `CadastroClienteXpTeste.API`, observe que já existe uma pasta de migrations. Para criar a estrutura do banco no Docker, use:
     ```
     dotnet ef database update
     ```

   - Para executar a API:
     ```
     dotnet run
     ```

5. **Acessando a Documentação**:
   - Após iniciar a API, abra em seu navegador o endereço sugerido na linha de comando e acrescente `/swagger` ao final "http://localhost:5228/swagger".
