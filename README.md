# Sistema de Gestão de Tarefas - API RESTful

Este projeto consiste em uma aplicação completa para **gestão de tarefas**, desenvolvida com o backend em .NET 6 e uma interface web frontend inclusa na solução `WebUI`. A aplicação permite que usuários criem, editem, excluam, filtrem e consultem tarefas de maneira simples e organizada.

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 6
- Entity Framework Core (InMemory)
- AutoMapper
- xUnit (testes automatizados)
- Swagger (documentação da API)
- Frontend com Razor Pages (projeto `WebUI`)
- Dependency Injection
- Validações de entrada
- Logging básico

## 🎯 Funcionalidades

- **Criar tarefa** com:
  - Título (obrigatório)
  - Descrição (opcional)
  - Data de vencimento (opcional)
  - Status: "Pendente", "Em progresso", "Concluída"
- **Listar todas as tarefas**
  - Com filtros por status e data de vencimento
- **Editar tarefa** existente
- **Excluir tarefa**
- **Buscar tarefas** por critérios

## 🧱 Estrutura do Projeto

A solução está dividida de forma modular, seguindo boas práticas:

- `Domain` – Entidades e enums
- `Application` – Serviços, DTOs, regras de negócio
- `Infrastructure` – Repositórios e persistência (EF Core InMemory)
- `API` – Camada RESTful (Swagger habilitado)
- `WebUI` – Interface web (frontend com Razor Pages)
- `Tests` – Testes unitários com xUnit

## 🖼️ AutoMapper

Foi utilizado o **AutoMapper** para mapear objetos entre as camadas (por exemplo, entre entidades e DTOs), facilitando a transformação de dados e mantendo o código mais limpo e desacoplado.

## 🧪 Testes Automatizados

Foram implementados testes automatizados com **xUnit** para validar as regras de negócio da aplicação.

```bash
dotnet test
```

## 💻 Como Executar o Projeto

### Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

### Passos

1. Clone o repositório:
```bash
git clone https://github.com/guilherme-luiz-pinheiro/TaskManager.git
cd TaskManager
```

2. Restaure as dependências:
```bash
dotnet restore
```

3. Execute o projeto da API ou da interface WebUI:

- Para executar apenas a API:
```bash
cd src/API
dotnet run
```

- Para executar o projeto com frontend:
```bash
cd src/WebUI
dotnet run
```

4. Acesse:
- API (Swagger): [http://localhost:5000/swagger](http://localhost:5000/swagger)
- Interface Web: [http://localhost:5000](http://localhost:5000)

> Obs: A porta pode variar conforme a configuração do seu `launchSettings.json`.

## ✅ Boas Práticas Aplicadas

- Princípios **SOLID**
- Padrão arquitetural em camadas
- **RESTful API**
- **AutoMapper** para mapeamento entre DTOs e entidades
- **Injeção de dependência**
- **Validações** de entrada
- **Tratamento de erros**
- **Swagger** para documentação
- Interface web funcional com `WebUI`

## 📜 Licença

Este projeto foi desenvolvido exclusivamente para fins de avaliação técnica.

---

> Desenvolvido por Guilherme Luiz Pinheiro para o desafio técnico .NET Junior - Grupo SADA
