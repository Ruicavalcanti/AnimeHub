# AnimeHub

## Rodando a aplicação com Docker Compose (API apenas)

Este projeto contém um arquivo `docker-compose.yml` para facilitar o deploy da API usando Docker. A configuração atual gera somente a imagem da API, assumindo que o banco SQL Server está rodando localmente (fora do container).

### Pré-requisitos

- Docker instalado na máquina
- Banco de dados SQL Server rodando localmente ou acessível pela rede
- A connection string na variável de ambiente está configurada para acessar o banco local

### Usando o Docker Compose

No terminal, dentro da pasta do projeto, execute:

```bash
docker-compose up --build
