# FleetRental CP2 - API .NET 8 (Clean Architecture)

API RESTful para gestão de frotas e alugueis: cadastro de entregadores (Riders), motos (Motorcycles) e contratos de aluguel (Rentals). Estruturada em Clean Architecture + DDD, com EF Core + MySQL, AutoMapper, FluentValidation e Swagger.

## Tecnologias
- .NET 8
- ASP.NET Core Web API
- EF Core 8 + Pomelo MySQL
- AutoMapper
- FluentValidation
- Swagger/OpenAPI
- Docker Compose (MySQL)

## Estrutura (Clean Architecture)
- `src/Mottu.Domain` → Assembly/Namespace: `FleetRental.Domain`
- `src/Mottu.Application` → Assembly/Namespace: `FleetRental.Application`
- `src/Mottu.Infrastructure` → Assembly/Namespace: `FleetRental.Infrastructure`
- `src/Mottu.Presentation` → Assembly/Namespace: `FleetRental.Presentation`

Observação: as pastas mantêm o prefixo original, mas a solution e os assemblies/namespace usam FleetRental.

## Como executar
1. Subir o MySQL com Docker:
   ```bash
   docker compose up -d
   ```
2. Abrir a solution `FleetRental.sln` no Rider.
3. Restaurar pacotes e compilar a solution.
4. Rodar o projeto `FleetRental.Presentation`. O Swagger estará em `/swagger`.

Connection string (Development) está em `src/Mottu.Presentation/appsettings.Development.json` apontando para o MySQL do Docker.

## Migrations
As migrations iniciais já estão incluídas em `src/Mottu.Infrastructure/Migrations` (InitialCreate). Caso deseje recriar:
```bash
# Exemplo (opcional), dentro do projeto Infrastructure
# dotnet ef migrations add InitialCreate -s ..../Mottu.Presentation -p .
# dotnet ef database update -s ..../Mottu.Presentation -p .
```

## Rotas (CRUD principal)
- Riders
  - `GET /api/riders?page=1&pageSize=20`
  - `GET /api/riders/{id}`
  - `POST /api/riders` { FullName, DocumentNumber, Phone }
  - `PUT /api/riders/{id}` { FullName, DocumentNumber, Phone }
  - `DELETE /api/riders/{id}`
- Motorcycles
  - `GET /api/motorcycles?page=1&pageSize=20`
  - `GET /api/motorcycles/{id}`
  - `POST /api/motorcycles` { Plate, Model, Year }
  - `PUT /api/motorcycles/{id}` { Plate, Model, Year }
  - `DELETE /api/motorcycles/{id}`

HTTP Codes: 200, 201, 204, 400 (validações), 404.

## Documento complementar
Veja `docs/Projeto.md` com a ideia e contexto do domínio.

## Integrantes
- Bruno Tizer - RM5
- Natalia Santos - RM560306

