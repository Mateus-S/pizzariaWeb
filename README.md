# Pizzaria Web

Sistema web para gestão de pedidos, produção e entregas de uma pizzaria com atendimento ao balcão e integração via WhatsApp.

---

## ✅ Card 01 — Estrutura Inicial do Projeto

- Estruturado repositório monorepo com solução `PizzariaWeb.sln`
- Adicionados os projetos:
  - `Pizzaria.API` (Web API com Clean Architecture)
  - `Pizzaria.Domain`, `Pizzaria.Application`, `Pizzaria.Infrastructure`, `Pizzaria.Shared`
  - `Pizzaria.WEB` (Blazor WebAssembly com Bootstrap)
- Bootstrap incluído via CDN
- Git configurado para usar VS Code como editor de commits

Branch: `feature/card-01-config-structure`

---

## ✅ Card 01.02 — Configuração do SQLite + Estrutura de Domínio

- Criado banco de dados com **SQLite**
- Criado `PizzariaDbContext` com suporte a Fluent API separada por entidade
- Adicionadas pastas `DependencyInjection`, `Migrations`, `Configurations`
- Criadas as principais **entidades** do domínio (ex: `Order`, `Product`, `Customer`, `Employee`, etc)
- Criados os **Value Objects** (ex: `Money`, `Address`, `PhoneNumber`, etc)
- Criados os **Enums** (`OrderStatus`, `UserRole`, etc)
- DTOs gerados com estrutura separada no projeto `Application`
- Adicionado e configurado **AutoMapper** (com profiles organizados)
- Criada e aplicada a primeira **migration** (`InitialCreate`)
- Criado script PowerShell para reorganizar as pastas e corrigir o repositório Git
- Corrigido `appsettings.json` para definir `DefaultConnection` com o SQLite

Branch: `feature/card-1.02-sqlite`
