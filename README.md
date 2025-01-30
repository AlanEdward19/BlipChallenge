# **BlipChallenge 🚀**  

> Desafio técnico que combina uma API RESTful em **ASP.NET Core** e um fluxo conversacional no **Blip**.  

## 📌 Visão Geral  
O **BlipChallenge** é um projeto dividido em duas partes principais:  

1️⃣ **API**: Desenvolvida em **ASP.NET Core com .NET 9**, esta API consome a API do GitHub para buscar repositórios com base no usuário, linguagem e quantidade especificada.  
2️⃣ **Flow**: Um fluxo conversacional construído na plataforma **Blip**, permitindo interações automatizadas via chatbot.  

---

## 🚀 Tecnologias Usadas  

### **API**  
- **.NET 9**  
- **ASP.NET Core**  
- **Refit** (para chamadas HTTP simplificadas)  
- **FluentValidation** (para validação de requisições)  
- **Middleware global** para tratamento de exceções  
- **SOLID Principles**  

### **Flow**  
- **Plataforma Blip**  
- **Chatbot Conversacional**  

---

## 📦 Instalação e Execução  

### 1️⃣ Clone o Repositório  
```bash
git clone https://github.com/AlanEdward19/BlipChallennge.git
cd BlipChallennge
```

### 2️⃣ Configure as Dependências da API
Certifique-se de ter o .NET 9 SDK instalado. Em seguida, restaure os pacotes:
```bash
dotnet restore
```

### 3️⃣ Execute a API
```bash
dotnet run
```

A API estará disponível em:
👉 https://localhost:5000/GitHubRepository/GetOldestRepositoriesByProgrammingLanguage

Uma documentação OpenAPI/Swagger com definição de todos os campos pode ser encontrada em:
👉 https://localhost:5000/swagger/index.html

## 🛠️ Como Usar a API?

### 🔹 Buscar Repositórios do GitHub
GET /GitHubRepository/GetOldestRepositoriesByProgrammingLanguage?UserName={user_or_org}&ProgrammingLanguage={language}&Rows={number}&Type={User | 0 | Organization | 1}

### 📌 Exemplo de Requisição
GET /GitHubRepository/GetOldestRepositoriesByProgrammingLanguage?UserName=takenet&ProgrammingLanguage=Java&Rows=5&Type=1

### 📌 Exemplo de Resposta
```json
[
    {
        "name": "blip-chat-android",
        "htmlUrl": "https://github.com/takenet/blip-chat-android",
        "language": "Java",
        "description": "BLiP Chat widget for Android apps",
        "createdAt": "2017-01-04T15:37:51Z"
    },
    {
        "name": "blip-cards-android",
        "htmlUrl": "https://github.com/takenet/blip-cards-android",
        "language": "Java",
        "description": "Reusable BLiP cards for your Android app 📲",
        "createdAt": "2017-10-24T21:17:22Z"
    }
]
```

## 📝 Estrutura do Projeto
```css
  BlipChallenge/
│── Api/
│   ├── src/
│   │   ├── Common/
│   │   │   ├── Interfaces/
│   │   │   │   └── IHandler.cs
│   │   │   ├── Services/
│   │   │   │   ├── GithubApi/
│   │   │   │   │   ├── GitHubRepositoryViewModel.cs
│   │   │   │   │   └── IGitHubApi.cs
│   │   │   ├── CommonModule.cs
│   │   ├── Configurations/
│   │   │   ├── Endpoints.cs
│   │   │   ├── IoC.cs
│   │   │   ├── Middleware.cs
│   │   │   ├── Swagger.cs
│   │   │   └── Validators.cs
│   │   ├── Features/
│   │   │   ├── GitHubRepository/
│   │   │   │   ├── GetRepositories/
│   │   │   │   │   ├── Enums/
│   │   │   │   │   │   └── ERepositoryType.cs
│   │   │   │   │   ├── GetRepositoryQuery.cs
│   │   │   │   │   ├── GetRepositoryQueryHandler.cs
│   │   │   │   │   ├── GetRepositoryQueryValidator.cs
│   │   │   │   │   └── RepositoryViewModel.cs
│   │   │   │   ├── GitHubRepositoryController.cs
│   │   │   │   └── GitHubRepositoryModule.cs
│   │   ├── Middleware/
│   │   │   └── ExceptionMiddleware.cs
│   │   ├── BlipChallenge.csproj
│   │   └── Program.cs
│   ├── test/
│   │   │   ├── Integration/
│   │   │   │   └── GitHubRepositoryIntegrationTests.cs
│── Flow/
│   └── desafioblip24.json
```

## 📄 Licença
Este projeto é de código aberto e está sob a licença MIT.
