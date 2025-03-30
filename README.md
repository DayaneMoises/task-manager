# TaskManager.API

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![MongoDB](https://img.shields.io/badge/MongoDB-3.3.0-green)
![Swagger](https://img.shields.io/badge/Swagger-6.6.2-blue)

## Funcionalidades
- Adicionar tarefas
- Marcar como concluído
- Editar tarefas existentes
- Excluir tarefa

## 🛠 Stack Tecnológica

- **.NET 8.0** - Framework principal
- **MongoDB.Driver 3.3.0** - Cliente oficial para MongoDB
- **Swashbuckle.AspNetCore 6.6.2** - Documentação Swagger/OpenAPI

## 📦 Dependências do Projeto

```xml
<PackageReference Include="MongoDB.Driver" Version="3.3.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />´´´
```


## 🚀 Como Executar

1. Clone o repositório
2. Configure a string de conexão do MongoDB no `appsettings.json`
   ```json
   "MongoDB": {
     "ConnectionString": "mongodb://localhost:27017",
     "DatabaseName": "TaskManagerDB"
   }

3. Execute:
   ```bash
   dotnet run
   ```
4. Acesse a documentação Swagger em:
   ```
   https://localhost:44376/swagger
```