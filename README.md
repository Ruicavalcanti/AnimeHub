# AnimeHub

O **AnimeHub** é uma aplicação desenvolvida em **.NET 8** com **Entity Framework Core** para gerenciamento de animes.  
O objetivo do projeto é oferecer uma API REST que permita cadastrar, consultar e gerenciar informações sobre animes, como nome, diretor e outros atributos.

Esta API foi projetada seguindo boas práticas de arquitetura, como **Clean Architecture** e **Repository Pattern**, e suporta consultas filtradas por diferentes campos.

---

## Funcionalidades

- Cadastro de animes
- Consulta de animes por:
  - ID
  - Nome
  - Diretor
  - Qualquer combinação dos filtros acima
- Listagem de todos os animes
- Documentação e testes via Swagger

---

## Tecnologias utilizadas

- **.NET 9**
- **Entity Framework Core**
- **SQL Server**
- **Docker**
- **Swagger/OpenAPI**
- **Clean Architecture**
- **Mediator**

---

## Rodando a aplicação com Docker Compose (API apenas)

Este projeto contém um arquivo `docker-compose.yml` para facilitar o deploy da API usando Docker.  
A configuração atual gera somente a imagem da API, assumindo que o banco SQL Server está rodando localmente (fora do container).

### Pré-requisitos

- Docker instalado na máquina
- Banco de dados SQL Server rodando localmente ou acessível pela rede
- A connection string na variável de ambiente configurada para acessar o banco local

---

### Usando o Docker Compose

No terminal, dentro da pasta do projeto, execute:

```bash
docker-compose up --build
