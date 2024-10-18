# README - Projeto DevOps de Cidades Inteligentes

## Visão Geral

Este projeto é parte do desafio DevOps focado em soluções para Cidades Inteligentes, implementando um pipeline completo de CI/CD, containerização da aplicação e orquestração dos serviços. A aplicação foi desenvolvida em C# utilizando .NET Core e visa gerenciar notificações de coleta de lixo de forma eficiente.

## Funcionalidades

Notificações de Coleta de Lixo: CRUD (Criar, Ler, Atualizar e Deletar) para gerenciar notificações de coleta de lixo.

Autenticação JWT: Autenticação segura para acesso aos endpoints.

## Estrutura do Projeto

O projeto é composto por:

- Código-fonte da aplicação em C#.
- Arquivos de configuração do Docker (Dockerfile, docker-compose.yml).
- Scripts de configuração do pipeline de CI/CD usando GitHub Actions.

## Pipeline de CI/CD
Este projeto utiliza um pipeline de CI/CD implementado com **GitHub Actions** para automatizar todo o ciclo de vida da aplicação. O pipeline inclui:
1. **Compilação Automática do Código**: Utilizando GitHub Actions para garantir que a versão mais recente esteja sempre disponível e funcionando.
2. **Testes Automatizados**: Execução de testes unitários após a compilação para validar as funcionalidades.
3. **Build da Imagem Docker**: A imagem Docker é construída automaticamente e carregada no ambiente local para ser utilizada.
4. **Deployment para Staging e Produção**: Orquestração dos ambientes usando Docker Compose, simulando ambientes de staging e produção para garantir robustez.

## Containerização e Orquestração
A aplicação foi containerizada usando **Docker**, o que garante consistência em todos os ambientes. Para orquestrar múltiplos serviços, como a API e um possível banco de dados, utilizamos **Docker Compose**.

- **Docker**: Responsável por criar contêineres que encapsulam a aplicação e suas dependências.
- **Docker Compose**: Utilizado para definir e rodar múltiplos contêineres, facilitando o gerenciamento do ambiente.

## Requisitos de Instalação
- **Docker** (pode ser instalado a partir do site oficial: [https://www.docker.com/](https://www.docker.com/)).
- **Docker Compose** (normalmente incluído junto com o Docker Desktop).
- **.NET Core SDK** para desenvolver e testar localmente.


## Como Rodar o Projeto
### Passo 1: Clonar o Repositório
```bash
git clone https://github.com/seu-usuario/projeto-devops.git

cd projeto-devops
```

### Passo 2: Configurar o Ambiente
  Certifique-se de que Docker e Docker Compose estão instalados e funcionando.

### Passo 3: Construir e Rodar a Aplicação com Docker Compose
```bash
docker-compose up --build -d
```

Isso irá construir a imagem Docker e inicializar os serviços definidos no docker-compose.yml.

## Endpoints Disponíveis

### 1. Autenticação

Gerar Token JWT: POST https://localhost:<port>/api/auth/login

- Corpo da requisição:
  ```bash
  {
    "username": "seu-usuario",
    "password": "sua-senha"
  }
  ```
### 2. Notificações de Coleta de Lixo

Criar Notificação: POST https://localhost:<port>/api/notificacoes

Cabeçalho: Authorization: Bearer <token>

Corpo:

{
  "titulo": "Notificação de Teste",
  "mensagem": "Esta é uma mensagem de teste",
  "dataEnvio": "2024-06-27T00:08:32.883Z",
  "enviada": true
}

Obter Notificações: GET https://localhost:<port>/api/notificacoes

Cabeçalho: Authorization: Bearer <token>

Atualizar Notificação: PUT https://localhost:<port>/api/notificacoes/{id}

Cabeçalho: Authorization: Bearer <token>

Corpo: Mesma estrutura do POST.

Excluir Notificação: DELETE https://localhost:<port>/api/notificacoes/{id}

Cabeçalho: Authorization: Bearer <token>

Documentação

Este projeto também inclui uma documentação em PDF que detalha:

As etapas e componentes do pipeline de CI/CD.

A estratégia de containerização e sua relevância para DevOps.

Prints de configuração e execução do pipeline.

Como Contribuir

Sinta-se à vontade para abrir issues e pull requests. Qualquer sugestão ou melhoria é muito bem-vinda!

Licença

Este projeto está sob a licença MIT - veja o arquivo LICENSE para mais detalhes.

