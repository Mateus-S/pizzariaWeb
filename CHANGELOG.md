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
## [v1.2.0] – 2025-08-03

### 🧩 Card 02 – Backend Core (Domínio + API)

Implementação completa da base do back-end da aplicação, cobrindo desde a modelagem de domínio até a exposição da API REST, seguindo **DDD**, **Clean Architecture** e **Clean Code**.

---

### ✅ Card 02.01 – Modelagem do Domínio

#### 🧱 Domain
- Criação e consolidação das entidades principais do sistema:
  - `Category`
  - `MenuItem` (renomeação e substituição conceitual de `Product`)
  - `Customer`
  - `Employee`
  - `User`
  - `Order`
  - `OrderItem`
- Implementação de **entidades ricas**, seguindo DDD:
  - Construtores protegendo invariantes do domínio
  - Propriedades com `private set` para encapsulamento
  - Métodos de domínio (`Activate`, `Deactivate`, `AddItem`, `UpdateStatus`, etc.)
- Definição e validação dos **Enums de negócio**:
  - `OrderStatus`
  - `DeliveryType`
  - `EmployeeRole`
  - `UserRole`
- Remoção do enum `ProductCategory`, substituído pela entidade persistida `Category`
- Padronização de identificadores utilizando **GUID**

#### 🧩 Value Objects
- Revisão e refatoração dos Value Objects:
  - `Address`
  - `DeliveryAddress`
- Garantida a **imutabilidade conceitual** dos VOs
- Remoção de dependência direta do EF Core no projeto `Domain`
- Mapeamento dos VOs realizado exclusivamente via **Fluent API** na camada Infrastructure

#### 🗄️ Infrastructure / EF Core
- Criação e revisão completa das configurações EF Core (`IEntityTypeConfiguration`) para:
  - `Category`
  - `MenuItem`
  - `Customer`
  - `Employee`
  - `User`
  - `Order`
  - `OrderItem`
- Configuração explícita de:
  - Relacionamentos (`1:N`, `1:1`)
  - FKs explícitas (sem shadow properties)
  - `DeleteBehavior` apropriado (`Restrict`, `Cascade`, `SetNull`)
  - Índices e constraints (`Unique`, `CheckConstraint`)
- Correção de warning de **shadow property (`UserId1`)** no relacionamento `Employee ↔ User`
- Criação da migration:
  - `InitialModel_Card02_01`
- Aplicação segura da migration após correções de mapeamento

#### 🔄 DTOs (Application)
- Criação e padronização de DTOs por responsabilidade:
  - `CategoryDto`, `CreateCategoryDto`, `UpdateCategoryDto`
  - `MenuItemDto`, `CreateMenuItemDto`, `UpdateMenuItemDto`
  - `CustomerDto`, `CreateCustomerDto`, `UpdateCustomerDto`
  - `EmployeeDto`, `CreateEmployeeDto`, `UpdateEmployeeDto`
  - `UserDto`, `CreateUserDto`, `UpdateUserDto`
  - `AddressDto`, `DeliveryAddressDto`
- Separação clara entre DTOs de **leitura**, **criação** e **atualização**

#### 🔀 AutoMapper
- Criação/atualização dos Profiles:
  - `CategoryProfile`
  - `MenuItemProfile`
  - `CustomerProfile`
  - `EmployeeProfile`
  - `UserProfile`
- Mapeamentos explícitos para:
  - Campos derivados (`CategoryName`)
  - Campos sensíveis (`PasswordHash` ignorado no Create)
- Registro automático dos profiles via assembly

#### 🧹 Qualidade e Arquitetura
- Eliminação de warnings críticos do EF Core
- Garantia de isolamento entre camadas (Domain sem EF)
- Consolidação de uma base de domínio sólida para os próximos cards

➡️ **Resultado**: domínio totalmente modelado, consistente e pronto para o início do Card 02.02 (Services, Repositories e Controllers).

---

### ✅ Card 02.02 – DTOs, Formulários e Tratamento Global de Erros

#### 🔄 DTOs
- Criação e consolidação de DTOs para **MenuItem**:
  - `CreateMenuItemDto`
  - `UpdateMenuItemDto`
  - `MenuItemDto` (Read)
