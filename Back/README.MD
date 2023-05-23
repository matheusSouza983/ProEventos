CRIANDO O PROJETO

1 - para criar o repositorio roda o comando "dotnet new webapi -n ProEventos.API" (caso tenha duvidas escreva o -h que ele sugere algumas dicas) no terminal dentro do src
obs1: rodar "dotnet dev-certs https --trust" para instalar o certificado de desenvolvedor para poder fazer os testes.
obs2: para criar o gitignore do c# rodar o comando "dotnet new gitignore"


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
5 - importar o contexto na controller