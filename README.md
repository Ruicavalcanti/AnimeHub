AnimeHub
Rodando a aplicação com Docker Compose (API apenas)
Este projeto contém um arquivo docker-compose.yml para facilitar o deploy da API usando Docker. A configuração atual gera somente a imagem da API, assumindo que o banco SQL Server está rodando localmente (fora do container).

Pré-requisitos
Docker instalado na máquina

Banco de dados SQL Server rodando localmente ou acessível pela rede

A connection string na variável de ambiente está configurada para acessar o banco local

Usando o Docker Compose
No terminal, dentro da pasta do projeto, execute:

bash
Copiar
Editar
docker-compose up --build
Isso irá:

Construir a imagem da API (animehub-api)

Subir o container da API, expondo a porta 5000 para acesso externo

A API estará disponível em http://localhost:5000

Configuração da conexão com o banco
A variável de ambiente ConnectionStrings__DefaultConnection está definida para:

pgsql
Copiar
Editar
Server=localhost,1433;Database=AnimeDb;User Id=sa;Password=AnimeHub123*;TrustServerCertificate=True;
Atenção: Ajuste esta string conforme sua configuração local do SQL Server, especialmente o servidor (localhost), porta, usuário e senha.

Considerações
O serviço do banco não está incluído neste docker-compose.yml. Você deve garantir que o banco esteja rodando e acessível pela aplicação.

Caso queira usar o SQL Server via container, consulte a versão completa do docker-compose.yml no repositório.
