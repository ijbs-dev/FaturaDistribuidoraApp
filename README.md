# Distribuidora Frontend e API Backend

Este projeto é composto por uma aplicação Angular no frontend e uma API RESTful criada com ASP.NET Core no backend. A aplicação permite gerenciar o faturamento de uma distribuidora, realizando operações de CRUD e exibindo resumos dos valores de faturamento.

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

### 8. Tecnologias Utilizadas

- **Frontend**: Angular
- **Backend**: ASP.NET Core
- **Banco de Dados**: SQLite
- **Ferramentas**: Entity Framework Core, Angular CLI

