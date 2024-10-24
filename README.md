# Faturamento de uma Distribuidora 

Este projeto é composto por uma aplicação Angular no frontend e uma API RESTful criada com ASP.NET Core no backend. A aplicação permite gerenciar o faturamento de uma distribuidora, realizando operações de CRUD e exibindo resumos dos valores de faturamento.

---
## Índice

1. [Visualização Detalhada](#visualização-detalhada)
   - [Diretório Projeto](#diretorio-projeto)
   - [Tela de Home](#tela-de-home)
2. [Pré-requisitos](#pré-requisitos)
3. [Instalação](#instalação)
   - [1. Clone o repositório](#1-clone-o-repositório)
   - [2. Configuração do Backend (API .NET)](#2-configuração-do-backend-api-net)
     - [2.1. Restaurar os pacotes do .NET](#21-restaurar-os-pacotes-do-net)
     - [2.2. Aplicar as Migrations (Banco de Dados)](#22-aplicar-as-migrations-banco-de-dados)
     - [2.3. Rodar o Backend](#23-rodar-o-backend)
   - [3. Configuração do Frontend (Angular)](#3-configuração-do-frontend-angular)
     - [3.1. Instalar as dependências do Angular](#31-instalar-as-dependências-do-angular)
     - [3.2. Configurar o Ambiente](#32-configurar-o-ambiente)
     - [3.3. Rodar o Frontend](#33-rodar-o-frontend)
4. [Testando a Aplicação](#testando-a-aplicação)
5. [Estrutura do Projeto](#estrutura-do-projeto)
   - [Backend (.NET API)](#backend-net-api)
   - [Frontend (Angular)](#frontend-angular)
6. [Operações Suportadas](#operações-suportadas)
7. [Exemplos de Requests](#exemplos-de-requests)
   - [7.1. Adicionar um novo Faturamento (POST)](#71-adicionar-um-novo-faturamento-post)
   - [7.2. Atualizar um Faturamento (PUT)](#72-atualizar-um-faturamento-put)
   - [7.3. Excluir um Faturamento (DELETE)](#73-excluir-um-faturamento-delete)
8. [Exemplo da Interface da Aplicação](#exemplo-da-interface-da-aplicação)
   - [8.1 Fluxo de Cadastro e Visualização de Faturamentos](#81-fluxo-de-cadastro-e-visualização-de-faturamentos)
     - [8.1.1 Criando Novos dados](#811-criando-novos-dados)
     - [8.1.2 Alterando dados](#812-alterando-dados)
     - [8.1.3 Apagando dados](#813-apagando-dados)
9. [Tecnologias Utilizadas](#tecnologias-utilizadas)

### Visualização Detalhada

#### Diretorio Projeto 
![Visualização Geral - Exemplo 1](https://drive.google.com/uc?export=view&id=1BGJmvSP0sFkhACwp8oGADQ4Es5VPolFH)

#### Tela de Home
![Exemplo de Funcionamento](https://drive.google.com/uc?export=view&id=15o3-RNs6JrzQHj5QtnTVyvj2bQiSOCEw)

## Pré-requisitos

Antes de começar, certifique-se de ter o seguinte instalado em sua máquina:

- [Node.js](https://nodejs.org/en/) (versão LTS recomendada)
- [Angular CLI](https://angular.io/cli) (para rodar o frontend)
- [.NET SDK](https://dotnet.microsoft.com/download) (para rodar a API backend)
- SQLite (usado para o banco de dados)

## Instalação

Siga os passos abaixo para configurar o ambiente e rodar o projeto localmente.

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio
```

### 2. Configuração do Backend (API .NET)

#### 2.1. Restaurar os pacotes do .NET

Navegue até o diretório do backend e restaure os pacotes:

```bash
cd DistribuidoraAPI
dotnet restore
```

#### 2.2. Aplicar as Migrations (Banco de Dados)

Execute as migrations para preparar o banco de dados:

```bash
dotnet ef database update
```

> **Nota:** Verifique se o SQLite está instalado e configurado corretamente.

#### 2.3. Rodar o Backend

Inicie a API backend no ambiente de desenvolvimento:

```bash
dotnet run
```

A API estará rodando em `http://localhost:{PORT}`.

### 3. Configuração do Frontend (Angular)

#### 3.1. Instalar as dependências do Angular

Navegue até o diretório do frontend e instale as dependências:

```bash
cd distribuidora-frontend
npm install
```

#### 3.2. Configurar o Ambiente

Certifique-se de que o arquivo `src/environments/environment.ts` aponte corretamente para a URL da API, por exemplo:

```typescript
export const environment = {
  production: false,
  apiUrl: 'http://localhost:5068/api' // URL da API backend
};
```

#### 3.3. Rodar o Frontend

Inicie o frontend no ambiente de desenvolvimento:

```bash
ng serve
```

O frontend estará acessível em `http://localhost:4200`.

### 4. Testando a Aplicação

Após iniciar tanto o backend quanto o frontend, acesse `http://localhost:4200` no navegador e você poderá interagir com a aplicação de faturamento.

### 5. Estrutura do Projeto

- **Backend (.NET API)**
  - Localizado na pasta `DistribuidoraAPI`
  - Controladores e models para gerenciar o faturamento
  - Conexão com banco de dados SQLite
- **Frontend (Angular)**
  - Localizado na pasta `distribuidora-frontend`
  - Componentes para CRUD e exibição de dados
  - Integração com a API através do `FaturamentoService`

### 6. Operações Suportadas

- **GET**: Exibir todos os faturamentos e resumo mensal
- **POST**: Adicionar um novo faturamento
- **PUT**: Atualizar um faturamento existente
- **DELETE**: Remover um faturamento

### 7. Exemplos de Requests

#### 7.1. Adicionar um novo Faturamento (POST)

Endpoint: `POST /api/faturamento`

```json
{
  "data": "2024-10-01",
  "valor": 500.00
}
```

#### 7.2. Atualizar um Faturamento (PUT)

Endpoint: `PUT /api/faturamento/{id}`

```json
{
  "id": 1,
  "data": "2024-10-02",
  "valor": 700.00
}
```

#### 7.3. Excluir um Faturamento (DELETE)

Endpoint: `DELETE /api/faturamento/{id}`

---

## 8. Exemplo da Interface da Aplicação

### 8.1 Fluxo de Cadastro e Visualização de Faturamentos

#### 8.1.1 Criando Novos dados 
![GIF 1](https://github.com/ijbs-dev/FaturaDistribuidoraApp/blob/main/mov/1.gif)

#### 8.1.2 Alterando dados
![GIF 2](https://github.com/ijbs-dev/FaturaDistribuidoraApp/blob/main/mov/2.gif)

#### 8.1.3 Apagando dados
![GIF 3](https://github.com/ijbs-dev/FaturaDistribuidoraApp/blob/main/mov/3.gif)


### 9. Tecnologias Utilizadas

- **Frontend**: Angular
- **Backend**: ASP.NET Core
- **Banco de Dados**: SQLite
- **Ferramentas**: Entity Framework Core, Angular CLI

