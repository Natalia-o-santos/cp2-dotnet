# Projeto CP2 - FleetRental: Gestão de Aluguéis de Motos

## Contexto
Uma empresa de entregas precisa alugar motos para entregadores. Necessidades:
- Cadastrar entregadores (dados pessoais e documento).
- Cadastrar motos (placa, modelo, ano).
- Registrar contratos de aluguel, com taxa diária e período.
- Garantir integridade (placa e documento únicos), validações e respostas REST adequadas.

## Objetivo
Fornecer uma API RESTful que permita o CRUD de entidades principais (Rider e Motorcycle) e relacione-as por meio de `Rental`.

## Escopo
- CRUD completo de Rider e Motorcycle.
- Relação Rider x Motorcycle via Rental.
- Validações de domínio e DTOs (FluentValidation).
- Documentação via Swagger.
- Persistência com EF Core + MySQL.

## Arquitetura (Clean + DDD)
- Domain: Entidades ricas e contratos de repositório.
- Application: DTOs, validação, serviços e mapeamentos.
- Infrastructure: EF Core (DbContext, repositórios, migrations).
- Presentation: API (controllers, configuração, Swagger).

## Decisões
- Banco: MySQL (Docker) por simplicidade e disponibilidade.
- Provider: Pomelo.EntityFrameworkCore.MySql.
- Mapeamento: AutoMapper para converter entidades -> responses.
- Validação: FluentValidation para requests.
- Migrations: inicial incluída.

## Próximos passos (opcional)
- Endpoints de Rentals (abrir/encerrar aluguel e cálculo de custo).
- Autenticação/Autorização (JWT).
- Observabilidade (logging estruturado, tracing).
- Testes unitários e de integração.