- Separação clara entre:
  - **DTOs de escrita** (Create / Update)
  - **DTOs de leitura** (Read)
- Preparação dos DTOs para consumo direto pelo front-end Blazor

#### 🧩 Formulários e Componentes (Front-end)
- Implementação do componente `MenuItemForm`:
  - Suporte unificado para **Create** e **Edit**
  - Reutilização do mesmo formulário para ambos os fluxos
  - Validações com `DataAnnotations`
- Implementação do componente `MenuItemList`:
  - Listagem dos itens
  - Integração com ações de edição e toggle de status
- Criação da página administrativa `MenuItemManager`
  - Orquestração entre lista e formulário
  - Controle de estado (Create / Edit)

#### 🌐 Services e Interfaces (Front-end)
- Criação da interface `IMenuItemService`
- Implementação do `MenuItemService`:
  - `GetAllAsync`
  - `CreateAsync`
  - `UpdateAsync`
  - `ToggleStatusAsync`
- Preparação dos serviços para consumo da API (controllers serão implementados no próximo card)

#### 🚨 Tratamento Global de Erros
- Criação do componente reutilizável `ErrorModal`
  - Modal centralizado
  - Mensagens dinâmicas
  - Reutilizável em toda a aplicação
- Implementação do serviço global `ErrorHandlerService`
  - Interface `IErroHandleService`
  - Registro dinâmico do modal via `RegisterModal`
  - Exibição centralizada de erros via serviço
- Integração do modal no `MainLayout`
  - Registro automático no primeiro render
- Estrutura preparada para:
  - Tratamento de erros HTTP
  - Mensagens amigáveis ao usuário
  - Reuso em todos os serviços da aplicação

#### 🧼 Arquitetura e Boas Práticas
- Separação clara de responsabilidades:
  - Components
  - Pages
  - Services
  - Interfaces
- Código preparado para evolução sem quebra quando o backend for implementado
- Nenhuma dependência de autenticação (login será tratado em card futuro)

### ✅ Card 02.03 – API, Services e Repositories

#### 📦 Repositories
Implementação dos repositórios seguindo o padrão Repository:
- Interfaces na camada `Domain`
- Implementações na camada `Infrastructure`
- Uso de EF Core isolado do restante da aplicação

Repositórios implementados:
- `CategoryRepository`
- `MenuItemRepository`
- `CustomerRepository`
- `EmployeeRepository`
- `OrderRepository`
- `OrderItemRepository`
- `UserRepository`

---

#### ⚙️ Services
Implementação dos services na camada `Application`, responsáveis por:
- Orquestrar regras de negócio
- Converter DTOs ↔ Entidades
- Validar existência de dados antes de update/delete
- Controlar parsing de enums vindos do front-end

Services implementados:
- `CategoryService`
- `MenuItemService`
- `CustomerService`
- `EmployeeService`
- `OrderService`
- `OrderItemService`
- `UserService`

---

#### 🌐 Controllers
Criação dos controllers RESTful:
- `CategoryController`
- `MenuItemController`
- `CustomerController`
- `EmployeeController`
- `OrderController`
- `OrderItemController`
- `UserController`

Com:
- Endpoints REST (`GET`, `POST`, `PUT`, `DELETE`)
- Uso exclusivo de DTOs
- Retornos HTTP padronizados
- Integração com Swagger

---

#### 🧩 Infraestrutura
- Registro completo de Services e Repositories no `DependencyInjection`
- Configuração do AutoMapper por assembly
- Configuração de CORS para integração com Blazor Web
- Integração com SQLite via EF Core
- Pipeline de middleware com tratamento global de exceções

---

### 🛡️ Boas Práticas Consolidadas
- Separação total entre camadas
- Nenhuma entidade do domínio exposta na API
- Domínio livre de dependências externas
- Base preparada para autenticação, autorização e escalabilidade futura

---

## [v1.0.0] – Versão inicial
- Estrutura inicial do repositório criada
## [v1.2.0] – 2025-08-03
- Arquitetura de Dominio, Repositorio e Service Iniciais. 
