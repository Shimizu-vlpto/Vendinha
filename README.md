# Vendinha - Sistema de Gestão de Clientes e Dívidas

Este projeto é um sistema completo de gerenciamento de clientes e controle financeiro de dívidas (fiado), composto por uma API REST (Backend) e um aplicativo desktop Windows Forms (Frontend).

## Funcionalidades
- Cadastro, edição, listagem e exclusão de clientes.
- Validação de CPF com 11 dígitos numéricos e validação de formato de e-mail.
- Lançamento de compras (dívidas) e abatimento de valores (pagamentos).
- Visualização da data do último pagamento realizado pelo cliente.
- Paginação de dados na tabela principal.
- Ordenação dinâmica clicando no cabeçalho da coluna de dívidas.
- Pesquisa de clientes por nome em tempo real.

## Requisitos Próximos
* .NET SDK 7.0 ou superior
* PostgreSQL

## Configuração do Banco de Dados
1. Crie um banco de dados no PostgreSQL chamado `VendinhaDB`.
2. Execute o script contido no arquivo `schema.sql` para criar as tabelas necessárias.
3. Atualize a string de conexão no arquivo `appsettings.json` do Backend se for necessário.

## Como Executar o Backend
1. Abra o terminal na pasta do projeto Backend.
2. Execute o comando: dotnet run

## Como Executar o Frontend
Abra o projeto Frontend no Visual Studio.
Certifique-se de que a URL da API no arquivo ApiService.cs corresponde à URL onde o Backend está rodando.
Clique em iniciar ou pressione F5 para rodar o aplicativo Windows Forms.

------ Script Banco de Dados PostgreSQL ------

"""CREATE TABLE "Clientes" (
"Id" SERIAL PRIMARY KEY,
"NomeCompleto" VARCHAR(255) NOT NULL,
"Cpf" VARCHAR(11) NOT NULL,
"DataNascimento" TIMESTAMP NOT NULL,
"Email" VARCHAR(255) NOT NULL,
"DataCriacao" TIMESTAMP NOT NULL
);

CREATE TABLE "Dividas" (
"Id" SERIAL PRIMARY KEY,
"ClienteId" INT NOT NULL,
"Valor" NUMERIC(18,2) NOT NULL,
"DataCriacao" TIMESTAMP NOT NULL,
"DataPagamento" TIMESTAMP NULL,
CONSTRAINT "FK_Dividas_Clientes_ClienteId" FOREIGN KEY ("ClienteId") REFERENCES "Clientes" ("Id") ON DELETE CASCADE
);
"""

with open("README.md", "w", encoding="utf-8") as f:
f.write(readme_content)

with open("schema.sql", "w", encoding="utf-8") as f:
f.write(schema_content)

print("Arquivos gerados com sucesso.")
