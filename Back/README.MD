CRIANDO O PROJETO

1 - para criar o repositorio roda o comando "dotnet new webapi -n ProEventos.API" (caso tenha duvidas escreva o -h que ele sugere algumas dicas) no terminal dentro do src
obs1: rodar "dotnet dev-certs https --trust" para instalar o certificado de desenvolvedor para poder fazer os testes.
obs2: para criar o gitignore do c# rodar o comando "dotnet new gitignore"

------------------------------------------------------------------------------------------

ENTITY FRAMEWORK CORE

1 - para instalar o EF core rodar os comandos "dotnet tool install --global dotnet-ef"
2 - para referenciar o projeto para usar o EF core:
    2.1 - apertar ctrl + shift + P e buscar por nugget galery.
    2.2 - instalar os pacotes (entityframeworkCore,entityframeworkCore.design, entityframeworkCore.tools, entityframeworkCore.sqlite)
3 - criando contexto
    3.1 - criar um novo diretorio data e nele criar uma classe datacontext, e herdar a classe DbContext
    3.2 - criar um novo registro dentro de startup(ConfigureServices) services.AddDbContext<DataContext>(context => context.UseSqlite(configuration.getConnectionString("default")));
    3.3 - criar a string de conexao com banco dentro da appsettings
4 - criando a migration
    4.1 - dotnet ef migrations add Initial -o Data/Migrations (-h para ajuda / -o para caminho)  
    4.2 - dotnet ef database update (criar o banco de dados)

------------------------------------------------------------------------------------------

MULTIPLAS CAMADAS

1 - criar o arquivo de solução
    1.1 - entrar no diretorio src e rodar o comando "dotnet new sln -n ProEventos"
    1.2 - criar uma class library com o comando "dotnet new classlib -n ProEventos.Persistence"
    1.3 - criar uma class library com o comando "dotnet new classlib -n ProEventos.Domain"
    1.4 - criar uma class library com o comando "dotnet new classlib -n ProEventos.Application"
2 - referenciar os projetos no arquivo de solução
    2.1 - adicionar a class library no arquivo de solução "dotnet sln ProEventos.sln add ProEventos.Application"
    2.2 - adicionar a class library no arquivo de solução "dotnet sln ProEventos.sln add ProEventos.Persistence"
    2.3 - adicionar a class library no arquivo de solução "dotnet sln ProEventos.sln add ProEventos.Domain"
    2.3 - adicionar a class library no arquivo de solução "dotnet sln ProEventos.sln add ProEventos.API"
3 - adicionando referencia no ProEventos.API
    3.1 - dotnet add ProEventos.API/ProEventos.API.csproj reference ProEventos.Application
4 - adicionando referencia no ProEventos.Application
    4.1 - dotnet add ProEventos.Application/ProEventos.Application.csproj reference ProEventos.Domain
    4.2 - dotnet add ProEventos.Application/ProEventos.Application.csproj reference ProEventos.Persistence
5 - adicionando referencia no ProEventos.Domain
    5.1 - nao precisa referenciar ninguem
6 - adicionando referencia no ProEventos.Persistence
    6.1 - dotnet add ProEventos.Persistence/ProEventos.Persistence.csproj reference ProEventos.Domain
7 - criando a nota migration "dotnet ef migrations add Initial -p ProEventos.Persistence -s ProEventos.API"
8 - criar o banco de dados "dotnet ef database update -s ProEventos.API"

obs: instalar o entityframeworkcore e entityframeworkcore.tools no persistence
obs: instalar o Microsoft.AspNetCore.Mvc.NewtonsoftJson no proeventos.api

------------------------------------------------------------------------------------------

AUTOMAPPER E PROFILE

1 - abrir a galeria nugget e instalar o AutoMapper.Extensions.Microsoft.DependencyInjection dentro do proeventos.api
2 - entrar no startup e adicionar o services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
3 - 
4 - 
5 - 
6 - 
7 - 