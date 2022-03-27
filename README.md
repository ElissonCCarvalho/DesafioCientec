# Backend

## Descrição
O projeto backend foi desenvolvido por meio da plataforma .Net usando conceitos de REST-APi implementada usando a linguagem c#.

## Requerimentos
### Servidor MySql
- Está configurado para executar localmente de acordo com as seguintes configurações:
	- server=localhost
	- user=root
	- database=dbchallenge
	- port=3306
- Esta configuração pode ser alterada editando o arquivo `appsettings.json`

### .NET versão 6.0 

## Executar o Projeto Via Terminal

Baixe as ferramentas de [Entity Framework Core-CLI do .NET Core](https://docs.microsoft.com/pt-br/ef/core/cli/dotnet): `dotnet tool install --global dotnet-ef`

Baixe o projeto
Na pasta backend:
- Execute as migrations: `dotnet ef database update`
- Execute o projeto: `dotnet run`

# Frontend

## Descrição
O projeto frontend foi desenvolvido usando o framework [Bootstrap](https://getbootstrap.com/) para criar a interface do usuário. Para fazer as requisições à API, foi utilizado a biblioteca [jQuery](https://jquery.com/).
