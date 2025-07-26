# 📦 Changelog – Pizzaria Web

Todas as mudanças relevantes neste projeto serão documentadas aqui seguindo o padrão [Keep a Changelog](https://keepachangelog.com/).

---

## [v1.1.0] – 2025-07-26

### ✅ Card 01.01 – Estrutura Inicial do Projeto
- Estruturado repositório monorepo com solução `PizzariaWeb.sln`
- Adicionados os projetos:
  - `Pizzaria.API` (Web API com Clean Architecture)
  - `Pizzaria.Domain`, `Pizzaria.Application`, `Pizzaria.Infrastructure`, `Pizzaria.Shared`
  - `Pizzaria.WEB` (Blazor WebAssembly com Bootstrap)
- Bootstrap incluído via CDN
- Git configurado para usar VS Code como editor de commits

### ✅ Card 01.02 – Configuração do SQLite + Estrutura de Domínio
- Criado banco de dados com **SQLite**
- Implementado `PizzariaDbContext` com Fluent API por entidade
- Criadas entidades principais: `Order`, `Product`, `Customer`, `Employee`
- Criados Value Objects como `Money`, `Address`, `PhoneNumber`
- Criados Enums como `OrderStatus`, `UserRole`
- AutoMapper configurado com `Profiles`
- Criada e aplicada a primeira migration `InitialCreate`

### ✅ Card 01.03 – Layout Responsivo com Blazor + Bootstrap
- Criado layout base com Bootstrap 5 e estrutura responsiva
- Componentes criados:
  - `Header.razor` com NavBar colapsável e rotas
  - `Footer.razor` reutilizável
- `MainLayout.razor` atualizado para incluir os componentes
- Rotas configuradas:
  - `/` e `/home` – Página inicial
  - `/pedidos` – Tela de pedidos
  - `/cozinha` – Visualização de produção
  - `/entregas` – Tela de entregas
  - `/login` – Tela de autenticação

---

## [v1.0.0] – Versão inicial
- Estrutura inicial do repositório criada
