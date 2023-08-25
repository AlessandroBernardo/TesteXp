# Descrição do Projeto

Este projeto foi desenvolvido com base em uma versão simplificada da Arquitetura Limpa e utiliza:

- .NET 7
- AutoMapper
- ORM com EF Migrations (Code First)
- Testes unitários/automatizados com xUnit

Alguns dos padrões de design aplicados incluem:
- **Repositório**: Utilizado para abstrair o acesso aos dados, permitindo maior flexibilidade e isolamento entre a lógica de negócio e a camada de dados.
- **Injeção de Dependência**: Aplicada para promover a inversão de controle, tornando o código mais modular e facilitando o teste unitário.

O projeto também conta com testes unitários, focados na validação de e-mail e telefone.

Adicionalmente, o projeto contém o arquivo `docker-compose`, que está configurado para subir um container no Docker com um banco SQL, servindo assim a aplicação.

## Testes de Funcionalidade com Swagger

Para facilitar a execução de testes de funcionalidade no backend, optei por utilizar o Swagger. Isso elimina a necessidade de criar uma interface separada para interagir com os métodos disponíveis.

O projeto implementa operações CRUD seguindo os conceitos de REST. Além disso, um método adicional, `GetClienteResumidoById`, foi criado. Este método retorna os dados resumidos de um cliente, incluindo o endereço principal e o e-mail principal. A lógica aplicada para determinar o "principal" é baseada na data mais recente de atualização ou inclusão do registro.

## Pré-requisitos para execução após ter clonado o repositório localmente:

> ⚠️ Esteja ciente de possíveis problemas de segurança ao executar o `run.bat`, como bloqueios por antivírus ou falta do **WSL 2** e `dotnet-ef`.

1. Ter o Docker instalado com WSL 2. Siga os passos deste [tutorial](https://learn.microsoft.com/pt-br/windows/wsl/install-manual#step-4---download-the-linux-kernel-update-package).
2. Verifique se tem a ferramenta `dotnet-ef` instalada. Caso contrário, instale-a usando o comando:
    ```
    dotnet tool install --global dotnet-ef
    ```
3. Na raiz do projeto existe o arquivo **run.bat**, que automatiza as etapas envolvidas para execução do projeto, testes e subida do container sql no docker, além da criação do banco. Basta executá-lo. Se tudo correr bem, a aplicação poderá ser acessada por aqui http://localhost:5228/swagger.

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

   Nesta fase, você estará preparando a API para ser executada, garantindo que todas as dependências sejam instaladas e que o código esteja compilado. Além disso, você também verificará a integridade do código executando testes.

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
   - 4 testes devem ser executados com sucesso.

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
   - Após iniciar a API, abra em seu navegador o endereço sugerido na linha de comando e acrescente `/swagger` ao final. A interface do Swagger proporcionará uma maneira visual e interativa de testar os endpoints da API. Visite: "http://localhost:5228/swagger".
